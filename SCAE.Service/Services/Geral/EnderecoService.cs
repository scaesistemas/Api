using HtmlAgilityPack;
using Newtonsoft.Json;
using SCAE.Data.Interface.Geral;
using SCAE.Domain.Entities.Geral;
using SCAE.Domain.Models.Shared;
using SCAE.Framework.Exceptions;
using SCAE.Framework.Helper;
using SCAE.Service.Interfaces.Geral;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace SCAE.Service.Services.Geral
{
    public class EnderecoService : IEnderecoService
    {
        private readonly IEstadoRepository _estadoRepository;
        private readonly IMunicipioRepository _municipioRepository;

        public EnderecoService(IEstadoRepository estadoRepository, IMunicipioRepository municipioRepository)
        {
            _estadoRepository = estadoRepository;
            _municipioRepository = municipioRepository;
        }

        public IQueryable<Estado> ObterEstados()
        {
            return _estadoRepository.GetAll();
        }

        public async Task<Estado> ObterEstado(int id)
        {
            return await _estadoRepository.GetByIdAsync(id);
        }

        public IQueryable<Municipio> ObterMunicipios(int estadoId)
        {
            return _municipioRepository.GetAll().Where(x => x.EstadoId == estadoId);
        }

        public async Task<Municipio> ObterMunicipio(int id)
        {
            return await _municipioRepository.GetByIdAsync(id);
        }

        public async Task<EnderecoModel> ObterPorCep(string cep)
        {
            try
            {

                if (string.IsNullOrEmpty(cep))
                    return null;

                HttpClient client = new HttpClient();
                HttpResponseMessage resultado = await client.GetAsync($"https://viacep.com.br/ws/{cep}/json/");
                var contentStream = await resultado.Content.ReadAsStreamAsync();
                using var streamReader = new StreamReader(contentStream);
                using var jsonReader = new JsonTextReader(streamReader);

                JsonSerializer serializer = new JsonSerializer();

                var endereco = new EnderecoModel();
                endereco =  serializer.Deserialize<EnderecoModel>(jsonReader);
                endereco.Estado = Estado.ObterPorUf(endereco.UF)?.Nome ?? throw new NotFoundException(MensagemHelper.RegistroNaoEncontrato);
                endereco.EstadoId = Estado.ObterPorUf(endereco.UF)?.Id ?? throw new NotFoundException(MensagemHelper.RegistroNaoEncontrato);
                endereco.MunicipioId = Municipio.ObterPorNome(endereco.EstadoId,endereco.Localidade)?.Id ?? throw new NotFoundException(MensagemHelper.RegistroNaoEncontrato);
                return endereco;

            }
            catch
            {
                return null;
            }
        }
    }
}
