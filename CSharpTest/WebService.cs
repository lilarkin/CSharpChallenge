using System;
using System.Net;

namespace CSharpTest
{
    public static class WebService
    {
        public static string GetPrinters()
        {
            try
            {
                using (var client = new WebClient())
                {
                    client.Headers.Add("Content-Type:application/json");
                    client.Headers.Add("Accept:application/json");
                    var result = client.DownloadString("http://localhost:24520/api/printers");
                    return result.ToString();
                }
            }
            catch
            {
                return string.Empty;
            }
        }
    }
}
