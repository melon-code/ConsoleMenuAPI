using System.Collections.Generic;

namespace ConsoleMenuAPI {
    public static class Localization {
        static LocalizationDictionary currentDictionary = new RusLangDictionary();

        public static string OnTitle => currentDictionary.GetItem(LocalizationDictionary.OnTitleKey);
        public static string OffTitle => currentDictionary.GetItem(LocalizationDictionary.OffTitleKey);
        public static string InputNumber => currentDictionary.GetItem(LocalizationDictionary.InputNumberKey);
        public static string ExitString => currentDictionary.GetItem(LocalizationDictionary.ExitStringKey);

        public static void ChangeLanguage(LocalizationDictionary dictionary) {
            currentDictionary = dictionary;
        }

        public static string GetString(int key) {
            return currentDictionary.GetItem(key);
        }
    }
}