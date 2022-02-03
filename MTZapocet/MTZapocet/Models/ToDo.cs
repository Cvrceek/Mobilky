using System;
using System.Collections.Generic;
using System.Text;

namespace MTZapocet.Models
{
    public class ToDo : BaseModel 
    {
        public ToDo() : base("ToDo") { }
        public int user_id { get; set; }
        public string title { get; set; }
        public DateTime due_on { get; set; }
        public string status { get; set; }
    }
}
