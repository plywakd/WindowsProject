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
    public class ResultsController : ControllerBase
    {
        private readonly CustomContext _context;

        public ResultsController(CustomContext context)
        {
            _context = context;
        }

        public ActionResult<IEnumerable<Result>> Index()
        {
            return _context.Results.ToList();
        }

        [HttpPost("/[controller]/add")]
        public async Task<ActionResult> AddAsync()
        {
            try
            {
                using (StreamReader stream = new StreamReader(HttpContext.Request.Body))
                {
                    string body = await stream.ReadToEndAsync();
                    ResultJSON resultJSON = JsonSerializer.Deserialize<ResultJSON>(body);
                    Result result = resultJSON.getResult(_context.Games.Find(resultJSON.gameID), _context.Accounts.Find(resultJSON.accountID));
                    _context.Results.Add(result);
                    _context.SaveChanges();
                    return StatusCode(200);
                }
            }
            catch
            {
                return StatusCode(404);
            }
        }

        [HttpGet("/[controller]/find")]
        public ActionResult<Result> Find(int id)
        {
                return _context.Results.Find(id);
        }

        [HttpGet("/[controller]/player")]
        public ActionResult<IEnumerable<Result>> ForAccount(int accId)
        {
            try { return findByAccount(accId).ToList(); }
            catch { return StatusCode(404); }
        }

        [HttpGet("/[controller]/player/criteria")]
        public async Task<ActionResult<IEnumerable<Result>>> ForAccountAsync()
        {
            //try{
                using (StreamReader stream = new StreamReader(HttpContext.Request.Body))
                {
                    string body = await stream.ReadToEndAsync();
                if (body == "") return StatusCode(407);
                    ResultSearchJSON resultJSON = JsonSerializer.Deserialize<ResultSearchJSON>(body);
                    IEnumerable<Result> results = findByAccount(resultJSON.accountID).Where(r => r.isPassed == resultJSON.isPassed);
                    if (resultJSON.startDate != null) results = results.Where(r => r.finish_date >= resultJSON.startDate);
                    if (resultJSON.endDate != null) results = results.Where(r => r.finish_date <= resultJSON.endDate);
                    return results.ToList();
                }
/*            }
            catch
            {
                return StatusCode(404);
            }*/
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

        private IEnumerable<Result> findByAccount(int accID)
        {
            return _context.Results.Where(r => r.account == _context.Accounts.Find(accID));
        }


    }
}
