using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace MVC6_QAndA.DAL.Entities
{
    public class UserRoleEF : IdentityRole<string>
    {
        public UserRoleEF()
        {
        }

        public UserRoleEF(string roleName) : base(roleName)
        {
        }
    }
}
