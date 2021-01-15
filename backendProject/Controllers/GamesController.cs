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

        public ActionResult<IEnumerable<Game>> Index()
        {
            return _context.Games.Include(game => game.textToWrite).ToList();
        }

        [HttpPost("/[controller]/add")]
        public ActionResult Add(string gameName, int textID, Difficulty diff)
        {
            try
            {
                Game game = new Game(gameName, _context.WritingTexts.Find(textID), (Difficulty)diff);
                //_context.Entry(game).State = EntityState.Modified;
                _context.Games.Add(game);
                _context.SaveChanges();
                return StatusCode(200);
            } catch { return StatusCode(404); }
        }

        [HttpGet("/[controller]/find")]
        public ActionResult<Game> Find(int id)
        {
            return _context.Games.Find(id);
        }

        [HttpDelete("/[controller]/delete")]
        public ActionResult Delete(int id)
        {
            try
            {
                Game game = _context.Games.Find(id);
                _context.Games.Remove(game);
                _context.SaveChanges();
                return StatusCode(200);
            } catch { return StatusCode(404); }
        }

        [HttpPut("/[controller]/update")]
        public ActionResult Update(int id, string name, int textID, int diff)
        {
            try
            {
                Game game = _context.Games.Find(id);
                game.gameName = name;
                game.textToWrite = _context.WritingTexts.Find(textID);
                game.difficulty = (Difficulty)diff;
                _context.Games.Update(game);
                _context.SaveChanges();
                return StatusCode(200);
            }
            catch { return StatusCode(404); }
        }


    }
}
