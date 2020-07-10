using System;
using System.Collections.Generic;
using System.Text;

namespace MVC6_QAndA.DAL.Entities
{
    public class AnswerEF
    {
        public int Id { get; set; }
        public int QuestionId { get; set; }
        public string Answering { get; set; }
        public string SaviorId { get; set; }
        public DateTime AnswerTime { get; set; }
        public bool IsDeleted { get; set; }
    }
}
