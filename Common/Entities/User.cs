using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Entities
{
    public class User : BasicEntity
    {
        public string Name { get; set; }
        
        public string Surname { get; set; }
        
        public string Adress { get; set; }
        
        public string Password { get; set; }
    }
}
