﻿using System;
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
                    await DisplayAlert("Nezadané uživatelské jméno", "Pro přihlášení je nutné zadat uživatelské jméno", "OK");
                else if (!string.IsNullOrWhiteSpace(_UserName.Text) && _UserName.Text == admin)
                {
                    App.LocalDataStorage.LoggedUser = new Models.User()
                    {
                        email = "admin@admin.cz",
                        id = -666,
                        gender = "male",
                        status = "active",
                        name = "Admin Administratorovič"
                    };

                    Navigation.InsertPageBefore(new UsersPage(), this);
                    await Navigation.PopAsync();
                }
                else
                {
                    //login vole dodělej

                    if (true)
                    {
                        App.LocalDataStorage.LoggedUser = new Models.User()
                        {
                            email = "admin@admin.cz",
                            id = 666,
                            gender = "male",
                            status = "active",
                            name = "Admin Administratorovič"
                        };

                        Navigation.InsertPageBefore(new TasksPage(), this);
                        await Navigation.PopAsync();
                    }
                    else
                    {
                        await DisplayAlert("Neplatné uživatelské jméno", "Pro přihlášení je nutné zadat správné uživatelské jméno", "OK");
                    }

                }
            };
        }

        protected override void OnAppearing()
        {
#if DEBUG
            _UserName.Text = "Administrator";
#endif

            base.OnAppearing();
        }





    }
}