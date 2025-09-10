using SCAE.Data.Context;
using SCAE.Domain.Models.ChatBot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCAE.Service.Interfaces.Geral
{
    public interface IChatBotService
    {
        Task<(MenuChatBotModel menuChatBotRetorno, InformacaoChatBotModel InformacaoChatBotRetorno)> MenuContratosCliente(RequestChatBotModel requisicao);
        Task<InformacaoChatBotModel> GetBoletoCliente(RequestChatBotModel requisicao, int AssinanteId);
    }
}
