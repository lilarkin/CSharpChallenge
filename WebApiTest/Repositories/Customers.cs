using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiTest.Repositories
{
    public static class Customers
    {
        public static List<Models.Customer> GetCustomers()
        {
            List<Models.Customer> customers = new List<Models.Customer>();
            customers.Add(new Models.Customer()
        {
            Id = 1,
            Name = "Customer 1"
        });

        customers.Add(new Models.Customer()
        {
            Id = 2,
            Name = "Customer 2"
        });

            return customers;
    }

    public static Models.Customer GetCustomer(int id)
    {
            switch (id)
            {
                case 1:
                    return new Models.Customer()
                    {
                        Id = 1,
                        Name = "Customer 1"
                    };
                case 2:
                    return new Models.Customer()
                    {
                        Id = 2,
                        Name = "Customer 2"
                    };
                default:
                    return new Models.Customer();
            }
        }
    }
}