using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using SignUp.Models;
using System.Data;

namespace SignUp.DAL
{
    public class SignUpDAL
    {
        private string conString = ConfigurationManager.ConnectionStrings["adoConnectionString"].ToString();

        public bool AddUser(string username, string email, string password, string confirmPassword, string profilePicturePath)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(conString))
                {
                    string sqlQuery = "INSERT INTO UsersTbl (Username, Email, Password, ConfirmPassword, ProfilePicturePath) VALUES (@Username, @Email, @Password, @ConfirmPassword, @ProfilePicturePath)";
                    using (SqlCommand command = new SqlCommand(sqlQuery, conn))
                    {
                        command.Parameters.AddWithValue("@Username", username);
                        command.Parameters.AddWithValue("@Email", email);
                        command.Parameters.AddWithValue("@Password", password);
                        command.Parameters.AddWithValue("@ConfirmPassword", confirmPassword);
                        command.Parameters.AddWithValue("@ProfilePicturePath", profilePicturePath);

                        conn.Open();
                        int rowsAffected = command.ExecuteNonQuery();

                     
                        return rowsAffected > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                
                Console.WriteLine($"Error adding user: {ex.Message}");
                return false;
            }
        }

        public List<SignUpModel> GetAllUsers()
        {
            List<SignUpModel> users = new List<SignUpModel>();

            try
            {
                using (SqlConnection conn = new SqlConnection(conString))
                {
                    string sqlQuery = "SELECT Username, Email, ProfilePicturePath FROM UsersTbl";
                    using (SqlCommand command = new SqlCommand(sqlQuery, conn))
                    {
                        conn.Open();
                        SqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            SignUpModel user = new SignUpModel
                            {
                                Username = reader["Username"].ToString(),
                                Email = reader["Email"].ToString(),
                            };
                            users.Add(user);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                
                throw new Exception("An error occurred while fetching users", ex);
            }

            return users;
        }
    }
}