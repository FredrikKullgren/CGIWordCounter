using System;
using System.Collections.Generic;
using System.Linq;
using wordcounter.Interfaces;
using wordcounter.Model;

namespace wordcounter.ServiceLayer
{
    public class WordCountService : IWordCountService
    {

        public List<WordOccurence> GetWordOccurence(string sourceString)
        {
            //Trimming quotation marks and whitespaces if text is pasted into for example postman and the user decides to add quotation marks...
            var trimmedEdges = sourceString.Trim();
            var trimmedLeading = trimmedEdges.TrimStart('"');
            var trimmedResult = trimmedLeading.TrimEnd('"');
             
            var stringList = trimmedResult.Split(new[] { " ", "\n", "\r" }, StringSplitOptions.RemoveEmptyEntries).ToList();
            List<string> lowerCaseStringList = stringList.Select(x => x.ToLower()).ToList();
            var counts = lowerCaseStringList
            .GroupBy(w => w)
            .Select(g => new WordOccurence { Word = g.Key, Count = g.Count() })
            .OrderByDescending(o => o.Count)
            .Take(10).ToList();
            
            return counts;
        }
    }
}
