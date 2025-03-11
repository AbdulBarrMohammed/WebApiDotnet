using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public enum AccountType {
        Main,
        Sub
    }
    public class Account
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Number { get; set; }
        public AccountType AccountType { get; set; }

        public ICollection<Card> Cards {get; set;} = new List<Card>();


    }
}
