using System.Collections.Generic;

namespace ConsoleMenuAPI {
    public class LocalizationDictionary {
        const string errorString = "NULL";
        public const int OnTitleKey = 1;
        public const int OffTitleKey = 2;
        public const int InputNumberKey = 3;
        public const int ExitStringKey = 4;

        readonly protected Dictionary<int, string> dictionary;

        public string this[int key] => GetItem(key);

        protected LocalizationDictionary(string onTitle, string offTitle, string inputNumber, string exitString) {
            dictionary = new Dictionary<int, string>{
                { OnTitleKey, onTitle },
                { OffTitleKey, offTitle },
                { InputNumberKey, inputNumber },
                { ExitStringKey, exitString }
            };
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
