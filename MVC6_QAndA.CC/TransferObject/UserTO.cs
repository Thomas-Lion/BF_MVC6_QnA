using System;
using System.Collections.Generic;
using System.Text;

namespace MVC6_QAndA.CC.TransferObject
{
    class UserTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public ICollection<QuestionTO> Questions { get; set; }
    }
}
