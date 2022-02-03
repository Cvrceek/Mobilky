using System;
using System.Collections.Generic;
using System.Text;

namespace MTZapocet.Models
{
    public class User : BaseModel
    {
        public User() : base("User") { }
        public string name { get; set; }
        public string email { get; set; }
        public string gender { get; set; }
        public string status { get; set; }

    }
}
