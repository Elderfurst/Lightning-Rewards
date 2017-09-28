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
        public IQueryable<Card> GetPendingCardsDetails(int userId)
        {
            return _cardManager.GetPendingCardDetails(userId);
        }

        [Route("api/Cards/Pending/Approval")]
        public IQueryable<Card> GetPendingApprovalsDetails(int userId)
        {
            return _cardManager.GetPendingApprovalsDetails(userId);
        }

        [Route("api/Cards/Claim")]
        public void PutClaimCard(int cardId)
        {
            _cardManager.ClaimCard(cardId);
        }
        // GET: api/Cards/5
        [ResponseType(typeof(Card))]
        public IHttpActionResult GetCard(long id)
        {
            Card card = db.Cards.Find(id);
            if (card == null)
            {
                return NotFound();
            }

            return Ok(card);
        }

        // PUT: api/Cards/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCard(long id, Card card)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != card.Id)
            {
                return BadRequest();
            }

            db.Entry(card).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CardExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Cards
        [ResponseType(typeof(Card))]
        public IHttpActionResult PostCard(Card card)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Cards.Add(card);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = card.Id }, card);
        }

        // DELETE: api/Cards/5
        [ResponseType(typeof(Card))]
        public IHttpActionResult DeleteCard(long id)
        {
            Card card = db.Cards.Find(id);
            if (card == null)
            {
                return NotFound();
            }

            db.Cards.Remove(card);
            db.SaveChanges();

            return Ok(card);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CardExists(long id)
        {
            return db.Cards.Count(e => e.Id == id) > 0;
        }
    }
}