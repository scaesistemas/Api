using Microsoft.EntityFrameworkCore;
using SCAE.Domain.Entities.Geral;
using System.ComponentModel.DataAnnotations.Schema;

namespace SCAE.Domain.Entities.OrcamentoObras
{
    [Owned]
    public class InsumoEstado
    {
        private int _estadoId = 11;

        private decimal _coeficiente = 1;
        private InsumoEstadoValor acre;
        private InsumoEstadoValor alagoas;
        private InsumoEstadoValor amapa;
        private InsumoEstadoValor amazonas;
        private InsumoEstadoValor bahia;
        private InsumoEstadoValor ceara;
        private InsumoEstadoValor espiritoSanto;
        private InsumoEstadoValor goias;
        private InsumoEstadoValor maranhao;
        private InsumoEstadoValor matoGrosso;
        private InsumoEstadoValor matoGrossoDoSul;
        private InsumoEstadoValor minasGerais;
        private InsumoEstadoValor para;
        private InsumoEstadoValor paraiba;
        private InsumoEstadoValor parana;
        private InsumoEstadoValor pernambuco;
        private InsumoEstadoValor piaui;
        private InsumoEstadoValor rioDeJaneiro;
        private InsumoEstadoValor rioGrandeDoNorte;
        private InsumoEstadoValor rioGrandeDoSul;
        private InsumoEstadoValor rondonia;
        private InsumoEstadoValor roraima;
        private InsumoEstadoValor santaCatarina;
        private InsumoEstadoValor saoPaulo;
        private InsumoEstadoValor sergipe;
        private InsumoEstadoValor tocantins;
        private InsumoEstadoValor distritoFederal;

        public InsumoEstado AtualizaCoeficiente(decimal coeficiente)
        {
            _coeficiente = coeficiente;

            return this;
        }
        public void AtualizarEstado(int id) 
        {
            _estadoId = id;
        }

