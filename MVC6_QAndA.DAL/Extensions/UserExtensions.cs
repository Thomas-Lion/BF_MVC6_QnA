using MVC6_QAndA.CC.TransferObject;
using MVC6_QAndA.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MVC6_QAndA.DAL.Extensions
{
    public static class UserExtensions
    {
        public static UserTO ToTO(this UserEF user)
        {
            return new UserTO
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
            };

        }

        public static UserEF ToEF(this UserTO user)
        {
            return new UserEF
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                //Questions = user.Questions?.Select(x => x.ToEF()).ToList()
            };
        }
    }
}
