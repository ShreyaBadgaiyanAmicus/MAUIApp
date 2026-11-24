
using InspectorManagementApplication.Models;
using InspectorManagementApplication.ViewModels;

namespace InspectorManagementApplication.Views;

public partial class InspectionListPage : ContentPage
{
    public InspectionListViewModel ViewModel { get; }

    public InspectionListPage()
    {
        InitializeComponent();

        ViewModel = new InspectionListViewModel();
        BindingContext = ViewModel;
    }

    // CollectionView selection handler.
    private async void OnInspectionSelectionChanged(
        object? sender,
        SelectionChangedEventArgs e)
    {
        var selectedInspection =
            e.CurrentSelection.FirstOrDefault() as Inspection;

        if (selectedInspection == null)
            return;

        ViewModel.SelectedInspection = selectedInspection;

        await NavigateToDetails(selectedInspection);
    }

    // ListView tap handler.
    private async void OnInspectionTapped(
        object? sender,
        TappedEventArgs e)
    {
        if (sender is not BindableObject bindable ||
            bindable.BindingContext is not Inspection selectedInspection)
        {
            return;
        }

        ViewModel.SelectedInspection = selectedInspection;

        await NavigateToDetails(selectedInspection);
    }

    // Navigate to inspection details.
    private async Task NavigateToDetails(Inspection inspection)
    {
        await Shell.Current.GoToAsync(
            $"{nameof(InspectionDetailPage)}?inspectionId={inspection.Id}");
    }

    // Open New Inspection as a modal.
    private async void OnNewInspectionClicked(
        object? sender,
        EventArgs e)
    {
        await Navigation.PushModalAsync(
            new NewInspectionPage());
    }
}
