using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace backendProject.Models
{
    public class Game
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public String gameName { set; get; }
        public WritingText textToWrite { set; get; }
        public int wordCount { set; get; }
        public double minWordspeed { set; get; }
        public int maxMistakes { set; get; }
        public Difficulty difficulty { set; get; }


    }

    public enum Difficulty
    {
        EASY,
        MEDIUM,
        HARD,
    }
}