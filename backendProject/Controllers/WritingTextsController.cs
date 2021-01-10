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
    public class WritingTextsController : ControllerBase
    {
        private readonly Context _context;

        public WritingTextsController(Context context)
        {
            _context = context;
        }

        public List<WritingText> Index()
        {
            return _context.WritingTexts.ToList();
        }

        [HttpPost("/[controller]/add/{text}/{source}")]
        public string Add(string text, string source)
        {
            try
            {
                WritingText wt = new WritingText(text, source);
                _context.WritingTexts.Add(wt);
                _context.SaveChanges();
                return String.Format("WritingText - {0} - added", wt.ID);
            }catch(Exception e)
            {
                return e.Message;
            }
        }

        [HttpGet("/[controller]/find/{id}")]
        public string Find(int id)
        {
            try
            {
                return _context.WritingTexts.Find(id).ToString();
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
                WritingText wt = _context.WritingTexts.Find(id);
                _context.WritingTexts.Remove(wt);
                _context.SaveChanges();
                return String.Format("WritingText - {0} - removed", wt.ID);
            }
            catch (Exception e) { return e.Message; }
        }

        [HttpPut("/[controller]/update/{id}/{text}/{source}")]
        public string Update(int id, string text, string source)
        {
            try
            {
                WritingText wt = _context.WritingTexts.Find(id);
                wt.text = text;
                wt.source = source;
                _context.WritingTexts.Update(wt);
                _context.SaveChanges();
                return String.Format("WritingText - {0} - updated", wt.ID);
            }
            catch (Exception e) { return e.Message; }
        }

        [HttpPut("/[controller]/updateSpeeds/{id}")]
        public string UpdateSpeeds(int id)
        {
            try
            {
                WritingText wt = _context.WritingTexts.Find(id);
                wt.topSpeed = getTopSpeed(id);
                wt.averageSpeed = getAvgSpeed(id);
                _context.WritingTexts.Update(wt);
                _context.SaveChanges();
                return String.Format("WritingText - {0} - updated", wt.ID);
            }
            catch (Exception e) { return e.Message; }
        }

        private double getAvgSpeed(int textID)
        {
            double sumSpeed = _context.Results.ToList().Aggregate(0.0d, (acc, x) => acc + x.wordSpeed);
            double resultSpeed = sumSpeed / _context.Results.ToList().Count();
            return resultSpeed;
        }

        private double getTopSpeed(int textID)
        {
            return _context.Results.ToList().Max(r => r.wordSpeed);
        }


    }
}
