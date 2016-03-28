using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VotingAPI
{
    public class VoteCreateVM
    {
       public int VoterId { get; set; }    
       public int CandidateId { get; set; }
        public Guid Token { get; set; }


    }

    public class Vote
    {
        public int Id { get; set; }
        [Required]
        public virtual Voter Voter { get; set; }
        [Required]
        public virtual Candidate Candidate { get; set; }
    }
}