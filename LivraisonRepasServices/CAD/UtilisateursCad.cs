using System.Collections.Generic;
using System.Linq;
using LivraisonRepasServices.Composite;

namespace LivraisonRepasServices.CAD
{
    public class UtilisateursCad
    {
        public List<UtilisateursComposite> GetUtilisateurs()
        {
            List<UtilisateursComposite> utilisateursList = new List<UtilisateursComposite>();

            List<Utilisateurs> utilisateurs;
            using (var bdd = new LivraisonRepasEntities())
            {
                var requete = from u in bdd.Utilisateurs
                              select u;

                utilisateurs = requete.ToList();
            }

            if (utilisateurs.Count > 0)
            {
                foreach (Utilisateurs u in utilisateurs)
                {
                    UtilisateursComposite composite = new UtilisateursComposite();
                    composite.IdUtilisateurs = u.Id;
                    composite.Pseudo = u.Pseudo;
                    composite.Password = u.Password;
                    composite.Adresse = u.Adresse;
                    composite.Type = u.Type;
                    utilisateursList.Add(composite);
                }
            }

            return utilisateursList;
        }

        public UtilisateursComposite GetUtilisateurs(int id)
        {
            UtilisateursComposite compositeUtilisateurs = new UtilisateursComposite();
            Utilisateurs utilisateurs;

            using (var bdd = new LivraisonRepasEntities())
            {
                var requete = from u in bdd.Utilisateurs
                              where u.Id == id
                              select u;

                utilisateurs = requete.FirstOrDefault();
            }

            if (utilisateurs != null)
            {
                compositeUtilisateurs.IdUtilisateurs = utilisateurs.Id;
                compositeUtilisateurs.Pseudo = utilisateurs.Pseudo;
                compositeUtilisateurs.Password = utilisateurs.Password;
                compositeUtilisateurs.Adresse = utilisateurs.Adresse;
                compositeUtilisateurs.Type = utilisateurs.Type;
            }

            return compositeUtilisateurs;
        }

        public void AddUtilisateurs(UtilisateursComposite uu)
        {
            Utilisateurs u = new Utilisateurs();

            u.Id = uu.IdUtilisateurs;
            u.Pseudo = uu.Pseudo;
            u.Password = uu.Password;
            u.Adresse = uu.Adresse;
            u.Type = uu.Type;

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

        public void UpdateUtilisateurs(UtilisateursComposite uu)
        {
            Utilisateurs u = new Utilisateurs();

            u.Id = uu.IdUtilisateurs;
            u.Pseudo = uu.Pseudo;
            u.Password = uu.Password;
            u.Adresse = uu.Adresse;
            u.Type = uu.Type;

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

        public UtilisateursComposite AuthentificationUtilisateur(string pseudo, string password)
        {
            UtilisateursComposite compositeUtilisateurs = new UtilisateursComposite();
            Utilisateurs utilisateurs;

            using (var bdd = new LivraisonRepasEntities())
            {
                var requete = from u in bdd.Utilisateurs
                              where u.Pseudo == pseudo && u.Password == password
                              select u;

                utilisateurs = requete.FirstOrDefault();
            }

            if (utilisateurs != null)
            {
                compositeUtilisateurs.IdUtilisateurs = utilisateurs.Id;
                compositeUtilisateurs.Pseudo = utilisateurs.Pseudo;
                compositeUtilisateurs.Password = utilisateurs.Password;
                compositeUtilisateurs.Adresse = utilisateurs.Adresse;
                compositeUtilisateurs.Type = utilisateurs.Type;
            }

            return compositeUtilisateurs;
        }

        public bool ExistePseudo(string pseudo)
        {
            bool existe = false;

            List<Utilisateurs> utilisateurs;
            using (var bdd = new LivraisonRepasEntities())
            {
                var requete = from u in bdd.Utilisateurs
                              select u;

                utilisateurs = requete.ToList();


                foreach (Utilisateurs utilisateursListe in utilisateurs)
                {
                    if (utilisateursListe.Pseudo.Equals(pseudo))
                        existe = true;
                }
            }

            return existe;
        }
    }
}
