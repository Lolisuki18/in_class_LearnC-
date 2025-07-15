using BusinessObjects_EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer_EF
{
    public class AccountMemberDAO
    {
        MyStoreContext context = new MyStoreContext();

        public AccountMember Login (string email , string pwd)
        {
            return context.AccountMembers.FirstOrDefault(a => a.EmailAddress == email && a.MemberPassword == pwd);
        }
    }
}
