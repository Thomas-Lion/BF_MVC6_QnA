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
    }
}
