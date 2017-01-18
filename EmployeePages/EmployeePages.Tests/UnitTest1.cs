using System;
using EmployeePages.Controllers;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace EmployeePages.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
        }

        [TestMethod]
        public void TestFilter()
        {
            HomeController hc = new HomeController();
           
            //var result = hc.Filter("FirstName", "Sandy");
            //Assert.AreEqual(1, result);
            
            
        }

        [TestMethod]
        public void TestSort()
        {
            HomeController hc = new HomeController();
            //var result = hc.Sort("FirstName", true);
        }
    }
}
