
namespace InspectorManagementApplication.Pages.Controls;

public partial class StatusBadge : ContentView
{
    public static readonly BindableProperty StatusProperty =
        BindableProperty.Create(
            nameof(Status),
            typeof(string),
            typeof(StatusBadge),
            "Pending",
            propertyChanged: OnStatusChanged);

    public string Status
    {
        get => (string)GetValue(StatusProperty);
        set => SetValue(StatusProperty, value);
    }

    public StatusBadge()
    {
        InitializeComponent();
        UpdateBadge();
    }

    private static void OnStatusChanged(
        BindableObject bindable,
        object oldValue,
        object newValue)
    {
        if (bindable is StatusBadge badge)
        {
            badge.UpdateBadge();
        }
    }

    private void UpdateBadge()
    {
        StatusLabel.Text = Status;

        string resourceKey = Status switch
        {
            "Pending" => "StatusPending",
            "In Progress" => "StatusInProgress",
            "Completed" => "StatusCompleted",
            _ => "StatusPending"
        };

        if (Application.Current?.Resources.TryGetValue(
            resourceKey, out var color) == true && color is Color badgeColor)
        {
            BadgeBorder.BackgroundColor = badgeColor;
        }
    }
}
