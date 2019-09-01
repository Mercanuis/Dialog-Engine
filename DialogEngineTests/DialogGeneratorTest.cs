using Microsoft.VisualStudio.TestTools.UnitTesting;
using Errors;
using System.IO;
using System;
using System.Collections.Generic;

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
                IDialogPrinter underTest = mgmr.GetForScript(BAD_FILEPATH);
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
            IDialogPrinter underTest = mgmr.GetForScript(FILEPATH);
           
            string expectedActor = "Arin : What do you say, suck my dick?";
            Assert.AreEqual(expectedActor, underTest.GetDialogLine());
        }

        [TestMethod]
        public void TestDialogPrinter()
        {
            DialogManager mgmr = new DialogManager();
            IDialogPrinter underTest = mgmr.GetForScript(FILEPATH);

            Assert.AreEqual("Arin : What do you say, suck my dick?", underTest.GetDialogLine());
            Assert.AreEqual("Danny : Arin!? Really!? I thought you'd never ask!", underTest.GetDialogLine());
            Assert.AreEqual("____END____", underTest.GetDialogLine());
        }

        [TestMethod]
        public void TestRepeatingPrinter()
        {
            Queue<string> queue = new Queue<string>();
            queue.Enqueue("Welcome to Corneria");
            queue.Enqueue("I like swords");
            RepeatingPrinter repeating = new RepeatingPrinter(queue);

            int numLineOne = 0;
            int numbLineTwo = 0;

            for (int i = 0; i < 10; i++)
            {
                string ret = repeating.GetDialogLine();
                Console.WriteLine(ret);
                if (ret.Equals("Welcome to Corneria"))
                {
                    numLineOne++;
                }
                else if (ret.Equals("I like swords"))
                {
                    numbLineTwo++;
                }
            }
            Assert.AreEqual(5, numLineOne);
            Assert.AreEqual(5, numbLineTwo);
        }
    }
}
