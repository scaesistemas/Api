using Microsoft.EntityFrameworkCore;
using SCAE.Data.Interface.Geral.CRMVendas;
using SCAE.Domain.Entities.Geral.CRMVendas;
using SCAE.Domain.Models.Geral.CRMVendas;
using SCAE.Framework.Exceptions;
using SCAE.Framework.Helper;
using SCAE.Service.Interfaces.Geral.CRMVendas;
using SCAE.Service.Services.Shared;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SCAE.Service.Services.Geral.CRMVendas
{
    public class AtendimentoService : CrudService<Atendimento, IAtendimentoRepository>, IAtendimentoService
    {
        public readonly ILeadService _leadService;
        public AtendimentoService(IAtendimentoRepository repository, ILeadService leadService) : base(repository) 
        {
            _leadService = leadService;
        }

        public override async Task Post(Atendimento entity)
        {
            if(entity.Realizado)
            {
                using (var transaction = BeginTransaction())
                {
                    await _repository.Insert(entity);

                    var lead = await _leadService.GetTracking(entity.LeadId) ?? throw new NotFoundException("Lead não encontrado");

                    if (entity.Realizado)
                        entity.DataConclusao = DateTime.Now;

                    lead.DataUltimaInteracao = DateTime.Now;
                    await SaveChangesAsync();

                    transaction.Commit();
                }
            }
            else
            {
                await base.Post(entity);
            }

        }
        public async Task<AtendimentoTarefaModel> GetAtendimentoByLeadCorretor( int leadId, int corretorId,string include)
        {

            var atendimentos = await _repository.GetAtendimentoByLeadCorretor(leadId, corretorId, include).ToListAsync();

            var retorno = new AtendimentoTarefaModel()
            {
                Atendimentos = atendimentos.Where(x => x.Realizado).OrderBy(x => x.DataCriacao).ToList(),
                Tarefas = atendimentos.Where(x => x.Realizado == false).OrderBy(x=>x.DataAgendamento).ToList(),
            };
            return retorno;
        }

        public async Task AlterarRealizado(int atendimentoId, bool realizado)
        {
            var atendimento = await GetTracking(atendimentoId, "Lead") ?? throw new NotFoundException(MensagemHelper.RegistroNaoEncontrato);

            if(atendimento.Realizado == false && realizado)
            {
                atendimento.DataConclusao = DateTime.Now;
                atendimento.Lead.DataUltimaInteracao = DateTime.Now;
            }

            atendimento.Realizado = realizado;


            await SaveChangesAsync();

        }
    }
}
