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
    public class CandidatesController : ApiController
    {
        private VotingAPIContext db = new VotingAPIContext();

        // GET: api/Candidate
        public IQueryable<Candidate> GetCandidates()
        {
            return db.Candidates;
        }

        // GET: api/Candidate/5
        [ResponseType(typeof(Candidate))]
        public IHttpActionResult GetCandidates(int id)
        {
            Candidate candidate = db.Candidates.Find(id);
            if (candidate == null)
            {
                return NotFound();
            }

            return Ok(candidate);
        }


        // POST: api/Candidate
        [ResponseType(typeof(Candidate))]
        public IHttpActionResult PostCandidates(Candidate candidate)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Candidates.Add(candidate);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = candidate.Id }, candidate);
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CandidatesExists(int id)
        {
            return db.Candidates.Count(e => e.Id == id) > 0;
        }
    }
}