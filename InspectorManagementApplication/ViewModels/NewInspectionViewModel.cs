
using InspectorManagementApplication.Commands;
using InspectorManagementApplication.Models;
using InspectorManagementApplication.Services;

namespace InspectorManagementApplication.ViewModels;

public class NewInspectionViewModel : BaseViewModel
{
    private string _title = string.Empty;
    private string _siteName = string.Empty;
    private string _status = string.Empty;
    private string _priority = string.Empty;
    private DateTime _scheduledOn = DateTime.Today;
    private string _inspectorName = string.Empty;
    private string _notes = string.Empty;

    public string Title
    {
        get => _title;
        set => SetProperty(ref _title, value);
    }

    public string SiteName
    {
        get => _siteName;
        set => SetProperty(ref _siteName, value);
    }

    public string Status
    {
        get => _status;
        set => SetProperty(ref _status, value);
    }

    public string Priority
    {
        get => _priority;
        set => SetProperty(ref _priority, value);
    }

    public DateTime ScheduledOn
    {
        get => _scheduledOn;
        set => SetProperty(ref _scheduledOn, value);
    }

    public string InspectorName
    {
        get => _inspectorName;
        set => SetProperty(ref _inspectorName, value);
    }

    public string Notes
    {
        get => _notes;
        set => SetProperty(ref _notes, value);
    }

    public bool HasChanges =>
        !string.IsNullOrWhiteSpace(Title) ||
        !string.IsNullOrWhiteSpace(SiteName) ||
        !string.IsNullOrWhiteSpace(Status) ||
        !string.IsNullOrWhiteSpace(Priority) ||
        ScheduledOn != DateTime.Today ||
        !string.IsNullOrWhiteSpace(InspectorName) ||
        !string.IsNullOrWhiteSpace(Notes);

    public event Action? InspectionSaved;
    public event Action? CancelRequested;

    public RelayCommand SaveCommand { get; }
    public RelayCommand CancelCommand { get; }

    public NewInspectionViewModel()
    {
        SaveCommand = new RelayCommand(Save);
        CancelCommand = new RelayCommand(
            () => CancelRequested?.Invoke());
    }

    private void Save()
    {
        var inspection = new Inspection
        {
            Title = Title,
            SiteName = SiteName,
            Status = Status,
            Priority = Priority,
            ScheduledOn = ScheduledOn,
            InspectorName = InspectorName,
            Notes = Notes
        };

        InspectionService.Instance.AddInspection(inspection);

        InspectionSaved?.Invoke();
    }
}
