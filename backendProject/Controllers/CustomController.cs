using backendProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace backendProject.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomController : ControllerBase
    {
        public List<String> callurl(int wordsCount)
        {
            String url = String.Format("https://random-word-api.herokuapp.com/word?number={0}", wordsCount);
            WebRequest request = HttpWebRequest.Create(url);
            WebResponse response = request.GetResponse();
            using (StreamReader Reader = new StreamReader(response.GetResponseStream()))
            {
                var myObject = JsonConvert.DeserializeObject<List<String>>(Reader.ReadToEnd());
                return myObject;
            }
        }

        private readonly ILogger<CustomController> _logger;
        private readonly CustomContext context;

        public CustomController(ILogger<CustomController> logger, CustomContext context)
        {
            this.context = context;
            _logger = logger;
        }

        [HttpGet("/[controller]/get/{words}")]
        public IEnumerable<String> Get(int words)
        {
            return callurl(words).ToArray();
        }

        [HttpGet("/[controller]/save/{name}/{password}")]
        public string Save(int id, string name, string password)
        {
            Account acc = new Account(name, password);
            context.Accounts.Add(acc);
            context.SaveChanges();
            return "Account added";
        }


    }
}
