using Microsoft.EntityFrameworkCore;
using SCAE.Domain.Entities.Geral.ModuloPrefeitura;
using System.ComponentModel.DataAnnotations;

namespace SCAE.Domain.Entities.Shared
{
    [Owned]
    public class Moradia
    {
        public bool? PossuiDocumentacaoImovel { get; set; }
        public string TipoDocumentoImovel { get; set; }
        public int? NumeroComodos { get; set; }
        public int? NumeroFamiliasImovel { get; set; }
        public int? NumeroQuartos { get; set; } = 0;
        public int? NumeroBanheiros { get; set; }
        public bool? SituacaoRiscoImovel { get; set; }
        public Endereco Endereco { get; set; }
        public int? TipoMoradiaId { get; set; }
        public TipoMoradia TipoMoradia { get; set; }
        public int? TipoAbastecimentoAguaId { get; set; }
        public TipoAbastecimentoAgua TipoAbastecimentoAgua { get; set; }
        public int? TipoEnergiaMoradiaId { get; set; }
        public TipoEnergiaMoradia TipoEnergiaMoradia { get; set; }
        public int? TipoColetaLixoId { get; set; }
        public TipoColetaLixo TipoColetaLixo { get; set; }
        public int? TipoEsgotamentoSanitarioId { get; set; }
        public TipoEsgotamentoSanitario TipoEsgotamentoSanitario { get; set; }
        public int? TipoCondicaoMoradiaId { get; set; }
        public TipoCondicaoMoradia TipoCondicaoMoradia { get; set; }
        public int? TipoEdificacaoMoradiaId { get; set; }
        public TipoEdificacaoMoradia TipoEdificacaoMoradia { get; set; }
        public bool? PossuiEscoamentoSanitario { get; set; }
        public bool? PossuiCaixaDagua { get; set; }
        public int? NumeroOcupacoes { get; set; } = 0;
        public string IPTU { get; set; }
        public string FinalidadeImovel { get; set; }
        public decimal? AreaMetroQuadrado { get; set; }
        public string DominioImovel { get; set; }
        public string Edificacao { get; set; }
        public string FormaAquisicao { get; set; }
        public bool? BeneficiarioRegularizacaoFundiaria { get; set; }
        
    }
}
