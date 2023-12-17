using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace ConsoleMenuAPITests {
    public static class Utility {
        const string filesDirectory = @"XML files";
        const string xmlTag = ".xml";

        public static string GetPath(string fileName) {
            return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, filesDirectory, fileName + xmlTag);
        }

        public static void AssertException(TestDelegate code, string expectedMessage) {
            Assert.AreEqual(expectedMessage, Assert.Throws<ArgumentException>(code).Message);
        }
    }
}
