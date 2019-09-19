using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Award
    {
        public int? IdAward { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public byte[] AwardImage { get; set; }

        public override string ToString()
        {
            return $"{IdAward}; {Title}; {Description}";
        }
    }
}
