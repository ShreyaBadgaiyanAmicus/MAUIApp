
using InspectorManagementApplication.Models;
using InspectorManagementApplication.Services;

namespace InspectorManagementApplication.ViewModels;

public class InspectionDetailViewModel : BaseViewModel
{
    private Inspection? _inspection;

    public Inspection? Inspection
    {
        get => _inspection;
        set => SetProperty(ref _inspection, value);
    }

    public InspectionDetailViewModel(int inspectionId)
    {
        // Retrieve the selected inspection using its Id.
        Inspection = InspectionService.Instance.GetInspectionById(inspectionId);
    }
}
