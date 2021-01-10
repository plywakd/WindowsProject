using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace backendProject.Models
{
    public class Result
    {
        public int ResultID { get; set; }
        public Game game { get; set; }
        public double wordSpeed { get; set; }

        public Account account { get; set; }
        public DateTime finish_date { get; set; }
        public Boolean isPassed { get; set; }
        public List<String> mistakes { get; set; }
    }
}