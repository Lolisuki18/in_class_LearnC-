using BusinessObject_EF_IO;
using Repositories_EF_IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services_EF_IO
{
    public class AccountMemberService : IAccountMemberService
    {
        AccountMemberRepository repository = new AccountMemberRepository();
        public AccountMember Login(string username, string password) => repository.Login(username, password);
       
    }
}
