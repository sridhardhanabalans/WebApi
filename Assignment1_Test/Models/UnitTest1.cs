using Microsoft.VisualStudio.TestTools.UnitTesting;
using Assignment1_Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1_Api.Models.Tests
{
    [TestClass()]
    public class UnitTest1
    {
        DALLayer dalLayer = new DALLayer();

        [TestMethod()]
        public void GetSuppliersTest()
        {
            var result=dalLayer.GetSuppliers().Count;

            Assert.IsTrue(result>0);
        }

        [TestMethod()]
        public void GetItemsTest()
        {
            var result = dalLayer.GetItems().Count;

            Assert.IsTrue(result > 0);
        }

        [TestMethod()]
        public void GetPOMasterTest()
        {
            var result = dalLayer.GetPOMaster().Count;

            Assert.IsTrue(result > 0);
        }

        [TestMethod()]
        public void GetPODetailsTest()
        {
            var result = dalLayer.GetPODetails().Count;

            Assert.IsTrue(result > 0);
        }

        [TestMethod()]
        public void AddPOMasterTest()
        {
            POMaster value = new POMaster();
            value.PONO = "6";
            value.PODATE = DateTime.Now.AddDays(-6);
            value.SUPLNO = "4";
            var result=dalLayer.AddPOMaster(value);
            Assert.IsTrue(result == 1);
        }

        [TestMethod()]
        public void DeletePOMasterTest()
        {
            var result = dalLayer.DeletePOMaster("5");
            Assert.IsTrue(result == 2);
        }
    }
}