        public InsumoEstadoValor Acre
        {
            get
            {
                if (acre == null)
                    acre = new InsumoEstadoValor();
                else
                    acre.AtualizaCoeficiente(_coeficiente);
                return acre;
            }
            set
            {
                acre = value;
            }
        }
        public InsumoEstadoValor Alagoas
        {
            get
            {
                if (alagoas == null)
                    alagoas = new InsumoEstadoValor();
                else
                    alagoas.AtualizaCoeficiente(_coeficiente);
                return alagoas;
            }
            set
            {
                alagoas = value;
            }
        }
        public InsumoEstadoValor Amapa
        {
            get
            {
                if (amapa == null)
                    amapa = new InsumoEstadoValor();
                else
                    amapa.AtualizaCoeficiente(_coeficiente);
                return amapa;
            }
            set
            {
                amapa = value;
            }
        }
        public InsumoEstadoValor Amazonas
        {
            get
            {
                if (amazonas == null)
                    amazonas = new InsumoEstadoValor();
                else
                    amazonas.AtualizaCoeficiente(_coeficiente);
                return amazonas;
            }
            set
            {
                amazonas = value;
            }
        }
        public InsumoEstadoValor Bahia
        {
            get
            {
                if (bahia == null)
                    bahia = new InsumoEstadoValor();
                else
                    bahia.AtualizaCoeficiente(_coeficiente);
                return bahia;
            }
            set
            {
                bahia = value;
            }
        }
        public InsumoEstadoValor Ceara
        {
            get
            {
                if (ceara == null)
                    ceara = new InsumoEstadoValor();
                else
                    ceara.AtualizaCoeficiente(_coeficiente);
                return ceara;
            }
            set
            {
                ceara = value;
            }
        }
        public InsumoEstadoValor EspiritoSanto
        {
            get
            {
                if (espiritoSanto == null)
                    espiritoSanto = new InsumoEstadoValor();
                else
                    espiritoSanto.AtualizaCoeficiente(_coeficiente);
                return espiritoSanto;
            }
            set
            {
                espiritoSanto = value;
            }
        }
        public InsumoEstadoValor Goias
        {
            get
            {
                if (goias == null)
                    goias = new InsumoEstadoValor();
                else
                    goias.AtualizaCoeficiente(_coeficiente);
                return goias;
            }
            set
            {
                goias = value;
            }
        }
        public InsumoEstadoValor Maranhao
        {
            get
            {
                if (maranhao == null)
                    maranhao = new InsumoEstadoValor();
                else
                    maranhao.AtualizaCoeficiente(_coeficiente);
                return maranhao;
            }
            set
            {
                maranhao = value;
            }
        }
        public InsumoEstadoValor MatoGrosso
        {
            get
            {
                if (matoGrosso == null)
                    matoGrosso = new InsumoEstadoValor();
                else
                    matoGrosso.AtualizaCoeficiente(_coeficiente);
                return matoGrosso;
            }
            set
            {
                matoGrosso = value;
            }
        }
        public InsumoEstadoValor MatoGrossoDoSul
        {
            get
            {
                if (matoGrossoDoSul == null)
                    matoGrossoDoSul = new InsumoEstadoValor();
                else
                    matoGrossoDoSul.AtualizaCoeficiente(_coeficiente);
                return matoGrossoDoSul;
            }
            set
            {
                matoGrossoDoSul = value;
            }
        }
        public InsumoEstadoValor MinasGerais
        {
            get
            {
                if (minasGerais == null)
                    minasGerais = new InsumoEstadoValor();
                else
                    minasGerais.AtualizaCoeficiente(_coeficiente);
                return minasGerais;
            }
            set
            {
                minasGerais = value;
            }
        }
        public InsumoEstadoValor Para
        {
            get
            {
                if (para == null)
                    para = new InsumoEstadoValor();
                else
                    para.AtualizaCoeficiente(_coeficiente);
                return para;
            }
            set
            {
                para = value;
            }
        }
        public InsumoEstadoValor Paraiba
        {
            get
            {
                if (paraiba == null)
                    paraiba = new InsumoEstadoValor();
                else
                    paraiba.AtualizaCoeficiente(_coeficiente);
                return paraiba;
            }
            set
            {
                paraiba = value;
            }
        }
        public InsumoEstadoValor Parana
        {
            get
            {
                if (parana == null)
                    parana = new InsumoEstadoValor();
                else
                    parana.AtualizaCoeficiente(_coeficiente);
                return parana;
            }
            set
            {
                parana = value;
            }
        }
        public InsumoEstadoValor Pernambuco
        {
            get
            {
                if (pernambuco == null)
                    pernambuco = new InsumoEstadoValor();
                else
                    pernambuco.AtualizaCoeficiente(_coeficiente);
                return pernambuco;
            }
            set
            {
                pernambuco = value;
            }
        }
        public InsumoEstadoValor Piaui
        {
            get
            {
                if (piaui == null)
                    piaui = new InsumoEstadoValor();
                else
                    piaui.AtualizaCoeficiente(_coeficiente);
                return piaui;
            }
            set
            {
                piaui = value;
            }
        }
        public InsumoEstadoValor RioDeJaneiro
        {
            get
            {
                if (rioDeJaneiro == null)
                    rioDeJaneiro = new InsumoEstadoValor();
                else
                    rioDeJaneiro.AtualizaCoeficiente(_coeficiente);
                return rioDeJaneiro;
            }
            set
            {
                rioDeJaneiro = value;
            }
        }
        public InsumoEstadoValor RioGrandeDoNorte
        {
            get
            {
                if (rioGrandeDoNorte == null)
                    rioGrandeDoNorte = new InsumoEstadoValor();
                else
                    rioGrandeDoNorte.AtualizaCoeficiente(_coeficiente);
                return rioGrandeDoNorte;
            }
            set
            {
                rioGrandeDoNorte = value;
            }
        }
        public InsumoEstadoValor RioGrandeDoSul
        {
            get
            {
                if (rioGrandeDoSul == null)
                    rioGrandeDoSul = new InsumoEstadoValor();
                else
                    rioGrandeDoSul.AtualizaCoeficiente(_coeficiente);
                return rioGrandeDoSul;
            }
            set
            {
                rioGrandeDoSul = value;
            }
        }
        public InsumoEstadoValor Rondonia
        {
            get
            {
                if (rondonia == null)
                    rondonia = new InsumoEstadoValor();
                else
                    rondonia.AtualizaCoeficiente(_coeficiente);
                return rondonia;
            }
            set
            {
                rondonia = value;
            }
        }
        public InsumoEstadoValor Roraima
        {
            get
            {
                if (roraima == null)
                    roraima = new InsumoEstadoValor();
                else
                    roraima.AtualizaCoeficiente(_coeficiente);
                return roraima;
            }
            set
            {
                roraima = value;
            }
        }
        public InsumoEstadoValor SantaCatarina
        {
            get
            {
                if (santaCatarina == null)
                    santaCatarina = new InsumoEstadoValor();
                else
                    santaCatarina.AtualizaCoeficiente(_coeficiente);
                return santaCatarina;
            }
            set
            {
                santaCatarina = value;
            }
        }
        public InsumoEstadoValor SaoPaulo
        {
            get
            {
                if (saoPaulo == null)
                    saoPaulo = new InsumoEstadoValor();
                else
                    saoPaulo.AtualizaCoeficiente(_coeficiente);
                return saoPaulo;
            }
            set
            {
                saoPaulo = value;
            }
        }
        public InsumoEstadoValor Sergipe
        {
            get
            {
                if (sergipe == null)
                    sergipe = new InsumoEstadoValor();
                else
                    sergipe.AtualizaCoeficiente(_coeficiente);
                return sergipe;
            }
            set
            {
                sergipe = value;
            }
        }
        public InsumoEstadoValor Tocantins
        {
            get
            {
                if (tocantins == null)
                    tocantins = new InsumoEstadoValor();
                else
                    tocantins.AtualizaCoeficiente(_coeficiente);
                return tocantins;
            }
            set
            {
                tocantins = value;
            }
        }
        public InsumoEstadoValor DistritoFederal
        {
            get
            {
                if (distritoFederal == null)
                    distritoFederal = new InsumoEstadoValor();
                else
                    distritoFederal.AtualizaCoeficiente(_coeficiente);
                return distritoFederal;
            }
            set
            {
                distritoFederal = value;
            }
        }

