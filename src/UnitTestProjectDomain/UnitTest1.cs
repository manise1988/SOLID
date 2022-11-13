using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace UnitTestProjectDomain
{
    [TestClass]
    public class UnitTest1
    {
        
        [TestMethod]
        public void TestMethod1()
        {

              

                bool result = true;
                Assert.IsTrue(result);
            
        }
        [TestMethod]
        public void TestMethod2()
        {



            bool result = false;
            Assert.IsTrue(result);

        }
    }
}
