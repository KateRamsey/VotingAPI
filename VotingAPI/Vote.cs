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
        public Voter Voter { get; set; }
        [Required]
        public Candidate Candidate { get; set; }
    }
}