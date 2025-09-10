using System.Collections.Generic;

namespace SCAE.Migracao.Models
{
    public class ResultData
    {
        public List<ResultId> Items { get; set; }
    }

    public class ResultId
    {
        public int Id { get; set; }
    }
}
