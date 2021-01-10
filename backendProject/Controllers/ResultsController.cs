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

        [HttpGet("/[controller]/add/{username}/{password}")]
        public string Add(string username, string password)
        {
            try
            {
                Result acc = new Result(username, password);
                _context.Results.Add(acc);
                _context.SaveChanges();
                return String.Format("User - {0} - added", acc.Username);
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
                return _context.Accounts.Find(id).ToString();
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        [HttpPost("/[controller]/add/{username}/{password}")]
        public string Add(string username, string password)
        {
            try
            {
                Account acc = new Account(username, password);
                _context.Accounts.Add(acc);
                _context.SaveChanges();
                return String.Format("User - {0} - added", acc.Username);
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
                Account acc = _context.Accounts.Find(id);
                _context.Accounts.Remove(acc);
                _context.SaveChanges();
                return String.Format("User - {0} - removed", acc.Username);
            }
            catch (Exception e) { return e.Message; }
        }

        [HttpPost("/[controller]/update/{id}/{username}/{password}")]
        public string Update(int id, string username, string password)
        {
            try
            {
                Account acc = _context.Accounts.Find(id);
                acc.Username = username;
                acc.Password = password;
                _context.Accounts.Update(acc);
                _context.SaveChanges();
                return String.Format("User - {0} - updated", acc.Username);
            }
            catch (Exception e) { return e.Message; }
        }


    }
}
