using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MTZapocet.ViewModels
{
    public class AddUserPageVM
    {
        public Models.User User { get; set; }
        
        public AddUserPageVM()
        {
            User = new Models.User()
            {
                gender = "female",
                status = "active"
            };
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

        public async Task<bool> Create()
        {
            var tempJsonObj = Newtonsoft.Json.Linq.JObject.FromObject(User);
            tempJsonObj.Property("id").Remove();
            tempJsonObj.Property("classname").Remove();

            var response = await App.RestManager.Post("Users", tempJsonObj.ToString());

            if (string.IsNullOrEmpty(response))
                return false;
            else
            {
                var retUser = Newtonsoft.Json.JsonConvert.DeserializeObject<Models.User>(response);
                App.LocalDataStorage.Users.Add(retUser);
                await App.LocalDataStorage.SaveState();
                return true;
            }
        }








    }
}
