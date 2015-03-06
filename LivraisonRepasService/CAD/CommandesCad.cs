using System.Collections.Generic;
using System.Linq;

namespace LivraisonRepasService.CAD
{
    public class CommandesCad
    {
        public List<Commandes> GetCommandes()
        {
            List<Commandes> commandes;
            using (var bdd = new LivraisonRepasEntities())
            {
                var requete = from c in bdd.Commandes
                                select c;

                commandes = requete.ToList();
            }
            return commandes;
        }

        public Commandes GetCommandes(int id)
        {
            Commandes commandes;

            using (var bdd = new LivraisonRepasEntities())
            {
                var requete = from c in bdd.Commandes
                                where c.Id == id
                                select c;

                commandes = requete.FirstOrDefault();
            }

            return commandes;
        }

        public void AddCommandes(Commandes c)
        {
            using (var bdd = new LivraisonRepasEntities())
            {
                bdd.Commandes.Add(c);
                bdd.SaveChanges();
            }
        }

        public void DeleteCommandes(int id)
        {
            using (var bdd = new LivraisonRepasEntities())
            {
                var requete = from c in bdd.Commandes
                                where c.Id == id
                                select c;

                Commandes commandes = requete.FirstOrDefault();

                if (commandes != null)
                {
                    bdd.Commandes.Remove(commandes);
                    bdd.SaveChanges();
                }
            }
        }

        public void UpdateCommandes(Commandes c)
        {
            using (var bdd = new LivraisonRepasEntities())
            {
                Commandes commandes = bdd.Commandes.Find(c.Id);

                if (commandes != null)
                {
                    bdd.Entry(commandes).CurrentValues.SetValues(c);
                    bdd.SaveChanges();
                }
            }
        }
    }
}