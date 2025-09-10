using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Reflection;
using System.Runtime.Intrinsics.X86;


namespace SCAE.Framework.Attributes
{
    /// <summary>
    /// Fornece validação condicional com base no valor da propriedade relacionada.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public sealed class RequiredIfAttribute : ValidationAttribute
    {
        #region Propriedades

        /// <summary>
        /// Obtém ou define o nome da outra propriedade que será usada durante a validação.
        /// </summary>
        /// <value>
        /// O nome da outra propriedade.
        /// </value>
        public string OtherProperty { get; private set; }

        /// <summary>
        /// Obtém ou define o nome de exibição da outra propriedade.
        /// </summary>
        /// <value>
        /// O nome de exibição da outra propriedade.
        /// </value>
        public string OtherPropertyDisplayName { get; set; }

        /// <summary>
        /// Obtém ou define o valor da outra propriedade que será relevante para a validação.
        /// </summary>
        /// <value>
        /// O valor da outra propriedade.
        /// </value>
        public object OtherPropertyValue { get; private set; }

        /// <summary>
        /// Obtém ou define um valor que indica se o valor da outra propriedade deve ser igual ou diferente do valor da outra propriedade fornecida (o padrão é <c>false</c>).
        /// </summary>
        /// <value>
        ///   <c>true</c> se a validação do valor da outra propriedade deve ser invertida; caso contrário, <c>false</c>.
        /// </value>
        /// <remarks>
        /// Como isso funciona
        /// - true: a propriedade validada é necessária quando o valor da outra propriedade não é igual ao valor fornecido
        /// - false: a propriedade validada é necessária quando o valor da outra propriedade é igual ao valor fornecido
        /// </remarks>
        public bool IsInverted { get; set; }

        /// <summary>
        /// Obtém um valor que indica se o atributo requer contexto de validação.
        /// </summary>
        /// <returns><c>true</c> se o atributo requer contexto de validação; caso contrário, <c>false</c>.</returns>
        public override bool RequiresValidationContext
        {
            get { return true; }
        }

        #endregion

        #region Construtor

        /// <summary>
        /// Inicializa uma nova instância da classe <see cref="RequiredIfAttribute"/>.
        /// </summary>
        /// <param name="otherProperty">A outra propriedade.</param>
        /// <param name="otherPropertyValue">O valor da outra propriedade.</param>
        public RequiredIfAttribute(string otherProperty, object otherPropertyValue)
            : base("'{0}' é necessário porque '{1}' tem o valor {3}'{2}'.") //modelo original: "'{0}' é necessário porque '{1}' tem o valor {3}'{2}'."
        {
            this.OtherProperty = otherProperty;
            this.OtherPropertyValue = otherPropertyValue;
            this.IsInverted = false;
        }

        #endregion

        /// <summary>
        /// Aplica formatação a uma mensagem de erro, com base no campo de dados onde ocorreu o erro.
        /// </summary>
        /// <param name="name">O nome a incluir na mensagem formatada.</param>
        /// <returns>
        /// Uma instância da mensagem de erro formatada.
        /// </returns>
        public override string FormatErrorMessage(string name)
        {
            return string.Format(
                CultureInfo.CurrentCulture,
                base.ErrorMessageString,
                name,
                this.OtherPropertyDisplayName ?? this.OtherProperty,
                this.OtherPropertyValue,
                this.IsInverted ? "diferente de " : "de ");
        }

        /// <summary>
        /// Valida o valor especificado em relação ao atributo de validação atual.
        /// </summary>
        /// <param name="value">O valor a ser validado.</param>
        /// <param name="validationContext">As informações de contexto sobre a operação de validação.</param>
        /// <returns>
        /// Uma instância do <see cref="T:System.ComponentModel.DataAnnotations.ValidationResult" /> class.
        /// </returns>
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (validationContext == null)
            {
                throw new ArgumentNullException("validationContext");
            }

            PropertyInfo otherProperty = validationContext.ObjectType.GetProperty(this.OtherProperty);
            if (otherProperty == null)
            {
                return new ValidationResult(
                    string.Format(CultureInfo.CurrentCulture, "Não foi possível encontrar a propriedade chamada '{0}'.", this.OtherProperty));
            }

            object otherValue = otherProperty.GetValue(validationContext.ObjectInstance);

            // verifique se este valor é realmente necessário e valide-o
            if (!this.IsInverted && object.Equals(otherValue, this.OtherPropertyValue) ||
                this.IsInverted && !object.Equals(otherValue, this.OtherPropertyValue))
            {
                if (value == null)
                {
                    return new ValidationResult(this.FormatErrorMessage(validationContext.DisplayName));
                }

                // verificação adicional de strings para que não fiquem vazias
                string val = value as string;
                if (val != null && val.Trim().Length == 0)
                {
                    return new ValidationResult(this.FormatErrorMessage(validationContext.DisplayName));
                }
            }

            return ValidationResult.Success;
        }
    }
}
