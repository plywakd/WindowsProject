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

        public List<Result> Index()
        {
            return _context.Results.ToList();
        }

        [HttpGet("/[controller]/add/{gameID}/{ws}/{accID}/{m}")]
        public string Add(int gameID, double ws, int accID, int m)
        {
            try
            {
                Result result = new Result(_context.Games.Find(gameID), ws, _context.Accounts.Find(accID), DateTime.Now  , m);
                _context.Results.Add(result);
                _context.SaveChanges();
                return String.Format("Result - {0} - added", result.ID);
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
                return _context.Results.Find(id).ToString();
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        [HttpPost("/[controller]/player/{accId}")]
        public List<Result> ForAccount(int accId)
        {
            return (List<Result>)_context.Results.ToList().Where(r => r.account == _context.Accounts.Find(accId));
        }

        [HttpPost("/[controller]/player/{accId}/{passed}")]
        public List<Result> ForAccountPassed(int accId, bool passed)
        {
            return (List<Result>)ForAccount(accId).Where(r => r.isPassed == passed);
        }

        [HttpPost("/[controller]/player/{accId}/{date1}/{date2}")]
        public List<Result> ForAccountBetweenDates(int accId, DateTime date1, DateTime date2)
        {
            return (List<Result>)ForAccount(accId).Where(r => r.finish_date >= date1 && r.finish_date <= date2);
        }

        [HttpDelete("/[controller]/delete/{id}")]
        public string Delete(int id)
        {
            try
            {
                Result result = _context.Results.Find(id);
                _context.Results.Remove(result);
                _context.SaveChanges();
                return String.Format("Result - {0} - removed", result.ID);
            }
            catch (Exception e) { return e.Message; }
        }


    }
}
