using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUnitSelenium1
{
    internal class NU_02_Asserts
    {
        //[Test]

        public void ValidateTitles() // failed test case
        {
            // A A A
            // Arrange, Act, Assert

            string expectedTitle = "Google.com"; //excel sheet
            string actualTitle = "Yahoo.com"; //title
            int expected = 18;
            int actual = 15;



            //if (!expectedTitle.Equals(actualTitle))
            //{
            //    Console.WriteLine("Test Case fail");
            //    Assert.Fail("Failing the test as the condition is not met");
            //}
            //else
            //{
            //    Console.WriteLine("Test case pass");
            //    Assert.Pass("Test case is passed");
            //}

            // actions to be performed


            // options for assertings
            // Assert.That(expectedTitle, Is.EqualTo(actualTitle), "Titles are not matching hence failing the test");
            //  Assert.That((expectedTitle.Equals(actualTitle)), "Element not present hence failing the test case");
            //  Assert.Fail("Failing the test as the condition is not met");

            // more than one test to be done and report all the failures at the end
            Console.WriteLine("Beginning");

            Assert.Multiple(() =>
            {
                Assert.IsNull(actualTitle, "Actual value getting from action is null");

               
                Assert.GreaterOrEqual(expected, actual); // fail
                

                Assert.That(expectedTitle, Is.EqualTo(actualTitle), "Titles are not matching hence failing the test");

                Assert.That(false, "Element not present hence failing the test case");

                Assert.Fail("Failing the test as the condition is not met");

            });

            Console.WriteLine("Ending");
        }

    }
}
