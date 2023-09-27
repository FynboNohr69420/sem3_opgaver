using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Todo {
        public Todo()
        {
        }
        public long TodoID { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public int BoardID { get; set; }
        public Board Board { get; set; }
        public User User { get; set; }
    }
}
