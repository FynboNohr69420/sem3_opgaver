using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Board
    {
        public Board()
        {
        }

        public int Id { get; set; }

        // Navigation property for the one-to-many relationship with Task
        public ICollection<Todo> Tasks { get; set; } = new List<Todo>();

    }
}
