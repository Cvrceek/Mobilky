using MTZapocet.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace MTZapocet.Pages
{
    public class AddUserPage : ContentPage
    {
        ScrollView _ScrollView;
        Entry _Name, _EMail;
        RadioButton _FemaleRB, _MaleRB;
        StackLayout _StackLayout, _RBGroup;
        Button _AddBtn;
        AddUserPageVM ViewModel;


        public AddUserPage()
        {
            ViewModel = new AddUserPageVM();
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

            _AddBtn = new Button()
            {
                Text = "Přidat uživatele"
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
            _StackLayout.Children.Add(_AddBtn);

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

            _AddBtn.Clicked += async (s, e) =>
            {
                string validateMsg = ViewModel.Validate();
                if (string.IsNullOrEmpty(validateMsg))
                {
                    if (await ViewModel.Create())
                    {
                        await DisplayAlert("Vytvoření uživatele", "Vytvoření se povedlo", "OK");
                        await Navigation.PopAsync();
                    }
                    else
                    {
                       await DisplayAlert("Vytvoření uživatele", "Vytvoření se nepovedlo", "OK");
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