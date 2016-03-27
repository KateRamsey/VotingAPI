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
    public class VotersController : ApiController
    {
        private VotingAPIContext db = new VotingAPIContext();


        // GET: api/Voters/5
        [ResponseType(typeof(Voter))]
        [Route("api/Voters/{token:guid}")]
        public IHttpActionResult GetVoter(Guid token)
        {
            Voter voter = db.Voters.FirstOrDefault(v => v.Token == token);
            if (voter == null)
            {
                return NotFound();
            }

            return Ok(voter);
        }

        // PUT: api/Voters/5
        [ResponseType(typeof(Voter))]
        [Route("api/Voters/{token:guid}")]
        public IHttpActionResult PutVoter(Guid token, Voter voter)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (token != voter.Token)
            {
                return BadRequest();
            }

            Voter currentVoter = db.Voters.FirstOrDefault(x => x.Token == token);
            if (currentVoter != null)
            {
                currentVoter.Name = voter.Name;
                currentVoter.Party = voter.Party;
            }

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VoterExists(voter.Id))
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

        // POST: api/Voters
        [ResponseType(typeof(Voter))]
        public IHttpActionResult PostVoter(Voter voter)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            voter.Token = Guid.NewGuid();

            db.Voters.Add(voter);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { token = voter.Token }, voter);
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool VoterExists(int id)
        {
            return db.Voters.Count(e => e.Id == id) > 0;
        }
    }
}