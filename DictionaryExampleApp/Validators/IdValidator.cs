using System.Text.RegularExpressions;

namespace DictionaryExampleApp.Validators
{
    public static class IdValidator
    {
        private static readonly Regex _idValidationRegex = new Regex(
            "[1-5]{1}[a-z]{1}", 
            RegexOptions.Compiled | RegexOptions.IgnoreCase);

        public static bool Validate(string id)
        {
            return _idValidationRegex.IsMatch(id);
        }
    }
}