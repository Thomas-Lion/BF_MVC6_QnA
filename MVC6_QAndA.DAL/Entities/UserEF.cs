using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace MVC6_QAndA.DAL.Entities
{
    public class UserEF : IdentityUser<string>
    {
        public UserEF()
        {
        }

        public UserEF(string userName) : base(userName)
        {
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        //public ICollection<QuestionEF> Questions { get; set; }
    }
}
