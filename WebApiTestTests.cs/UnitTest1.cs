using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace WebApiTestTests.cs
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void CountCustomers()
        {
            List<WebApiTest.Models.Customer> customers = WebApiTest.Repositories.Customers.GetCustomers();

            Assert.IsTrue(customers.Count > 0);
        }

        [TestMethod]
        public void GetCustomer()
        {
            WebApiTest.Models.Customer cust = WebApiTest.Repositories.Customers.GetCustomer(1);

            string custName = cust == null ? string.Empty : cust.Name;

            Assert.IsTrue(custName.Equals("Customer 1"));
        }
    }
}
