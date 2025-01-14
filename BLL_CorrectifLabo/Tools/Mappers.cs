using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL = BLL_CorrectifLabo.Models;
using DAL = DAL_CorrectifLabo.Entities;


namespace BLL_CorrectifLabo.Tools
{
    public static class Mappers
    {
        public static BLL.User ToBLL(this DAL.User user)
        {
            return new BLL.User
            {
                Id = user.Id,
                Nom = user.Nom,
                Prenom = user.Prenom,
                Adresse_CP = user.Adresse_CP,
                Adresse_Localite = user.Adresse_Localite,
                Adresse_Num = user.Adresse_Num,
                Adresse_Rue = user.Adresse_Rue,
                Email = user.Email,
                IsAdmin = user.IsAdmin

            };
        }

        public static DAL.User ToDAL(this BLL.User user)
        {
            return new DAL.User
            {
                Id = user.Id,
                Nom = user.Nom,
                Prenom = user.Prenom,
                Adresse_CP = user.Adresse_CP,
                Adresse_Localite = user.Adresse_Localite,
                Adresse_Num = user.Adresse_Num,
                Adresse_Rue = user.Adresse_Rue,
                Email = user.Email,
                IsAdmin = user.IsAdmin
            };
        }

        public static BLL.Genre ToBLL(this DAL.Genre genre )
        {
            return new BLL.Genre { Id = genre.Id, Label = genre.Label };
        }
        public static DAL.Genre ToDAL(this BLL.Genre genre)
        {
            return new DAL.Genre { Id = genre.Id, Label = genre.Label };
        }

        public static BLL.Coffret ToBLL(this DAL.Coffret coffret )
        {
            return new BLL.Coffret
            {
                Id = coffret.Id,
                Titre = coffret.Titre,
                Synopsis = coffret.Synopsis,
                Bonus = coffret.Bonus,
                PosterUrl = coffret.PosterUrl,
                Prix = coffret.Prix,
                GenreId = coffret.GenreId,
                Quantite = coffret.Quantite
            };
        }

        public static DAL.Coffret ToDAL(this BLL.Coffret coffret)
        {
            return new DAL.Coffret
            {
                Id = coffret.Id,
                Titre = coffret.Titre,
                Synopsis = coffret.Synopsis,
                Bonus = coffret.Bonus,
                PosterUrl = coffret.PosterUrl,
                Prix = coffret.Prix,
                GenreId = coffret.GenreId,
                Quantite = coffret.Quantite
            };
        }
    }
}
