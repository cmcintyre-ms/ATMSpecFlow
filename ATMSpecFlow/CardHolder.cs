using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace ATMSpecFlow
{
    public class CardHolder
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CardNumber { get; set; }
        public double Balance { get; set; }
        public int Pin { get; set; }

        //public CardHolder(string firstName, string lastName, string cardNumber, double balance, int pin)
        //{
        //    FirstName = firstName;
        //    LastName = lastName;
        //    CardNumber = cardNumber;
        //    Balance = balance;
        //    Pin = pin;
        //}

        public static List<CardHolder> cardHolders = new()
        {
            new CardHolder()
            {
                FirstName = "Cheryl",
                LastName = "McIntyre",
                CardNumber = "5698563214578963",
                Balance = 12500.50,
                Pin = 1234
            },
            new CardHolder()
            {
                FirstName = "Joe",
                LastName = "Bloggs",
                CardNumber = "6985452123654785",
                Balance = 500.00,
                Pin = 1234
            },
            new CardHolder()
            {
                FirstName = "Jane",
                LastName = "Doe",
                CardNumber = "98756320145236514",
                Balance = 60.00,
                Pin = 1234
            }
        };

        public void Withdraw(double amount)
        {
            if (amount < 0 || Balance < amount)
            {
                throw new ArgumentOutOfRangeException("amount");
            } 

            Balance -= amount;
        }

        public void Deposit(double amount)
        {
            if (amount < 0)
            {
                throw new ArgumentOutOfRangeException("amount");
            }

            Balance += amount;
        }

        public bool CardNumCheck(string cardNum)
        {
            if (cardNum.Length < 16 || cardNum.Length > 16)
            {
                throw new ArgumentException("Incorrect amount of digits for card number");
            }
            else if (cardNum == CardNumber)
            {
                return true;
            }
            return false;
        }

        public bool PinNumCheck(int pin)
        {
            string stringPin = pin.ToString();

            if (stringPin.Length < 4 || stringPin.Length > 4)
            {
                throw new ArgumentException("Incorrect amount of digits for PIN");
            }
            else if(pin == Pin)
            {
                return true;
            }
            return false;
        }

        //public bool CheckForCardHolder(string cardNum)
        //{
        //    var result = cardHolders.Find(c => c.CardNumber == cardNum);

        //    if (result != null)
        //    {
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}

    }
}
