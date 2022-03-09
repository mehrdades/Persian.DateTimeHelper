using System;

namespace Persian.DateTimeHelper
{
    public static class PersianDayOfWeek
    {
        public const string Saturday = "شنبه";
        public const string Sunday = "يکشنبه";
        public const string Monday = "دوشنبه";
        public const string Tuesday = "سه شنبه";
        public const string Wednesday = "چهارشنبه";
        public const string Thursday = "پنجشنبه";
        public const string Friday = "جمعه";
        public static string GetPersianDayOfWeek(DayOfWeek dayOfWeek)
        {
            switch (dayOfWeek)
            {
                case DayOfWeek.Friday:
                    return Friday;
                case DayOfWeek.Monday:
                    return Monday;
                case DayOfWeek.Saturday:
                    return Saturday;
                case DayOfWeek.Sunday:
                    return Sunday;
                case DayOfWeek.Thursday:
                    return Thursday;
                case DayOfWeek.Tuesday:
                    return Tuesday;
                case DayOfWeek.Wednesday:
                    return Wednesday;
                default:
                    throw new Exception("Not valid date time!");
            }
        }
    }
}
}
