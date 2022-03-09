using System;
using System.Globalization;

namespace Persian.DateTimeHelper
{
    public static class Extensions
    {
        #region Private Member

        private static PersianCalendar _persianCalendar;

        private const string DefaultDateSeparator = "/";

        #endregion

        #region Constructor

        static Extensions()
        {
            _persianCalendar = new PersianCalendar();

        }

        #endregion

        #region Public Method

        public static string ToShamsiDate(this DateTime datetime, string dateSeparator)
        {
            try
            {
                string shamsiDate = string.Empty;

                PersianCalendar pc = new PersianCalendar();
                int year = pc.GetYear(datetime);
                int month = pc.GetMonth(datetime);
                int day = pc.GetDayOfMonth(datetime);

                shamsiDate = String.Format("{1:0000}{0}{2:00}{0}{3:00}",
                    dateSeparator,
                    year, month, day);

                return shamsiDate;
            }
            catch (Exception exp)
            {
                return string.Empty;
            }
        }
        public static string ToShamsiDate(this DateTime datetime)
        {
            return ToShamsiDate(datetime, DefaultDateSeparator);
        }
        public static string ToShamsiDate(this DateTime datetime, bool withPersianMounth)
        {
            try
            {
                string shamsiDate = string.Empty;

                PersianCalendar pc = new PersianCalendar();

                int year = pc.GetYear(datetime);

                int month = pc.GetMonth(datetime);

                int day = pc.GetDayOfMonth(datetime);

                if (withPersianMounth)
                    return day.ToString() + " " + PersianMonth.GetPersianMonthName(month) + " " + year.ToString();
                else
                    return ToShamsiDate(datetime, DefaultDateSeparator);
            }
            catch
            {
                return string.Empty;
            }
        }
        public static string GetPersianMonthName(this DateTime datetime)
        {
            var month = GetPersianMonth(datetime);
            return PersianMonth.GetPersianMonthName(month);
        }
        public static string GetPersianDayOfWeek(this DateTime datetime)
        {
            PersianCalendar pc = new PersianCalendar();
            var dayOfWeek = pc.GetDayOfWeek(datetime);
            return PersianDayOfWeek.GetPersianDayOfWeek(dayOfWeek);
        }
        public static int GetPersianMonth(this DateTime datetime)
        {
            PersianCalendar pc = new PersianCalendar();
            int month = pc.GetMonth(datetime);
            return month;
        }
        public static int GetPersianYear(this DateTime datetime)
        {
            PersianCalendar pc = new PersianCalendar();
            int year = pc.GetYear(datetime);
            return year;
        }
        public static int GetPersianDayOfMonth(this DateTime datetime)
        {
            PersianCalendar pc = new PersianCalendar();
            int dayOfMonth = pc.GetDayOfMonth(datetime);
            return dayOfMonth;
        }
        public static int GetPersianDayOfYear(this DateTime datetime)
        {
            PersianCalendar pc = new PersianCalendar();
            int dayOfYear = pc.GetDayOfYear(datetime);
            return dayOfYear;
        }
        public static int GetPersianDaysInYear(this DateTime datetime, int persianYear)
        {
            PersianCalendar pc = new PersianCalendar();
            int dayInYear = pc.GetDaysInYear(persianYear);
            return dayInYear;
        }
        public static int GetPersianWeekOfYear(this DateTime datetime, CalendarWeekRule weekRule, DayOfWeek dayOfWeek)
        {
            PersianCalendar pc = new PersianCalendar();
            var year = pc.GetYear(datetime);
            int weekOfYear = pc.GetWeekOfYear(datetime, weekRule, dayOfWeek);
            return weekOfYear;
        }
        public static int GetPersianWeekOfMonth(this DateTime value)
        {
            var result = 1;

            var monthDays = value.GetPersianDaysInMonth();
            var firstDayOfWeekOfMonth = value.GetPersianFirstDateOfMonth().DayOfWeek;
            var persianDayOfMonth = _persianCalendar.GetDayOfMonth(value);

            result += persianDayOfMonth / 7;

            return result;
        }
        public static DateTime GetPersianFirstDateOfMonth(this DateTime value)
        {
            return new DateTime(_persianCalendar.GetYear(value), _persianCalendar.GetMonth(value), 1, _persianCalendar);
        }
        public static int GetPersianDaysInMonth(this DateTime datetime, int persianYear, int month)
        {
            PersianCalendar pc = new PersianCalendar();
            int daysInMonth = pc.GetDaysInMonth(persianYear, month);
            return daysInMonth;
        }
        public static int GetPersianDaysInMonth(this DateTime datetime)
        {
            PersianCalendar pc = new PersianCalendar();
            int daysInMonth = pc.GetDaysInMonth(pc.GetYear(datetime), pc.GetMonth(datetime));
            return daysInMonth;
        }
        public static bool IsPersianLeapYear(this DateTime datetime, int persianYear)
        {
            PersianCalendar pc = new PersianCalendar();
            return pc.IsLeapYear(persianYear);
        }
        public static bool IsPersianLeapYear(this DateTime datetime)
        {
            PersianCalendar pc = new PersianCalendar();
            int year = pc.GetYear(datetime);
            return pc.IsLeapYear(year);
        }
        public static bool IsPersianLeapMonth(this DateTime datetime, int persianYear, int persianMonth)
        {
            PersianCalendar pc = new PersianCalendar();
            return pc.IsLeapMonth(persianYear, persianMonth);
        }
        public static bool IsPersianLeapMonth(this DateTime datetime)
        {
            PersianCalendar pc = new PersianCalendar();
            int year = pc.GetYear(datetime);
            int month = pc.GetMonth(datetime);
            return pc.IsLeapMonth(year, month);
        }
        public static DateTime GetDateTimeFromShamsiDate(this DateTime datetime, string strShamsiDate, string dateSeparator)
        {
            return DateTimeHelper.GetDateTimeFromShamsiDate(strShamsiDate, dateSeparator);
        }
        public static DateTime GetDateTimeFromShamsiDate(this DateTime datetime, string strShamsiDate)
        {
            return DateTimeHelper.GetDateTimeFromShamsiDate(strShamsiDate);
        }
        public static bool IsValidShamsiDate(this DateTime datetime, string strShamsiDate, string dateSeparator)
        {
            return DateTimeHelper.IsValidShamsiDate(strShamsiDate, dateSeparator);
        }
        public static bool IsValidShamsiDate(this DateTime datetime, string strShamsiDate)
        {
            return DateTimeHelper.IsValidShamsiDate(strShamsiDate);
        }
        public static DateTime AddPersianYears(this DateTime datetitme, int years)
        {
            try
            {
                PersianCalendar pc = new PersianCalendar();
                return pc.AddYears(datetitme, years);
            }
            catch
            {
                throw;
            }
        }
        public static DateTime AddPersianMonths(this DateTime datetime, int months)
        {
            try
            {
                PersianCalendar pc = new PersianCalendar();
                return pc.AddMonths(datetime, months);
            }
            catch
            {
                throw;
            }
        }
        public static DateTime AddPersianDays(this DateTime datetime, int days)
        {
            try
            {
                PersianCalendar pc = new PersianCalendar();
                return pc.AddDays(datetime, days);
            }
            catch
            {
                throw;
            }
        }
        public static DateTime ToDateFromMiladi(this String miladiDate)
        {
            var result = DateTime.MinValue;
            try
            {
                result = Convert.ToDateTime(miladiDate);
            }
            catch
            {
            }
            return result;
        }
        public static DateTime ToDateFromShamsi(this String shamsiDate)
        {
            var result = DateTime.MinValue;
            try
            {
                result = DateTimeHelper.GetDateTimeFromShamsiDate(shamsiDate);
            }
            catch
            {
            }
            return result;
        }
        public static DateTime ToDateFromShamsi(this String shamsiDate, string dateSeparator)
        {
            var result = DateTime.MinValue;
            try
            {
                result = DateTimeHelper.GetDateTimeFromShamsiDate(shamsiDate, dateSeparator);
            }
            catch
            {
            }
            return result;
        }
        public static DateTime ToDate(this DateTime datetime, int persianDayOfMonth)
        {
            var pc = new PersianCalendar();

            var shamsiDate = String.Format("{0:d4}/{1:d2}/{2:d2}", pc.GetYear(datetime), pc.GetMonth(datetime), persianDayOfMonth);

            if (shamsiDate.IsValidShamsiDate() == false)
            {
                throw new Exception("persianDayOfMonth is out of range!");
            }

            return shamsiDate.ToDateFromShamsi();
        }
        public static bool IsValid(this DateTime? dateTime)
        {
            return dateTime != null && dateTime > DateTime.MinValue;
        }
        public static bool IsValidDate(this String miladiDate)
        {
            var result = false;
            try
            {
                Convert.ToDateTime(miladiDate);
                result = true;
            }
            catch
            {
            }
            return result;
        }
        public static bool IsValidShamsiDate(this String shamsiDate)
        {
            return DateTimeHelper.IsValidShamsiDate(shamsiDate);
        }
        public static bool IsValidShamsiDate(this String shamsiDate, string dateSeparator)
        {
            return DateTimeHelper.IsValidShamsiDate(shamsiDate, dateSeparator);
        }
        public static bool IsLeapYear(this int year)
        {
            if ((year % 400 == 0) || (year % 4 == 0 && year % 100 != 0))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        #endregion
    }
}
