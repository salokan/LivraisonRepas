using System;
using System.Runtime.Serialization;

namespace LivraisonRepasServices
{
    [DataContract(Name = "Test")]
    public class Test
    {
        [DataMember(Order = 1)]
        public int Id { get; set; }

        [DataMember(Order = 2)]
        public String Titre { get; set; }

        [DataMember(Order = 3)]
        public int Annee { get; set; } //année de sortie

        [DataMember(Order = 4)]
        public double Entrees { get; set; }  //nombre d'entrées en millions

        [DataMember(Order = 5)]
        public Uri Uri { get; set; }
    }
}
