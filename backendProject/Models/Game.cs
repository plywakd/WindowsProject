using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace backendProject.Models
{
    public class Game
    {
        public int GameID { get; set; }
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