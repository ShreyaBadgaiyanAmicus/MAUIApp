
using InspectorManagementApplication.ViewModels;

namespace InspectorManagementApplication.Views;

[QueryProperty(nameof(InspectionId), "inspectionId")]
public partial class InspectionDetailPage : ContentPage
{
    private int _inspectionId;

    public int InspectionId
    {
        get => _inspectionId;
        set
        {
            _inspectionId = value;

            BindingContext = new InspectionDetailViewModel(_inspectionId);
        }
    }

    public InspectionDetailPage()
    {
        InitializeComponent();
    }
}
