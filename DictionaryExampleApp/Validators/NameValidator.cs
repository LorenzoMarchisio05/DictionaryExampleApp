using System.Text.RegularExpressions;

namespace DictionaryExampleApp.Validators
{
    public static class NameValidator
    {
        private static readonly Regex _nameValidationRegex = new Regex(
            @"^[\p{L},.'-]{2,}$", 
            RegexOptions.Compiled | RegexOptions.IgnoreCase );

        public static bool Validate(string name)
        {
            return _nameValidationRegex.IsMatch(name);
        }
    }
}