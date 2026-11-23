
using System.Collections.ObjectModel;
using System.Windows.Input;
using InspectorManagementApplication.Models;

namespace InspectorManagementApplication.ViewModels;

public class InspectionListViewModel : BaseViewModel
{
    private bool _isBusy;
    private bool _isCollectionViewVisible = true;
    private bool _isListViewVisible;
    private Inspection? _selectedInspection;

    public ObservableCollection<Inspection> Inspections { get; } = new();

    public bool IsBusy
    {
        get => _isBusy;
        set => SetProperty(ref _isBusy, value);
    }

    public bool IsCollectionViewVisible
    {
        get => _isCollectionViewVisible;
        set => SetProperty(ref _isCollectionViewVisible, value);
    }

    public bool IsListViewVisible
    {
        get => _isListViewVisible;
        set => SetProperty(ref _isListViewVisible, value);
    }

    public Inspection? SelectedInspection
    {
        get => _selectedInspection;
        set => SetProperty(ref _selectedInspection, value);
    }

    public ICommand ShowCollectionViewCommand { get; }
    public ICommand ShowListViewCommand { get; }
    public ICommand SelectInspectionCommand { get; }

    public InspectionListViewModel()
    {
        ShowCollectionViewCommand = new Command(ShowCollectionView);
        ShowListViewCommand = new Command(ShowListView);
        SelectInspectionCommand = new Command<Inspection>(SelectInspection);

        _ = LoadInspectionsAsync();
    }

    private void ShowCollectionView()
    {
        IsCollectionViewVisible = true;
        IsListViewVisible = false;
    }

    private void ShowListView()
    {
        IsCollectionViewVisible = false;
        IsListViewVisible = true;
    }

    private void SelectInspection(Inspection? inspection)
    {
        SelectedInspection = inspection;
    }

    public async Task LoadInspectionsAsync()
    {
        if (IsBusy)
            return;

        try
        {
            IsBusy = true;

            await Task.Delay(2000);

            var inspections = new List<Inspection>
            {
                new()
                {
                    Id = 1,
                    Title = "Safety Equipment Inspection",
                    SiteName = "Pune Industrial Site",
                    Status = "Pending",
                    Priority = "High",
                    ScheduledOn = new DateTime(2026, 11, 18)
                },
                new()
                {
                    Id = 2,
                    Title = "Building Maintenance Check",
                    SiteName = "Mumbai Office",
                    Status = "In Progress",
                    Priority = "Medium",
                    ScheduledOn = new DateTime(2026, 11, 18)
                },
                new()
                {
                    Id = 3,
                    Title = "Fire Safety Inspection",
                    SiteName = "Chennai Warehouse",
                    Status = "Completed",
                    Priority = "High",
                    ScheduledOn = new DateTime(2026, 11, 17)
                },
                new()
                {
                    Id = 4,
                    Title = "Electrical Systems Check",
                    SiteName = "Bengaluru Office",
                    Status = "Pending",
                    Priority = "Low",
                    ScheduledOn = new DateTime(2026, 11, 19)
                },
                new()
                {
                    Id = 5,
                    Title = "Quality Compliance Audit",
                    SiteName = "Hyderabad Facility",
                    Status = "In Progress",
                    Priority = "Medium",
                    ScheduledOn = new DateTime(2026, 11, 20)
                },
                new()
                {
                    Id = 6,
                    Title = "Fire Extinguisher Check",
                    SiteName = "Pune Warehouse",
                    Status = "Completed",
                    Priority = "High",
                    ScheduledOn = new DateTime(2026, 11, 16)
                },
                new()
                {
                    Id = 7,
                    Title = "Emergency Exit Inspection",
                    SiteName = "Mumbai Industrial Site",
                    Status = "Pending",
                    Priority = "High",
                    ScheduledOn = new DateTime(2026, 11, 21)
                },
                new()
                {
                    Id = 8,
                    Title = "Machinery Safety Audit",
                    SiteName = "Chennai Factory",
                    Status = "In Progress",
                    Priority = "Medium",
                    ScheduledOn = new DateTime(2026, 11, 22)
                },
                new()
                {
                    Id = 9,
                    Title = "Storage Area Inspection",
                    SiteName = "Bengaluru Warehouse",
                    Status = "Completed",
                    Priority = "Low",
                    ScheduledOn = new DateTime(2026, 11, 15)
                },
                new()
                {
                    Id = 10,
                    Title = "Electrical Wiring Inspection",
                    SiteName = "Hyderabad Office",
                    Status = "Pending",
                    Priority = "Medium",
                    ScheduledOn = new DateTime(2026, 11, 23)
                }
            };

            Inspections.Clear();

            foreach (var inspection in inspections)
            {
                Inspections.Add(inspection);
            }
        }
        finally
        {
            IsBusy = false;
        }
    }
}
