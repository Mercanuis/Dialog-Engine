using DialogEngine.Printers;
using DialogEngine.Utilities;
using Errors;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;


namespace DialogEngine
{
    [TestClass]
    public class DialogEngineTests
    {
        private readonly string FILEPATH = Path.Combine(Environment.CurrentDirectory, @"TestData\", "GeneralPrintFile.txt");
        private readonly string REPEATING_FILEPATH = Path.Combine(Environment.CurrentDirectory, @"TestData\", "RepeatingPrintFile.txt");
        private readonly string BATTLE_FILEPATH = Path.Combine(Environment.CurrentDirectory, @"TestData\", "BattleText.txt");

        private readonly string BAD_FILEPATH = Path.Combine(Environment.CurrentDirectory, @"TestData\", "BAD.txt");
        private readonly string INVALID_FILE_PATH = Path.Combine(Environment.CurrentDirectory, @"TestData\", "Invalidfile.txt");



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
            DialogManager mgmr = new DialogManager();
            IDialogPrinter underTest = mgmr.GetForScript(REPEATING_FILEPATH);

            int numLineOne = 0;
            int numbLineTwo = 0;

            for (int i = 0; i < 10; i++)
            {
                string ret = underTest.GetDialogLine();
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

        [TestMethod]
        public void TestBattlePrinter()
        {
            DialogManager mgmr = new DialogManager();
            IDialogPrinter underTest = mgmr.GetForScript(BATTLE_FILEPATH);

            string[] dmgTakenParams = new string[] { "Terra", "25" };
            Assert.AreEqual("Terra takes 25 points of damage.", string.Format(underTest.GetDialogLine(0), dmgTakenParams));

            string[] dmgDealtParams = new string[] { "Setzer", "Goblin", "12" };
            Assert.AreEqual("Setzer hits the Goblin for 12 points of damage.", string.Format(underTest.GetDialogLine(1), dmgDealtParams));

            string[] magDealtParams = new string[] { "Celes", "Ice", "Magitec Armor MkII", "150" };
            Assert.AreEqual("Celes casts Ice! The Magitec Armor MkII takes 150 points of damage.", string.Format(underTest.GetDialogLine(2), magDealtParams));

            //Check to see if extra parameters are ignored, in case they're accidentially sent
            string[] dmgTakenParams2 = new string[] { "Terra", "25", "35" };
            Assert.AreEqual("Terra takes 25 points of damage.", string.Format(underTest.GetDialogLine(0), dmgTakenParams2));
        }

        [TestMethod]
        public void TestInvalidType()
        {
            DialogManager mgmr = new DialogManager();
            IDialogPrinter underTest = mgmr.GetForScript(INVALID_FILE_PATH);
            Assert.AreEqual("This should be findable, but exception was thrown", underTest.GetDialogLine());
            Assert.AreEqual("____END____", underTest.GetDialogLine());

        }
    }
}
