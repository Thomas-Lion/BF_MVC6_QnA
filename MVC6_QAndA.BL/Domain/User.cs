using System;
using System.Collections.Generic;
using System.Text;

namespace MVC6_QAndA.BL.Domain
{
    public class User
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public ICollection<Question> Questions { get; set; }
    }
}