        public decimal valorDesonerado => ObterValorDesonerado(_estadoId);

        public decimal ObterValorDesonerado(int estadoId)
        {
            switch (estadoId)
            {
                case int x when x == Estado.AC.Id:
                    return Acre.ValorDesonerado;
                case int x when x == Estado.AL.Id:
                    return Alagoas.ValorDesonerado;
                case int x when x == Estado.AP.Id:
                    return Amapa.ValorDesonerado;
                case int x when x == Estado.AM.Id:
                    return Amazonas.ValorDesonerado;
                case int x when x == Estado.BA.Id:
                    return Bahia.ValorDesonerado;
                case int x when x == Estado.CE.Id:
                    return Ceara.ValorDesonerado;
                case int x when x == Estado.ES.Id:
                    return EspiritoSanto.ValorDesonerado;
                case int x when x == Estado.GO.Id:
                    return Goias.ValorDesonerado;
                case int x when x == Estado.MA.Id:
                    return Maranhao.ValorDesonerado;
                case int x when x == Estado.MT.Id:
                    return MatoGrosso.ValorDesonerado;
                case int x when x == Estado.MS.Id:
                    return MatoGrossoDoSul.ValorDesonerado;
                case int x when x == Estado.MG.Id:
                    return MinasGerais.ValorDesonerado;
                case int x when x == Estado.PA.Id:
                    return Para.ValorDesonerado;
                case int x when x == Estado.PB.Id:
                    return Paraiba.ValorDesonerado;
                case int x when x == Estado.PR.Id:
                    return Parana.ValorDesonerado;
                case int x when x == Estado.PE.Id:
                    return Pernambuco.ValorDesonerado;
                case int x when x == Estado.PI.Id:
                    return Piaui.ValorDesonerado;
                case int x when x == Estado.RJ.Id:
                    return RioDeJaneiro.ValorDesonerado;
                case int x when x == Estado.RN.Id:
                    return RioGrandeDoNorte.ValorDesonerado;
                case int x when x == Estado.RS.Id:
                    return RioGrandeDoSul.ValorDesonerado;
                case int x when x == Estado.RO.Id:
                    return Rondonia.ValorDesonerado;
                case int x when x == Estado.RR.Id:
                    return Roraima.ValorDesonerado;
                case int x when x == Estado.SC.Id:
                    return SantaCatarina.ValorDesonerado;
                case int x when x == Estado.SP.Id:
                    return SaoPaulo.ValorDesonerado;
                case int x when x == Estado.SE.Id:
                    return Sergipe.ValorDesonerado;
                case int x when x == Estado.TO.Id:
                    return Tocantins.ValorDesonerado;
                case int x when x == Estado.DF.Id:
                    return DistritoFederal.ValorDesonerado;
                default:
                    return 0;
            }
        }

