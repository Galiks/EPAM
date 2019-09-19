using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class UsersAwards
    {
        public int? UserId { get; set; }
        public int? AwardId { get; set; }

        public override string ToString()
        {
            return $"{UserId}; {AwardId}";
        }
    }
}
