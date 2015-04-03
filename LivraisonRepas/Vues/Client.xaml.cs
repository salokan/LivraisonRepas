using System;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using LivraisonRepas.Models;
using LivraisonRepas.Webservices;
using System.Collections.Generic;

namespace LivraisonRepas.Vues
{
    public sealed partial class Client
    {
        private Utilisateurs _userConnected;
        private Services _service;
        private List<Restaurants> ListRestaurants;
        private List<Menus> ListMenus;
        private List<Menus> ListMenusCommande;
        private List<Commandes> ListCommande;
        private List<Utilisateurs> users;
        private List<int> ListLivreurs;
        private Menus _menuSelected;
        private Commandes commande;
        private decimal prix;
        private static Random rnd;

        public Client()
        {
            InitializeComponent();
            _service = new Services();
            _userConnected = ((App)(Application.Current)).UserConnected;
            InitalizeCombobox();
        }

        private async void InitalizeCombobox()
        {
            rnd = new Random();
            ListRestaurants = new List<Restaurants>();
            ListMenusCommande = new List<Menus>();
            ListMenus = new List<Menus>();
            users = new List<Utilisateurs>();
            ListCommande = new List<Commandes>();
            ListLivreurs = new List<int>();
            users = await _service.Utilisateurs.GetUtilisateurs();
            foreach(Utilisateurs user in users){
                if(user.Type.Equals("Livreur")){
                    ListLivreurs.Add(user.IdUtilisateurs);
                }
            }
            ListRestaurants = await _service.Restaurants.GetRestaurants();
            ListMenus = await _service.Menus.GetMenus();

            foreach (Restaurants restos in ListRestaurants)
            {
                RestaurantBox.Items.Add(restos);
            }
        }

        private async void AjouterPanierClick(object sender, RoutedEventArgs e)
        {
            Menus _menuSelected = (Menus)MenuBox.SelectedItem;
            prix = 0.0M;
           
            if (_menuSelected != null)
            {
                Menus _stock = await _service.Menus.GetMenus(_menuSelected.IdMenus);
                if(_stock.Stock > 0)
                {
                    ListViewPanier.Items.Add(_menuSelected);
                }
            }
            for (int i = 0; i < ListViewPanier.Items.Count; i++)
            {
                Menus _itemMenu = (Menus)MenuBox.Items[i];
                ListMenusCommande.Add(_itemMenu);
                prix = (decimal)prix + (decimal)_itemMenu.Prix;
            }
            PrixTotal.Text = prix.ToString();
        }

        private async void ValiderClick(object sender, RoutedEventArgs e)
        {
            if(!NomPaiement.Text.Equals("") && NomPaiement.Text != "" 
                && !PrenomPaiement.Text.Equals("") && PrenomPaiement.Text != "" 
                && !NumeroPaiement.Text.Equals("") && NumeroPaiement.Text != "" && NumeroPaiement.Text.Length == 16
                && !CodePaiement.Text.Equals("") && CodePaiement.Text != "" && CodePaiement.Text.Length == 3
                && !DatePaiement.Text.Equals("") && DatePaiement.Text != "" && CodePaiement.Text.Length == 5)
            {
                int r = rnd.Next(ListLivreurs.Count);
                commande = new Commandes((double)prix, "Non livré", _userConnected.IdUtilisateurs, ListLivreurs[r]);
                _service.Commandes.AddCommandes(commande);
                ListCommande = await _service.Commandes.GetCommandes();
                commande = ListCommande[ListCommande.Count - 1];
                foreach (Menus menu in ListMenusCommande)
                {
                    MenuCommande menuCommande = new MenuCommande(commande.IdCommandes, menu.IdMenus);
                    _service.MenusCommande.AddMenuCommande(menuCommande);
                }
                ListViewPanier.Items.Clear();
                PrixTotal.Text = "";

                MessageDialog msgDialog = new MessageDialog("Votre commande a été créé", "Commande créé");
                await msgDialog.ShowAsync();
            }
            else
            {
                MessageDialog msgDialog = new MessageDialog("Informtion de paiement érroné", "Erreur");
                await msgDialog.ShowAsync();

            }
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            _userConnected = ((App)(Application.Current)).UserConnected;
            username.Text = _userConnected.Pseudo;
        }

        private async void RestaurantBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            MenuBox.Items.Clear();
            Restaurants restoItem = (Restaurants)RestaurantBox.SelectedItem;
            List<MenuRestaurant> menuResto = await _service.MenusRestaurant.GetMenuRestaurantByRestaurant(restoItem.IdRestaurants);
            foreach (MenuRestaurant _menuResto in menuResto)
            {
                foreach (Menus menu in ListMenus)
                {
                    if (menu.IdMenus == _menuResto.IdMenu)
                    {
                        MenuBox.Items.Add(menu);
                    }
                }
            }
        }

        private void Deco_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MainPage));
            ((App)(Application.Current)).UserConnected = null;
        }
    }
}
