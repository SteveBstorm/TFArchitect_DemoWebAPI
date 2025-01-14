using DAL_CorrectifLabo.Entities;
using DAL_CorrectifLabo.Interface;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_CorrectifLabo.Repositories
{
    public class UserRepository : BaseRepository, IUserRepository
    {
        public UserRepository(IConfiguration config) : base(config)
        {
        }

        protected override User Mapper(SqlDataReader reader)
        {
            return new User
            {
                Id = (int)reader["Id"],
                Nom = (string)reader["Nom"],
                Email = (string)reader["Email"],
                Prenom = (string)reader["Prenom"],
                Adresse_Rue = (string)reader["Adresse_Rue"],
                Adresse_Num = (int)reader["Adresse_Num"],
                Adresse_CP = (int)reader["Adresse_CP"],
                Adresse_Localite = (string)reader["Adresse_Localite"],
                IsAdmin = (bool)reader["IsAdmin"]
            };
        }

        public IEnumerable<User> GetAll()
        {
            List<User> users = new List<User>();
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM Users";
                    connection.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            users.Add(Mapper(reader));
                        }
                    }
                    connection.Close();
                }
            }
            return users;
        }

        public User GetByEmail(string email)
        {
            User CurrentUser = new User();
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM Users WHERE Email = @email";
                    cmd.Parameters.AddWithValue("email", email);
                    connection.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            CurrentUser = Mapper(reader);
                        }
                    }
                    connection.Close();
                }
            }
            return CurrentUser;
        }

        public string GetPassword(string email)
        {
            string password;
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "SELECT MotDePasse FROM Users WHERE Email = @email";
                    cmd.Parameters.AddWithValue("email", email);
                    connection.Open();
                    password = (string)cmd.ExecuteScalar();
                    connection.Close();
                }
            }
            if (!string.IsNullOrEmpty(password))
                return password;
            throw new ArgumentNullException("email inexistant");
        }

        public void Register(User user,  string password)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "INSERT INTO Users (Email, MotDePasse, Nom, Prenom, Adresse_Rue, " +
                        "Adresse_Num, Adresse_CP, Adresse_Localite) " +
                        "VALUES (@email, @password, @nom, @prenom, @adRue, @adNum, @adCP, @adLoc)";
                    cmd.Parameters.AddWithValue("email", user.Email);
                    cmd.Parameters.AddWithValue("password", password);
                    cmd.Parameters.AddWithValue("nom", user.Nom);
                    cmd.Parameters.AddWithValue("prenom", user.Prenom);
                    cmd.Parameters.AddWithValue("adRue", user.Adresse_Rue);
                    cmd.Parameters.AddWithValue("adNum", user.Adresse_Num);
                    cmd.Parameters.AddWithValue("adCP", user.Adresse_CP);
                    cmd.Parameters.AddWithValue("adLoc", user.Adresse_Localite);


                    try
                    {
                        connection.Open();
                        cmd.ExecuteNonQuery();
                        connection.Close();
                    }
                    catch (SqlException ex)
                    {
                        throw ex;
                    }
                }
            }
        }

        public User GetById(int id)
        {
            User CurrentUser = new User();
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM Users WHERE Id = @id";
                    cmd.Parameters.AddWithValue("id", id);
                    connection.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            CurrentUser = Mapper(reader);
                        }
                    }
                    connection.Close();
                }
            }
            return CurrentUser;
        }

        public void UpdatePassword(int id, string password)
        {
            using(SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "UPDATE Users SET MotDePasse = @pwd WHERE Id = @id";
                    cmd.Parameters.AddWithValue("pwd", password);
                    cmd.Parameters.AddWithValue("id", id);
                    connection.Open();
                    cmd.ExecuteNonQuery();
                    connection.Close();
                }
            }
        }

        public void UpdateDeliveryInfo(int id, string ad_rue, string ad_num, string ad_cp, string ad_loc)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "UPDATE Users SET Adresse_Rue = @ad_rue, Adresse_Num = @ad_num, " +
                        "Adresse_CP = @ad_cp, Adresse_Localite = @ad_loc WHERE Id = @id";
                    cmd.Parameters.AddWithValue("ad_rue", ad_rue);
                    cmd.Parameters.AddWithValue("ad_num", ad_num);
                    cmd.Parameters.AddWithValue("ad_cp", ad_cp);
                    cmd.Parameters.AddWithValue("ad_loc", ad_loc);
                    cmd.Parameters.AddWithValue("id", id);
                    connection.Open();
                    cmd.ExecuteNonQuery();
                    connection.Close();
                }
            }
        }
    }
}
