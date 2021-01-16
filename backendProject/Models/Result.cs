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
        public bool isPassed { get; set; }
        public int mistakes { get; set; }

        public Result() { }
        public Result(Game g, double ws, Account acc, DateTime fd, int m) 
        {
            game = g;
            wordSpeed = ws;
            account = acc;
            finish_date = fd;
            mistakes = m;
            isPassed = ws >= game.minWordspeed && mistakes <= game.maxMistakes;
        }
    }

    public class ResultJSON
    {
        public int gameID { get; set; }
        public string username { get; set; }
        public double wordSpeed { get; set; }
        //public int accountID { get; set; }
        public int mistakes { get; set; }

        public Result getResult(Game game, Account account)
        {
            return new Result(game, wordSpeed, account, DateTime.Now, mistakes);
        }
    }

    public class ResultSearchJSON
    {
        public int accountID { get; set; }
        public bool isPassed { get; set; }
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }

    }
}