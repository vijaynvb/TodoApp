using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.DevTools.V129.DOM;
using OpenQA.Selenium.Support.UI;

namespace NunitSelenium
{
    internal class NU_12_DBConnection
    {
        static IWebDriver driver;
        SqlConnection conn;
        List<string> TestData;
        SqlDataReader reader;

       [OneTimeSetUp]
        public void OpenConnection()
        {
            string server = "(localdb)\\MSSQLLocalDB";
            string db = "TestDB";
            String connectionString = $"Server={server};Database={db};Integrated Security = True;MultipleActiveResultSets=true";
            conn = new SqlConnection(connectionString);
            conn.Open();
        }


            [SetUp]
        public void SetUp()
        {
            SqlCommand cmd = new SqlCommand("select * from TestData", conn);
            reader = cmd.ExecuteReader();
            TestData = new List<string>();
            while (reader.Read())
            {
                string row = $"{reader[0]} {reader[1]} {reader[2]}";
                TestData.Add(row);
                //Console.WriteLine(row);
            }
        }


        [Test]
         public void WikiPage()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Url = "https://www.wikipedia.org/";
            
            driver.Manage().Window.Maximize();

            // read data from the db and use it in testcases
            TestData.ForEach(TestData =>
            {
               Console.WriteLine(TestData);
            });
        }

        [TearDown]
        public void TearDown()
        {
            if (driver != null)
            {
                driver.Dispose();
                driver.Quit();
            }
            if(reader != null)
            {
                reader.Close();
            }
        }

        [OneTimeTearDown]
        public void CloseConnection()
        {
            conn.Close();
        }
    }
}
