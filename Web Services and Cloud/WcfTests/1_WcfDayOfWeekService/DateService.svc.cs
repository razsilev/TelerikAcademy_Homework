namespace _1_WcfDayOfWeekService
{
    using System;
    using System.Globalization;

    public class DateServise : IDateService
    {

        public string GetDayOfWeek(DateTime date)
        {
            System.Globalization.CultureInfo cultureinfo =
                        new System.Globalization.CultureInfo("bg-BG");

            var result = date.ToString("ddddddddddddd", cultureinfo);

            return result;
        }
    }
}
