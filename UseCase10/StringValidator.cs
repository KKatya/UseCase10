using System.Text.RegularExpressions;

namespace UseCase10;

public static class StringValidator
{
    public static bool IsValidString(string input, int maxLength)
    {
        // Validate input parameters
        if (input is null || maxLength <= 0)
        {
            return false;
        }

        // Regular expression pattern:
        // 1. ^                     : start of the line
        // 2. (?=.*[a-z])           : positive lookahead, ensure at least one lower case letter exists
        // 3. (?=.*[A-Z])           : positive lookahead, ensure at least one upper case letter exists
        // 4. (?=.*\d)              : positive lookahead, ensure at least one digit exists
        // 5. (?=.*[!""#$%&'()*+,-./:;<=>?@\\[\\]^_`{|}~]) : positive lookahead, ensure at least one special character exists
        // 6. (?!.*\s)              : negative lookahead, ensure no whitespace character exists
        // 7. .{1,maxLength}$       : match anything with length from 1 to maxLength till the end of the line
        string pattern = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[!""#$%&'()*+,-./:;<=>?@[\]^_`{|}~])(?!.*\s).{1," + maxLength + @"}$";

        // Validate the string against the regular expression
        return Regex.IsMatch(input, pattern);
    }
}