using Microsoft.AspNetCore.Mvc;
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
        public async Task<Dictionary<string, int>> GetWordCount()
        {
            using (StreamReader reader = new StreamReader(Request.Body, Encoding.UTF8)) //Necesarry workaround to enable post request using plain/text format
            {
                string inputString = await reader.ReadToEndAsync();
                var result = _wordCounterService.GetWordOccurence(inputString);

                return result; 
            }
        }

    }

}

