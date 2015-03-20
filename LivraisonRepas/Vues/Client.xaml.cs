using LivraisonRepas.LivraisonRepasUtilisateursServiceReference;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// Pour en savoir plus sur le modèle d'élément Page vierge, consultez la page http://go.microsoft.com/fwlink/?LinkId=234238

namespace LivraisonRepas.Vues
{
    /// <summary>
    /// Une page vide peut être utilisée seule ou constituer une page de destination au sein d'un frame.
    /// </summary>
    public sealed partial class Client : Page
    {

        public Client()
        {
            this.InitializeComponent();
        }

        private void Ajouter_Panier_Click(object sender, RoutedEventArgs e)
        {
            ComboBoxItem typeItem = (ComboBoxItem)Menu.SelectedItem;
            string selected = typeItem.Content.ToString();
            ListViewPanier.Items.Add(selected);
        }

        private void Valider_Click(object sender, RoutedEventArgs e)
        {

        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            ListViewPanier.Items.Clear();
            Utilisateurs user = e.Parameter as Utilisateurs;
            if (user != null)
            {
                username.Text = user.Pseudo;
            }
        }
    }
}
