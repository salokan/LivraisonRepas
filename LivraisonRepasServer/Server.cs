using System;
using System.ServiceModel.Web;
using LivraisonRepasServices;

namespace LivraisonRepasServer
{
    public class Server
    {
        static void Main()
        {
            LivraisonRepasService services = new LivraisonRepasService();
            WebServiceHost serviceHost = new WebServiceHost(services, new Uri("http://localhost:1234/LivraisonRepas"));
            serviceHost.Open();

            Console.WriteLine("Serveur démarré");

            Console.ReadKey();
            serviceHost.Close();
        }
    }
}
