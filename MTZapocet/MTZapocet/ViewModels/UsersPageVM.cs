using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace MTZapocet.ViewModels
{
    public class UsersPageVM
    {
        public ObservableCollection<Models.User> Users
        {
            get { return App.LocalDataStorage.Users; }
            private set { }
        }
    }
}
