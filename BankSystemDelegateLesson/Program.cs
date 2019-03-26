using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystemDelegateLesson
{
    class Program
    {
        static void Main(string[] args)
        {
            var account = new BankAccount
            {
                FullName = "Петр Иванович Жмых"
            };

            var consoleReporter = new ConsoleReport();
            var reporterDelegate = new ReporterDelegate(consoleReporter.SendReport);
            //1-й способ
            account.ReportEvent += reporterDelegate;
            //2-й способ
            account.ReportEvent += AccountReportEvent; //Console.WrieLine;
            //3-й способ (анонимный метод)
            account.ReportEvent += delegate (string data)
            {
                // если хотим вернуть значение, то пишем return - он сам поймет
            };
            //4-й способ
            account.ReportEvent += text => Console.WriteLine(text);
            account.ReportEvent += (text) =>
            {
                Console.WriteLine(text);
                //если много действий
            };

            account.Add(1000);
            account.Withdraw(5000);
            account.Withdraw(500);

            var cities = new List<string>
            {
                "Алматы",
                "Караганда",
                "Павлодар"
            };

            //var newCities = new List<string>();
            //foreach (var cityName in cities)
            //{
            //    if (cityName.ToLower().Contains("р"))
            //    {
            //        newCities.Add(cityName);
            //    }
            //}
            var result = cities.Where(cityName => cityName.ToLower().Contains("р"));
            var anotherResult = from cityName 
                                in cities
                                where cityName.ToLower().Contains("р")
                                select cityName;
        }

        private static void AccountReportEvent(string reportText)
        {
            throw new NotImplementedException();
        }
    }
}
