using MVC6_QAndA.CC.TransferObject;
using System;
using System.Collections.Generic;
using System.Text;

namespace MVC6_QAndA.CC.Interfaces
{
    public interface IAnswerRepository : IRepository<AnswerTO>
    {
        public bool Delete(AnswerTO entity);
    }
}
