using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace ATMSpecFlow.Server.Services
{
    public class CardHolderService
    {
        public void Withdraw(CardHolder cardHolder, double amount)
        {
            if (amount < 0)
            {
                throw new AmountLessThanZeroException();
            }
            else if (cardHolder.Balance < amount)
            {
                throw new AmountCannotBeMoreThanBalanceException();
            }

            cardHolder.Balance -= amount;
        }

        public void Deposit(CardHolder cardHolder, double amount)
        {
            if (amount < 0)
            {
                throw new AmountLessThanZeroException();
            }

            cardHolder.Balance += amount;
        }

        public bool CardNumCheck(CardHolder cardHolder, string cardNum)
        {
            if (cardNum.Length < 16 || cardNum.Length > 16)
            {
                throw new IncorrectDigitsCardNumberException();
            }
            else if (cardNum == cardHolder.CardNumber)
            {
                return true;
            }
            return false;
        }

        public bool PinNumCheck(CardHolder cardHolder, int pin)
        {
            string stringPin = pin.ToString();

            if (stringPin.Length < 4 || stringPin.Length > 4)
            {
                throw new IncorrectDigitsPinNumberException();
            }
            else if (pin == cardHolder.Pin)
            {
                return true;
            }
            return false;
        }
    }
}
