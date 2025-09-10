using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using SCAE.Data.Interface.Financeiro;
using SCAE.Domain.Entities.Financeiro;
using SCAE.Service.Interfaces.Financeiro;
using SCAE.Service.Services.Shared;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCAE.Service.Services.Financeiro
{
    public class IndiceService : CrudService<Indice, IIndiceRepository>, IIndiceService
    {
        public IndiceService(IIndiceRepository repository) : base(repository)
        {

        }

        public async Task<string> DeleteDataInferior(string ano) 
        {
            var errosLista = new StringBuilder();
            var errosCount = 0;
            errosLista.Append("<!DOCTYPE html><html><head><meta charset=\"UTF-8\">Relatório de Erros ao Deletar Índices</head><body>");
            ushort resultado;

            if (!ushort.TryParse(ano, out resultado))
                throw new Exception("Parâmetro não pôde ser convertido para ushort");

            var indices = await Get().Where(x => x.Ano < resultado).Select(x => x.Id).ToListAsync();

            try
            {
                foreach (var i in indices)
                {
                    await Delete(i);
                }
            }
            catch (Exception e)
            {
                errosLista.AppendLine(e.Message);
                errosLista.AppendLine( e.InnerException != null ? e.InnerException.Message : "");
                errosCount++;
            }

            errosLista.Append("</body></html>");

            return errosCount > 0 ? errosLista.ToString() : "";
        }
    }
}
