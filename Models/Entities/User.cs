using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        //[NotMapped]
        public byte[] PasswordHash { get; set; }
        //[NotMapped]
        public byte[] PasswordSalt { get; set; }
        public string Email { get; set; }
        public int IdProfile { get; set; }
    }
}
