using SCAE.Domain.Entities.Financeiro;
using SCAE.Domain.Models.Financeiro.Relatorio;
using System;

namespace SCAE.Domain.Models.ControleAgua;

public class MarcacaoAguaModel
{
    public int Id { get; set; }
    public string Lote { get; set; }
    public string Proprietario { get; set; }
    public int HidrometroId { get; set; }
    public string Hidrometro { get; set; }
    public DateTime DataAfericao { get; set; }
    public int LeituraAnterior { get; set; }
    public int LeituraFinal { get; set; }
    public int? ResponsavelId { get; set; }
    public string Responsavel { get; set; }
    public decimal Media { get; set; }
    public int Consumo { get; set; }
    public decimal Valor { get; set; }
    public bool Status { get; set; }
    public int? ParcelaId { get; set; }
    public ReceitaParcela? Parcela { get; set; }
    public string ProprietarioTelefone { get; set; }


}
