using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VotingAPI
{
    public class Voter
    {
        [Required]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Party { get; set; }
        public Guid Token { get; set; }

        public virtual ICollection<Vote> Votes { get; set; } = new List<Vote>();
    }
}