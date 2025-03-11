using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class Card
    {
        public int Id { get; set; }
        public string HolderName { get; set; }
        public string Number { get; set; }

        public string ExpireDate { get; set; }

    }
}
