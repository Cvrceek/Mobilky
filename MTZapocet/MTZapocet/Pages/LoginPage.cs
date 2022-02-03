using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace MTZapocet.Pages
{
    public class LoginPage : ContentPage
    {
        StackLayout _StackLayout;
        Image _Image;
        Entry _UserName;
        Button _LoginBtn;


        public LoginPage()
        {
            NavigationPage.SetHasNavigationBar(this, false);

            _Image = new Image()
            {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Start,
                Background = Color.Black
            };

            _UserName = new Entry()
            {
                Placeholder = "Token",
                Margin = 16
            };

            _LoginBtn = new Button()
            {
                Text = "Login",
                HorizontalOptions = LayoutOptions.Center
            };

            _StackLayout = new StackLayout()
            {
                Spacing = 0,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.StartAndExpand
            };

            _StackLayout.Children.Add(_Image);
            _StackLayout.Children.Add(_UserName);
            _StackLayout.Children.Add(_LoginBtn);

            Content = _StackLayout;

            _LoginBtn.Clicked += async (s, e) =>
            {
                if (string.IsNullOrWhiteSpace(_UserName.Text))
                    await DisplayAlert("Nezadaný token", "Pro přihlášení je nutné zadat ověřovací token", "OK");
                else if (!string.IsNullOrWhiteSpace(_UserName.Text) && _UserName.Text != "2b35e5dc854f2a8f8701719747fc6a46503265b1cd74f03e697ab67db23f803b")
                    await DisplayAlert("Neplatný token", "Zadaný token není platný", "OK");
                else
                {
                    Navigation.InsertPageBefore(new DashboardPage(), this);
                    await Navigation.PopAsync();
                }
            };
        }

        protected override void OnAppearing()
        {
#if DEBUG
            _UserName.Text = "2b35e5dc854f2a8f8701719747fc6a46503265b1cd74f03e697ab67db23f803b";
#endif

            base.OnAppearing();
        }

        
    }
}