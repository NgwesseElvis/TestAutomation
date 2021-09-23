using NUnit.Framework;
using PageObjectProject.Hooks;

namespace TestProject
{
    public class Tests : Hook
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }
    }
}