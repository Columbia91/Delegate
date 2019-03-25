using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BankSystemDelegateLesson
{
    public delegate void ReporterDelegate(string reportText);
    public class BankAccount
    {
        private ReporterDelegate reporterDelegate;
        public string FullName { get; set; }
        public int Sum { get; private set; }
        public void RegisterDelegate(ReporterDelegate reporter)
        {
            //Delegate.Combine(reporterDelegate, reporter);
            reporterDelegate += reporter;
        }
        public void UnregisterDelegate(ReporterDelegate reporter)
        {
            //Delegate.Remove(reporterDelegate, reporter);
            reporterDelegate -= reporter;
        }
        public BankAccount()
        {}

        public BankAccount(string fullName, int sum)
        {
            FullName = fullName;
            Sum = sum;
        }

        public void Add(int sum)
        {
            Sum += sum;
            reporterDelegate?.Invoke($"На ваш поступило {sum} тг");
        }
        public void Withdraw(int sum)
        {
            if(sum <= Sum)
            {
                Sum -= sum;
                reporterDelegate?.Invoke($"С вашего счета списано {sum} тг");
                return;
            }
            reporterDelegate?.Invoke("Недостаточно средств для списания");
        }
    }
}
