
using System.Text.RegularExpressions;

namespace InspectorManagementApplication.ViewModels;

public class LoginViewModel : BaseViewModel
{
    private const string ValidEmail = "admin@example.com";
    private const string ValidPassword = "Admin@123";

    private string _email = string.Empty;
    private string _password = string.Empty;
    private string _emailError = string.Empty;
    private string _passwordError = string.Empty;
    private string _loginMessage = string.Empty;

    public string Email
    {
        get => _email;
        set
        {
            if (SetProperty(ref _email, value))
            {
                ValidateEmail();
                LoginMessage = string.Empty;
            }
        }
    }

    public string Password
    {
        get => _password;
        set
        {
            if (SetProperty(ref _password, value))
            {
                ValidatePassword();
                LoginMessage = string.Empty;
            }
        }
    }

    public string EmailError
    {
        get => _emailError;
        set => SetProperty(ref _emailError, value);
    }

    public string PasswordError
    {
        get => _passwordError;
        set => SetProperty(ref _passwordError, value);
    }

    public string LoginMessage
    {
        get => _loginMessage;
        set
        {
            if (SetProperty(ref _loginMessage, value))
                OnPropertyChanged(nameof(LoginMessageColor));
        }
    }

    public Color LoginMessageColor =>
        LoginMessage == "Login successful!"
            ? Colors.Green
            : Colors.Red;

    public bool IsLoginEnabled =>
        string.IsNullOrEmpty(EmailError) &&
        string.IsNullOrEmpty(PasswordError) &&
        !string.IsNullOrWhiteSpace(Email) &&
        !string.IsNullOrWhiteSpace(Password);

    private void ValidateEmail()
    {
        EmailError = string.IsNullOrWhiteSpace(Email) ||
                     !Regex.IsMatch(
                         Email,
                         @"^[^@\s]+@[^@\s]+\.[^@\s]+$")
            ? "Please enter a valid email address."
            : string.Empty;

        OnPropertyChanged(nameof(IsLoginEnabled));
    }

    private void ValidatePassword()
    {
        PasswordError = Password.Length < 8
            ? "Password must be at least 8 characters."
            : string.Empty;

        OnPropertyChanged(nameof(IsLoginEnabled));
    }

    public void Login()
    {
        if (!IsLoginEnabled)
            return;

        LoginMessage =
            Email == ValidEmail && Password == ValidPassword
                ? "Login successful!"
                : "Invalid email or password.";
    }
}
