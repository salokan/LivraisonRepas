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
    
    public partial class MenuCommande
    {
        public int Id { get; set; }
        public Nullable<int> IdMenu { get; set; }
        public Nullable<int> IdCommande { get; set; }
    
        public virtual Commandes Commandes { get; set; }
        public virtual Menu Menu { get; set; }
    }
}
