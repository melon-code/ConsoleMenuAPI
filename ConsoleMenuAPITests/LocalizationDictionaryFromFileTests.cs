using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using ConsoleMenuAPI;

namespace ConsoleMenuAPITests {
    class LocalizationDictionaryFromFileTests {
        const string fileName = "localizationfile";
        const string rusLangKey = "rus", engLangKey = "eng";
        const string exitEng = "Exit", exitRus = "Выход";
        const string onEng = "On", onRus = "Вкл";


        static LocalizationDictionaryFromFile CreateDicitonary() {
            return new LocalizationDictionaryFromFile(Utility.GetPath(fileName), engLangKey);
        }

        static void CheckExitString(string expectedExitString, ILocalizationDictionary dictionary) {
            Assert.AreEqual(expectedExitString, dictionary.GetItem(Utility.ExitKey));
        }

        static void CheckServiceString(string expected, string service) {
            Assert.AreEqual(expected, service);
        }

        [Test]
        public void SetNewDictionaryTest() {
            LocalizationDictionaryFromFile dictionary = CreateDicitonary();
            CheckExitString(exitEng, dictionary);
            dictionary.SetNewDictionary(rusLangKey);
            CheckExitString(exitRus, dictionary);
        }

        [Test]
        public void LocalizationTest() {
            LocalizationDictionaryFromFile dictionary = CreateDicitonary();
            Localization.ChangeLanguage(dictionary);
            CheckServiceString(onEng, Localization.OnTitle);
            dictionary.SetNewDictionary(rusLangKey);
            CheckServiceString(onRus, Localization.OnTitle);
        }
    }
}
