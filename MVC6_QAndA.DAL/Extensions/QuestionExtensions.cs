using MVC6_QAndA.CC.TransferObject;
using MVC6_QAndA.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MVC6_QAndA.DAL.Extensions
{
    public static class QuestionExtensions
    {
        public static QuestionTO ToTO(this QuestionEF question)
        {
            if (question is null)
            {
                throw new ArgumentNullException(nameof(question));
            }

            var questionTO = new QuestionTO
            {
                Id = question.Id,
                Questioning = question.Questioning,
                CreationDate = question.CreationDate,
                IsArchived = question.IsArchived,
                State = question.State,
                LostSoul = question.LostSoul.ToTO(),
                Answers = question.Answers?
                            .OrderBy(x => x.AnswerTime)
                            .Select(x => x.ToTO()).ToList()
            };
            return questionTO;
        }

        public static QuestionEF ToEF(this QuestionTO question)
        {
            if (question is null)
            {
                throw new ArgumentNullException(nameof(question));
            }

            var result = new QuestionEF
            {
                Id = question.Id,
                Questioning = question.Questioning,
                CreationDate = question.CreationDate,
                IsArchived = question.IsArchived,
                State = question.State,
                LostSoul = question.LostSoul.ToEF(),
                Answers = question.Answers?
                            .OrderBy(x => x.AnswerTime)
                            .Select(x => x.ToEF()).ToList()
            };
            return result;
        }

        public static QuestionEF UpdateFromDetached(this QuestionEF qAttach, QuestionEF qDetached)
        {
            if (qAttach is null)
                throw new ArgumentNullException();

            if (qDetached is null)
                throw new NullReferenceException();

            if (qAttach.Id != qDetached.Id)
                throw new Exception("Cannot update Question because it is not the same ID.");

            if ((qAttach != default) && (qDetached != default))
            {
                qAttach.Id = qDetached.Id;
                qAttach.LostSoul = qDetached.LostSoul;
                qAttach.IsArchived = qDetached.IsArchived;
                qAttach.Questioning = qDetached.Questioning;
                qAttach.Answers = qDetached.Answers;
                qAttach.CreationDate = qDetached.CreationDate;
                qAttach.State = qDetached.State;
            }

            return qAttach;
        }
    }
}
