using SCAE.Domain.Entities.Financeiro;
using SCAE.Domain.Entities.Geral;
using SCAE.Domain.Interfaces.Shared;
using System;
using System.ComponentModel.DataAnnotations.Schema;


namespace SCAE.Domain.Entities.ControleAgua
{
    [Table("marcacaoagua", Schema = "controleagua")]
    public class MarcacaoAgua : IEntity
    {
        public int Id { get; set; }
        public DateTime DataAfericao { get; set; }
        public int HidrometroId { get; set; }
        public Hidrometro Hidrometro { get; set;} 
        public int Leitura {  get; set; }
        public int ResponsavelId { get; set; }
        public Usuario Responsavel { get; set; }
        public int Consumo { get; set; }
        public decimal Valor {  get; set; }

        public int? ParcelaId {  get; set; }
        public ReceitaParcela Parcela { get; set; }

    }
}
