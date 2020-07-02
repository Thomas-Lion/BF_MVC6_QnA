using System.Collections.Generic;

namespace MVC6_QAndA.CC.TransferObject
{
    public class UserTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public ICollection<QuestionTO> Questions { get; set; }
    }
}