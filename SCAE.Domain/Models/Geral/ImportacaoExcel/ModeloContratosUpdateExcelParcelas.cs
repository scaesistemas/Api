using SCAE.Domain.Entities.Clientes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCAE.Domain.Models.Geral.ImportacaoExcel
{
    public class ModeloContratosUpdateExcelParcelas
    {
        public List<ExcelParcelaModel> ExcelParcelasValidasParaBaixas = new List<ExcelParcelaModel>();
        public List<Contrato> ContratosComUpdate = new List<Contrato>();
        public StringBuilder TextoRetorno = new StringBuilder();
        public StringBuilder TextoRetornoFalhas = new StringBuilder();
        public int Sucessos = 0;
        public int Falhas = 0;
    }
}
