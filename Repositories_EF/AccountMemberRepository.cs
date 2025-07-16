using BusinessObjects_EF;
using DataAccessLayer_EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories_EF
{
    public class AccountMemberRepository : IAccountMemberRepository
    {

        AccountMemberDAO accountMemberDAO = new AccountMemberDAO();

        public bool ChangePassword(string email, string password, string oldPassword)
        {
          return  accountMemberDAO.ChangePassword(email, password,  oldPassword);
        }

        public AccountMember Login(string email, string pwd)
        {
            return accountMemberDAO.Login(email, pwd);
        }
    }
}
