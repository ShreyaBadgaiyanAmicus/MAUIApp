
using InspectorManagementApplication.ViewModels;

namespace InspectorManagementApplication.Views;

public partial class NewInspectionPage : ContentPage
{
    private readonly NewInspectionViewModel _viewModel;

    public NewInspectionPage()
    {
        InitializeComponent();

        _viewModel = new NewInspectionViewModel();
        BindingContext = _viewModel;

        _viewModel.InspectionSaved += OnInspectionSaved;
        _viewModel.CancelRequested += OnCancelRequested;
    }

    private async void OnInspectionSaved()
    {
        await CloseModalAsync();
    }

    private async void OnCancelRequested()
    {
        if (_viewModel.HasChanges)
        {
            bool discard = await DisplayAlert(
                "Discard Changes?",
                "You have entered inspection details. Are you sure you want to discard them?",
                "Discard",
                "Keep Editing");

            if (!discard)
                return;
        }

        await CloseModalAsync();
    }

    private async Task CloseModalAsync()
    {
        _viewModel.InspectionSaved -= OnInspectionSaved;
        _viewModel.CancelRequested -= OnCancelRequested;

        await Navigation.PopModalAsync();
    }
}
