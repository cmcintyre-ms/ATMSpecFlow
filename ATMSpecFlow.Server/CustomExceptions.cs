using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMSpecFlow
{
    public class CustomExceptions
    {
    }

    public class AmountLessThanZeroException : Exception
    {
        public override string Message
        {
            get { return "Amount cannot be less than zero"; }
        }
    }

    public class AmountCannotBeMoreThanBalanceException : Exception
    {
        public override string Message
        {
            get { return "Amount cannot be more than the account balance "; }
        }
    }

    public class IncorrectDigitsCardNumberException : Exception
    {
        public override string Message
        {
            get { return "Incorrect number of digits for card number"; }
        }
    }

    public class IncorrectDigitsPinNumberException : Exception
    {
        public override string Message
        {
            get { return "Incorrect number of digits for the PIN number"; }
        }
    }
}
