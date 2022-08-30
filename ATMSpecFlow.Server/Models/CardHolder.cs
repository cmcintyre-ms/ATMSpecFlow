using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace ATMSpecFlow.Server
{
    public class CardHolder
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CardNumber { get; set; }
        public double Balance { get; set; }
        public int Pin { get; set; }

        public CardHolder() { }

        public CardHolder(string firstName, string lastName, string cardNumber, double balance, int pin)
        {
            FirstName = firstName;
            LastName = lastName;
            CardNumber = cardNumber;
            Balance = balance;
            Pin = pin;
        }

    }
}
