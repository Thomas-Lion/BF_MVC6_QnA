using System;
using System.Collections.Generic;
using System.Text;

namespace MVC6_QAndA.CC.TransferObject
{
    public class AnswerTO
    {
        public int Id { get; set; }
        public int QuestionId { get; set; }
        public string Answering { get; set; }
        public UserTO Savior { get; set; }
        public DateTime AnswerTime { get; set; }
        public bool IsDeleted { get; set; }
    }
}
