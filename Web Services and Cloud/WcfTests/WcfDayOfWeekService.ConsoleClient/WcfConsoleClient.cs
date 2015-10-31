namespace WcfDayOfWeekService.ConsoleClient
{
    using System;

    using WcfDayOfWeekService.ConsoleClient.DateServiceReference;

    class WcfConsoleClient
    {
        static void Main()
        {
            DateServiceClient client = new DateServiceClient();

            var date = DateTime.Now;

            var dayOfWeek = client.GetDayOfWeek(date);

            Console.WriteLine("Day of week is: {0}\n", dayOfWeek);
        }
    }
}
