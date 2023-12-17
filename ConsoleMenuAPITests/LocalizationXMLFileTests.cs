using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using ConsoleMenuAPI;

namespace ConsoleMenuAPITests {
    class LocalizationXMLFileTests {
        const string testFileName = "testlocalization";

        static void CheckException(string name, string message, string dictionaryKey) {
            Utility.AssertException(() => new LocalizationXMLFile(Utility.GetPath(name)).GetDictionary(dictionaryKey), message);
        }

        static void CheckException(string path, string message) {
            CheckException(path, message, "nokey");
        }

        static int GetIntKey(string stringKey) {
            return stringKey.GetHashCode();
        }

        static void AssertContains(Dictionary<int, string> dictionary, string key, string expectedValeu) {
            Assert.IsTrue(dictionary.TryGetValue(GetIntKey(key), out string value));
            Assert.AreEqual(expectedValeu, value);
        }

        [Test]
        public void NoFileTest() {
            const string path = @"\directory\file.xml";
            Utility.AssertException(() => new LocalizationXMLFile(path), LocalizationErrors.NoFileFound.Message);
        }

        [Test]
        public void NoLocalizationFileTest() {
            const string name = "nolocalization";
            CheckException(name, LocalizationErrors.NoRootInFile.Message);
        }

        [Test]
        public void EmptyLocalizationFileTest() {
            const string name = "emptylocalization";
            CheckException(name, LocalizationErrors.NoDictionariesInFile.Message);
        }

        [Test]
        public void NotFoundDictionaryTest() {
            CheckException(testFileName, LocalizationErrors.DictionaryNotFound.Message);
        }

        [Test]
        public void GetEmptyDictionaryTest() {
            const string emptyDictionaryKey = "eng";
            CheckException(testFileName, LocalizationErrors.EmptyDicitonary.Message, emptyDictionaryKey);
        }

        [Test]
        public void GetDictionaryTest() {
            const string key = "rus";
            const int expectedDictionaryCount = 2;
            const string onValue = "Вкл", offValue = "Выкл";
            var dictionary = new LocalizationXMLFile(Utility.GetPath(testFileName)).GetDictionary(key);
            Assert.AreEqual(expectedDictionaryCount, dictionary.Count);
            AssertContains(dictionary, ExternalLocalizationDictionary.OnTitleKey, onValue);
            AssertContains(dictionary, ExternalLocalizationDictionary.OffTitleKey, offValue);
        }
    }
}
