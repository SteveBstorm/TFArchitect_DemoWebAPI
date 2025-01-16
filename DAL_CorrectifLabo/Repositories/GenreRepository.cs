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
    public class GenreRepository : BaseRepository, IGenreRepository
    {
        public GenreRepository(IConfiguration config) : base(config)
        {
        }

        protected override Genre Mapper(SqlDataReader reader)
        {
            return new Genre
            {
                Id = (int)reader["Id"],
                Label = (string)reader["Label"]
            };
        }

        public void Create(string label)
        {
            using(SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using(SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "INSERT INTO Genre (Label) VALUES (@label)";
                    cmd.Parameters.AddWithValue("label", label);
                    connection.Open();
                    cmd.ExecuteNonQuery();
                    connection.Close();
                }
            }
        }

        public IEnumerable<Genre> GetAll()
        {
            List<Genre> list = new List<Genre>();
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM Genre";
                    connection.Open();
                    using(SqlDataReader reader =  cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add( Mapper(reader));
                        }
                    }
                    connection.Close();
                }
            }
            return list;
        }

        public Genre? GetById(int id)
        {
            Genre g = null;
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM Genre WHERE Id = @id";
                    cmd.Parameters.AddWithValue("id", id);
                    connection.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            g = Mapper(reader);
                        }
                    }
                    connection.Close();
                }
            }
            return g;
        }

    }
}
