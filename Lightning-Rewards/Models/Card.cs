using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lightning_Rewards.Models
{
    public class Card
    {
        public long Id;

        public string LetterValue;

        public long CreatedByUserId;

        public long RecipientUserId;

        public long ManagerUserId;

        public string CardStatus;

        public DateTime DateCreated;

        public DateTime DateModified;
    }
}