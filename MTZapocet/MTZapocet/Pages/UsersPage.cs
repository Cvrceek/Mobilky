using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace MTZapocet.Pages
{
    public class UsersPage : ContentPage
    {
        Grid _Grid;
        ListView _ListView;
        ImageButton _AddBtn;

        ViewModels.UsersPageVM ViewModel;


        public UsersPage()
        {
            NavigationPage.SetHasBackButton(this, false);
            var menu = new Menu();
            
            ViewModel = new ViewModels.UsersPageVM();
            BindingContext = ViewModel;
            _Grid = new Grid()
            {
                RowDefinitions = new RowDefinitionCollection()
                {
                    new RowDefinition(){Height = GridLength.Star}
                },
                ColumnDefinitions = new ColumnDefinitionCollection()
                {
                    new ColumnDefinition(){Width = GridLength.Star}
                }
            };

            _ListView = new ListView()
            {
                VerticalScrollBarVisibility = ScrollBarVisibility.Never,
                HorizontalScrollBarVisibility = ScrollBarVisibility.Never,
                SelectionMode = ListViewSelectionMode.None,
                HasUnevenRows = true,
                SeparatorVisibility = SeparatorVisibility.Default,
                Footer = new BoxView() { HeightRequest = 106}
                
            };
            _ListView.ItemTemplate = new DataTemplate(() => new ViewCell() { View = dataTemplateView() });
            _ListView.SetBinding(ListView.ItemsSourceProperty, "Users", BindingMode.OneWay);

            _AddBtn = new ImageButton()
            {
                Source = "outline_add_black_48.png",
                HorizontalOptions = LayoutOptions.End,
                VerticalOptions = LayoutOptions.End,
                CornerRadius = 32,
                BorderWidth = 1,
                BorderColor = Color.Black,
                BackgroundColor = Color.LightBlue,
                Margin = 16,
                
            };

            _Grid.Children.Add(_ListView, 0, 0);
            _Grid.Children.Add(_AddBtn, 0, 0);
            Content = _Grid;


            _ListView.ItemTapped += async (s, e) =>
            {
                await Navigation.PushAsync(new Pages.UserPage(((Models.User)e.Item).id));
            };

            _AddBtn.Clicked += async (s, e) =>
            {
                await Navigation.PushAsync(new Pages.AddUserPage());
            };
        }



        protected override void OnAppearing()
        {
            base.OnAppearing();
        }


        private View dataTemplateView()
        {
            Label view = new Label() 
            {
                Padding = new Thickness(16, 8, 16, 8) ,
                FontSize = 16
            };
            view.BindingContextChanged += (s, e) =>
            {
                if (view.BindingContext is Models.User item)
                {
                    view.Text = item.name;
                    view.InputTransparent = true;
                }
            };
            return view;
        }
    }
}
