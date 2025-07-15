using BusinessObjects_EF;
using Repositories_EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services_EF
{
    public class AccountMemberService : IAccountMemberService
    {
        IAccountMemberRepository accountMemberRepository;

        public AccountMemberService()
        {
            accountMemberRepository = new AccountMemberRepository();
        }
        public AccountMember Login(string email, string pwd)
        {
            return accountMemberRepository.Login(email, pwd);
        }
    }
}
