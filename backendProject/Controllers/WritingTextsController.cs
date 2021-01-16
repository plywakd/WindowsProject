using backendProject.Models;
using Microsoft.AspNetCore.Mvc;
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
    public class WritingTextsController : ControllerBase
    {
        private readonly CustomContext _context;

        public WritingTextsController(CustomContext context)
        {
            _context = context;
        }

        public ActionResult<IEnumerable<WritingText>> Index()
        {
            return _context.WritingTexts.ToList();
        }

        [HttpPost("/[controller]/add")]
        public async Task<ActionResult> AddAsync()
        {
            try
            {

                using (StreamReader stream = new StreamReader(HttpContext.Request.Body))
                {
                    string body = await stream.ReadToEndAsync();
                    WritingTextJSON writingTextJSON = JsonSerializer.Deserialize<WritingTextJSON>(body);
                    WritingText writingText = writingTextJSON.getWritingText();
                    _context.WritingTexts.Add(writingText);
                    _context.SaveChanges();
                    return StatusCode(200);
                }
            }
            catch (Exception e)
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
                _context.Games.Where(g => g.textToWrite == wt).ToList().ForEach(g => g.textToWrite = null);
                _context.WritingTexts.Remove(wt);
                _context.SaveChanges();
                return StatusCode(200);
            }
            catch { return StatusCode(404); }
        }

        [HttpPut("/[controller]/update")]
        public async System.Threading.Tasks.Task<ActionResult> UpdateAsync(int id)
        {
            try
            {
                using (StreamReader stream = new StreamReader(HttpContext.Request.Body))
                {
                    string body = await stream.ReadToEndAsync();
                    WritingTextJSON writingTextJSON = JsonSerializer.Deserialize<WritingTextJSON>(body);
                    WritingText writingText = writingTextJSON.getWritingText();
                    WritingText newWritingText = _context.WritingTexts.Find(id);
                    if (newWritingText != null) { 
                        if (writingText.text != "") newWritingText.text = writingText.text;
                        if (writingText.source != "") newWritingText.source = writingText.source;
                        _context.WritingTexts.Update(newWritingText);
                        _context.SaveChanges();
                        return StatusCode(200);
                    } else return StatusCode(404);
                }
            }
            catch (Exception e)
            {
                return StatusCode(404);
            }
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
            double resultSpeed;
            if (sumSpeed != 0) resultSpeed = sumSpeed / _context.Results.ToList().Count();
            else return 0;
            return resultSpeed;
        }

        private double getTopSpeed(int textID)
        {
            try { return _context.Results.ToList().Max(r => r.wordSpeed); }
            catch { return 0; }
        }


    }
}