        public decimal ObterValorNaoDesonerado(int estadoId)
        {
            switch (estadoId)
            {
                case int x when x == Estado.AC.Id:
                    return Acre.ValorNaoDesonerado;
                case int x when x == Estado.AL.Id:
                    return Alagoas.ValorNaoDesonerado;
                case int x when x == Estado.AP.Id:
                    return Amapa.ValorNaoDesonerado;
                case int x when x == Estado.AM.Id:
                    return Amazonas.ValorNaoDesonerado;
                case int x when x == Estado.BA.Id:
                    return Bahia.ValorNaoDesonerado;
                case int x when x == Estado.CE.Id:
                    return Ceara.ValorNaoDesonerado;
                case int x when x == Estado.ES.Id:
                    return EspiritoSanto.ValorNaoDesonerado;
                case int x when x == Estado.GO.Id:
                    return Goias.ValorNaoDesonerado;
                case int x when x == Estado.MA.Id:
                    return Maranhao.ValorNaoDesonerado;
                case int x when x == Estado.MT.Id:
                    return MatoGrosso.ValorNaoDesonerado;
                case int x when x == Estado.MS.Id:
                    return MatoGrossoDoSul.ValorNaoDesonerado;
                case int x when x == Estado.MG.Id:
                    return MinasGerais.ValorNaoDesonerado;
                case int x when x == Estado.PA.Id:
                    return Para.ValorNaoDesonerado;
                case int x when x == Estado.PB.Id:
                    return Paraiba.ValorNaoDesonerado;
                case int x when x == Estado.PR.Id:
                    return Parana.ValorNaoDesonerado;
                case int x when x == Estado.PE.Id:
                    return Pernambuco.ValorNaoDesonerado;
                case int x when x == Estado.PI.Id:
                    return Piaui.ValorNaoDesonerado;
                case int x when x == Estado.RJ.Id:
                    return RioDeJaneiro.ValorNaoDesonerado;
                case int x when x == Estado.RN.Id:
                    return RioGrandeDoNorte.ValorNaoDesonerado;
                case int x when x == Estado.RS.Id:
                    return RioGrandeDoSul.ValorNaoDesonerado;
                case int x when x == Estado.RO.Id:
                    return Rondonia.ValorNaoDesonerado;
                case int x when x == Estado.RR.Id:
                    return Roraima.ValorNaoDesonerado;
                case int x when x == Estado.SC.Id:
                    return SantaCatarina.ValorNaoDesonerado;
                case int x when x == Estado.SP.Id:
                    return SaoPaulo.ValorNaoDesonerado;
                case int x when x == Estado.SE.Id:
                    return Sergipe.ValorNaoDesonerado;
                case int x when x == Estado.TO.Id:
                    return Tocantins.ValorNaoDesonerado;
                case int x when x == Estado.DF.Id:
                    return DistritoFederal.ValorNaoDesonerado;
                default:
                    return 0;
            }
        }

        public InsumoEstadoValor ObterValores(int estadoId)
        {
            switch (estadoId)
            {
                case int x when x == Estado.AC.Id:
                    return acre;
                case int x when x == Estado.AL.Id:
                    return alagoas;
                case int x when x == Estado.AP.Id:
                    return amapa;
                case int x when x == Estado.AM.Id:
                    return amazonas;
                case int x when x == Estado.BA.Id:
                    return bahia;
                case int x when x == Estado.CE.Id:
                    return ceara;
                case int x when x == Estado.ES.Id:
                    return espiritoSanto;
                case int x when x == Estado.GO.Id:
                    return goias;
                case int x when x == Estado.MA.Id:
                    return maranhao;
                case int x when x == Estado.MT.Id:
                    return matoGrosso;
                case int x when x == Estado.MS.Id:
                    return matoGrossoDoSul;
                case int x when x == Estado.MG.Id:
                    return minasGerais;
                case int x when x == Estado.PA.Id:
                    return para;
                case int x when x == Estado.PB.Id:
                    return paraiba;
                case int x when x == Estado.PR.Id:
                    return parana;
                case int x when x == Estado.PE.Id:
                    return pernambuco;
                case int x when x == Estado.PI.Id:
                    return piaui;
                case int x when x == Estado.RJ.Id:
                    return rioDeJaneiro;
                case int x when x == Estado.RN.Id:
                    return rioGrandeDoNorte;
                case int x when x == Estado.RS.Id:
                    return rioGrandeDoSul;
                case int x when x == Estado.RO.Id:
                    return rondonia;
                case int x when x == Estado.RR.Id:
                    return roraima;
                case int x when x == Estado.SC.Id:
                    return santaCatarina;
                case int x when x == Estado.SP.Id:
                    return saoPaulo;
                case int x when x == Estado.SE.Id:
                    return sergipe;
                case int x when x == Estado.TO.Id:
                    return tocantins;
                case int x when x == Estado.DF.Id:
                    return distritoFederal;
                default:
                    return null;
            }
        }
    }
}
