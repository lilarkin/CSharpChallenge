using System;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Collections.Generic;

namespace CSharpTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Press any key to start");
            Console.ReadKey();

            List<Models.PrinterInfo> results = null;
            string response = WebService.GetPrinters();

            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(List<Models.PrinterInfo>));
            using (MemoryStream stream = new MemoryStream(System.Text.Encoding.Default.GetBytes(response ?? string.Empty)))
            {
                results = serializer.ReadObject(stream) as List<Models.PrinterInfo>;
            }

            foreach (Models.PrinterInfo printer in (results ?? new List<Models.PrinterInfo>()))
            {
                DataBase.StorePrinter(printer);
            }

            Console.WriteLine("Done!");
            // Console.WriteLine("Press any key to exit");
            // Console.ReadKey();
        }
    }
}
