namespace Persian.DateTimeHelper
{
    public static class PersianMonth
    {
        public const string Farvardin = "فروردين";
        public const string Ordibehesht = "ارديبهشت";
        public const string Khordad = "خرداد";
        public const string Tir = "تير";
        public const string Mordad = "مرداد";
        public const string Shahrivar = "شهريور";
        public const string Mehr = "مهر";
        public const string Aban = "آبان";
        public const string Azar = "آذر";
        public const string Dey = "دي";
        public const string Bahman = "بهمن";
        public const string Esfand = "اسفند";
        public const string MonthCaption = "ماه";

        public static string GetPersianMonthName(int month)
        {
            switch (month)
            {
                case 1:
                    return string.Format("{0} {1}", Farvardin, MonthCaption);
                case 2:
                    return string.Format("{0} {1}", Ordibehesht, MonthCaption);
                case 3:
                    return string.Format("{0} {1}", Khordad, MonthCaption);
                case 4:
                    return string.Format("{0} {1}", Tir, MonthCaption);
                case 5:
                    return string.Format("{0} {1}", Mordad, MonthCaption);
                case 6:
                    return string.Format("{0} {1}", Shahrivar, MonthCaption);
                case 7:
                    return string.Format("{0} {1}", Mehr, MonthCaption);
                case 8:
                    return string.Format("{0} {1}", Aban, MonthCaption);
                case 9:
                    return string.Format("{0} {1}", Azar, MonthCaption);
                case 10:
                    return string.Format("{0} {1}", Dey, MonthCaption);
                case 11:
                    return string.Format("{0} {1}", Bahman, MonthCaption);
                case 12:
                    return string.Format("{0} {1}", Esfand, MonthCaption);
                default:
                    return month.ToString();
            }
        }
    }
}
}
