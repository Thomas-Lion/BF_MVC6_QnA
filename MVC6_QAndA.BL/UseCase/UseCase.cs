using MVC6_QAndA.CC.Enum;
using MVC6_QAndA.CC.Interfaces;
using MVC6_QAndA.CC.TransferObject;
using System;
using System.Collections.Generic;
using System.Text;

namespace MVC6_QAndA.BL.UseCase
{
    public partial class UseCase_Question : IQAndAUC
    {
        public AnswerTO AddAnswer(int questionId, AnswerTO answer)
        {
            throw new NotImplementedException();
        }

        public bool ArchiveQuestion(QuestionTO question)
        {
            throw new NotImplementedException();
        }

        public QuestionTO AskAQuestion(QuestionTO question)
        {
            throw new NotImplementedException();
        }

        public QuestionTO ChangeState(State state, QuestionTO question)
        {
            throw new NotImplementedException();
        }

        public QuestionTO GetQuestionById(int id)
        {
            throw new NotImplementedException();
        }

        public List<QuestionTO> ShowArchivedQuestions()
        {
            throw new NotImplementedException();
        }

        public List<QuestionTO> ShowNotResolvedQuestions()
        {
            throw new NotImplementedException();
        }

        public List<QuestionTO> ShowResolvedQuestions()
        {
            throw new NotImplementedException();
        }

        public QuestionTO UpdateQuestion(QuestionTO question)
        {
            throw new NotImplementedException();
        }
    }
}
