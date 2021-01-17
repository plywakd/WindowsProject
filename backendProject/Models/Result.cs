using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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

        public ResultTableJSON GetResultTableJSON(Game game, Account account)
        {
            return new ResultTableJSON(this, game, account);
        }
    }

    public class ResultJSON
    {
        public int gameID { get; set; }
        public string username { get; set; }
        public double wordSpeed { get; set; }
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

    public class ResultTableJSON
    {
        public int ID { get; set; }
        public string game { get; set; }
        public double wordSpeed { get; set; }
        public string account { get; set; }
        public DateTime finish_date { get; set; }
        public bool isPassed { get; set; }
        public int mistakes { get; set; }

        public ResultTableJSON (Result result, Game game, Account account)
        {
            this.ID = result.ID;
            this.game = game.gameName;
            this.wordSpeed = result.wordSpeed;
            this.account = account.Username;
            this.finish_date = result.finish_date;
            this.isPassed = result.isPassed;
            this.mistakes = result.mistakes;
        }
    }
}