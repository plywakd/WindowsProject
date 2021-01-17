using backendProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace backendProject.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GamesController : ControllerBase
    {
        private readonly CustomContext _context;

        public GamesController(CustomContext context)
        {
            _context = context;
        }

        public ActionResult<IEnumerable<Game>> Index()
        {
            try
            {
                return _context.Games.Include(game => game.textToWrite).ToList();
            } catch {
                return StatusCode(404);
            }
        }


        [HttpPost("/[controller]/add")]
        public async Task<ActionResult> AddAsync()
        {
            try
            {
                using (StreamReader stream = new StreamReader(HttpContext.Request.Body))
                {
                    string body = await stream.ReadToEndAsync();
                    GameJSON gameJSON = JsonSerializer.Deserialize<GameJSON>(body);
                    Game game = gameJSON.getGame(_context.WritingTexts.Find(gameJSON.textToWrite));
                    _context.Games.Add(game);
                    _context.SaveChanges();
                    return StatusCode(200);
                }
            } catch
            {
                return StatusCode(404);
            }
        }

        [HttpGet("/[controller]/find")]
        public ActionResult<Game> Find(int id)
        {
            Game game = _context.Games.Include(g => g.textToWrite).Where(g=> g.ID==id).FirstOrDefault();
            return game;
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
        public async Task<ActionResult> UpdateAsync(int id)
        {
            try
            {
                using (StreamReader stream = new StreamReader(HttpContext.Request.Body))
                {
                    string body = await stream.ReadToEndAsync();
                    GameJSON gameJSON = JsonSerializer.Deserialize<GameJSON>(body);
                    Game game = gameJSON.getGame(_context.WritingTexts.Find(gameJSON.textToWrite));
                    Game newGame = _context.Games.Find(id);
                    if (game.gameName != "") newGame.gameName = game.gameName;
                    if (game.difficulty != newGame.difficulty)
                    {
                        newGame.difficulty = game.difficulty;
                        newGame.difficultySetting(newGame.difficulty);
                    }
                    if (game.textToWrite != newGame.textToWrite) newGame.textToWrite = game.textToWrite;
                    _context.Games.Update(newGame);
                    _context.SaveChanges();
                    return StatusCode(200);
                }
            }
            catch { return StatusCode(404); }
        }


    }
}
