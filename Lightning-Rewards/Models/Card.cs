using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace Lightning_Rewards.Models
{
    public class Card
    {
        public long Id { get; set; }

        public string LetterValue { get; set; }

        public string Message { get; set; }

        public long CreatedByUserId { get; set; }

        public long RecipientUserId { get; set; }

        public long ManagerUserId { get; set; }

        public string CardStatus { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime? DateModified { get; set; }
        [JsonIgnore]
        public virtual User CreatedByUser { get; set; }
        [JsonIgnore]
        public virtual User ReceivedByUser { get; set; }
        [JsonIgnore]
        public virtual User ManagedByUser { get; set; }
    }
}