using SoftUniTestingFramework.Runner;
using System;

namespace MySpecialApp
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            TestRunner testRunner = new TestRunner();
            var resultSet = testRunner
                .Run(@"C:\Users\Valio\Desktop\MySpecialApp.Tests\bin\Debug\netcoreapp2.2\MySpecialApp.Tests.dll");

            foreach (var item in resultSet)
            {
                Console.WriteLine(item);
            }
        }
    }
}
