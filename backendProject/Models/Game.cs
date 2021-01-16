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
        public string gameName { set; get; }
        public WritingText textToWrite { set; get; }
        public int wordCount { set; get; }
        public double minWordspeed { set; get; }
        public int maxMistakes { set; get; }
        public Difficulty difficulty { set; get; }

        public Game() { }
        public Game(string gn, WritingText ttw, Difficulty d) //remove wc
        {
            gameName = gn;
            textToWrite = ttw;
            difficulty = d;
            difficultySetting(d);
        }

        public void difficultySetting(Difficulty d)
        {
            switch (d)
            {
                case Difficulty.EASY:
                    {
                        minWordspeed = 20.0d;
                        maxMistakes = (int)(textToWrite.wordCount * 0.1);
                        break;
                    }
                case Difficulty.MEDIUM:
                    {
                        minWordspeed = 30.0d;
                        maxMistakes = (int)(textToWrite.wordCount * 0.05);
                        break;
                    }
                case Difficulty.HARD:
                    {
                        minWordspeed = 60.0d;
                        maxMistakes = (int)(textToWrite.wordCount * 0.01);
                        break;
                    }
                default: break;
            }
        }
    }

    public class GameJSON
    {
        public string gameName { set; get; }
        public int textToWrite { set; get; }
        public int difficulty { set; get; }
        
        public Game getGame( WritingText wt )
        {
            return new Game(gameName, wt, (Difficulty)difficulty);
        }
    }

    public enum Difficulty
    {
        EASY,
        MEDIUM,
        HARD,
    }
}