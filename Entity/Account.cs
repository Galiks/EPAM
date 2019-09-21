using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Account
    {
        public int? IdAccount { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? LoggedInto { get; set; }
        public DateTime? PasswordLifetime { get; set; }
        public int? IdUser { get; set; }
    }
}
