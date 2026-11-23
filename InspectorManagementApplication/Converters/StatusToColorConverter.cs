
using System.Globalization;

namespace InspectorManagementApplication.Converters;

public class StatusToColorConverter : IValueConverter
{
    public object Convert(
        object? value,
        Type targetType,
        object? parameter,
        CultureInfo culture)
    {
        if (value is not string status)
            return Colors.Gray;

        return status switch
        {
            "Pending" => Colors.Orange,
            "In Progress" => Colors.DodgerBlue,
            "Completed" => Colors.ForestGreen,
            _ => Colors.Gray
        };
    }

    public object ConvertBack(
        object? value,
        Type targetType,
        object? parameter,
        CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}
