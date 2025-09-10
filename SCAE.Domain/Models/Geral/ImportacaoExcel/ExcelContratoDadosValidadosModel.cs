using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualBasic;
using SCAE.Domain.Entities.Empreendimento;
using SCAE.Domain.Entities.Geral;

namespace SCAE.Domain.Models.Geral.ImportacaoExcel
{
    public class ExcelContratoDadosValidadosModel

    {
        public bool IsValido = false;
        public Pessoa Cliente;
        public Pessoa Corretor;
        public Unidade Unidade;
        public Empresa Empresa;

        public string LogFalhas;
    }

    public class ExcelValidacaoRetorno
    {
        public bool Validado;
        public string Log;
        public string LogFalhas;

        public ExcelValidacaoRetorno(bool validado, string log, string logFalhas)
        {
            Validado = validado;
            Log = log;
            LogFalhas = logFalhas;
        }
    }
}