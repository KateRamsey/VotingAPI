using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VotingAPI
{
    public class Vote
    {
        public int Id { get; set; }
        [Required]
        public virtual Voter Voter { get; set; }
        [Required]
        public virtual Candidate Candidate { get; set; }
    }
}