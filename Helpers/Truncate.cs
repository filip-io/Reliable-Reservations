namespace Reliable_Reservations.Helpers
{
    public static class Truncate
    {
        public static DateTime TruncateToMinutes(DateTime dateTime)
        {
            return new DateTime(dateTime.Year, dateTime.Month, dateTime.Day, dateTime.Hour, dateTime.Minute, 0);
        }
    }
}