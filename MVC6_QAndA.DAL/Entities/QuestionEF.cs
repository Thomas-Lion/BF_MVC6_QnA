using MVC6_QAndA.CC.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace MVC6_QAndA.DAL.Entities
{
    public class QuestionEF
    {
        public int Id { get; set; }
        public string Questioning { get; set; }
        public bool IsArchived { get; set; }
        public DateTime CreationDate { get; set; }
        public UserEF LostSoul { get; set; }
        public ICollection<AnswerEF> Answers { get; set; }
        public State State { get; set; }
    }
}
