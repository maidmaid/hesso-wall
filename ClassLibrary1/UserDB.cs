using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace ClassLibrary1
{
    public class UserDB
    {
        public static User CheckUser(String username, String pwd)
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionNorth"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string query = "SELECT * FROM Users WHERE UserName = @username AND UserPassword = @pwd";
                    SqlCommand command = new SqlCommand(query, connection);
                    SqlParameter usernameParam = command.Parameters.Add("@username", SqlDbType.VarChar);
                    usernameParam.Value = username;
                    SqlParameter pwdParam = command.Parameters.Add("@password", SqlDbType.VarChar);
                    pwdParam.Value = pwd;

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            reader.Read();

                            User user = new User();
                            user.UserId = reader.GetInt32(0);
                            user.UserName = reader.GetString(1);
                            user.UserPassword = reader.GetString(2);

                            return user;
                        }
                    }
                }
                catch (Exception)
                {
                    throw;
                }
            }

            return null;
        }
    }
}
