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
                FullName = "Петр Иванович Жмых",
            };

            var consoleReporter = new ConsoleReport();
            var reporterDelegate = new ReporterDelegate(consoleReporter.SendReport);
            account.RegisterDelegate(reporterDelegate);
            account.RegisterDelegate(new ReporterDelegate(Console.WriteLine));

            account.Add(1000);
            account.Withdraw(5000);
            account.Withdraw(500);
        }
    }
}
