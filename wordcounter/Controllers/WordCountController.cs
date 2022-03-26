using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wordcounter.Interfaces;
using wordcounter.Model;

namespace wordcounter.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WordCountController : ControllerBase
    {

        private readonly IWordCountService _wordCounterService;

        public WordCountController(IWordCountService wordCounterService)
        {
            _wordCounterService = wordCounterService;
        }


        [HttpPost]
        public async Task<ActionResult<Dictionary<string, int>>> GetWordCount()
        {
            
            using (StreamReader reader = new StreamReader(Request.Body, Encoding.UTF8)) //Necesarry workaround to enable post request using plain/text format
            {
                try
                {
                    string inputString = await reader.ReadToEndAsync();
                    return _wordCounterService.GetWordOccurence(inputString);
                }
                catch(Exception e)
                {
                    return BadRequest(e.Message);
                }
                
            }
        }

    }

}

