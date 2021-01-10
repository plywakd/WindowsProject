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

        [HttpGet("/[controller]/add/{username}/{password}")]
        public string Add(string username, string password)
        {
            try
            {
                Game acc = new Game(username, password);
                _context.Games.Add(acc);
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
                return _context.Games.Find(id).ToString();
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
                Game acc = new Game(username, password);
                _context.Games.Add(acc);
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
                Game acc = _context.Games.Find(id);
                _context.Games.Remove(acc);
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
                Game acc = _context.Games.Find(id);
                acc.Username = username;
                acc.Password = password;
                _context.Games.Update(acc);
                _context.SaveChanges();
                return String.Format("User - {0} - updated", acc.Username);
            }
            catch (Exception e) { return e.Message; }
        }


    }
}
