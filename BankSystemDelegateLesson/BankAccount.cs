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
        public event ReporterDelegate ReportEvent;

        public string FullName { get; set; }
        public int Sum { get; private set; }
        
        public BankAccount() {}

        public BankAccount(string fullName, int sum)
        {
            FullName = fullName;
            Sum = sum;
        }

        public void Add(int sum)
        {
            Sum += sum;
            ReportEvent?.Invoke($"На ваш поступило {sum} тг");
        }
        public void Withdraw(int sum)
        {
            if(sum <= Sum)
            {
                Sum -= sum;
                ReportEvent?.Invoke($"С вашего счета списано {sum} тг");
                return;
            }
            ReportEvent?.Invoke("Недостаточно средств для списания");
        }
    }
}
