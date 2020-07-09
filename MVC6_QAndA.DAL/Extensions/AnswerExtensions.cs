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
            if (answer is null)
            {
                throw new ArgumentNullException(nameof(answer));
            }

            return new AnswerTO
            {
                Id = answer.Id,
                Answering = answer.Answering,
                AnswerTime = answer.AnswerTime,
                Savior = answer.Savior.ToTO(),
                QuestionId = answer.QuestionId
            };
        }

        public static AnswerEF ToEF(this AnswerTO answer)
        {
            if (answer is null)
            {
                throw new ArgumentNullException(nameof(answer));
            }

            return new AnswerEF
            {
                Id = answer.Id,
                Answering = answer.Answering,
                AnswerTime = answer.AnswerTime,
                Savior = answer.Savior.ToEF(),
                QuestionId = answer.QuestionId
            };
        }
    }
}
