
using System.Globalization;

namespace InspectorManagementApplication.Converters;

public class DateToRelativeTextConverter : IValueConverter
{
    public object Convert(
        object? value,
        Type targetType,
        object? parameter,
        CultureInfo culture)
    {
        if (value is not DateTime date)
            return string.Empty;

        var difference = (date.Date - DateTime.Today).Days;

        return difference switch
        {
            0 => "Today",
            1 => "Tomorrow",
            -1 => "Yesterday",
            > 1 => $"In {difference} days",
            < -1 => $"{Math.Abs(difference)} days ago"
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
