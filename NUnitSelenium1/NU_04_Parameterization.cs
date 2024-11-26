using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUnitSelenium1
{
    internal class NU_04_Parameterization
    {
        [TestCase("vijay@g.com", "P@ssw0rd")]
        [TestCase("ram@g.com", "P@ssw0rd")]
        [TestCase("jerry@g.com", "P@ssw0rd")]
        public void LoginTest(string username, string password)
        {

            Console.WriteLine(username + " " + password);

        }

        #region :: TestCaseSource ::
        [Test, TestCaseSource("GetTestData")]
        public void UserRegTest(string firstname, string lastname)
        {
            Console.WriteLine(firstname + " ---" + lastname);
        }

        public static IEnumerable<TestCaseData> GetTestData()
        {

            //Yield will wait until all returns are successfully completed
            //The purpose of using Yield is to return a value from the iterator method
            //and temporarily suspends its execution until the next value is requested.
            //This allows the method to resume execution from where it left off when the next value is needed
            yield return new TestCaseData("Vijay", "Reddy");
            yield return new TestCaseData("Sri", "Ram");
            yield return new TestCaseData("Tom", "Jerry");


        }
        #endregion

    }
}
