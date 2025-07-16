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
        public bool ChangePassword( string email,string password , string oldPassword)
        {
            if(password == null || email == null)
            {
                return false;
            }
            AccountMember existAccount = context.AccountMembers.FirstOrDefault(a => a.EmailAddress == email);
            if(existAccount != null)
            {
                if (existAccount.MemberPassword == oldPassword)
                {
                    existAccount.MemberPassword = password;
                    int ret = context.SaveChanges();
                    return ret > 0;
                }
            }
            return false;

        }
    }
}
