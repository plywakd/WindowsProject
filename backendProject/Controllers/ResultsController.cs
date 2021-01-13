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
    public class ResultsController : ControllerBase
    {
        private readonly Context _context;

        public ResultsController(Context context)
        {
            _context = context;
        }

        public ActionResult<IEnumerable<Result>> Index()
        {
            return _context.Results.ToList();
        }

        [HttpPost("/[controller]/add/{gameID}/{ws}/{accID}/{m}")]
        public ActionResult Add(int gameID, double ws, int accID, int m)
        {
            try
            {
                Result result = new Result(_context.Games.Find(gameID), ws, _context.Accounts.Find(accID), DateTime.Now  , m);
                _context.Results.Add(result);
                _context.SaveChanges();
                return StatusCode(200);
            }catch
            {
                return StatusCode(404);
            }
        }

        [HttpGet("/[controller]/find/{id}")]
        public ActionResult<Result> Find(int id)
        {
                return _context.Results.Find(id);
        }

        [HttpGet("/[controller]/player/{accId}")]
        public ActionResult<IEnumerable<Result>> ForAccount(int accId)
        {
            return findByAccount(accId).ToList();
        }

        [HttpGet("/[controller]/player/{accId}/{passed}")]
        public ActionResult<IEnumerable<Result>> ForAccountPassed(int accId, bool passed)
        {
            return findByAccount(accId).Where(r => r.isPassed == passed).ToList();
        }

        [HttpGet("/[controller]/player/{accId}/{date1}/{date2}")]
        public ActionResult<IEnumerable<Result>> ForAccountBetweenDates(int accId, DateTime date1, DateTime date2)
        {
            return findByAccount(accId).Where(r => r.finish_date >= date1 && r.finish_date <= date2).ToList();
        }

        [HttpDelete("/[controller]/delete/{id}")]
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

        private IEnumerable<Result> findByAccount(int accID)
        {
            return _context.Results.Where(r => r.account == _context.Accounts.Find(accID));
        }


    }
}
