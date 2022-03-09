using System;
using System.Globalization;

namespace Persian.DateTimeHelper
{
    public static partial class DateTimeHelper
    {
        #region Private Member
        private const string DefaultDateSeparator = "/";

        private static PersianCalendar _persianCalendar;
        #endregion

        #region Constrructor
        static DateTimeHelper()
        {
            _persianCalendar = new PersianCalendar();
        }
        #endregion

        #region Public Method
        public static DateTime GetDateTimeFromShamsiDate(string strShamsiDate, string dateSeparator = DefaultDateSeparator)
        {
            try
            {
                string[] dateparts = strShamsiDate.Split(new string[] { dateSeparator }, StringSplitOptions.None);
                DateTime dt = new DateTime(Convert.ToInt32(dateparts[0]), Convert.ToInt32(dateparts[1]), Convert.ToInt32(dateparts[2]), _persianCalendar);
                return dt;
            }
            catch
            {
                throw new Exception("Shamsi date is not in correct Format!");
            }
        }

        public static bool IsValidShamsiDate(string strShamsiDate, string dateSeparator = DefaultDateSeparator)
        {
            try
            {
                string[] dateparts = strShamsiDate.Split(new string[] { dateSeparator }, StringSplitOptions.None);

                DateTime dt = new DateTime(Convert.ToInt32(dateparts[0]), Convert.ToInt32(dateparts[1]), Convert.ToInt32(dateparts[2]), _persianCalendar);

                return true;
            }
            catch
            {
                return false;
            }

        }

        public static DateTime GetNow()
        {
            return DateTime.Now;
        }

        public static DateTime? GetPersianDateInWeek(int persianYear, int persianMonth, DayOfWeek dayOfWeek, WeekOfMonth weekOfMonth)
        {
            DateTime? result = null;

            var tempStartDate = DateTime.MinValue;
            var tempEndDate = DateTime.MinValue;

            switch (weekOfMonth)
            {
                case WeekOfMonth.First:
                    tempStartDate = new DateTime(persianYear, persianMonth, 1, _persianCalendar);
                    tempEndDate = new DateTime(persianYear, persianMonth, 7, _persianCalendar);
                    break;
                case WeekOfMonth.Second:
                    tempStartDate = new DateTime(persianYear, persianMonth, 8, _persianCalendar);
                    tempEndDate = new DateTime(persianYear, persianMonth, 14, _persianCalendar);
                    break;
                case WeekOfMonth.Third:
                    tempStartDate = new DateTime(persianYear, persianMonth, 15, _persianCalendar);
                    tempEndDate = new DateTime(persianYear, persianMonth, 21, _persianCalendar);

                    break;
                case WeekOfMonth.Fourth:
                    tempStartDate = new DateTime(persianYear, persianMonth, 22, _persianCalendar);
                    tempEndDate = new DateTime(persianYear, persianMonth, 28, _persianCalendar);

                    break;
                case WeekOfMonth.Last:
                    tempStartDate = new DateTime(persianYear, persianMonth, 29, _persianCalendar);
                    tempEndDate = new DateTime(persianYear, persianMonth, _persianCalendar.GetDaysInMonth(persianYear, persianMonth), _persianCalendar);
                    break;
            }

            while (tempStartDate <= tempEndDate)
            {
                if (tempStartDate.DayOfWeek == dayOfWeek)
                {
                    result = tempStartDate;
                    break;
                }

                tempStartDate = tempStartDate.AddDays(1);
            }

            return result;
        }
        #endregion
    }
}

