using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SCAE.Domain.Models.Financeiro
{
    public class WorkerPositionModel
    {
        private bool _gerarBoleto;
        private bool _baixarParcela;
        private bool _envioCobranca;
        private bool _cancelarAgrupadasVencidas;
        private bool _cancelarReservasExpiradas;
        private int _parcelaId;
        private int _transacaoId;

        public int ParcelaId { get => _parcelaId > 0 ? _parcelaId : -1; set => _parcelaId = value; }
        public int TransacaoId { get => _transacaoId > 0 ? _transacaoId : -1; set => _transacaoId = value; }
        public int AssinanteId { get; set; }

        public WorkerPositionModel()
        {
            _gerarBoleto = false;
            _baixarParcela = false;
            _envioCobranca = false;
            _cancelarAgrupadasVencidas = false;
            _cancelarReservasExpiradas = false;
        }

        public void SetGerarBoleto()
        {
            _gerarBoleto = true;
            _baixarParcela = false;
            _envioCobranca = false;
            _cancelarAgrupadasVencidas = false;
            _cancelarReservasExpiradas = false;
            _parcelaId = 0;
            _transacaoId = 0;
        }

        public void SetBaixarParcela()
        {
            _gerarBoleto = false;
            _baixarParcela = true;
            _envioCobranca = false;
            _cancelarAgrupadasVencidas = false;
            _cancelarReservasExpiradas = false;
            _parcelaId = 0;
            _transacaoId = 0;
        }

        public void SetEnvioCobranca()
        {
            _gerarBoleto = false;
            _baixarParcela = false;
            _envioCobranca = true;
            _cancelarAgrupadasVencidas = false;
            _cancelarReservasExpiradas = false;
            _parcelaId = 0;
            _transacaoId = 0;
        }
        public void SetCancelamentoReservas()
        {
            _gerarBoleto = false;
            _baixarParcela = false;
            _envioCobranca = false;
            _cancelarAgrupadasVencidas = false;
            _cancelarReservasExpiradas = true;
            _parcelaId = 0;
            _transacaoId = 0;
        }
        public void SetAgrupadasVencidas()
        {
            _gerarBoleto = false;
            _baixarParcela = false;
            _envioCobranca = false;
            _cancelarAgrupadasVencidas=true;
            _cancelarReservasExpiradas = false;
            _parcelaId = 0;
            _transacaoId = 0;
        }

        public string GetMessage()
        {
            var mensagem = string.Empty;

            if (_gerarBoleto)
                mensagem = "Estou em Gerar Boleto!";

            if (_baixarParcela)
                mensagem = "Estou em Baixa de Parcela!";

            if (_envioCobranca)
                mensagem = "Estou em Envio de Cobrança!";

            if (_cancelarAgrupadasVencidas)
                mensagem = "Estou em Cancelar Agrupadas Vencidas!";

            if (_cancelarReservasExpiradas)
                mensagem = "Estou em Cancelar Agrupadas Vencidas!";

            if (_parcelaId > 0)
                mensagem += $", ParcelaId {_parcelaId}";

            if (!string.IsNullOrEmpty(mensagem))
                return mensagem;
            
            return "Não entrei e nenhuma função!";
        }

    }
}