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
    public class AccountsController : ControllerBase
    {
        private readonly CustomContext _context;

        public AccountsController(CustomContext context)
        {
            _context = context;
        }

        public ActionResult<IEnumerable<Account>> Index()
        {
            return _context.Accounts.ToList();
        }

        [HttpGet("/[controller]/find")]
        public ActionResult<Account> FindById(int id)
        {
            return _context.Accounts.Find(id);
        }

        [HttpPost("/[controller]/login")]
        public async Task<ActionResult> LogInUserAsync()
        {
            try
            {
                using (StreamReader stream = new StreamReader(HttpContext.Request.Body))
                {
                    string body = await stream.ReadToEndAsync();
                    AccountJSON accJSON = JsonSerializer.Deserialize<AccountJSON>(body);
                    Account acc = _context.Accounts.Where(s => s.Username.Equals(accJSON.username)).FirstOrDefault();
                    if (acc != null && acc.Password.Equals(accJSON.password))
                    {
                        return StatusCode(200);
                    }
                    return StatusCode(404);
                }
            } catch {return StatusCode(404); }
        }

        [HttpPost("/[controller]/add")]
        public async Task<ActionResult> AddAsync()
        {
            try
            {

                using (StreamReader stream = new StreamReader(HttpContext.Request.Body))
                {
                    string body = await stream.ReadToEndAsync();
                    AccountJSON accJSON = JsonSerializer.Deserialize<AccountJSON>(body);
                    Account acc = accJSON.getAccount();
                    _context.Accounts.Add(acc);
                    _context.SaveChanges();
                    return StatusCode(200);
               }
            }
            catch (Exception e)
            {
                return StatusCode(404);
            }
        }

        [HttpDelete("/[controller]/delete")]
        public ActionResult Delete(int id)
        {
            try
            {
                Account acc = _context.Accounts.Find(id);
                _context.Accounts.Remove(acc);
                _context.SaveChanges();
                return StatusCode(200);
            }
            catch
            {
                return StatusCode(404);
            }
        }

        [HttpPut("/[controller]/update")]
        public async Task<ActionResult> UpdateAsync(int id)
        {
            try
            {

                using (StreamReader stream = new StreamReader(HttpContext.Request.Body))
                {
                    string body = await stream.ReadToEndAsync();
                    AccountJSON accJSON = JsonSerializer.Deserialize<AccountJSON>(body);
                    Account acc = accJSON.getAccount();
                    Account newAcc = _context.Accounts.Find(id);
                    if (acc.Username != "") newAcc.Username = acc.Username;
                    if (acc.Password != "") newAcc.Password = acc.Password;
                    _context.Accounts.Update(newAcc);
                    _context.SaveChanges();
                    return StatusCode(200);
                }
            }
            catch (Exception e)
            {
                return StatusCode(404);
            }
        }


    }
}
