using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
 //   id_account int IDENTITY(1,1) NOT NULL CONSTRAINT[PK_Account] primary key,
	//[Email] nvarchar(250) unique NOT NULL,
	//[Password] nvarchar(500) NOT NULL,

 //   [Role] nvarchar(150) NOT NULL,

 //   [CreatedAt] datetime NOT NULL,
	//[LoggedInto] datetime NOT NULL,
	//[PasswordLifetime] datetime NOT NULL,
	//id_user int unique NOT NULL,
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
