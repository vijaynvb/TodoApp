namespace NUnitSelenium1
{


   // [TestFixture]

    public class TestSuite1 : BaseTest
    {
        // employee
        [SetUp]
        public void BeforeEachTestCase()
        {
            // connect to departments -> prepare db 
            Console.WriteLine("Before each test ");
        }
        [TearDown]
        public void AfterEachTestCase()
        {
            Console.WriteLine("After each test ");
        }

        [Test]
        public void Test1()
        {
            Console.WriteLine("My Test case 1");
            Assert.Pass();
        }
    }
}