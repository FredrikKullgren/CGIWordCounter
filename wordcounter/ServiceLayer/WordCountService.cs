using System;
using System.Collections.Generic;
using System.Linq;
using wordcounter.Interfaces;
using wordcounter.Model;

namespace wordcounter.ServiceLayer
{
    public class WordCountService : IWordCountService
    {

        public Dictionary<string, int> GetWordOccurence(string sourceString) //List<WordOccurence>
        {
            //Trimming quotation marks and whitespaces if text is pasted into for example postman and the user decides to add quotation marks...
            var trimmedEdges = sourceString.Trim();
            var trimmedLeading = trimmedEdges.TrimStart('"');
            var trimmedResult = trimmedLeading.TrimEnd('"');

            var splittedList = trimmedResult.Split(new[] { " ", "\n" , "\r", "\t", ".", ",", "?", "!", "(", ")" }, StringSplitOptions.RemoveEmptyEntries).ToList();
            var lowerCaseStringList = splittedList.Select(x => x.ToLower()).ToList();

            IEnumerable<WordOccurence> topList = lowerCaseStringList
            .GroupBy(w => w)
            .Select(g => new WordOccurence { Word = g.Key, Count = g.Count() })
            .OrderByDescending(o => o.Count);
            //.Take(10);

            Dictionary<string, int> result = topList.ToDictionary(x => x.Word, x => x.Count);

            return result;
        }
    }
}
