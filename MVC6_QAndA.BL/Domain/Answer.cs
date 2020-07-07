using System;
using System.Collections.Generic;
using System.Text;

namespace MVC6_QAndA.BL.Domain
{
    public class Answer
    {
        public int Id { get; set; }
        public Question Question { get; set; }
        public string Answering { get; set; }
        public User Savior { get; set; }
        public DateTime AnswerTime { get; set; }
    }
}
