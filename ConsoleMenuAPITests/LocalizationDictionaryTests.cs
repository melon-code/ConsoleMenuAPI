using NUnit.Framework;
using ConsoleMenuAPI;
using System.Collections.Generic;
using System;

namespace ConsoleMenuAPITests {
    public class LocalizationDictionaryTests {
        int OnKey => Utility.OnKey;
        int OffKey => Utility.OffKey;
        int InputKey => Utility.InputKey;
        int ExitKey => Utility.ExitKey;
        
        public static void ConstructorTest(Dictionary<int, string> dictionary) {
            Utility.AssertException(() => new ExternalLocalizationDictionary(dictionary), LocalizationErrors.NoMenuItemsLocalization.Message);
        }

        [Test]
        public void EmptyDictionaryConstructorExceptionTest() {
            ConstructorTest(new Dictionary<int, string>());
        }

        [Test]
        public void PartialDictionaryConstructorExceptionTest() {
            ConstructorTest(new Dictionary<int, string>() { { OnKey, "On" }, { OffKey, "Exit" } });
        }

        [Test]
        public void ValidDictionaryConstructorTest() {
            Dictionary<int, string> dicitonary = new Dictionary<int, string>() { { OnKey, "on" }, { OffKey, "off" }, { InputKey, "Input" }, { ExitKey, "exit" } };
            Assert.DoesNotThrow(() => new ExternalLocalizationDictionary(dicitonary));
        }
    }
}