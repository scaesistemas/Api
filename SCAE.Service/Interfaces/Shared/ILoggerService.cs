using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCAE.Service.Interfaces.Shared
{
    public interface ILoggerService
    {
        Task EnviarWorker(int assinanteId, int parcelaId, int transacaoId, string descricao, bool isErro, ILogger logger, bool isCobranca = false, bool isBaixa = false, bool isEmissaoBoleto = false, bool isCancelamento = false, bool isCRM = false);
    }
}
