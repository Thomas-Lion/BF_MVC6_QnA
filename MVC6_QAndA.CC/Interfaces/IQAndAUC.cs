using MVC6_QAndA.CC.Enum;
using MVC6_QAndA.CC.TransferObject;
using System;
using System.Collections.Generic;
using System.Text;

namespace MVC6_QAndA.CC.Interfaces
{
    public interface IQAndAUC
    {
        List<QuestionTO> ShowNotResolvedQuestions();
        List<QuestionTO> ShowResolvedQuestions();
        List<QuestionTO> ShowArchivedQuestions();
        QuestionTO AskAQuestion(QuestionTO question);
        QuestionTO UpdateQuestion(QuestionTO question);
        bool ArchiveQuestion(QuestionTO question);
        QuestionTO ChangeState(State state, QuestionTO question);
        QuestionTO GetQuestionById(int id);
        AnswerTO AddAnswer(int questionId, AnswerTO answer);
    }
}
