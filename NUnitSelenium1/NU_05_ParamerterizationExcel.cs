using NunitSelenium.Utilities;

namespace NUnitSelenium1
{
    internal class NU_05_ParamerterizationExcel
    {
        // 
        [Test, TestCaseSource(nameof(GetTestData))]
        public void LoginTest(string username, string password)
        {
            Console.WriteLine(username + " " + password);
        }
        public static IEnumerable<TestCaseData> GetTestData()
        {
            var columns = new List<string> { "username", "password" };
            return ExcelReadUtil.GetTestDataFromExcel(Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName + "\\resources\\testdata.xlsx", "LoginTest", columns);
        }

        [Test, TestCaseSource("GetUserRegTestData")]
        public void UserRegTest(string firstname, string lastname)
        {
            Console.WriteLine(firstname + " ---" + lastname);
        }

        public static IEnumerable<TestCaseData> GetUserRegTestData()
        {
            var columns = new List<string> { "firstname", "lastname" };
            return ExcelReadUtil.GetTestDataFromExcel(Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName + "\\resources\\testdata.xlsx", "UserRegTest", columns);
        }

    }
}
