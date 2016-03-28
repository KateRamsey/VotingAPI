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
        public IHttpActionResult GetVotes()
        {
            var model = db.Candidates.Select(x => new {Candiate = x.Name, NumberOfVotes = x.Votes.Count()});
            return Ok(model);
        }


        // POST: api/Votes
        [ResponseType(typeof(Vote))]
        [Route("api/votes/{token}")]
        [HttpPost]
        public IHttpActionResult PostVotes(Guid token, VoteCreateVM newVote)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Voter v = db.Voters.Find(newVote.VoterId);
            Candidate c  = db.Candidates.Find(newVote.CandidateId);

            if (v == null || c ==null)
            {
                return BadRequest("Voter or candidate not found.");
            }

            if (token != v.Token)
            {
                return BadRequest("Not a valid voter token");
            }

            if (v.Votes.Any())
            {
                return BadRequest("You have already voted, thanks");
            }

            var vote = new Vote() {Candidate = c};
            v.Votes.Add(vote);

            db.SaveChanges();

            return Ok(vote);
        }

        // DELETE: api/Votes/5
        [ResponseType(typeof(Vote))]
        [Route("api/votes/{token}")]
        public IHttpActionResult DeleteVotes(Guid token)
        {
            Vote vote = db.Votes.SingleOrDefault(x => x.Voter.Token == token);
            if (vote == null)
            {
                return NotFound();
            }

            db.Votes.Remove(vote);
            db.SaveChanges();

            return Ok(vote);
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