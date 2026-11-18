
namespace InspectorManagementApplication.Models;

public class Inspection
{
    public string Title { get; set; } = string.Empty;

    public string Site { get; set; } = string.Empty;

    public string Status { get; set; } = string.Empty;

    public string Priority { get; set; } = string.Empty;

    public DateTime ScheduledDate { get; set; }
}
