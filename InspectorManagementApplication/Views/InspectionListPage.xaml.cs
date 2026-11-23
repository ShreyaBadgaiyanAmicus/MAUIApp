
using InspectorManagementApplication.ViewModels;

namespace InspectorManagementApplication.Views;

public partial class InspectionListPage : ContentPage
{
    public InspectionListPage()
    {
        InitializeComponent();
        BindingContext = new InspectionListViewModel();
    }
}
