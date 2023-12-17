using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.IO;

namespace ConsoleMenuAPI {
    public class LocalizationXMLFile : ILocalizationFile {
        public const string FileRootKey = "localization";
        public const string DictionaryElementKey = "dictionary";
        const string DictionaryAttributeKey = "lang";
        public const string ErrorString = "NULL";
        
        static IEnumerable<XElement> IfEmptyNull(IEnumerable<XElement> item) {
            return item.Count() != 0 ? item : null;
        }

        readonly string path;

        public LocalizationXMLFile(string filePath) {
            if (!File.Exists(filePath))
                throw LocalizationErrors.NoFileFound;
            path = filePath;
        }

        public Dictionary<int, string> GetDictionary(string dictionaryKey) {
            Dictionary<int, string> dictionary = new Dictionary<int, string>();
            var elements = new NotNull<XDocument>(XDocument.Load(path))
                .Check((doc) => doc.Element(FileRootKey), LocalizationErrors.NoRootInFile)
                .Check((root) => IfEmptyNull(root.Elements(DictionaryElementKey)), LocalizationErrors.NoDictionariesInFile)
                .Check((dics) => dics.FirstOrDefault(d => d.Attribute(DictionaryAttributeKey)?.Value == dictionaryKey), LocalizationErrors.DictionaryNotFound)
                .Check((dic) => IfEmptyNull(dic.Elements()), LocalizationErrors.EmptyDicitonary);
            foreach (var line in elements.Value) 
                dictionary.Add(line.Name.LocalName.GetHashCode(), line?.Value ?? ErrorString);
            return dictionary;
        }
    }
}