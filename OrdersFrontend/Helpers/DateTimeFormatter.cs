namespace OrdersFrontend.Helpers;

public static class DateTimeFormatter
{
    public static string ToShortDate(DateTime dateTime)
    {
        return dateTime.ToString("yyyy-MM-dd");
    }
}
