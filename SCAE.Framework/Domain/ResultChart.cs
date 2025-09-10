using System.Collections.Generic;

namespace SCAE.Framework.Domain
{
    public class ResultChart
    {
        public List<string> Legendas { get; set; }
        public List<ResultNameValue> Dados { get; set; }

        public ResultChart()
        {
            Legendas = new List<string>();
            Dados = new List<ResultNameValue>();
        }

        public void SetDados(List<KeyValuePair<string, decimal?>> dados)
        {
            Dados.Clear();
            Legendas.Clear();

            dados.ForEach(x => Dados.Add(new ResultNameValue(x.Key, x.Value)));
            Dados.ForEach(x => Legendas.Add(x.Name));
        }

        public class ResultNameValue
        {
            public string Name { get; set; }
            public decimal? Value { get; set; }

            public ResultNameValue(string name, decimal? value)
            {
                Name = name;
                Value = value;
            }
        }
        
    }


}
