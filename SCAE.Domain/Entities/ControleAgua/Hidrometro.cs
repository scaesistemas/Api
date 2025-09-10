using SCAE.Domain.Entities.Clientes;
using SCAE.Domain.Entities.Empreendimento;
using SCAE.Domain.Entities.Financeiro;
using SCAE.Domain.Entities.Geral;
using SCAE.Domain.Interfaces.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace SCAE.Domain.Entities.ControleAgua;

[Table("hidrometro", Schema = "controleagua")]
public class Hidrometro : IEntity
{
    public int Id { get; set; }
    public string Codigo { get; set; }
    public string Descricao { get; set; }
    public int PessoaId { get; set; }
    public Pessoa Pessoa { get; set; }
    public string NumeroHidrometro { get; set; }
    public bool Ativo { get; set; }

    public int? ContratoId { get; set; }
    public Contrato Contrato { get; set; }
    public int? ReceitaId { get; set; }
    public Receita Receita { get; set; }
    public ICollection<MarcacaoAgua> Marcacoes { get; set; }
    public ICollection<HidrometroUnidade> Unidades { get; set; }


    public Hidrometro()
    {
        Unidades = new List<HidrometroUnidade>();
        Marcacoes = new List<MarcacaoAgua>();
    }
}

[Table("hidrometrounidade", Schema = "controleagua")]
public class HidrometroUnidade : IEntity
{
    public int Id { get; set; }
    public int HidrometroId { get; set; }
    public Hidrometro Hidrometro { get; set; }
    public int UnidadeId { get; set; }
    public Unidade Unidade { get; set; }


}
