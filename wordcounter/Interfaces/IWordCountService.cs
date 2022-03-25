using System.Collections.Generic;
using wordcounter.Model;

namespace wordcounter.Interfaces
{
    public interface IWordCountService
    {
        List<WordOccurence> GetWordOccurence(string inputString);
    }
}
