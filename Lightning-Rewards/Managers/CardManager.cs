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
            return _db.Cards.Where(c => c.RecipientUserId == userId && c.CardStatus == "PAC");
        }

        public IQueryable<Card> GetPendingApprovalsDetails(int userId)
        {
            return _db.Cards.Where(c => c.ManagerUserId == userId && c.CardStatus == "PAP");
        }

        public void ClaimCard(int cardId)
        {
            _db.Cards.First(c => c.Id == cardId).CardStatus = "ACC";
            _db.SaveChanges();
        }

        public void ApproveCard(int cardId)
        {
            _db.Cards.First(c => c.Id == cardId).CardStatus = "PAC";
            _db.SaveChanges();
        }

        public Card CreateCard(CardRequest request)
        {
            var userManager = new UserManager(_db);
            var card = new Card
            {
                LetterValue = GenerateLetter(),
                Message = request.Message,
                CreatedByUserId = request.SenderId,
                RecipientUserId = request.ReceiverId,
                ManagerUserId = request.ManagerId,
                CardStatus = userManager.UserIsManager(request.SenderId) ? "PAC" : "PAP",
                DateCreated = DateTime.Now
            };
            _db.Cards.Add(card);
            _db.SaveChanges();
            return card;
        }

        private string GenerateLetter()
        {
            var random = new Random();
            var number = random.Next(6);

            switch (number)
            {
                case 0:
                    return "R";
                case 1:
                    return "E";
                case 2:
                    return "L";
                case 3:
                    return "I";
                case 4:
                    return "A";
                default:
                    return "S";
            }
        }
    }
}