using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;

namespace GitHubUsersRepository.CustomValidators
{
    public class GithubUsernameAttribute : ValidationAttribute
    {
        //Validation message from Github for Usernames:
        //Username may only contain alphanumeric characters or single hyphens, and cannot begin or end with a hyphen.
        //Maximum is 39 characters
        protected override ValidationResult IsValid(
            object value, ValidationContext validationContext)
        {
            if (value == null)
            {
                return new ValidationResult("Please enter a Username");
            }

            //Trim the input string
            string input = value.ToString().Trim();

            //Check if input is Null Or Empty
            if (string.IsNullOrEmpty(input)) { return new ValidationResult("Please enter a Username"); }

            //Check input doesn't exceed 39 chars
            if (input.Count() > 39) { return new ValidationResult("Username cannot be longer than 39 characters"); }

            //Check input doesn't start or end with a hyphen
            if (input.StartsWith("-") || input.EndsWith("-")) { return new ValidationResult("Username cannot start nor end with a hyphen"); }

            //Use regex to check if more than a single hyphen has been used(one after the other)
            Match hyphensNextToEachOther = Regex.Match(input, @"(-)\1{1,}", RegexOptions.IgnoreCase);
            if (hyphensNextToEachOther.Success)
            {
                return new ValidationResult("Username can only have single hyphens");
            }

            //Check to see all chars are either letters, digits or hyphens
            if (input.All(x => char.IsLetterOrDigit(x) || x == '-'))
            {
                return ValidationResult.Success;
            }

            return ValidationResult.Success;
        }
    }
}