﻿using System;
using System.Collections.Generic;
using System.Text;

namespace MVC6_QAndA.DAL.Entities
{
    public class AnswerEF
    {
        public int Id { get; set; }
        public QuestionEF Question { get; set; }
        public string Answering { get; set; }
        public UserEF Savior { get; set; }
        public DateTime AnswerTime { get; set; }
    }
}