using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MTZapocet.ViewModels
{
    public class LoginPageVM 
    {
        public LoginPageVM()
        {
#if DEBUG
            username = "Administrator";
#endif
        }

        private string username;

        public string Username
        {
            get { return username; }
            set { username = value; }
        }
        public bool IsAdmin { get; private set; }

        public async Task<bool> Login()
        {
            if(Username == "Administrator")
            {
                ObservableCollection<Models.User> users;
                var response = await App.RestManager.Get("Users");
                if (string.IsNullOrEmpty(response))
                    return false;
                else
                    users = Newtonsoft.Json.JsonConvert.DeserializeObject<ObservableCollection<Models.User>>(response);

                ObservableCollection<Models.ToDo> todos;
                response = await App.RestManager.Get("Todos");
                if (string.IsNullOrEmpty(response))
                    return false;
                else
                    todos = Newtonsoft.Json.JsonConvert.DeserializeObject<ObservableCollection<Models.ToDo>>(response);


                App.LocalDataStorage.Users = users;
                App.LocalDataStorage.Todos = todos;

                App.LocalDataStorage.LoggedUser = new Models.User()
                {
                    id = -666,
                    email = "admin@admin.cz",
                    name = "Admin Adminičovič"
                };
                IsAdmin = true;

                await App.LocalDataStorage.SaveState();
            }
            else
            {
                Models.User user;
                var response = await App.RestManager.Get("Users?email=" + username);
                if (string.IsNullOrEmpty(response))
                    return false;
                else
                    user = Newtonsoft.Json.JsonConvert.DeserializeObject<Models.User>(response);

                ObservableCollection<Models.ToDo> todos;
                response = await App.RestManager.Get("Todos?user_id=" + user.id);
                if (string.IsNullOrEmpty(response))
                    return false;
                else
                    todos = Newtonsoft.Json.JsonConvert.DeserializeObject<ObservableCollection<Models.ToDo>>(response);


                App.LocalDataStorage.LoggedUser = user;
                App.LocalDataStorage.Todos = todos;
                IsAdmin = false;
                await App.LocalDataStorage.SaveState();
            }

            return true;
        }






    }
}
