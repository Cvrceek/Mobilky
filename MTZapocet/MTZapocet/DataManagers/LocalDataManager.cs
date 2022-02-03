using MTZapocet.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MTZapocet.DataManagers
{
    public class LocalDataManager
    {
        public LocalDataManager() 
        {
            Users = new List<User>()
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

            Todos = new List<ToDo>()
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


        public List<ToDo> Todos { get; set; }
        public List<User> Users { get; set; }


        #region LoggedUser
        public User LoggedUser { get; set; }
        #endregion



    }
}
