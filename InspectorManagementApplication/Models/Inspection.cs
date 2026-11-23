
namespace InspectorManagementApplication.Models;

public class Inspection
{
    public int Id { get; set; }

    public string Title { get; set; } = string.Empty;

    public string SiteName { get; set; } = string.Empty;

    public string Status { get; set; } = string.Empty;

    public string Priority { get; set; } = string.Empty;

    public DateTime ScheduledOn { get; set; }

    public string InspectorName { get; set; } = string.Empty;

    public string Notes { get; set; } = string.Empty;
}
