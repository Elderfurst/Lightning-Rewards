using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Lightning_Rewards.Models;

namespace Lightning_Rewards.Managers
{
    public class DashboardManager : IDashboardManager
    {
        private readonly Lightning_RewardsContext _db;

        public DashboardManager(Lightning_RewardsContext db)
        {
            _db = db;
        }
        public Dashboard GetDashboard(long userId)
        {
            var userManager = new UserManager(_db);
            if (!userManager.UserExists(userId))
            {
                return null;
            }
            Dictionary<string, int> letters = new Dictionary<string, int>();
            var cards = _db.Cards.Where(c => c.RecipientUserId == userId && c.CardStatus == "ACC");
            foreach (var card in cards)
            {
                if (letters.ContainsKey(card.LetterValue))
                {
                    letters[card.LetterValue]++;
                }
                else
                {
                    letters.Add(card.LetterValue, 1);
                }
            }
            var dashboard = new Dashboard
            {
                UnapprovedCards = _db.Cards.Count(c => c.ManagerUserId == userId && c.CardStatus == "PAP"),
                UnclaimedCards = _db.Cards.Count(c => c.RecipientUserId == userId && c.CardStatus == "PAC"),
                Letters = letters
            };

            return dashboard;
        }
    }
}