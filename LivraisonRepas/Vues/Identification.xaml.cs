using System;
using Windows.UI.Popups;
using Windows.UI.Xaml;

using LivraisonRepas.LivraisonRepasUtilisateursServiceReference;
using LivraisonRepas.Webservices;

namespace LivraisonRepas.Vues
{
    public sealed partial class Identification
    {
        private Services _service;
        public Identification()
        {
            InitializeComponent();
            _service = new Services();
        }

        private async void InscriptionClick(object sender, RoutedEventArgs e)
        {
            if (Pseudo.Text.Equals("") || Password.Text.Equals("") || Adresse.Text.Equals(""))
            {
                MessageDialog msgDialog = new MessageDialog("Aucun champ ne doit être vide", "Erreur");
                await msgDialog.ShowAsync();
            }
            else
            {
                if (!System.Text.RegularExpressions.Regex.IsMatch(Pseudo.Text, "^[a-zA-Z]+$"))
                {
                    MessageDialog msgDialog = new MessageDialog("Le pseudo ne doit être composé que de lettres", "Erreur");
                    await msgDialog.ShowAsync();
                }
                else
                {
                    if (await _service._utilisateurs.ExistePseudo(Pseudo.Text))
                    {
                        MessageDialog msgDialog = new MessageDialog("Le pseudo existe déjà!", "Attention");
                        await msgDialog.ShowAsync();
                    }
                    else
                    {
                        _service._utilisateurs.AddUtilisateurs(new Utilisateurs { Adresse = Adresse.Text, Pseudo = Pseudo.Text, Password = Password.Text, Type = "livreur" });
                        Frame.GoBack();
                    }
                }      
            } 
        }
        private void BackClick(object sender, RoutedEventArgs e)
        {
            Frame.GoBack();
        }
    }
}
