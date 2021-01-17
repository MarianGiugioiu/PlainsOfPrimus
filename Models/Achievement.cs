using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlainsOfPrimus.Models
{
    public class Achievement
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Requirements { get; set; }
        public int Points { get; set; }
        public List<Character> Characters { get; set; }
    }
}