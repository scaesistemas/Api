using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCAE.Framework.Helper
{
    //Classe para acumular soluções recorrentes de StringBuilder no sistema
    public class StringBuilderHelper
    {
        public static StringBuilder AcoplarFalhasImportacao(StringBuilder textoRetornoPrincipal, StringBuilder textoRetornoFalhas) 
        {
            textoRetornoPrincipal.AppendLine($"<br><b>---------------------------------FALHAS---------------------------------</b><br>");
            textoRetornoPrincipal.Append(textoRetornoFalhas);
            textoRetornoPrincipal.AppendLine($"<br><b>---------------------------------FALHAS---------------------------------</b><br>");
            return textoRetornoPrincipal;
        }
    }
}
