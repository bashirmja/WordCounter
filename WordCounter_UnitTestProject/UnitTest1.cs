using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WordCounter_ClassLibrary;
using System.IO;

namespace WordCounter_UnitTestProject
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod_Empty()
        {
            WordCounter w = new WordCounter();

            Dictionary<string, int> result = w.CountInputText("");

            Assert.AreEqual(result.Count, 0);
        }

        [TestMethod]
        public void TestMethod_OneWord()
        {
            WordCounter w = new WordCounter();

            Dictionary<string, int> result = w.CountInputText("My");

            Assert.AreEqual(result.Count, 1,"count of keys");
            Assert.AreEqual(result["my"], 1, "number of'My'");
        }

        [TestMethod]
        public void TestMethod_OneSentence()
        {
            WordCounter w = new WordCounter();

            Dictionary<string, int> result = w.CountInputText("Go do that thing that you do so well");

            Assert.AreEqual(result.Count, 7, "count of keys");
            Assert.AreEqual(result["go"], 1);
            Assert.AreEqual(result["do"], 2);
            Assert.AreEqual(result["that"], 2);
            Assert.AreEqual(result["thing"], 1);
            Assert.AreEqual(result["you"], 1);
            Assert.AreEqual(result["so"], 1);
            Assert.AreEqual(result["well"], 1);

        }

        [TestMethod]
        public void TestMethod_DoubleSpace()
        {
            WordCounter w = new WordCounter();

            Dictionary<string, int> result = w.CountInputText("  ");

            Assert.AreEqual(result.Count, 0);
        }


        [TestMethod]
        public void TestMethod_WithSign()
        {
            WordCounter w = new WordCounter();

            Dictionary<string, int> result = w.CountInputText("How are you? ");

            Assert.AreEqual(result.Count, 3);
            Assert.AreEqual(result["how"], 1);
            Assert.AreEqual(result["are"], 1);
            Assert.AreEqual(result["you"], 1);
        }

        [TestMethod]
        public void TestMethod_FileInput()
        {
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string path = desktopPath+@"\a.txt";
            System.IO.StreamWriter f =new System.IO.StreamWriter(path, true);
            f.WriteLine("Go do that thing that you do so well");
            f.Close();

            WordCounter w = new WordCounter();
            Dictionary<string, int> result = w.CountInputFile(path);

            File.Delete(path);

            Assert.AreEqual(result.Count, 7, "count of keys");
            Assert.AreEqual(result["go"], 1);
            Assert.AreEqual(result["do"], 2);
            Assert.AreEqual(result["that"], 2);
            Assert.AreEqual(result["thing"], 1);
            Assert.AreEqual(result["you"], 1);
            Assert.AreEqual(result["so"], 1);
            Assert.AreEqual(result["well"], 1);
        }
        

        [TestMethod]
        public void TestMethod_WithSigns()
        {
            WordCounter w = new WordCounter();

            Dictionary<string, int> result = w.CountInputText(@"//D:\Windows\system32");

            Assert.AreEqual(result.Count, 3);
            Assert.AreEqual(result["d"], 1);
            Assert.AreEqual(result["windows"], 1);
            Assert.AreEqual(result["system"], 1);
        }

        [TestMethod]
        public void TestMethod_UpperCase()
        {
            WordCounter w = new WordCounter();

            Dictionary<string, int> result = w.CountInputText("Delta delta");

            Assert.AreEqual(result.Count, 1);
            Assert.AreEqual(result["delta"], 2);
            
        }

    }
}
