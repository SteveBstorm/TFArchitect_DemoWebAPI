using BLL_CorrectifLabo.Models;
using DemoWebAPI.DTOs;
namespace DemoWebAPI.Tools
{
    public static class Mappers
    {
        public static User ToBLL(this UserRegisterForm form)
        {
            return new User
            {
                Nom = form.Nom,
                Prenom = form.Prenom,
                Adresse_CP = form.Adresse_CP,
                Adresse_Localite = form.Adresse_Localite,
                Adresse_Num = form.Adresse_Num,
                Adresse_Rue = form.Adresse_Rue,
                Email = form.Email
            };
        }

        public static Coffret ToBLL(this CoffretForm form)
        {
            return new Coffret
            {
                Titre = form.Titre,
                Synopsis = form.Synopsis,
                Bonus = form.Bonus,
                PosterUrl = form.PosterUrl,
                Prix = form.Prix,
                GenreId = form.GenreId,
                Quantite = form.Quantite
            };
        }
    }
}
