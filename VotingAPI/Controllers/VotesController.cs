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
using VotingAPI;
using VotingAPI.Models;

namespace VotingAPI.Controllers
{
    public class VotesController : ApiController
    {
        private VotingAPIContext db = new VotingAPIContext();

        // GET: api/Votes
        public IQueryable<Votes> GetVotes()
        {
            return db.Votes;
        }


        // POST: api/Votes
        [ResponseType(typeof(Votes))]
        public IHttpActionResult PostVotes(Votes votes)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Votes.Add(votes);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = votes.Id }, votes);
        }

        // DELETE: api/Votes/5
        [ResponseType(typeof(Votes))]
        public IHttpActionResult DeleteVotes(int id)
        {
            Votes votes = db.Votes.Find(id);
            if (votes == null)
            {
                return NotFound();
            }

            db.Votes.Remove(votes);
            db.SaveChanges();

            return Ok(votes);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool VotesExists(int id)
        {
            return db.Votes.Count(e => e.Id == id) > 0;
        }
    }
}