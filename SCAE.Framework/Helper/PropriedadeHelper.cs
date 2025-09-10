using System.Reflection;

namespace SCAE.Framework.Helper
{
    public class PropriedadeHelper
    {
        public static PropertyInfo PegarPropriedadePorNome<T>(string nome, bool primeiraMaiuscula = true)
        {
            if (nome != null)
            {
                var nomePropriedade = StringHelper.PadronizarPrimeiraMaiuscula(StringHelper.RemoverAcentos(nome), primeiraMaiuscula, false);
                return typeof(T).GetProperty(nomePropriedade);
            }
            else
            {
                return null;
            }
        }
    }
}
