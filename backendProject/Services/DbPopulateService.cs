using backendProject.Controllers;
using backendProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace backendProject.Services
{
    [ApiController]
    [Route("[controller]")]
    public class DbPopulateController : ControllerBase
    {
        private readonly CustomContext _context;

        public DbPopulateController(CustomContext context)
        {
            _context = context;
        }

        [HttpPut("/[controller]/dbInit")]
        public ActionResult prepareDbContent()
        {
            try
            {
                cleanDb();
                populateDb();
                return StatusCode(200);
            }
            catch { return StatusCode(405); }
        }

        public void populateDb()
        {
            populateAccounts();
            _context.SaveChanges();
            populateWritingTexts();
            _context.SaveChanges();
            populateGames();
            _context.SaveChanges();
            populateResults();
            _context.SaveChanges();
        }

        public void cleanDb()
        {
            _context.Results.RemoveRange(_context.Results);
            _context.SaveChanges();
            _context.Games.RemoveRange(_context.Games);
            _context.SaveChanges();
            _context.WritingTexts.RemoveRange(_context.WritingTexts);
            _context.SaveChanges();
            _context.Accounts.RemoveRange(_context.Accounts);
            _context.SaveChanges();
        }

        public void populateAccounts()
        {
            List<Account> accounts = new List<Account>();
            for(int i = 1; i<100; i++)
            {
                accounts.Add(new Account("User" + 1, "Password" + 1));
            }
            _context.Accounts.AddRange(accounts);
        }

        public void populateWritingTexts()
        {
            List<WritingText> texts = new List<WritingText>();
            List<String> strings = new List<String>();
            String url = "https://random-word-api.herokuapp.com/word?number=100";
            WebRequest request;
            WebResponse response;
            for (int i = 1; i < 100; i++)
            {
                request = HttpWebRequest.Create(url);
                response = request.GetResponse();
                using (StreamReader Reader = new StreamReader(response.GetResponseStream()))
                {
                    strings = JsonConvert.DeserializeObject<List<String>>(Reader.ReadToEnd());
                }
                string text = strings.Aggregate("", (s1, s2) => s1 +" "+ s2);
                texts.Add(new WritingText(text, "Source " + 1));
            }
            _context.WritingTexts.AddRange(texts);
        }

        public void populateGames()
        {
            List<Game> games = new List<Game>();
            Random random = new Random();
            for (int i = 1; i < 250; i++)
            {
                string gameName = "Game Name " + i;
                WritingText writingText = _context.WritingTexts.Find(_context.WritingTexts.Select(t => t.ID).ToList().ElementAt(random.Next(1, _context.WritingTexts.ToList().Count())));
                Difficulty difficulty = (Difficulty)random.Next(0, 3);
                games.Add(new Game(gameName, writingText, difficulty));
            }
            _context.Games.AddRange(games);
        }

        public void populateResults()
        {
            Random random = new Random();
            List<Result> results = new List<Result>();
            for (int i = 1; i < 1000; i++)
            {
                Game game = _context.Games.Find(_context.Games.Select(t => t.ID).ToList().ElementAt(random.Next(1, _context.Games.ToList().Count())));
                double wordSpeed = random.Next(10, 81) + random.NextDouble();
                Account account = _context.Accounts.Find(_context.Accounts.Select(t => t.ID).ToList().ElementAt(random.Next(1, _context.Accounts.ToList().Count())));
                DateTime finish_date = DateTime.Today.AddDays(-random.Next(0, 365));
                int mistakes = random.Next(0, 10);
                results.Add(new Result(game, wordSpeed, account, finish_date, mistakes));
            }
            _context.Results.AddRange(results);

        }
    }
}
