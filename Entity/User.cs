using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class User
    {
        public int IdUser { get; set; }
        public string Name { get; set; }
        public DateTime Birthday { get; set; }
        public int Age { get; set; }

        public override int GetHashCode()
        {
            return Name.GetHashCode() ^ Birthday.GetHashCode() ^ Age.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (!(obj is User value))
            {
                throw new ArgumentException("Ooops. Argument Exception");
            }

            return value.Name.Equals(this.Name) ^ value.Birthday.Equals(this.Birthday) ^ value.Age.Equals(this.Age);
        }

        public override string ToString()
        {
            return $"{IdUser}; {Name}; {Birthday}; {Age}";
        }
    }
}
