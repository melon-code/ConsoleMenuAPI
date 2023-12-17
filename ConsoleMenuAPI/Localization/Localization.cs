namespace ConsoleMenuAPI {
    public static class Localization {
        static ILocalizationDictionary currentDictionary = new RusLangDictionary();

        static ServiceItemsLocalization ServiceLocalization => currentDictionary.ServiceLocalization;
        public static string OnTitle => ServiceLocalization.OnTitle;
        public static string OffTitle => ServiceLocalization.OffTitle;
        public static string InputNumber => ServiceLocalization.InputNumber;
        public static string ExitString => ServiceLocalization.ExitString;

        public static void ChangeLanguage(ILocalizationDictionary dictionary) {
            currentDictionary = dictionary;
        }

        public static string GetString(int key) {
            return currentDictionary.GetItem(key);
        }
    }
}