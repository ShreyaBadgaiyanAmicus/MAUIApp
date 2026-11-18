
using InspectorManagementApplication.Pages;

namespace InspectorManagementApplication
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(
                nameof(InspectorProfilePage),
                typeof(InspectorProfilePage)
            );

            Routing.RegisterRoute(
            nameof(InspectionListPage),
            typeof(InspectionListPage));
        }
    }
}
