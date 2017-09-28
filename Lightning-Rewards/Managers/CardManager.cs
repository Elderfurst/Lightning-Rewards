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
        public IQueryable<Card> GetPendingCardDetails(long userId)
        {
            return _db.Cards.Where(c => c.RecipientUserId == userId && c.CardStatus == "PAC");
        }

        public IQueryable<Card> GetPendingApprovalsDetails(long userId)
        {
            return _db.Cards.Where(c => c.ManagerUserId == userId && c.CardStatus == "PAP");
        }

        public void ClaimCard(long cardId)
        {
            _db.Cards.First(c => c.Id == cardId).CardStatus = "ACC";
            _db.SaveChanges();
        }

        public void ApproveCard(long cardId)
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

        public string RedeemCards(long userId)
        {
            var cards = _db.Cards.Where(c => c.RecipientUserId == userId && c.CardStatus == "ACC");
            var letters = cards.Select(c => c.LetterValue);
            if (!letters.Contains("R") || !letters.Contains("E") || !letters.Contains("L") || !letters.Contains("I") || !letters.Contains("A") || !letters.Contains("S"))
            {
                return null;
            }

            RedeemCard(cards.First(c => c.LetterValue == "R").Id);
            RedeemCard(cards.First(c => c.LetterValue == "E").Id);
            RedeemCard(cards.First(c => c.LetterValue == "L").Id);
            RedeemCard(cards.First(c => c.LetterValue == "I").Id);
            RedeemCard(cards.First(c => c.LetterValue == "A").Id);
            RedeemCard(cards.First(c => c.LetterValue == "S").Id);

            return GenerateRedemptionCode();
        }

        public void RedeemCard(long cardId)
        {
            _db.Cards.First(c => c.Id == cardId && c.CardStatus == "ACC").CardStatus = "RED";
            _db.SaveChanges();
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

        private string GenerateRedemptionCode()
        {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var stringChars = new char[19];
            var random = new Random();

            for (var i = 0; i < stringChars.Length; i++)
            {
                if (i == 4 || i == 9 || i == 14)
                {
                    stringChars[i] = '-';
                }
                else
                {
                    stringChars[i] = chars[random.Next(chars.Length)];
                }
            }

            var finalString = new String(stringChars);
            return finalString;
        }
    }
}