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
                new Account { AccountType = AccountType.Main, Id = 1, Name = "Acc1", Number = "AC1",
                Cards = new List<Card>() {
                    new Card{ Id = 1, Number = "3434-4455-3444", ExpireDate = "06/28", HolderName = "John"},
                    new Card{ Id = 2, Number = "3433-4355-3444", ExpireDate = "06/24", HolderName = "James"}
                }

                },
                new Account { AccountType = AccountType.Sub, Id = 2, Name = "Acc2", Number = "AC2",
                Cards = new List<Card>() {
                    new Card{ Id = 4, Number = "3434-4455-3444", ExpireDate = "06/28", HolderName = "Dave"},
                    new Card{ Id = 5, Number = "3433-4355-3444", ExpireDate = "06/24", HolderName = "Dan"}
                }
                },

            };
        }
        public static AccountDbContext Current = new AccountDbContext();
    }
}
