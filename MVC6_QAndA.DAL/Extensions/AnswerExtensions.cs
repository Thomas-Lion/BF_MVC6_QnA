using MVC6_QAndA.CC.TransferObject;
using MVC6_QAndA.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MVC6_QAndA.DAL.Extensions
{
    public static class AnswerExtensions
    {
        public static AnswerTO ToTO(this AnswerEF answer)
        {
            return new AnswerTO
            {
                Id = answer.Id,
                Answering = answer.Answering,
                AnswerTime = answer.AnswerTime,
                Savior = answer.Savior.ToTO(),
                Question = answer.Question.ToTO()
            };
        }

        public static AnswerEF ToEF(this AnswerTO answer)
        {
            return new AnswerEF
            {
                Id = answer.Id,
                Answering = answer.Answering,
                AnswerTime = answer.AnswerTime,
                Savior = answer.Savior.ToEF(),
                Question = answer.Question.ToEF()
            };
        }
    }
}
