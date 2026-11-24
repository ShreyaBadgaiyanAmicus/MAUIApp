
using System.ComponentModel;
using InspectorManagementApplication.ViewModels;

namespace InspectorManagementApplication.Views;

public partial class LoginPage : ContentPage
{
    private readonly LoginViewModel _viewModel;

    public LoginPage()
    {
        InitializeComponent();

        _viewModel = new LoginViewModel();
        _viewModel.PropertyChanged += OnViewModelPropertyChanged;

        BindingContext = _viewModel;
    }

    private void OnViewModelPropertyChanged(
        object? sender,
        PropertyChangedEventArgs e)
    {
        if (e.PropertyName == nameof(LoginViewModel.LoginMessage) &&
            _viewModel.LoginMessage == "Login successful!")
        {
            _viewModel.PropertyChanged -= OnViewModelPropertyChanged;

            var window = Application.Current?.Windows.FirstOrDefault();

            if (window != null)
            {
                window.Page = new AppShell();
            }
        }
    }
}
