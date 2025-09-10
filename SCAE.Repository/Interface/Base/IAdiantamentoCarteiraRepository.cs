using SCAE.Data.Interface.Shared;
using SCAE.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCAE.Data.Interface.Base
{
    public interface IAdiantamentoCarteiraRepository : ICrudRepository<AdiantamentoCarteira>
    {
        IQueryable<ContratoAdiantamento> SetIncludeContrato(IQueryable<ContratoAdiantamento> query, string include);
        Task<ContratoAdiantamento> GetContrato(int contratoId, string include = "");
        Task RemoveContrato(int contratoId);
        Task<SplitPagamentoBase> GetSplitByIdAsync(int id);
        void InsertSplit(SplitPagamentoBase split);
        void UpdateSplit(SplitPagamentoBase split);
        Task RemoveSplit(int id);
        Task RemoveContratoAdiantamento(int id);
        Task<ContratoAdiantamento> GetContratoByIdAsync(int id);
    }
}
