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
    public class CoffretRepository : BaseRepository, ICoffretRepository
    {
        public CoffretRepository(IConfiguration config) : base(config)
        {
        }

        protected override Coffret Mapper(SqlDataReader reader)
        {
            return new Coffret
            {
                Id = (int)reader["Id"],
                Titre = (string)reader["Titre"],
                Synopsis = (string)reader["Synopsis"],
                Bonus = (string)reader["Bonus"],
                Quantite = (int)reader["Quantite"],
                PosterUrl = (string)reader["PosterUrl"],
                GenreId = (int)reader["GenreId"],
                Prix = (decimal)reader["Prix"]
            };
        }

        public void Create(Coffret coffret)
        {
            using(SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using(SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "INSERT INTO Coffrets (Titre, Synopsis, Bonus, Quantite, PosterUrl, GenreId, Prix) " +
                        "VALUES (@titre, @syn, @bonus, @qty, @posterUrl, @genreId, @prix)";

                    cmd.Parameters.AddWithValue("titre", coffret.Titre);
                    cmd.Parameters.AddWithValue("syn", coffret.Synopsis);
                    cmd.Parameters.AddWithValue("bonus", coffret.Bonus);
                    cmd.Parameters.AddWithValue("qty", coffret.Quantite);
                    cmd.Parameters.AddWithValue("posterUrl", coffret.PosterUrl);
                    cmd.Parameters.AddWithValue("genreId", coffret.GenreId);
                    cmd.Parameters.AddWithValue("prix", coffret.Prix);

                    connection.Open();
                    cmd.ExecuteNonQuery();
                    connection.Close();
                }
            }
        }

        public IEnumerable<Coffret> GetAll()
        {
            List<Coffret> list = new List<Coffret>();
            using(SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM Coffrets";
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

        public Coffret GetById(int id)
        {
            Coffret c = new Coffret();
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM Coffrets WHERE Id = @id";
                    cmd.Parameters.AddWithValue("id", id);
                    connection.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            c = Mapper(reader);
                        }
                    }
                    connection.Close();
                }
            }
            return c;
        }

        public void ModifyQuantity(int id, int quantity)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "UPDATE Coffrets SET Quantite = @qty WHERE Id = @id";
                    cmd.Parameters.AddWithValue("qty", quantity);
                    cmd.Parameters.AddWithValue("id", id);

                    connection.Open();
                    cmd.ExecuteNonQuery();
                    connection.Close();

                }
            }
        }
       
    }
}
