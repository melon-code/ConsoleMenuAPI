using System;

namespace ConsoleMenuAPI {
    public static class LocalizationErrors {
        const string noLocalizationFileMessage = "Localization file does not exist";
        const string noRootInFileMessage = "Localization file has no <localization> entry";
        const string noDictionariesInFileMessage = "Localization file has no <dictionary> entries";
        const string dictionaryNotFoundMessage = "Localization file has no dictionary with corresponding key";
        const string emptuDictionaryMessage = "Selected dictionary is empty";
        const string noMenuItemsLocalizationMessage = "Dictionary must have entries for OnTitle, OffTitle, InputNumber, ExitString";

        public static ArgumentException NoFileFound => new ArgumentException(noLocalizationFileMessage);
        public static ArgumentException NoRootInFile => new ArgumentException(noRootInFileMessage);
        public static ArgumentException NoDictionariesInFile => new ArgumentException(noDictionariesInFileMessage);
        public static ArgumentException DictionaryNotFound => new ArgumentException(dictionaryNotFoundMessage);
        public static ArgumentException EmptyDicitonary => new ArgumentException(emptuDictionaryMessage);
        public static ArgumentException NoMenuItemsLocalization => new ArgumentException(noMenuItemsLocalizationMessage);
    }
}