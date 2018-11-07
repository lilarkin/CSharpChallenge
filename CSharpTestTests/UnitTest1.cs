using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Collections.Generic;

namespace CSharpTestTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void WebServiceNotEmptyString()
        {
            // Act
            string response = CSharpTest.WebService.GetPrinters();
            //Assert
            Assert.AreNotEqual(string.Empty, response ?? string.Empty);
        }

        [TestMethod]
        public void WebServiceStringContainsJson()
        {
            // Arrange

            // Act
            bool isJson = true;
            try
            {
                string response = CSharpTest.WebService.GetPrinters();

                DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(List<CSharpTest.Models.PrinterInfo>));
                using (MemoryStream stream = new MemoryStream(System.Text.Encoding.Default.GetBytes(response ?? string.Empty)))
                {
                    List<CSharpTest.Models.PrinterInfo> results = serializer.ReadObject(stream) as List<CSharpTest.Models.PrinterInfo>;
                }
            }
            catch
            {
                isJson = false;
            }

            // Assert
            Assert.IsTrue(isJson);
        }
    }
}
