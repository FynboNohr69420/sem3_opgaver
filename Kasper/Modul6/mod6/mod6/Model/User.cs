using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class User
    {
        public User()
        {
        }
        public User(string name)
        {
            this.Navn = name;
        }
        public long UserId { get; set; }
        public string Navn { get; set; }
    }
}
