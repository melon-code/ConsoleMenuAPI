using System.Collections.Generic;

namespace ConsoleMenuAPI {
    public interface ILocalizationFile {
        Dictionary<int, string> GetDictionary(string dictionaryKey);
    }
}