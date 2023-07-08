# UseCase10
Compose regular expressions to efficiently search, match, and manipulate text patterns.

This library exposes a single method called `IsValidString`. It takes two parameters: `input` of type string and `maxLength` of type int. 
The function is responsible for validating whether the input string meets specific criteria: have at least one lowercase letter, one uppercase letter, one digit, one special character, no whitespaces (tabulations, line endings, or carriage return), and a length between 1 and maxLength.

It also does parameter validation: if the `input` is null or empty or the `maxLength` is 0 or negative, the function returns false indicating invalid input.

The function then constructs a regular expression pattern using the maxLength parameter. The pattern is explained as follows:

`^`: Matches the start of the line.

`(?=.*[a-z])`: Positive lookahead. Ensures that at least one lowercase letter exists.

`(?=.*[A-Z])`: Positive lookahead. Ensures that at least one uppercase letter exists.

`(?=.*\d)`: Positive lookahead. Ensures that at least one digit exists.

`(?=.*[!"#$%&'()*+,-./:;<=>?@[\]^_{|}~])`: Positive lookahead. Ensures that at least one special character exists (the special characters are within the square brackets).

`(?!.*\s)`: Negative lookahead. Ensures that no whitespace character exists.

`.{1,maxLength}$`: Matches any input with a length from 1 to maxLength until the end of the line.

The constructed regular expression pattern is then used with `Regex.IsMatch` to validate the input string.

If the input string matches the pattern, the function returns true, indicating that the string is valid according to the specified criteria. Otherwise, it returns false.