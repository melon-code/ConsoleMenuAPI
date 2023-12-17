namespace ConsoleMenuAPI {
    public class LocalizationDictionaryFromFile : ILocalizationDictionary {
        readonly ILocalizationFile file;
        ExternalLocalizationDictionary currentDictionary;

        public string CurrentDictionaryKey { get; private set; }
        public ServiceItemsLocalization ServiceLocalization => currentDictionary.ServiceLocalization;

        public LocalizationDictionaryFromFile(string filePath, string dictionaryKey) {
            file = new LocalizationXMLFile(filePath);
            SetNewDictionary(dictionaryKey);
        }

        public LocalizationDictionaryFromFile(ILocalizationFile localizationFile) {
            file = localizationFile;
        }

        public void SetNewDictionary(string dictionaryKey) {
            currentDictionary = new ExternalLocalizationDictionary(file.GetDictionary(dictionaryKey));
            CurrentDictionaryKey = dictionaryKey;
        }

        public string GetItem(int key) {
            return currentDictionary.GetItem(key);
        }
    }
}