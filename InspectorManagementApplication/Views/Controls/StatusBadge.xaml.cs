
namespace InspectorManagementApplication.Views.Controls;

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

        string backgroundKey;
        string textKey;

        switch (Status)
        {
            case "Pending":
                backgroundKey = "StatusPendingBackground";
                textKey = "StatusPending";
                break;

            case "In Progress":
                backgroundKey = "StatusInProgressBackground";
                textKey = "StatusInProgress";
                break;

            case "Completed":
                backgroundKey = "StatusCompletedBackground";
                textKey = "StatusCompleted";
                break;

            default:
                backgroundKey = "Gray200";
                textKey = "Gray600";
                break;
        }

        if (Application.Current?.Resources.TryGetValue(
            backgroundKey, out var background) == true &&
            background is Color backgroundColor)
        {
            BadgeBorder.BackgroundColor = backgroundColor;
        }

        if (Application.Current?.Resources.TryGetValue(
            textKey, out var text) == true &&
            text is Color textColor)
        {
            StatusLabel.TextColor = textColor;
        }
    }
}
