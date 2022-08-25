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

        public CardHolder() { }

        public CardHolder(string firstName, string lastName, string cardNumber, double balance, int pin)
        {
            FirstName = firstName;
            LastName = lastName;
            CardNumber = cardNumber;
            Balance = balance;
            Pin = pin;
        }

        public void Withdraw(double amount)
        {
            if (amount < 0)
            {
                throw new AmountLessThanZeroException();
            }
            else if (Balance < amount)
            {
                throw new AmountCannotBeMoreThanBalanceException();
            }

            Balance -= amount;
        }

        public void Deposit(double amount)
        {
            if (amount < 0)
            {
                throw new AmountLessThanZeroException();
            }

            Balance += amount;
        }

        public bool CardNumCheck(string cardNum)
        {
            if (cardNum.Length < 16 || cardNum.Length > 16)
            {
                throw new IncorrectDigitsCardNumberException();
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
                throw new IncorrectDigitsPinNumberException();
            }
            else if(pin == Pin)
            {
                return true;
            }
            return false;
        }

    }
}
