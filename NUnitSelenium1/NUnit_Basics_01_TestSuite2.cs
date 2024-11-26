using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUnitSelenium1
{
   // [TestFixture]
    public class TestSuite2 : BaseTest
    {
        
        // department
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
        [Test]
        public void Test2()
        {
            Console.WriteLine("My Test case 2");
            Assert.Pass();
        }
    }
}
