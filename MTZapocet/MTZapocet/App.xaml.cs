using MTZapocet.DataManagers;
using MTZapocet.Pages;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MTZapocet
{
    public partial class App : Application
    {
        public static LocalDataManager LocalDataStorage { get; set; }
        public App()
        {

            LocalDataStorage = new LocalDataManager();



            InitializeComponent();
            MainPage = new NavigationPage(new LoginPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
