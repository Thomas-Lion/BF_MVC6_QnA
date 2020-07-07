using MVC6_QAndA.BL.Domain;
using MVC6_QAndA.CC.TransferObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MVC6_QAndA.BL.Extensions
{
    public static class QuestionExtensions
    {

        //public static QuestionTO ToTransferObject(this Question question)
        //{
        //    return new QuestionTO
        //    {
        //        Id = question.Id,
        //        Questioning = question.Questioning,
        //        LostSoul = question.LostSoul.ToTransferObject(),
        //        IsArchived = question.IsArchived,
        //        CreationDate = question.CreationDate,
        //        State = question.State,
        //        Answers = question.Answers.Select(x=>x.ToTransferObject()).ToList()
        //    };
        //}
    }
}
