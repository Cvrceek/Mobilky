using System;
using System.Collections.Generic;
using System.Text;

namespace MTZapocet.Models
{
    public class BaseModel 
    {
        public BaseModel(string classname)
        {
            this.classname = classname;
        }
        public long id { get; set; }
        public string classname { get; set; }

    }
}
