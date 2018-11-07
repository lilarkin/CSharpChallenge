using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace CSharpTest
{
    public static class DataBase
    {
        public static void StorePrinter(Models.PrinterInfo printer)
        {
            // ShowTableContents();
            string connString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            using (SqlConnection con = new SqlConnection(connString))
            {
                con.Open();
                using (SqlCommand com = new SqlCommand("INSERT INTO printers(PrinterName,SerialKey,ExpireDate,CustomerName) VALUES(@printerName,@serialKey,GETDATE(),@customerName)", con))
                {
                    SqlParameter[] sParams = new SqlParameter[3];
                    sParams[0] = new SqlParameter("printerName", SqlDbType.VarChar);
                    sParams[0].Value = printer.Name;

                    sParams[1] = new SqlParameter("serialKey", SqlDbType.VarChar);
                    sParams[1].Value = printer.SerialKey;

                    sParams[2] = new SqlParameter("customerName", SqlDbType.VarChar);
                    sParams[2].Value = printer.Customer.Name;

                    com.Parameters.AddRange(sParams);
                    com.ExecuteNonQuery();
                }
                con.Close();
            }

            // ShowTableContents();
        }

        private static void ShowTableContents()
        {
            Console.WriteLine();
            Console.WriteLine("Showing table contents");
            string connString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            using (SqlConnection con = new SqlConnection(connString))
            {
                con.Open();
                using (SqlCommand com = new SqlCommand("SELECT * FROM printers", con))
                {
                    using (DataSet ds = new DataSet())
                    {
                        using (SqlDataAdapter da = new SqlDataAdapter(com))
                        {
                            da.Fill(ds);
                            foreach (DataRow row in ds.Tables[0].Rows)
                                Console.WriteLine("ID = {0}, PrinterName = {1}, SerialKey = {2}, ExpireDate = {3}, CustomerName = {4}", row["Id"], row["PrinterName"], row["SerialKey"], row["ExpireDate"], row["CustomerName"]);
                        }
                    }
                }
                con.Close();
            }
        }
    }
}
