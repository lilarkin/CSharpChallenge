namespace WebApiTest.Models
{
    public class PrinterInfo
    {
        public string Name { get; set; }
        public string SerialKey { get; set; }
        public Customer Customer { get; set; }
    }
}