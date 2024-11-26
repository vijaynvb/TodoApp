namespace NUnitSelenium1
{
    public class NU_01_Basics
    {
        [SetUp]
        public void LaunchBrowser()
        {
            Console.WriteLine("Launching the browser");
        }

        [TearDown]
        public void CloseBrowser()
        {

            Console.WriteLine("Closing the browser");
        }


        [Test, Order(1), Category("smoke")]
        public void DoUserReg()
        {

            Console.WriteLine("Executing User Reg Test");

        }


        [Test, Order(2), Category("smoke")]
        public void DoLogin()
        {

            Console.WriteLine("Executing Login Test");

        }

        [Test, Order(3), Category("bvt"), Ignore("Ignoring the test case")]
        public void Test3()
        { 
            Console.WriteLine("Executing Ignore");
        }


        [Test, Order(4), Category("functional")]
        public void Test4()
        {
        }


        [Test, Order(5), Category("functional")]
        public void Test5()
        {
        }
    }
}