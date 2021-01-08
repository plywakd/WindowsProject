using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace backend.Models
{
    public class Result
    {
        private int resultId { get; set; }
        private Game game { get; set; }
        private double wordSpeed { get; set; }

        private Account account { get; set; }
        private DateTime finish_date { get; set; }
        private Boolean isPassed { get; set; }
        private List<String> mistakes { get; set; }
    }
}