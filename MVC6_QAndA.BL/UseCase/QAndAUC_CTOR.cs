using MVC6_QAndA.CC.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MVC6_QAndA.BL.UseCase
{
    public partial class QAndAUC_CTOR 
    {
        private readonly IQuestionRepository questionRepository;
        private readonly IAnswerRepository answerRepository;


        public QAndAUC_CTOR(IAnswerRepository answerRepository, IQuestionRepository questionRepository)
        {
            this.questionRepository = questionRepository ?? throw new System.ArgumentNullException(nameof(questionRepository));
            this.answerRepository = answerRepository ?? throw new System.ArgumentNullException(nameof(answerRepository));
        }
    }
}
