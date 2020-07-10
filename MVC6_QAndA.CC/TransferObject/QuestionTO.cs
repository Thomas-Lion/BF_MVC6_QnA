using MVC6_QAndA.CC.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace MVC6_QAndA.CC.TransferObject
{
    public class QuestionTO
    {
        public int Id { get; set; }
        public string Questioning { get; set; }
        public bool IsArchived { get; set; }
        public DateTime CreationDate { get; set; }
        public UserTO LostSoul { get; set; }
        public string LostSoulId { get; set; }
        public ICollection<AnswerTO> Answers { get; set; }
        public State State { get; set; }
    }
}
