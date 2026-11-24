
using System.Collections.ObjectModel;
using System.Windows.Input;
using InspectorManagementApplication.Commands;
using InspectorManagementApplication.Models;
using InspectorManagementApplication.Services;

namespace InspectorManagementApplication.ViewModels;

public class InspectionListViewModel : BaseViewModel
{
    private bool _isBusy;
    private bool _isCollectionViewVisible = true;
    private bool _isListViewVisible;
    private bool _hasInspections;
    private Inspection? _selectedInspection;
    private string _searchText = string.Empty;

    // Stores the complete inspection list.
    private List<Inspection> _allInspections = new();

    // Stores the inspections currently displayed.
    public ObservableCollection<Inspection> Inspections { get; } = new();

    public AsyncRelayCommand LoadInspectionsCommand { get; }

    public bool IsBusy
    {
        get => _isBusy;
        set
        {
            if (SetProperty(ref _isBusy, value))
            {
                LoadInspectionsCommand.NotifyCanExecuteChanged();
            }
        }
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

    public bool HasInspections
    {
        get => _hasInspections;
        set => SetProperty(ref _hasInspections, value);
    }

    public Inspection? SelectedInspection
    {
        get => _selectedInspection;
        set => SetProperty(ref _selectedInspection, value);
    }

    public string SearchText
    {
        get => _searchText;
        set
        {
            if (SetProperty(ref _searchText, value))
            {
                ApplyFilter();
            }
        }
    }

    public ICommand ShowCollectionViewCommand { get; }
    public ICommand ShowListViewCommand { get; }
    public ICommand SelectInspectionCommand { get; }

    public InspectionListViewModel()
    {
        LoadInspectionsCommand = new AsyncRelayCommand(
            LoadInspectionsAsync,
            () => !IsBusy);

        ShowCollectionViewCommand = new Command(ShowCollectionView);
        ShowListViewCommand = new Command(ShowListView);
        SelectInspectionCommand = new Command<Inspection>(SelectInspection);

        // Load inspections through AsyncRelayCommand.
        LoadInspectionsCommand.Execute(null);
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

    // Filters inspections whenever SearchText changes.
    private void ApplyFilter()
    {
        var filteredInspections = _allInspections
            .Where(inspection =>
                inspection.Title.Contains(SearchText, StringComparison.OrdinalIgnoreCase) ||
                inspection.SiteName.Contains(SearchText, StringComparison.OrdinalIgnoreCase) ||
                inspection.Status.Contains(SearchText, StringComparison.OrdinalIgnoreCase) ||
                inspection.Priority.Contains(SearchText, StringComparison.OrdinalIgnoreCase) ||
                inspection.InspectorName.Contains(SearchText, StringComparison.OrdinalIgnoreCase))
            .ToList();

        Inspections.Clear();

        // Tracks whether the filtered collection contains records.
        HasInspections = filteredInspections.Count > 0;

        foreach (var inspection in filteredInspections)
        {
            Inspections.Add(inspection);
        }
    }

    public async Task LoadInspectionsAsync()
    {
        try
        {
            IsBusy = true;

            await Task.Delay(2000);

            // Get all inspections from the shared service.
            _allInspections = InspectionService.Instance.GetAllInspections();

            // Apply the current search filter.
            ApplyFilter();
        }
        finally
        {
            IsBusy = false;
        }
    }
}
