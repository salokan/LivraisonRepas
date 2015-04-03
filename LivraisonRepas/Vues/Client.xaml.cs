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
            prix = 0.0M;
            rnd = new Random();
            ListRestaurants = new List<Restaurants>();
            ListMenusCommande = new List<Menus>();
            ListMenus = new List<Menus>();
            users = new List<Utilisateurs>() ;
            ListLivreurs = new List<int>() ;
            foreach(Utilisateurs user in users){
                if(user.Type = "Livreur"){
                    ListLivreurs.Add(user.IdUtilisateurs);
                }
            }
            ListRestaurants = await _service.Restaurants.GetRestaurants();
            ListMenus = await _service.Menus.GetMenus();
            users = await _service.Utilisateurs.GetUtilisateurs();

            foreach (Restaurants restos in ListRestaurants)
            {
                RestaurantBox.Items.Add(restos);
            }
        }

        private async void AjouterPanierClick(object sender, RoutedEventArgs e)
        {
            Menus _menuSelected = (Menus)MenuBox.SelectedItem;
            Menus _stock = await _service.Menus.GetMenus(_menuSelected.IdMenus);
            if (_menuSelected != null && _stock.Stock > 0)
            {
                ListViewPanier.Items.Add(_menuSelected);
            }
            for (int i = 0; i < ListViewPanier.Items.Count; i++)
            {
                Menus _itemMenu = (Menus)RestaurantBox.Items[i];
                ListMenusCommande.Add(_itemMenu);
                prix = (decimal)prix + (decimal)_itemMenu.Prix;
            }
            PrixTotal.Text = prix.ToString();
        }

        private void ValiderClick(object sender, RoutedEventArgs e)
        {
            commande.Etat = "Non livré";
            commande.IdClients = _userConnected.IdUtilisateurs;
            int r = rnd.Next(ListLivreurs.Count);
            commande.IdLivreurs = ListLivreurs[r];
            commande.Prix = (double) prix;
            _service.Commandes.AddCommandes(commande);
            foreach (Menus menu in ListMenusCommande)
            {
                MenuCommande menuCommande = new MenuCommande();
                menuCommande.IdCommande = commande.IdCommandes;
                menuCommande.IdMenu = menu.IdMenus;
                _service.MenusCommande.AddMenuCommande(menuCommande);
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
    }
}
