using NUnit.Framework;

namespace Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            WebApplication2.Class test = new WebApplication2.Class();
            test.add();
            Assert.Pass();
        }
    }
}