
using InspectorManagementApplication.Models;

namespace InspectorManagementApplication.Pages;

public partial class InspectionListPage : ContentPage
{
    private Border? _selectedListCard;

    public InspectionListPage()
    {
        InitializeComponent();

        var inspections = new List<Inspection>
        {
            new()
            {
                Title = "Safety Equipment Inspection",
                Site = "Pune Industrial Site",
                Status = "Pending",
                Priority = "High",
                ScheduledDate = new DateTime(2026, 11, 18)
            },
            new()
            {
                Title = "Building Maintenance Check",
                Site = "Mumbai Office",
                Status = "In Progress",
                Priority = "Medium",
                ScheduledDate = new DateTime(2026, 11, 18)
            },
            new()
            {
                Title = "Fire Safety Inspection",
                Site = "Chennai Warehouse",
                Status = "Completed",
                Priority = "High",
                ScheduledDate = new DateTime(2026, 11, 17)
            },
            new()
            {
                Title = "Electrical Systems Check",
                Site = "Bengaluru Office",
                Status = "Pending",
                Priority = "Low",
                ScheduledDate = new DateTime(2026, 11, 19)
            },
            new()
            {
                Title = "Quality Compliance Audit",
                Site = "Hyderabad Facility",
                Status = "In Progress",
                Priority = "Medium",
                ScheduledDate = new DateTime(2026, 11, 20)
            },
            new()
            {
                Title = "Fire Extinguisher Check",
                Site = "Pune Warehouse",
                Status = "Completed",
                Priority = "High",
                ScheduledDate = new DateTime(2026, 11, 16)
            },
            new()
            {
                Title = "Emergency Exit Inspection",
                Site = "Mumbai Industrial Site",
                Status = "Pending",
                Priority = "High",
                ScheduledDate = new DateTime(2026, 11, 21)
            },
            new()
            {
                Title = "Machinery Safety Audit",
                Site = "Chennai Factory",
                Status = "In Progress",
                Priority = "Medium",
                ScheduledDate = new DateTime(2026, 11, 22)
            },
            new()
            {
                Title = "Storage Area Inspection",
                Site = "Bengaluru Warehouse",
                Status = "Completed",
                Priority = "Low",
                ScheduledDate = new DateTime(2026, 11, 15)
            },
            new()
            {
                Title = "Electrical Wiring Inspection",
                Site = "Hyderabad Office",
                Status = "Pending",
                Priority = "Medium",
                ScheduledDate = new DateTime(2026, 11, 23)
            }
        };

        InspectionsCollectionView.ItemsSource = inspections;
        InspectionsListView.ItemsSource = inspections;
    }

    private void OnCollectionViewClicked(object? sender, EventArgs e)
    {
        InspectionsCollectionView.IsVisible = true;
        InspectionsListView.IsVisible = false;

        CollectionViewButton.BackgroundColor =
            (Color)Application.Current!.Resources["Primary"];

        CollectionViewButton.TextColor =
            (Color)Application.Current.Resources["White"];

        ListViewButton.BackgroundColor =
            (Color)Application.Current.Resources["Gray200"];

        ListViewButton.TextColor =
            (Color)Application.Current.Resources["Primary"];
    }

    private void OnListViewClicked(object? sender, EventArgs e)
    {
        InspectionsCollectionView.IsVisible = false;
        InspectionsListView.IsVisible = true;

        ListViewButton.BackgroundColor =
            (Color)Application.Current!.Resources["Primary"];

        ListViewButton.TextColor =
            (Color)Application.Current.Resources["White"];

        CollectionViewButton.BackgroundColor =
            (Color)Application.Current.Resources["Gray200"];

        CollectionViewButton.TextColor =
            (Color)Application.Current.Resources["Primary"];
    }

    private void OnListInspectionTapped(object? sender, TappedEventArgs e)
    {
        if (sender is not Border selectedCard)
            return;

        // Reset previously selected card
        if (_selectedListCard != null)
        {
            _selectedListCard.BackgroundColor =
                (Color)Application.Current!.Resources["White"];

            _selectedListCard.Stroke =
                (Color)Application.Current.Resources["Gray200"];
        }

        // Highlight newly selected card
        selectedCard.BackgroundColor =
            (Color)Application.Current!.Resources["SelectedItemBackground"];

        selectedCard.Stroke =
            (Color)Application.Current.Resources["Primary"];

        _selectedListCard = selectedCard;
    }
}
