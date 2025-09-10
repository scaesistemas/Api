using System.Collections.Generic;
using System.Linq;

namespace SCAE.Framework.Helper
{
    public class ListHelper
    {
        public static bool VerificarDuplicatas<T>(List<T> lista)
        {
            return lista.Count != lista.Distinct().Count();
        }
    }
}
