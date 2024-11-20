using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumTest
{

    abstract class a
    {
        public abstract void method();
    }
    sealed class c
    {
        public void method()
        {
            Console.WriteLine("Hello World!");
        }
    }
    class b : a
    {
        public override void method()
        {
            Console.WriteLine("Hello World!");
        }
    }


    internal class ExtensionMethods
    {
        public static void Main()
        {
           string str= "hello";
            
            str.MaskedCreditcardDetails(); // extension methods
            a a = new b();

            Console.WriteLine("Hello World!");
        }
    }
    static class ExtensionMethodsOfVijay
    {
        public static void MaskedCreditcardDetails(this String str)
        {

            Console.WriteLine(str);
        }
    }
}
