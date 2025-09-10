using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace SCAE.Domain.Models.Geral;

public class LogModel<T>
{
    public string Nome;
    public int SucessosCount => SucessoLista?.Count ?? 0;
    public List<T> SucessoLista = new List<T>();
    public int FalhasCount => FalhaLista?.Count ?? 0;
    public List<T> FalhaLista = new List<T>();
    public int FaltantesCount => FaltanteLista?.Count ?? 0;
    public List<T> FaltanteLista = new List<T>();

    public int LogCount => LogLista?.Count ?? 0;
    public List<string> LogLista = new List<string>();

    public bool ProcessoCancelado = false;
    public string MotivoCancelamento;

    public LogModel(string nome)
    {
        Nome = nome;
    }
}

