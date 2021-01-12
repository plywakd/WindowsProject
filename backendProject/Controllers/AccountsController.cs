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
    public class AccountsController : ControllerBase
    {
        private readonly Context _context;

        public AccountsController(Context context)
        {
            _context = context;
        }

        public List<Account> Index()
        {
            return _context.Accounts.ToList();
        }

        [HttpGet("/[controller]/find/{id}")]
        public string FindById(int id)
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

        [HttpGet("/[controller]/login/{username}")]
        public ActionResult LogInUser(string username)
        {
            try
            {
                // TODO implement parsing parameters from json body request
                Account acc = _context.Accounts.Where(s => s.Username.Equals(username)).FirstOrDefault();
                if (acc != null)
                {
                    return StatusCode(200);
                }
                return StatusCode(404);
            }
            catch (Exception e)
            {
                return StatusCode(404);
            }
        }

        [HttpPost("/[controller]/add/{username}/{password}")]
        public ActionResult Add(string username, string password)
        {
            try
            {
                Account acc = new Account(username, password);
                _context.Accounts.Add(acc);
                _context.SaveChanges();
                //return String.Format("User - {0} - added", acc.Username);
                return StatusCode(201);
            }
            catch (Exception e)
            {
                return StatusCode(404);
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

        [HttpPut("/[controller]/update/{id}/{username}/{password}")]
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
