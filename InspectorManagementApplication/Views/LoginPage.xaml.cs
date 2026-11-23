
using InspectorManagementApplication.ViewModels;

namespace InspectorManagementApplication.Views;

public partial class LoginPage : ContentPage
{
    private readonly LoginViewModel _viewModel;

    public LoginPage()
    {
        InitializeComponent();

        _viewModel = new LoginViewModel();
        BindingContext = _viewModel;
    }

    private void OnLoginClicked(object sender, EventArgs e)
    {
        _viewModel.Login();
    }
}
