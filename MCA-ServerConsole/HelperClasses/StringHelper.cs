using System.Text.RegularExpressions;

namespace MCA_ServerConsole.HelperClasses
{
    internal class StringHelper
    {
        public static string CutTillLastPart(string text, string pattern = " ")
        {
            return text.Split(pattern)[^1];
        }

        public static string NormalizeCaseing(string text)
        {
            return text[0].ToString().ToUpper() + text.Remove(0, 1).ToLower();
        }

        public static bool IsValidIPv4(string ipAddress)
        {
            string pattern = @"^(25[0-5]|2[0-4][0-9]|1[0-9][0-9]|[1-9]?[0-9])(\.(25[0-5]|2[0-4][0-9]|1[0-9][0-9]|[1-9]?[0-9])){3}$";
            return Regex.IsMatch(ipAddress, pattern);
        }
    }
}