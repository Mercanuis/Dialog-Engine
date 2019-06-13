using Microsoft.VisualStudio.TestTools.UnitTesting;
using Errors;

namespace DialogEngine
{
    [TestClass]
    public class DialogGeneratorTest
    {
        private const string FILEPATH = "C:\\Users\\brogr\\source\\repos\\DialogEngine\\TokenizerTests\\TestData\\test1.txt.txt";
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
            DialogMap result = underTest.GetDialog();
            Assert.AreEqual(2, result.GetCount());

            string expectedActor = "Arin";
            string expected = "What do you say, suck my dick?";
            Assert.AreEqual(expectedActor, result.GetByKey(0).Actor);
            Assert.AreEqual(expected, result.GetByKey(0).Dialog);
        }

        [TestMethod]
        public void TestDialogPrinter()
        {
            DialogGenerator generator = new DialogGenerator(FILEPATH);
            DialogMap map = generator.GetDialog();
            DialogPrinter printer = new DialogPrinter(map);

            Assert.AreEqual("Arin: What do you say, suck my dick?", printer.GetNextDialogLine());
            Assert.AreEqual("Danny: Arin!? Really!? I thought you'd never ask!", printer.GetNextDialogLine());
            Assert.AreEqual("____END____", printer.GetNextDialogLine());
        }
    }
}
