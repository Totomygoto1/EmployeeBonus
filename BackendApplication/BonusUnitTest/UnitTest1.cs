using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using BackendApplication.Factory;
using BackendApplication.Models;
using BackendApplication;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace BonusUnitTest
{
    [TestClass]
    public class UnitTest1
    {

        public int TestLowBonusValue()
        {
            ConcreteCreator cc = new ConcreteCreator();

            cc.CreateEmployeeList();
            int check = cc.CheckToLowEmployeeBonus();

            return check;
        }

        [TestMethod]
        public void TestMethod1()
        {
            // Tests that All Employee Bonuses stored in List is not below 1000 ... if 1 value is below, it returns 0..

            int pass = 1;

            int check = TestLowBonusValue();

            Assert.AreEqual(pass, check);
        }

    }
}
