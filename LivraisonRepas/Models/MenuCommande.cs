using System.Runtime.Serialization;
using Windows.Data.Json;

namespace LivraisonRepas.Models
{
    [DataContract]
    public class MenuCommande
    {
        private int _id;
        private int _idCommande;
        private int _idMenu;

        public MenuCommande(JsonObject jsonObject)
        {
            IdMenuCommande = (int)jsonObject.GetNamedNumber("IdMenuCommande");
            IdCommande = (int)jsonObject.GetNamedNumber("IdCommande");
            IdMenu = (int)jsonObject.GetNamedNumber("IdMenu");
        }

        public MenuCommande(int idCommande, int idMenu)
        {
            IdMenuCommande = 0;
            IdCommande = idCommande;
            IdMenu = idMenu;
        }

        [DataMember(Name = "IdMenuCommande", IsRequired = true)]
        public int IdMenuCommande
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
            }
        }

        [DataMember(Name = "IdCommande", IsRequired = true)]
        public int IdCommande
        {
            get
            {
                return _idCommande;
            }
            set
            {
                _idCommande = value;
            }
        }

        [DataMember(Name = "IdMenu", IsRequired = true)]
        public int IdMenu
        {
            get
            {
                return _idMenu;
            }
            set
            {
                _idMenu = value;
            }
        }
    }
}
