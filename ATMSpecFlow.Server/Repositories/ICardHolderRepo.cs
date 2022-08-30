using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMSpecFlow.Server.Repositories
{
    public interface ICardHolderRepo
    {
        CardHolder GetCardHolderInfo(string cardNum);

        double GetBalanceForCardHolder(CardHolder cardHolder);

        void UpdateCardHolderLastName(CardHolder cardHolder, string newLastName);

        void UpdateCardHolderCardNumber(CardHolder cardHolder);

        void UpdateCardHolderPinNumber(CardHolder cardHolder);
    }
}
