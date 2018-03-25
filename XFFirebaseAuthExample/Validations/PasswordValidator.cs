using XFFirebaseAuthExample.ViewModels;

namespace XFFirebaseAuthExample
{
    public class PasswordValidator : IValidationRule<string>
    {
        const int minLength = 6;
        public string Description => $"Password should at least {minLength} characters long.";
        public bool Validate(string value) => !string.IsNullOrEmpty(value) && value.Length >= minLength;
    }
}
