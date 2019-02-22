using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Assignment1_Api.Models
{
    public class DALLayer
    {

        public List<Supplier> GetSuppliers()
        {
            List<Supplier> suppliers = new List<Supplier>();

            string connectionString = @"Data Source=DOTNET;Initial Catalog=PODb;Integrated Security=true";
            using (SqlConnection c = new SqlConnection(connectionString))
            {
                c.Open();
                using (SqlCommand sqlCommand = new SqlCommand("SELECT * FROM [PODb].[dbo].[SUPPLIER]", c))
                {
                    SqlDataReader reader = sqlCommand.ExecuteReader();
                    while (reader.Read())
                    {
                        Supplier supplier = new Supplier();
                        supplier.SUPLNO = Convert.ToInt32(reader["SUPLNO"].ToString());
                        supplier.SUPLNAME = reader["SUPLNAME"].ToString();
                        supplier.SUPLADDR = reader["SUPLADDR"].ToString();
                        suppliers.Add(supplier);
                    }
                    reader.Close();
                }
                return suppliers;
            }
        }

        
        public List<Item> GetItems()
        {
            List<Item> items = new List<Item>();

            string connectionString = @"Data Source=DOTNET;Initial Catalog=PODb;Integrated Security=true";
            using (SqlConnection c = new SqlConnection(connectionString))
            {
                c.Open();
                using (SqlCommand sqlCommand = new SqlCommand("SELECT * FROM [PODb].[dbo].[ITEM]", c))
                {
                    SqlDataReader reader = sqlCommand.ExecuteReader();
                    while (reader.Read())
                    {
                        Item item = new Item();
                        item.ITCODE = reader["ITCODE"].ToString();
                        item.ITDESC = reader["ITDESC"].ToString();
                        item.ITRATE = Convert.ToDecimal(reader["ITRATE"].ToString());
                        items.Add(item);
                    }
                    reader.Close();
                }
                return items;
            }
        }

        public List<POMaster> GetPOMaster()
        {
            List<POMaster> items = new List<POMaster>();

            string connectionString = @"Data Source=DOTNET;Initial Catalog=PODb;Integrated Security=true";
            using (SqlConnection c = new SqlConnection(connectionString))
            {
                c.Open();
                using (SqlCommand sqlCommand = new SqlCommand("SELECT * FROM [PODb].[dbo].[POMASTER]", c))
                {
                    SqlDataReader reader = sqlCommand.ExecuteReader();
                    while (reader.Read())
                    {
                        POMaster item = new POMaster();
                        item.PONO = reader["PONO"].ToString();
                        item.PODATE = Convert.ToDateTime(reader["PODATE"].ToString());
                        item.SUPLNO = reader["SUPLNO"].ToString();
                        items.Add(item);
                    }
                    reader.Close();
                }
                return items;
            }
        }

        
        public List<PODetail> GetPODetails()
        {
            List<PODetail> items = new List<PODetail>();

            string connectionString = @"Data Source=DOTNET;Initial Catalog=PODb;Integrated Security=true";
            using (SqlConnection c = new SqlConnection(connectionString))
            {
                c.Open();
                using (SqlCommand sqlCommand = new SqlCommand("SELECT * FROM [PODb].[dbo].[PODETAIL]", c))
                {
                    SqlDataReader reader = sqlCommand.ExecuteReader();
                    while (reader.Read())
                    {
                        PODetail item = new PODetail();
                        item.PONO = reader["PONO"].ToString();
                        item.ITCODE = reader["ITCODE"].ToString();
                        item.QTY = Convert.ToInt32(reader["QTY"].ToString());
                        items.Add(item);
                    }
                    reader.Close();
                }
                return items;
            }
        }

        
        public int AddPOMaster(POMaster value)
        {
            int result = -1;
            string connetionString = @"Data Source=DOTNET;Initial Catalog=PODb;Integrated Security=true";
            using (SqlConnection c = new SqlConnection(connetionString))
            {
                c.Open();
                using (SqlCommand sqlCommand = new SqlCommand("INSERT INTO [PODb].[dbo].[POMASTER] VALUES ('" + value.PONO + "', '" + value.PODATE + "', '" + value.SUPLNO + "')", c))
                {
                    result=sqlCommand.ExecuteNonQuery();
                }
                c.Close();
            }
            return result;
        }


        public int DeletePOMaster(string id)
        {
            int result = -1;
            string connetionString = @"Data Source=DOTNET;Initial Catalog=PODb;Integrated Security=true";
            using (SqlConnection c = new SqlConnection(connetionString))
            {
                c.Open();
                using (SqlCommand sqlCommand = new SqlCommand("DELETE FROM [PODb].[dbo].[PODETAIL] WHERE PONO = '" + id + "'", c))
                {
                    result=sqlCommand.ExecuteNonQuery();
                }
                using (SqlCommand sqlCommand = new SqlCommand("DELETE FROM [PODb].[dbo].[POMASTER] WHERE PONO = '" + id + "'", c))
                {
                    result=sqlCommand.ExecuteNonQuery()+result;
                }
            }
            return result;
        }
    }
}