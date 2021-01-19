using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PlainsOfPrimus.Models
{
    public class Ticket
    {
        public int Id { get; set; }
        public string Subject { get; set; }
        [MinLength(1, ErrorMessage = "Problem cannot have length less than 1!")]
        public string Problem { get; set; }
        public string Solution { get; set; }
        public Character Character { get; set; }
    }
}