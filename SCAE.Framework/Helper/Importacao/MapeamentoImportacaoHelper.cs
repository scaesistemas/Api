using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SCAE.Framework.Helper
{
    public static class MapeamentoImportacaoHelper
    {
        public static Dictionary<string, string> Contrato()
        {
            return new Dictionary<string, string>
                {
                    { "NumeroContrato", "Número Contrato" },
                    { "EmpresaCNPJ", "CNPJ Empresa" },
                    { "SituacaoContrato", "Situacão do contrato *" },
                    { "TipoAditamentoContrato", "Tipo de aditamento" },
                    { "PrimeiroClienteCpfCnpj", "CPF/CNPJ 1º Cliente" },
                    { "SegundoClienteCpfCnpj", "CPF/CNPJ 2º Cliente" },
                    { "TerceiroClienteCpfCnpj", "CPF/CNPJ 3º Cliente" },
                    { "PrimeiroCorretorCpfCnpj", "CPF/CNPJ 1º Corretor" },
                    { "PrimeiroCorretorPercentual", "Percentual 1º Corretor" },
                    { "SegundoCorretorCpfCnpj", " CPF/CNPJ 2º Corretor" },
                    { "SegundoCorretorPercentual", "Percentual 2º Corretor" },
                    { "TerceiroCorretorCpfCnpj", "CPF/CNPJ 3º Corretor" },
                    { "TerceiroCorretorPercentual", "Percentual 3º Corretor" },
                    { "UnidadeId", "Id da Unidade" },
                    { "DataContrato", "Data da venda" },
                    { "Indice", "Índice" },
                    { "IntervaloReajuste", "Intervalo do reajuste(anual ou mensal)" },
                    { "MesReajuste", "Mês do  reajuste" },
                    { "AnoPrimeiroReajuste", "Ano do primeiro reajuste" },
                    { "Tabela", "Tabela" },
                    { "JurosPrice", "Juros Price" },
                    { "Observacao", "Observação" },                       
                    { "Valor", "Valor" },
                    { "JurosDia", "Juros previsto por dia" },
                    { "Multa", "Multa prevista" },
                    { "DescontoVencimento", "Desconto de vencimento" },
                    { "DiasDescontoVencimento", "Dias para desconto de vencimento" },
                    { "DescontoAntecipacao", "Desconto de antecipacão" },
                    { "DiasAposVencimentoNaoReceber", "Dias após vencimento para não receber" }
                };
        }
    }
}