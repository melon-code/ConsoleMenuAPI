using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using ConsoleMenuAPI;

namespace ConsoleMenuAPITests {
    class ExitItemTests {
        static void AssertExitString(string expected, ExitItem item) {
            Assert.AreEqual(expected, item.GetString());
        }
        
        [Test]
        public void GetStringTest() {
            const string exit = "string";
            AssertExitString(exit, new ExitItem(exit));
            Assert.AreEqual(Localization.ExitString, new ExitItem().GetString());
        }

        [Test]
        public void GetStringDefault() {
            AssertExitString(Localization.ExitString, new ExitItem());
        }
    }
}
