using System;

namespace SCAE.Framework.Domain
{
    public interface IJsonResponse
    {
        int Id { get; set; }
        bool Success { get; set; }
        bool Alert { get; set; }
        string Message { get; set; }
        string Url { get; set; }
        long Count { get; set; }

        void SetAviso(string mensagem);
        void SetSucesso(string mensagem);
        void SetSucessoOperacao(int id = 0);
        void SetSucessoConsulta(object objeto);
        void SetErro(string mensagem);
    }

    [Serializable]
    public class JsonResponse<T> : IJsonResponse
    {
        public int Id { get; set; }
        public bool Success { get; set; }
        public bool Alert { get; set; }
        public string Message { get; set; }
        public string Url { get; set; }
        public long Count { get; set; }
        public T Obj { get; set; }

        public void SetAviso(string mensagem)
        {
            LimparDados();
            Message = mensagem;
            Alert = true;
        }

        public void SetSucesso(string mensagem)
        {
            LimparDados();
            Message = mensagem;
            Success = true;
        }

        public void SetSucessoOperacao(int id = 0)
        {
            LimparDados();
            Message = "Operação realizada com sucesso!";
            Success = true;
            Id = id;
        }

        public void SetSucessoConsulta(object objeto)
        {
            SetSucessoConsulta((T)objeto);
        }

        public void SetSucessoConsulta(T objeto)
        {
            LimparDados();
            Message = "Consulta realizada com sucesso!";
            Success = true;
            Obj = objeto;
        }

        public void SetErro(string mensagem)
        {
            LimparDados();
            Message = $"Algum erro o ocorreu! {mensagem}";
            Success = false;
        }

        private void LimparDados()
        {
            Message = string.Empty;
            Success = false;
            Alert = false;
            Id = 0;
            Count = 0;
            //Obj = null;
        }
    }
}
