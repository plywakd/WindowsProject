using backendProject.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

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

        [HttpPost("/[controller]/add")]
        public ActionResult Add(string text, string source)
        {
            try
            {
                WritingText wt = new WritingText(text, source);
                _context.WritingTexts.Add(wt);
                _context.SaveChanges();
                return StatusCode(200);
            } catch
            {
                return StatusCode(404);
            }
        }

        [HttpGet("/[controller]/find")]
        public ActionResult<WritingText> Find(int id)
        {
                return _context.WritingTexts.Find(id);
        }


        [HttpDelete("/[controller]/delete")]
        public ActionResult Delete(int id)
        {
            try
            {
                WritingText wt = _context.WritingTexts.Find(id);
                _context.WritingTexts.Remove(wt);
                _context.SaveChanges();
                return StatusCode(200);
            }
            catch { return StatusCode(404); }
        }

        [HttpPut("/[controller]/update")]
        public ActionResult Update(int id, string text, string source)
        {
            try
            {
                WritingText wt = _context.WritingTexts.Find(id);
                wt.text = text;
                wt.source = source;
                _context.WritingTexts.Update(wt);
                _context.SaveChanges();
                return StatusCode(200);
            }
            catch { return StatusCode(404); }
        }

        [HttpPut("/[controller]/updateSpeeds")]
        public ActionResult UpdateSpeeds(int id)
        {
            try
            {
                WritingText wt = _context.WritingTexts.Find(id);
                wt.topSpeed = getTopSpeed(id);
                wt.averageSpeed = getAvgSpeed(id);
                _context.WritingTexts.Update(wt);
                _context.SaveChanges();
                return StatusCode(200);
            }
            catch { return StatusCode(404); }
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
