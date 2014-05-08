using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class SupplierDB
    {
        public static List<Supplier> GetSuppliers()
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionNorth"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string query = "SELECT * FROM Suppliers";
                    SqlCommand command = new SqlCommand(query, connection);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        List<Supplier> suppliers = new List<Supplier>();

                        while (reader.Read())
                        {
                            Supplier supplier = new Supplier();

                            supplier.SupplierID = reader.GetInt32(0);
                            supplier.CompanyName = reader.GetString(1);
                            supplier.ContactName = reader.GetString(2);
                            supplier.ContactTitle = reader.GetString(3);
                            supplier.Address = reader.GetString(4);
                            supplier.City = reader.GetString(5);
                            supplier.PostalCode = reader.GetString(7);
                            supplier.Country = reader.GetString(8);
                            supplier.Phone = reader.GetString(9);

                            suppliers.Add(supplier);
                        }

                        return suppliers;
                    }
                }
                catch (Exception)
                {
                    throw;
                }
            }

            return null;
        }

        public static List<Supplier> SearchSppliers(String search)
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionNorth"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string query = "SELECT * FROM Suppliers WHERE ContactName like %@s% OR CompanyName like %@s% OR ContactTitle like %@s% OR Phone like %@s%";
                    SqlCommand command = new SqlCommand(query, connection);
                    SqlParameter searchParam = command.Parameters.Add("@s", SqlDbType.VarChar);
                    searchParam.Value = search;

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        List<Supplier> suppliers = new List<Supplier>();

                        while (reader.Read())
                        {
                            Supplier supplier = new Supplier();

                            supplier.SupplierID = reader.GetInt32(0);
                            supplier.CompanyName = reader.GetString(1);
                            supplier.ContactName = reader.GetString(2);
                            supplier.ContactTitle = reader.GetString(3);
                            supplier.Address = reader.GetString(4);
                            supplier.City = reader.GetString(5);
                            supplier.PostalCode = reader.GetString(7);
                            supplier.Country = reader.GetString(8);
                            supplier.Phone = reader.GetString(9);

                            suppliers.Add(supplier);
                        }

                        return suppliers;
                    }
                }
                catch (Exception)
                {
                    throw;
                }

            }

            return null;
        }

        public static void AddSupplier(Supplier supplier)
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionNorth"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "INSERT INTO Suppliers(CompanyName, ContactName, ContactTitle) VALUES(@CompanyName, @ContactName, @ContactTitle)";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.Add("@CompanyName", SqlDbType.VarChar).Value = supplier.CompanyName;
                    command.Parameters.Add("@ContactName", SqlDbType.VarChar).Value = supplier.ContactName;
                    command.Parameters.Add("@ContactTitle", SqlDbType.VarChar).Value = supplier.ContactTitle;
                    command.CommandType = CommandType.Text;
                    command.ExecuteNonQuery();
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
        public static void DeleteSpplier(Supplier supplier)
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionNorth"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "DELETE FROM Suppliers WHERE SupplierID = @id";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.Add("@id", SqlDbType.Int).Value = supplier.SupplierID;
                    command.CommandType = CommandType.Text;
                    command.ExecuteNonQuery();
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
    }
}
