
using InspectorManagementApplication.Models;

namespace InspectorManagementApplication.Services;

public class InspectionService
{
    public static InspectionService Instance { get; } = new();

    private readonly List<Inspection> _inspections = new()
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

    public List<Inspection> GetAllInspections()
    {
        return _inspections;
    }

    public Inspection? GetInspectionById(int id)
    {
        return _inspections.FirstOrDefault(
            inspection => inspection.Id == id);
    }

    public void AddInspection(Inspection inspection)
    {
        inspection.Id = _inspections.Max(item => item.Id) + 1;

        _inspections.Add(inspection);
    }
}
