using System.Collections.Generic;
using System.Linq;

namespace LivraisonRepasService.CAD
{
    public class UtilisateursCad
    {
        public List<Utilisateurs> GetUtilisateurs()
        {
            List<Utilisateurs> utilisateurs;
            using (var bdd = new LivraisonRepasEntities())
            {
                var requete = from u in bdd.Utilisateurs
                              select u;

                utilisateurs = requete.ToList();
            }
            return utilisateurs;
        }

        public Utilisateurs GetUtilisateurs(int id)
        {
            Utilisateurs utilisateurs;

            using (var bdd = new LivraisonRepasEntities())
            {
                var requete = from u in bdd.Utilisateurs
                              where u.Id == id
                              select u;

                utilisateurs = requete.FirstOrDefault();
            }

            return utilisateurs;
            //return new Utilisateurs{Id = 1,Pseudo = "a",Password = "a",Adresse = "a",Type = "a"}
            //;
        }

        public void AddUtilisateurs(Utilisateurs u)
        {
            using (var bdd = new LivraisonRepasEntities())
            {
                bdd.Utilisateurs.Add(u);
                bdd.SaveChanges();
            }
        }

        public void DeleteUtilisateurs(int id)
        {
            using (var bdd = new LivraisonRepasEntities())
            {
                var requete = from u in bdd.Utilisateurs
                              where u.Id == id
                              select u;

                Utilisateurs utilisateurs = requete.FirstOrDefault();

                if (utilisateurs != null)
                {
                    bdd.Utilisateurs.Remove(utilisateurs);
                    bdd.SaveChanges();
                }
            }
        }

        public void UpdateUtilisateurs(Utilisateurs u)
        {
            using (var bdd = new LivraisonRepasEntities())
            {
                Utilisateurs utilisateurs = bdd.Utilisateurs.Find(u.Id);

                if (utilisateurs != null)
                {
                    bdd.Entry(utilisateurs).CurrentValues.SetValues(u);
                    bdd.SaveChanges();
                }
            }
        }

        public Utilisateurs AuthentificationUtilisateur(string pseudo, string password)
        {
            Utilisateurs utilisateurs;

            using (var bdd = new LivraisonRepasEntities())
            {
                var requete = from u in bdd.Utilisateurs
                              where u.Pseudo == pseudo && u.Password == password
                              select u;

                utilisateurs = requete.FirstOrDefault();
            }

            return utilisateurs;
        }
    }
}