using System;

namespace CSharpTest.Models
{
   public class PrinterInfo
    {
        public string Name { get; set; }

        public string SerialKey { get; set; }

        public CustomerInfo Customer { get; set; }

        public int CustomerId { get; set; }
    }
}
