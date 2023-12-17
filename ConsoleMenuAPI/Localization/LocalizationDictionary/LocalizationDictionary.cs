using System.Collections.Generic;

namespace ConsoleMenuAPI {
    public abstract class LocalizationDictionary : ILocalizationDictionary {
        const string errorString = "NULL";

        readonly protected Dictionary<int, string> dictionary;

        public string this[int key] => GetItem(key);
        public abstract ServiceItemsLocalization ServiceLocalization { get; }

        protected LocalizationDictionary(Dictionary<int, string> localization) {
            dictionary = localization;
        }

        protected LocalizationDictionary() {
            dictionary = new Dictionary<int, string>();
        }

        public string GetItem(int key) {
            if (dictionary.TryGetValue(key, out string value))
                return value;
            return errorString;
        }

        protected void AddItem(int key, string value) {
            dictionary.Add(key, value);
        }
    }
}
