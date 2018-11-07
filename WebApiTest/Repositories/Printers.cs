using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiTest.Repositories
{
    public static class Printers
    {
        public static List<Models.PrinterInfo> GetPrinters()
        {
            List<Models.PrinterInfo> printers = new List<Models.PrinterInfo>();
            printers.Add(new Models.PrinterInfo()
            {
                Name = "Printer 1",
                SerialKey = "1234",
                Customer = new Models.Customer() { Id = 1 }
            });

            printers.Add(new Models.PrinterInfo()
            {
                Name = "Printer 2",
                SerialKey = "5678",
                Customer = new Models.Customer() { Id = 2 }
            });

            return printers;
        }

        public static Models.PrinterInfo GetPrinter(string serialKey)
        {
            switch (serialKey)
            {
                case "1234":
                    return new Models.PrinterInfo()
                    {
                        Name = "Printer 1",
                        SerialKey = "1234",
                        Customer = new Models.Customer() { Id = 1 }
                    };
                case "5678":
                    return new Models.PrinterInfo()
                    {
                        Name = "Printer 2",
                        SerialKey = "5678",
                        Customer = new Models.Customer() { Id = 2 }
                    };
                default:
                    return new Models.PrinterInfo();
            }
        }
    }
}