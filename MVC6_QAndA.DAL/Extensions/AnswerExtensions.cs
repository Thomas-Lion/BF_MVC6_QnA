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
                SaviorId = answer.SaviorId,
                QuestionId = answer.QuestionId,
                IsDeleted = answer.IsDeleted
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
                SaviorId = answer.SaviorId,
                QuestionId = answer.QuestionId,
                IsDeleted = answer.IsDeleted
            };
        }

        public static AnswerEF UpdateFromDetached(this AnswerEF qAttach, AnswerEF qDetached)
        {
            if (qAttach is null)
                throw new ArgumentNullException();

            if (qDetached is null)
                throw new NullReferenceException();

            if (qAttach.Id != qDetached.Id)
                throw new Exception("Cannot update Answer because it is not the same ID.");

            if ((qAttach != default) && (qDetached != default))
            {
                qAttach.Id = qDetached.Id;
                qAttach.SaviorId = qDetached.SaviorId;
                qAttach.IsDeleted = qDetached.IsDeleted;
                qAttach.Answering = qDetached.Answering;
                qAttach.AnswerTime = qDetached.AnswerTime;
                qAttach.QuestionId = qDetached.QuestionId;
            }

            return qAttach;
        }
    }
}
