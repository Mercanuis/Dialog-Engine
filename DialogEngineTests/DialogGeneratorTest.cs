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
        private readonly string FILEPATH = Path.Combine(Environment.CurrentDirectory, @"TestData\", "test1.txt");
        private readonly string BAD_FILEPATH = Path.Combine(Environment.CurrentDirectory, @"TestData\", "BAD.txt");

        [TestMethod]
        public void TestGenerator_BadFilePath()
        {
            try
            {
                DialogManager mgmr = new DialogManager();
                DialogPrinter underTest = mgmr.GetForScript(BAD_FILEPATH);
            }
            catch (ScriptNotFoundException e)
            {
                Assert.IsTrue(e.Message.Contains("The following script could not be found"));
            }
        }

        [TestMethod]
        public void TestGenerator()
        {
            DialogManager mgmr = new DialogManager();
            DialogPrinter underTest = mgmr.GetForScript(FILEPATH);
           
            string expectedActor = "Arin : What do you say, suck my dick?";
            Assert.AreEqual(expectedActor, underTest.GetNextDialogLine());
        }

        [TestMethod]
        public void TestDialogPrinter()
        {
            DialogManager mgmr = new DialogManager();
            DialogPrinter underTest = mgmr.GetForScript(FILEPATH);

            Assert.AreEqual("Arin : What do you say, suck my dick?", underTest.GetNextDialogLine());
            Assert.AreEqual("Danny : Arin!? Really!? I thought you'd never ask!", underTest.GetNextDialogLine());
            Assert.AreEqual("____END____", underTest.GetNextDialogLine());
        }
    }
}
