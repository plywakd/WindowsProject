using backendProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backendProject.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GamesController : ControllerBase
    {
        private readonly Context _context;

        public GamesController(Context context)
        {
            _context = context;
        }

        public List<Game> Index()
        {
            return _context.Games.ToList();
        }

        [HttpGet("/[controller]/add/{gameName}/{textID}/{diff}")]
        public string Add(string gameName, int textID, int diff)
        {
            try
            {
                Game game = new Game(gameName, _context.WritingTexts.Find(textID), (Difficulty)diff);
                _context.Games.Add(game);
                _context.SaveChanges();
                return String.Format("Game - {0}{1} - added", game.gameName, game.ID);
            }catch(Exception e)
            {
                return e.Message;
            }
        }

        [HttpPost("/[controller]/find/{id}")]
        public string Find(int id)
        {
            try
            {
                return _context.Games.Find(id).ToString();
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        [HttpDelete("/[controller]/delete/{id}")]
        public string Delete(int id)
        {
            try
            {
                Game game = _context.Games.Find(id);
                _context.Games.Remove(game);
                _context.SaveChanges();
                return String.Format("Game - {0}{1} - removed", game.gameName, game.ID);
            }
            catch (Exception e) { return e.Message; }
        }

        [HttpPost("/[controller]/update/{id}/{name}/{textID}/{diff}")]
        public string Update(int id, string name, int textID, int diff)
        {
            try
            {
                Game game = _context.Games.Find(id);
                game.gameName = name;
                game.textToWrite = _context.WritingTexts.Find(textID);
                game.difficulty = (Difficulty)diff;
                _context.Games.Update(game);
                _context.SaveChanges();
                return String.Format("Game - {0}{1} - updated", game.gameName, game.ID);
            }
            catch (Exception e) { return e.Message; }
        }


    }
}
