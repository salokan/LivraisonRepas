using System;
using Windows.UI.Popups;
using Windows.UI.Xaml;

using LivraisonRepas.LivraisonRepasUtilisateursServiceReference;
using LivraisonRepas.Webservices;

namespace LivraisonRepas.Vues
{
    public sealed partial class Enregistrement
    {
        private Services _service;
        public Enregistrement()
        {
            InitializeComponent();
            _service = new Services();
        }

        private async void InscriptionClick(object sender, RoutedEventArgs e)
        {
            if (Pseudo.Text.Equals("") || Password.Password.Equals("") || Adresse.Text.Equals(""))
            {
                MessageDialog msgDialog = new MessageDialog("Aucun champ ne doit être vide", "Erreur");
                await msgDialog.ShowAsync();
            }
            else
            {
                if (!System.Text.RegularExpressions.Regex.IsMatch(Pseudo.Text, "^[a-zA-Z]+$"))
                {
                    MessageDialog msgDialog = new MessageDialog("Le pseudo ne doit être composé que de lettres",
                        "Erreur");
                    await msgDialog.ShowAsync();
                }
                else
                {
                    if (await _service.Utilisateurs.ExistePseudo(Pseudo.Text))
                    {
                        MessageDialog msgDialog = new MessageDialog("Le pseudo existe déjà!", "Attention");
                        await msgDialog.ShowAsync();
                    }
                    else
                    {
                        try
                        {
                            Utilisateurs utilisateur = new Utilisateurs{
                                Adresse = Adresse.Text,
                                Pseudo = Pseudo.Text,
                                Password = Password.Password,
                                Type = "client"
                            };
                            _service.Utilisateurs.AddUtilisateurs(utilisateur);
                            ((App)(Application.Current)).UserConnected = utilisateur;

                            Frame.Navigate(typeof(Client));
                        }
                        catch (Exception ex)
                        {
                            MessageDialog msgDialog = new MessageDialog("Execption dans enregistrement : " + ex, "Erreur");
                            msgDialog.ShowAsync();          
                        }   
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

        
