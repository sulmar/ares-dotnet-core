using System;

namespace Ares.Extensions
{
    public static class DateTimeExtensions
    {
        public static new bool IsDaylightSavingTime(this DateTime dateTime)
        {
            return true;
        }

        public static bool IsWeekend(this DateTime dateTime)
        {
            return dateTime.DayOfWeek == DayOfWeek.Saturday ||
                 dateTime.DayOfWeek == DayOfWeek.Sunday;
        }

        public static DateTime AddWorkingDays(this DateTime dateTime, int days)
        {
            return dateTime.AddDays(days);
        }
    }


}
