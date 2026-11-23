
using InspectorManagementApplication.Views;

namespace InspectorManagementApplication.Views;

public partial class DashboardPage : ContentPage
{
    public DashboardPage()
    {
        InitializeComponent();
    }

    private async void OnProfileClicked(object? sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(InspectorProfilePage));
    }

    private async void OnShowAllClicked(object? sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(InspectionListPage));
    }
}
