using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Lightning_Rewards.Managers;
using Lightning_Rewards.Models;

namespace Lightning_Rewards.Controllers
{
    public class CardsController : ApiController
    {
        private readonly Lightning_RewardsContext db = new Lightning_RewardsContext();
        private readonly ICardManager _cardManager;

        public CardsController(ICardManager cardManager)
        {
            _cardManager = cardManager;
        }

        [Route("api/Cards/Pending/Receipt")]
        public IQueryable<Card> GetPendingCardsDetails(long userId)
        {
            return _cardManager.GetPendingCardDetails(userId);
        }

        [Route("api/Cards/Pending/Approval")]
        public IQueryable<Card> GetPendingApprovalsDetails(long userId)
        {
            return _cardManager.GetPendingApprovalsDetails(userId);
        }

        [Route("api/Cards/Claim")]
        public void PutClaimCard(long cardId)
        {
            _cardManager.ClaimCard(cardId);
        }

        [Route("api/Cards/Approve")]
        public void PutApproveCard(long cardId)
        {
            _cardManager.ApproveCard(cardId);
        }

        public IHttpActionResult PostCard([FromBody] CardRequest card)
        {
            var newCard = _cardManager.CreateCard(card);
            return Ok(newCard);
        }

        [Route("api/Cards/Redeem")]
        public IHttpActionResult PutRedeemCards(long userId)
        {
            var redemptionCode = _cardManager.RedeemCards(userId);
            if (redemptionCode == null)
            {
                return BadRequest();
            }
            return Ok(redemptionCode);
        }
    }
}