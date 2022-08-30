using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMSpecFlow.Server.Repositories
{
    public class CardHolderRepo : ICardHolderRepo
    {
        private ApplicationDbContext dbContext;

        public CardHolderRepo(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void GetBalanceForCardHolder(CardHolder cardHolder)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CardHolder> GetCardHolderInfo(string cardNum)
        {
            var cardHolder = dbContext.CardHolders.Where(c => c.CardNumber == cardNum);
            return cardHolder;
        }

        public void UpdateCardHolderCardNumber(CardHolder cardHolder)
        {
            throw new NotImplementedException();
        }

        public void UpdateCardHolderLastName(CardHolder cardHolder, string newLastName)
        {
            throw new NotImplementedException();
        }

        public void UpdateCardHolderPinNumber(CardHolder cardHolder)
        {
            throw new NotImplementedException();
        }
    }
}
