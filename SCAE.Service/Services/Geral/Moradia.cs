using Microsoft.EntityFrameworkCore;
using SCAE.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCAE.Service.Services.Geral
{
    [Owned]
    public class Moradia
    {
        [StringLength(100)]public string FinalidadeImovel { get; set; }
        public bool PossuiImovel { get; set; }
        public int? QuantImovel { get; set; }
        [StringLength(100)]public string DominioImovel { get; set; }
        [StringLength(100)]public string AbastecimentoAgua { get; set; }
        public Decimal  AreaMetrosQuadrados { get; set; }
        [StringLength(100)] public string EnergiaEletrica { get; set; }
        [StringLength(100)] public string Edificacao { get; set; }
        public Endereco Endereco { get; set; }
        [StringLength(100)] public string FormaAquisicao { get; set; }
        [StringLength(100)]public string BeneficiadoRegularizacaoFundiaria { get; set; }
    }
}
