using System.Collections.Generic;
using wordcounter.Model;

namespace wordcounter.Interfaces
{
    public interface IWordCountService
    {
        Dictionary<string, int> GetWordOccurence(string inputString);
    }
}
