using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Lightning_Rewards.Models;

namespace Lightning_Rewards.Managers
{
    public class CardManager : ICardManager
    {
        private readonly Lightning_RewardsContext _db;

        public CardManager(Lightning_RewardsContext db)
        {
            _db = db;
        }
        public IQueryable<Card> GetPendingCardDetails(int userId)
        {
            return _db.Cards.Where(c => c.RecipientUserId == userId && c.CardStatus == "PACC");
        }
    }
}