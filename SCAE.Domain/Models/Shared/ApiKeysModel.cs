using System.Collections.Generic;

namespace SCAE.Domain.Models.Shared
{
    public class ApiKeysContainerModel
    {
        public List<ApiKeys> ApiKeys { get; set; }
    }

    public class ApiKeys
    {
        public string Nome { get; set; }
        public string Chave { get; set; }
    }
}
