using System;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using LivraisonRepas.Models;
using LivraisonRepas.Webservices;


namespace LivraisonRepas.Vues
{
    public sealed partial class MainPage
    {
        private Services _service;
        public MainPage()
        {
            InitializeComponent();
            _service = new Services();
        }

        private async void ConnexionClick(object sender, RoutedEventArgs e)
        {
            Utilisateurs utilisateur = await _service.Utilisateurs.AuthentificationUtilisateur(Pseudo.Text, Password.Password);

            if (utilisateur.IdUtilisateurs == 0)
            {
                MessageDialog msgDialog = new MessageDialog("Le pseudo ou le mot de passe est incorrect", "Attention");
                await msgDialog.ShowAsync();
            }
            else
            {
                ((App)(Application.Current)).UserConnected = utilisateur;
                if (utilisateur.Type.Equals("Livreur"))
                {
                    Frame.Navigate(typeof(Livreur), utilisateur);
                }
                else if (utilisateur.Type.Equals("Client"))
                {
                    Frame.Navigate(typeof(Client), utilisateur);
                }
                else
                {
                    MessageDialog msgDialog = new MessageDialog("Il y a un problème concernant le type de l'utilisateur!", "Erreur");
                    await msgDialog.ShowAsync();
                }    
            }
        }

        private void InscriptionClick(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof (Enregistrement));
        }
    }
}
