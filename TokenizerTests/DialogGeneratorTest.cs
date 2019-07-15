using Microsoft.VisualStudio.TestTools.UnitTesting;
using Errors;
using System.Collections.Generic;
using System.IO;
using System;

namespace DialogEngine
{
    [TestClass]
    public class DialogGeneratorTest
    {
        // TODO: This is ugly, learn about relative paths, the issue seems to stem from something in netcore2.1, not sure what
        private string FILEPATH = "C:\\Users\\brogr\\source\\repos\\DialogEngine\\TokenizerTests\\TestData\\test1.txt";
        private const string BAD_FILEPATH = "C:\\Users\\brogr\\source\\repos\\DialogEngine\\TokenizerTests\\TestData\\testBAD.txt";

        [TestMethod]
        public void TestGenerator_BadFilePath()
        {
            try
            {
                DialogGenerator underTest = new DialogGenerator(BAD_FILEPATH);
            }
            catch (ScriptNotFoundException e)
            {
                Assert.AreEqual("DialogException: The following script could not be found: C:\\Users\\brogr\\source\\repos\\DialogEngine\\TokenizerTests\\TestData\\testBAD.txt", e.Message);
            }
        }

        [TestMethod]
        public void TestGenerator()
        {
            DialogGenerator underTest = new DialogGenerator(FILEPATH);
            Queue<string> result = underTest.getLines();
            Assert.AreEqual(2, result.Count);

            string expectedActor = "Arin : What do you say, suck my dick?";
            Assert.AreEqual(expectedActor, result.Dequeue());
        }

        [TestMethod]
        public void TestDialogPrinter()
        {
            DialogGenerator generator = new DialogGenerator(FILEPATH);
            Queue<string> lines = generator.getLines();
            DialogPrinter printer = new DialogPrinter(lines);

            Assert.AreEqual("Arin : What do you say, suck my dick?", printer.GetNextDialogLine());
            Assert.AreEqual("Danny : Arin!? Really!? I thought you'd never ask!", printer.GetNextDialogLine());
            Assert.AreEqual("____END____", printer.GetNextDialogLine());
        }
    }
}
