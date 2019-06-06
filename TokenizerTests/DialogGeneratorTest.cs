using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DialogEngine
{
    [TestClass]
    public class DialogGeneratorTest
    {
        private const string FILEPATH = "C:\\Users\\brogr\\source\\repos\\DialogEngine\\TokenizerTests\\TestData\\test1.txt.txt";

        [TestMethod]
        public void TestTokenizer()
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
