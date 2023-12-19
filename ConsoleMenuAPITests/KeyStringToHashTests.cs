using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using ConsoleMenuAPI;

namespace ConsoleMenuAPITests {
    class KeyStringToHashTests {
        const string key = "some";

        static int KeyInt => key.GetHashCode();
        
        [Test]
        public void ArrayTest() {
            const string key2 = "title";
            KeyStringToHashArray keys = new KeyStringToHashArray(new string[] { key, key2 });
            Assert.AreEqual(keys[0], KeyInt);
            Assert.AreEqual(keys[1], key2.GetHashCode());
        }

        [Test]
        public void StringKeyTest() {
            KeyStringToHash keys = new KeyStringToHash();
            Assert.AreEqual(keys[key], KeyInt);
        }
    }
}
