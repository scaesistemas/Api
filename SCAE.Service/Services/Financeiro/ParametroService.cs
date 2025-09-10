using DFe.Utils;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;
using SCAE.Data.Interface.Financeiro;
using SCAE.Domain.Entities.Financeiro;
using SCAE.Domain.Models.ChatBot;
using SCAE.Domain.Models.Financeiro.ApiFinanceiro.Gateway;
using SCAE.Domain.Models.Financeiro.ApiFinanceiro.Shared;
using SCAE.Domain.Models.GalaxPay;
using SCAE.Framework.Exceptions;
using SCAE.Framework.Helper;
using SCAE.Service.Interfaces.Financeiro;
using SCAE.Service.Interfaces.Financeiro.ApiFinanceiro;
using SCAE.Service.Interfaces.Financeiro.Gateway;
using SCAE.Service.Interfaces.Geral;
using SCAE.Service.Services.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SCAE.Service.Services.Financeiro
{
    public class ParametroService : CrudService<Parametro, IParametroRepository>, IParametroService
    {
        private readonly IReceitaRepository _receitaRepository;
        private readonly IGatewayService _gatewayService;
        private readonly IEmpresaService _empresaService;


        public ParametroService(IParametroRepository repository, IReceitaRepository receitaRepository, IGatewayService gatewayService, IEmpresaService empresaService) : base(repository)
        {
            _receitaRepository = receitaRepository;
            _gatewayService = gatewayService;
            _empresaService = empresaService;
        }

        public async Task<Parametro> GetFirst(int empresaId)
        {
            return await _repository.GetFirst(empresaId);
        }
        public IQueryable<Parametro> GetAllByEmpresaId(int empresaId)
        {
            return _repository.GetAllByEmpresaId(empresaId);
        }

        public override async Task Patch(int id, JsonPatchDocument<Parametro> model, string include)
        {

            await base.Patch(id, model, include);

            var operacao = model.Operations.FirstOrDefault(op => op.path.Equals("/desmarcarBoletosCobrancasAutomaticas", StringComparison.OrdinalIgnoreCase));

            if (operacao != null)
            {
                bool? novoValor = (bool)operacao?.value;
                await DesmarcarBoletoCobrancaAutomatico(id, novoValor.Value);
            }

        }

        public async Task DesmarcarBoletoCobrancaAutomatico(int parametroId, bool desmarcarBoletoCobrancaAutomatico)
        {

            Parametro parametro = await
                GetAllNoTracking()
                .Where(x => x.Id == parametroId)
                .FirstOrDefaultAsync();


            List<Receita> receitas = await _receitaRepository.GetAll().Where(x => x.EmpresaId == parametro.EmpresaId && x.ContratoId != null).ToListAsync();

            receitas.ForEach(x =>
            {
                x.GerarBoletoAutomatico = !desmarcarBoletoCobrancaAutomatico;
                x.RealizarCobrancaAutomatica = !desmarcarBoletoCobrancaAutomatico;
            });

            await SaveChangesAsync();
        }



        public async Task EnviarSms(int cobrancaId, bool enviarSms)
        {
            var parametroCobranca = await _repository.GetCobrancaById(cobrancaId);

            if (parametroCobranca == null)
                throw new NotFoundException(MensagemHelper.RegistroNaoEncontrato);

            parametroCobranca.EnviarSms = enviarSms;

            await SaveChangesAsync();
        }

        public async Task DefinirGatewayPrincipal(int gatewayId)
        {
            var gatewaySelecionado = await _repository.GetGatewayById(gatewayId);

            if (gatewaySelecionado == null)
                throw new NotFoundException("Gateway não encontrado");

            if (gatewaySelecionado.Principal)
                throw new BadRequestException("Gateway já é principal");

            var outrosGateways = await _repository.GetGatewayAll().Where(x => x.ParametroId == gatewaySelecionado.ParametroId && x.Id != gatewayId).ToListAsync();

            if (outrosGateways.Any())
            {
                foreach (var gateways in outrosGateways)
                {
                    gateways.Principal = false;
                }
            }
            gatewaySelecionado.Principal = true;

            await SaveChangesAsync();
        }

        public async Task<ParametroGatway> GetGatewayByIdNoInclude(int gatewayId)
        {
            return await _repository.GetGatewayById(gatewayId);
        }

        public async Task CriarSubConta(int id, int tipoGatewayId, SubContaModel subcontaScae)
        {
            var parametro = await _repository.GetByIdTrackingAsync(id, "Gatways") ?? throw new NotFoundException("Id de parâmetor inválido!");
            var tipoGateway = TipoGateway.ObterDados().FirstOrDefault(x => x.Id == tipoGatewayId) ?? throw new NotFoundException("TipoGateway informado é inválido!");
            var gateway = parametro.Gatways.FirstOrDefault(x => x.TipoId == tipoGatewayId);

            if (gateway == null)
            {
                parametro.Gatways.Add(new ParametroGatway
                {
                    ParametroId = parametro.Id,
                    TipoId = tipoGatewayId,
                    Principal = true
                });
                gateway = parametro.Gatways.FirstOrDefault(x => x.TipoId == tipoGatewayId);
                await SaveChangesAsync();
            }         

            RetornoSubContaModel retorno = null;

            switch (tipoGateway.Id)
            {
                case (int)EnumGateway.GalaxPay:
                    retorno =  await _gatewayService.CriarSubConta(EnumGateway.GalaxPay, subcontaScae);
                    gateway.GalaxPay.Id = retorno.EmpresaId;
                    gateway.GalaxPay.Hash = retorno.EmpresaHash;
                    gateway.GalaxPay.isSubconta = true;
                    gateway.GalaxPay.isSubcontaAtiva = false;
                    gateway.GalaxPay.DocumentosEnviados = false;
                    gateway.isGerado = true;
                    break;
                case (int)EnumGateway.Global:
                    retorno = await _gatewayService.CriarSubConta(EnumGateway.Global, subcontaScae);
                    gateway.GlobalPay.email = retorno.EmpresaId;
                    gateway.GlobalPay.Senha = retorno.EmpresaHash;
                    gateway.GlobalPay.isSubconta = true;
                    gateway.GlobalPay.isSubcontaAtiva = false;
                    gateway.GlobalPay.DocumentosEnviados = false;
                    gateway.isGerado = true;
                    break;
                default:
                    throw new Exception("Criação de subconta não implementada para o gateway informado");
            }
            await SaveChangesAsync();
        }

        public async Task EnviarDocumentoSubconta(int id, int tipoGatewayId, SubcontaDocumentoScaeModel documentos)
        {

            var parametro = await _repository.GetByIdTrackingAsync(id, $"Gatways") ?? throw new NotFoundException("Id de parâmetor inválido!");
            var tipoGateway = TipoGateway.ObterDados().FirstOrDefault(x => x.Id == tipoGatewayId) ?? throw new NotFoundException("TipoGateway informado é inválido!");
            var gateway = parametro.Gatways.FirstOrDefault(x => x.TipoId == tipoGatewayId);

            switch (tipoGatewayId)
            {
                case (int)EnumGateway.GalaxPay:
                    await _gatewayService.EnviarDocumentoSubConta(EnumGateway.GalaxPay, documentos, gateway.GalaxPay.Id, gateway.GalaxPay.Hash);
                    gateway.GalaxPay.DocumentosEnviados = true;
                    break;
                case (int)EnumGateway.Global:
                    await _gatewayService.EnviarDocumentoSubConta(EnumGateway.Global, documentos, gateway.GlobalPay.email, gateway.GlobalPay.Senha);
                    gateway.GlobalPay.DocumentosEnviados = true;
                    break;
                default:
                    throw new Exception("Enviar subconta do gateway informado não implementada.");
            }
            await SaveChangesAsync();
        }

        public async Task<SubcontaConsultaModel> ConsultarSubconta(int id, int tipoGatewayId)
        {
            var parametro = await _repository.GetByIdTrackingAsync(id, $"Gatways") ?? throw new NotFoundException("Id de parâmetor inválido!");
            var tipoGateway = TipoGateway.ObterDados().FirstOrDefault(x => x.Id == tipoGatewayId) ?? throw new NotFoundException("TipoGateway informado é inválido!");
            var gateway = parametro.Gatways.FirstOrDefault(x => x.TipoId == tipoGatewayId);

            switch (tipoGatewayId)
            {
                case (int)EnumGateway.GalaxPay:
                    var retorno = await _gatewayService.ConsultarSubconta(EnumGateway.GalaxPay, gateway.GalaxPay.Id);
                    if (retorno.Ativo)
                    {
                        gateway.GalaxPay.isSubcontaAtiva = true;
                        await SaveChangesAsync();
                    }
                    return retorno;
                default:
                    throw new Exception("Consulta de subconta não implementada para o gateway informado");
            }
        }
    }
}
