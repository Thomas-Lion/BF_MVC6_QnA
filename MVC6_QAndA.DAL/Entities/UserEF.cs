using System;
using System.Collections.Generic;
using System.Text;

namespace MVC6_QAndA.DAL.Entities
{
    public class UserEF
    {
        //id ? Identity or doing it myself ? 
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public ICollection<QuestionEF> Questions { get; set; }
    }
}
