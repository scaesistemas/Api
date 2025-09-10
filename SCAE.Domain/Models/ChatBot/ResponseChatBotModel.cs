using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCAE.Domain.Models.ChatBot
{
    public class ResponseChatBotModel
    {

    }

    public class MenuChatBotModel
    {
        [JsonProperty("type")] public string Tipo { get; private set; }
        [JsonProperty("text")] public string Texto { get; set; }
        [JsonProperty("attachments")] public List<Anexo> Anexos { get; set; }
        [JsonProperty("items")] public List<OpcaoMenu> OpcoesMenu { get; set; }

        public MenuChatBotModel()
        {
            Tipo = "MENU";
        }
    }

    public class PerguntaChatBotModel
    {
        [JsonProperty("type")] public string Tipo { get; set; }
        [JsonProperty("text")] public string Texto { get; set; }
        [JsonProperty("attachments")] public List<Anexo> Anexos { get; set; }
        [JsonProperty("callback")] public Retorno Retorno { get; set; } //caminho e dados que serão chamados ao escolher essa opção


        public PerguntaChatBotModel()
        {
            Tipo = "QUESTION";
        }
    }

    public class InformacaoChatBotModel
    {
        [JsonProperty("type")] public string Tipo { get; private set; }
        [JsonProperty("text")] public string Texto { get; set; }
        [JsonProperty("attachments")] public List<Anexo> Anexos { get; set; } 
        [JsonProperty("newTicket")] public NovoTicket NovoTicket { get; set; }


        public InformacaoChatBotModel()
        {
            Tipo = "INFORMATION";
            Anexos = new List<Anexo>();
        }
    }

    public class DirecionarMenuChatBotModel
    {
        [JsonProperty("type")] public string Tipo { get; set; }
        [JsonProperty("menuUUID")] public string MenuId { get; set; }

        public DirecionarMenuChatBotModel()
        {
            Tipo = "DIRECT_TO_MENU";
        }
    }

    public class Anexo
    {
        [JsonProperty("position")] public string Posicao { get; set; }
        [JsonProperty("type")] public string Tipo { get; set; }
        [JsonProperty("name")] public string Nome { get; set; }
        [JsonProperty("url")] public string Url { get; set; }
        [JsonProperty("base64")] public string Arquivo { get; set; }
    }

    public class OpcaoMenu
    {
        [JsonProperty("number")] public int Numero { get; set; }
        [JsonProperty("text")] public string Texto { get; set; }
        [JsonProperty("callback")] public Retorno Retorno { get; set; } //caminho e dados que serão chamados ao escolher essa opção
    }

    public class Retorno
    {
        [JsonProperty("endpoint")] public string Endpoint { get; set; }
        [JsonProperty("data")] public DadosAdicionais DadosAdicionais { get; set; }
    }

    public class NovoTicket
    {
        [JsonProperty("departmentUUID")] public int DepartamentoId { get; set; }
        [JsonProperty("userUUID")] public int AtendenteId { get; set; }
    }

    public class ContratoPorAssinante
    {
        public int ContratoId { get; set; }
        public int AssinanteId { get; set; }
        public string ContratoNumeroSequencia { get; set; }
        public string AssinanteNome { get; set; }
    }
}
