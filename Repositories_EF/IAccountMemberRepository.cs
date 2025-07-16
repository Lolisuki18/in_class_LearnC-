using BusinessObjects_EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories_EF
{
    public interface IAccountMemberRepository
    {
       public AccountMember Login(string email, string pwd);
        public bool ChangePassword(string email, string password, string oldPassword);
    }
}
