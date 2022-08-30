using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace ATMSpecFlow.Server.Repositories
{
    public class CardHolderRepo : ICardHolderRepo
    {
        private ApplicationDbContext dbContext;
        private static Random r = new Random();

        public CardHolderRepo(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public double GetBalanceForCardHolder(CardHolder cardHolder)
        {
            var holder = dbContext.CardHolders.FirstOrDefault(cardHolder);
            return holder.Balance;
        }

        public CardHolder GetCardHolderInfo(string cardNum)
        {
           return dbContext.CardHolders.FirstOrDefault(x => x.CardNumber == cardNum);
        }

        public void UpdateCardHolderCardNumber(CardHolder cardHolder)
        {
            var newCardNumber = "";
            var v = new char[16];
            for (var i =0; i < 16; i++)
            {
                v[i] = (char)(r.NextDouble()*10 + 48);
            }
             newCardNumber = new string(v);

            cardHolder.CardNumber = newCardNumber;
            dbContext.SaveChanges();
        }

        public void UpdateCardHolderLastName(CardHolder cardHolder, string newLastName)
        {
            var holder = dbContext.CardHolders.FirstOrDefault(cardHolder);
            holder.LastName = newLastName;
        }

        public void UpdateCardHolderPinNumber(CardHolder cardHolder)
        {
            int newPinNumber = r.Next(10000);
            var holder = dbContext.CardHolders.FirstOrDefault(cardHolder);
            holder.Pin = newPinNumber;
            
        }
    }
}
