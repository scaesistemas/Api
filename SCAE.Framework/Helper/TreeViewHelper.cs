using System.Text.RegularExpressions;

namespace SCAE.Framework.Helper
{
    public class TreeViewHelper
    {
        public static string PadNumbers(string input)
        {
            return string.IsNullOrEmpty(input) ? string.Empty : Regex.Replace(input, "[0-9]+", match => match.Value.PadLeft(10, '0'));
        }
    }
}
