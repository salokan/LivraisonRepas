//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré à partir d'un modèle.
//
//     Des modifications manuelles apportées à ce fichier peuvent conduire à un comportement inattendu de votre application.
//     Les modifications manuelles apportées à ce fichier sont remplacées si le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LivraisonRepasServices
{
    using System;
    using System.Collections.Generic;
    
    public partial class Utilisateurs
    {
        public Utilisateurs()
        {
            this.Commandes = new HashSet<Commandes>();
            this.Commandes1 = new HashSet<Commandes>();
        }
    
        public int Id { get; set; }
        public string Pseudo { get; set; }
        public string Password { get; set; }
        public string Adresse { get; set; }
        public string Type { get; set; }
    
        public virtual ICollection<Commandes> Commandes { get; set; }
        public virtual ICollection<Commandes> Commandes1 { get; set; }
    }
}
