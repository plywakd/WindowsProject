using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace backend.Models
{
    public class Game
    {
        private int gameId { get; set; }
        private String gameName { set; get; }
        private WritingText textToWrite { set; get; }
        private int wordCount { set; get; }
        private double minWordspeed { set; get; }
        private int maxMistakes { set; get; }
        private Difficulty difficulty { set; get; }

    }

    public enum Difficulty
    {
        EASY,
        MEDIUM,
        HARD,
    }
}