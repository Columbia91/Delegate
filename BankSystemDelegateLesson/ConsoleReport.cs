﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystemDelegateLesson
{
    public class ConsoleReport : IReporter
    {
        public void SendReport(string text)
        {
            Console.WriteLine(text);
        }
    }
}
