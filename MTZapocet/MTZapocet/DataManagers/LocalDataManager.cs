using MTZapocet.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace MTZapocet.DataManagers
{
    public class LocalDataManager
    {
        public LocalDataManager() 
        {
            Users = new ObservableCollection<User>()
            {
                new User()
                {
                    id = 1,
                    name = "test uzivatel",
                    email = "test@test.cz",
                    gender = "famele",
                    status = "active"
                }
            };

            Todos = new ObservableCollection<ToDo>()
            {
                new ToDo()
                {
                    id = 1,
                    due_on = DateTime.Now,
                    status = "completed",
                    title = "TODODODODOD",
                    user_id = 1
                }
            };

            LoggedUser = new User();
        
        
        }


        public ObservableCollection<ToDo> Todos { get; set; }
        public ObservableCollection<User> Users { get; set; }


        public async Task SaveState()
        {

        }

        #region LoggedUser
        public User LoggedUser { get; set; }
        #endregion



    }
}
