using MVC6_QAndA.CC.TransferObject;
using System;
using System.Collections.Generic;
using System.Text;

namespace MVC6_QAndA.CC.Interfaces
{
    public interface IQuestionRepository : IRepository<QuestionTO>
    {
        public bool Archive(QuestionTO entity);
    }
}
