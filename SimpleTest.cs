using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _13_paskaitaClassLibrary
{
    public class SimpleTest
    {
        [Test]
        public static void FirstTest()
        {
            Assert.AreEqual(0, 4 % 2, "4 is not even");
        }
        [Test]
        public static void SecondTest()
        {
            DateTime currentDate = DateTime.Now;
            Assert.IsTrue(19 == currentDate.Hour);
        }
        [Test]
        public static void ThirdTest()
        {
            Assert.AreEqual(0, 995 % 3, "995 doesn't divide by 3");
        }
        [Test]
        public static void DayTest()
        {
            Assert.IsTrue(DateTime.Now.DayOfWeek == DayOfWeek.Thursday);

        }
        [Test]
        public static void WaitTest()
        {
            Thread.Sleep(5000);
            Assert.Pass();
        }
        [Test]
        public static void EvenTest()
        {
            int howManyEvenNumbers = 0;
            for (int i = 0; i < 10; i++)
            {
                if(i != 0 && i % 2 == 0)
                {
                    howManyEvenNumbers++;
                }
            }
            Assert.AreEqual(4, howManyEvenNumbers);
        }
    }
}
