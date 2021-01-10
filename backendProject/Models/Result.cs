using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace backendProject.Models
{
    public class Result
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public Game game { get; set; }
        public double wordSpeed { get; set; }
        public Account account { get; set; }
        public DateTime finish_date { get; set; }
        public Boolean isPassed { get; set; }
        public List<String> mistakes { get; set; }
    }
}