using Microsoft.AspNetCore.Mvc;
using SCAE.Data.Interface.Shared;
using SCAE.Domain.Entities.Projeto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCAE.Data.Interface.Projeto
{
    public interface IMedicaoRepository : ICrudRepository<Medicao>
    {
        Task<List<Execucao>> GetExecucoesRelatorio(int? empreendimentoId, DateTime? dataEmissaoInicial, DateTime? dataEmissaoFinal, DateTime? dataVencimentoInicial, DateTime? dataVencimentoFinal,
          DateTime? dataBaixaInicial, DateTime? dataBaixaFinal);
    }
}
