using MTZapocet.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace MTZapocet.Pages
{
    public class UserPage : ContentPage
    {
        ScrollView _ScrollView;
        Entry _Name, _EMail;
        RadioButton _FemaleRB, _MaleRB, _ActiveRB, _InActiveRB;
        StackLayout _StackLayout, _RBGroup, _RBGroup2;
        Button _UpdateBtn, _DeleteBtn;
        UserPageVM ViewModel;

        public UserPage(long userID)
        {
            ViewModel = new UserPageVM(userID);
            BindingContext = ViewModel;

            _ScrollView = new ScrollView()
            {
                HorizontalScrollBarVisibility = ScrollBarVisibility.Never,
                VerticalScrollBarVisibility = ScrollBarVisibility.Never
            };


            _Name = new Entry()
            {
                Placeholder = "Jméno a příjmení",
                HorizontalOptions = LayoutOptions.FillAndExpand,
                HorizontalTextAlignment = TextAlignment.Start

            };
            _Name.SetBinding(Entry.TextProperty, "User.name");
            _EMail = new Entry()
            {
                Placeholder = "E-mail",
                HorizontalOptions = LayoutOptions.FillAndExpand,
                HorizontalTextAlignment = TextAlignment.Start
            };
            _EMail.SetBinding(Entry.TextProperty, "User.email");


            _FemaleRB = new RadioButton()
            {
                Content = "Žena",
                GroupName = "1",
                IsChecked = true,
                HorizontalOptions = LayoutOptions.Center
            };

            _MaleRB = new RadioButton()
            {
                Content = "Muž",
                GroupName = "1",
                HorizontalOptions = LayoutOptions.Center
            };

            _RBGroup = new StackLayout()
            {
                Spacing = 0,
                Orientation = StackOrientation.Horizontal,
                HorizontalOptions = LayoutOptions.CenterAndExpand
            };
            _RBGroup.Children.Add(_FemaleRB);
            _RBGroup.Children.Add(_MaleRB);

            _ActiveRB = new RadioButton()
            {
                Content = "Aktivní",
                GroupName = "2",
                IsChecked = ViewModel.User.status == "active",
                HorizontalOptions = LayoutOptions.Center
            };

            _InActiveRB = new RadioButton()
            {
                Content = "Neaktivní",
                GroupName = "2",
                IsChecked = !(ViewModel.User.status == "active"),
                HorizontalOptions = LayoutOptions.Center
            };

            _RBGroup2 = new StackLayout()
            {
                Spacing = 0,
                Orientation = StackOrientation.Horizontal,
                HorizontalOptions = LayoutOptions.CenterAndExpand
            };
            _RBGroup2.Children.Add(_ActiveRB);
            _RBGroup2.Children.Add(_InActiveRB);

            _UpdateBtn = new Button()
            {
                Text = "Aktualizovat uživatele"
            };

            _DeleteBtn = new Button()
            {
                Text = "Smazat uživatele"
            };


            _StackLayout = new StackLayout()
            {
                Spacing = 8,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                Margin = new Thickness(16, 8, 16, 8)

            };
            _StackLayout.Children.Add(_Name);
            _StackLayout.Children.Add(_EMail);
            _StackLayout.Children.Add(_RBGroup);
            _StackLayout.Children.Add(_RBGroup2);
            _StackLayout.Children.Add(_UpdateBtn);
            _StackLayout.Children.Add(_DeleteBtn);

            _ScrollView.Content = _StackLayout;

            Content = _ScrollView;



            _FemaleRB.CheckedChanged += (s, e) =>
            {
                if (e.Value)
                    ViewModel.User.gender = "female";
            };

            _MaleRB.CheckedChanged += (s, e) =>
            {
                if (e.Value)
                    ViewModel.User.gender = "male";
            };

            _ActiveRB.CheckedChanged += (s, e) =>
            {
                if (e.Value)
                    ViewModel.User.status = "active";
            };

            _InActiveRB.CheckedChanged += (s, e) =>
            {
                if (e.Value)
                    ViewModel.User.status = "inactive";
            };

            _DeleteBtn.Clicked += async (s, e) =>
            {
                if (await ViewModel.Delete())
                {
                    await DisplayAlert("Smazání uživatele", "Smazání se povedlo", "OK");
                    await Navigation.PopAsync();
                }
                else
                {
                    await DisplayAlert("Smazání uživatele", "Smazání se nepovedlo", "OK");
                }
            };

            _UpdateBtn.Clicked += async (s, e) =>
            {
                string validateMsg = ViewModel.Validate();
                if (string.IsNullOrEmpty(validateMsg))
                {
                    if (await ViewModel.Update())
                    {
                        await DisplayAlert("Aktualizace uživatele", "Aktualizace se povedla", "OK");
                        await Navigation.PopAsync();
                    }
                    else
                    {
                        await DisplayAlert("Aktualizace uživatele", "Aktualizace se nepovedla", "OK");
                    }
                }
                else
                {
                    await DisplayAlert("Chybí údaje", validateMsg, "OK");
                }
            };
        }
    }
}