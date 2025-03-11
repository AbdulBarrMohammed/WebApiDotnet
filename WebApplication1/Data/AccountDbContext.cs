using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Data
{
    public class AccountDbContext
    {
        public List<Account> Accounts { get; set; } = new List<Account>();
        private AccountDbContext() {
            Accounts = new List<Account>() {
                new Account { AccountType = AccountType.Main, Id = 1, Name = "Acc1", Number = "AC1"},
                new Account { AccountType = AccountType.Sub, Id = 2, Name = "Acc2", Number = "AC2"},

            };
        }
        public static AccountDbContext Current = new AccountDbContext();
    }
}
