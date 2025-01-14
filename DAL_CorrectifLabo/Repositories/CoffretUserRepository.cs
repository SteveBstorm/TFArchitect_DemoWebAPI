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
    public class CoffretUserRepository : BaseRepository, ICoffretUserRepository
    {
        public CoffretUserRepository(IConfiguration config) : base(config)
        {
        }

        protected override CoffretUser Mapper(SqlDataReader reader)
        {
            return new CoffretUser
            {
                UserId = (int)reader["UserId"],
                CoffretId = (int)reader["CoffretId"],
                DateAchat = (DateTime)reader["DateAchat"]
            };
        }

        public IEnumerable<CoffretUser> GetHistoryByClientId(int clientId)
        {
            List<CoffretUser> list = new List<CoffretUser>();
            using(SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using(SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM Coffret_Users WHERE UserId = @clientId";
                    cmd.Parameters.AddWithValue("clientId", clientId);
                    connection.Open();
                    using(SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while(reader.Read())
                        {
                            list.Add(Mapper(reader));
                        }
                    }
                    connection.Close();
                }
            }
            return list;
        }

        public IEnumerable<CoffretUser> GetHistoryByCoffretId(int coffretId)
        {
            List<CoffretUser> list = new List<CoffretUser>();
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM Coffret_Users WHERE CoffretId = @coffretId";
                    cmd.Parameters.AddWithValue("coffretId", coffretId);
                    connection.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(Mapper(reader));
                        }
                    }
                    connection.Close();
                }
            }
            return list;

        }

        public void CreateCommande(int coffretId, int userId)
        {
            using(SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using(SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "INSERT INTO Coffret_Users (CoffretId, UserId) VALUES (@cid, @uid)";
                    cmd.Parameters.AddWithValue("cid", coffretId);
                    cmd.Parameters.AddWithValue("uid", userId);
                    connection.Open();
                    cmd.ExecuteNonQuery();
                    connection.Close();
                }
            }
        }


    }
}
