using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Entities
{
    public class Interactions
    {
        public int Id { get; set; }
        public string Type { get; set; } 
        public DateTime Timestamp { get; set; }
        public int UserId { get; set; } // Foreign key to User
    }
}
