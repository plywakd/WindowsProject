using backendProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
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
    public class ResultsController : ControllerBase
    {
        private readonly CustomContext _context;

        public ResultsController(CustomContext context)
        {
            _context = context;
        }

        public ActionResult<IEnumerable<Result>> Index()
        {
            return _context.Results.Include(res => res.game).Include(res => res.account).ToList();
        }

        [HttpPost("/[controller]/add")]
        public async Task<ActionResult> AddAsync()
        {
            try
            {
                using (StreamReader stream = new StreamReader(HttpContext.Request.Body))
                {
                    string body = await stream.ReadToEndAsync();
                    ResultJSON resultJSON = System.Text.Json.JsonSerializer.Deserialize<ResultJSON>(body);
                    Console.WriteLine("Check body json: " + resultJSON.gameID+","+resultJSON.wordSpeed+","+resultJSON.mistakes+","+resultJSON.username);
                    Account acc = _context.Accounts.Where(a => a.Username.Equals(resultJSON.username)).FirstOrDefault();
                    Result result = resultJSON.getResult(_context.Games.Find(resultJSON.gameID), acc);
                    _context.Results.Add(result);
                    _context.SaveChanges();

                    return StatusCode(200);
                }
            }
            catch { return StatusCode(404); }
        }

        [HttpGet("/[controller]/find")]
        public ActionResult<Result> Find(int id)
        {
                return _context.Results.Find(id);
        }

        [HttpGet("/[controller]/player")]
        public ActionResult<IEnumerable<ResultTableJSON>> ForAccount(int accId)
        {
            try { return findByAccount(accId).Select(r => r.GetResultTableJSON(r.game, r.account)).ToList(); }
            catch { return StatusCode(404); }
        }

        [HttpPost("/[controller]/player/criteria")]
        public async Task<ActionResult<IEnumerable<ResultTableJSON>>> ForAccountAsync()
        {
            try{
                using (StreamReader stream = new StreamReader(HttpContext.Request.Body))
                {
                    string body = await stream.ReadToEndAsync();
                if (body == "") return StatusCode(407);
                ResultSearchJSON resultJSON = JsonConvert.DeserializeObject<ResultSearchJSON>(body, new IsoDateTimeConverter { DateTimeFormat = "yyyy-MM-ddTHH:mm:ss" });
                    IEnumerable<Result> results = findByAccount(resultJSON.accountID).OrderByDescending(r => r.finish_date).Where(r => r.isPassed == resultJSON.isPassed);
                    if (resultJSON.startDate != null) results = results.Where(r => r.finish_date >= resultJSON.startDate);
                    if (resultJSON.endDate != null) results = results.Where(r => r.finish_date <= resultJSON.endDate);
                return results.Select(r => r.GetResultTableJSON(r.game, r.account)).ToList();
                }
            }
            catch
            {
                return StatusCode(404);
            }
        }

        [HttpDelete("/[controller]/delete")]
        public ActionResult Delete(int id)
        {
            try
            {
                Result result = _context.Results.Find(id);
                _context.Results.Remove(result);
                _context.SaveChanges();
                return StatusCode(200);
            }
            catch (Exception e) { return StatusCode(404); }
        }

        [HttpGet("/[controller]/scoretable")]
        public ActionResult<IEnumerable<ResultTableJSON>> getScoreTable()
        {
            try
            {
                return _context.Results.OrderByDescending(r => r.finish_date).Select(r => r.GetResultTableJSON(r.game, r.account)).ToList();
            } catch { return StatusCode(404); }
        }

        [HttpGet("/[controller]/scoretable/player")]
        public ActionResult<IEnumerable<ResultTableJSON>> getScoreTableByAccount(int accId)
        {
            try
            {
                return _context.Results.OrderByDescending(r => r.finish_date).Where(r => r.account == _context.Accounts.Find(accId)).Select(r => r.GetResultTableJSON(r.game, r.account)).ToList();
            }
            catch { return StatusCode(404);
    }
}

        [HttpGet("/[controller]/scoretable/game")]
        public ActionResult<IEnumerable<ResultTableJSON>> getScoreTableByGame(int gameId)
        {
            try
            {
                return _context.Results.OrderByDescending(r => r.finish_date).Where(r => r.game == _context.Games.Find(gameId)).Select(r => r.GetResultTableJSON(r.game, r.account)).ToList();
            }
            catch { return StatusCode(404); }
        }

        private IEnumerable<Result> findByAccount(int accID)
        {
            return _context.Results.Include(res => res.game).Include(res => res.account).Where(r => r.account == _context.Accounts.Find(accID));
        }


    }
}
