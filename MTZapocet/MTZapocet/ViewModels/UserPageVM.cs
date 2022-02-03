using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;

namespace MTZapocet.ViewModels
{
    public class UserPageVM
    {
        public Models.User User { get; set; }


        public UserPageVM(long id)
        {
            User = new Models.User();
            var tempUser = App.LocalDataStorage.Users.First(x => x.id == id);
            foreach(var p in tempUser.GetType().GetProperties())
            {
                p.SetValue(User, p.GetValue(tempUser));
            }
        }

        public async Task<bool> Update()
        {
            var tempJsonObj = Newtonsoft.Json.Linq.JObject.FromObject(User);
            tempJsonObj.Property("id").Remove();
            tempJsonObj.Property("classname").Remove();

            var response = await App.RestManager.Put("Users/" + User.id.ToString(), tempJsonObj.ToString());

            if (string.IsNullOrEmpty(response))
                return false;
            else
            {
                var retUser = Newtonsoft.Json.JsonConvert.DeserializeObject<Models.User>(response);
                int index = App.LocalDataStorage.Users.IndexOf(App.LocalDataStorage.Users.First(x => x.id == User.id));
                App.LocalDataStorage.Users[index] = retUser;
                await App.LocalDataStorage.SaveState();
                return true;
            }
        }

        public async Task<bool> Delete()
        {
            var response = await App.RestManager.Delete("Users/" + User.id.ToString());

            if (string.IsNullOrEmpty(response))
                return false;
            else
            {
                App.LocalDataStorage.Users.Remove(App.LocalDataStorage.Users.First(x => x.id == User.id));
                await App.LocalDataStorage.SaveState();
                return true;
            }
        }

        public string Validate()
        {
            string retVal = string.Empty;
            if (string.IsNullOrWhiteSpace(User.name))
                retVal += "Vyplňte jméno uživatele." + System.Environment.NewLine;
            if (string.IsNullOrWhiteSpace(User.email))
                retVal += "Vyplňte e-mail uživatele." + System.Environment.NewLine;
            return retVal;
        }


    }
}
