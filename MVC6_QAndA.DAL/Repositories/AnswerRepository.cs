using MVC6_QAndA.CC.Interfaces;
using MVC6_QAndA.CC.TransferObject;
using System;
using System.Collections.Generic;
using System.Text;

namespace MVC6_QAndA.DAL.Repositories
{
    public class AnswerRepository : IAnswerRepository
    {
        private readonly QAndAContext context;

        public AnswerRepository(QAndAContext context)
        {
            this.context = context;
        }
        public int Save()
        {
            return context.SaveChanges();
        }

        public bool Delete(AnswerTO entity)
        {
            throw new NotImplementedException();
        }

        public AnswerTO Get(int Id)
        {
            throw new NotImplementedException();
        }

        public ICollection<AnswerTO> GetAll()
        {
            throw new NotImplementedException();
        }

        public AnswerTO Insert(AnswerTO entity)
        {
            throw new NotImplementedException();
        }

        public AnswerTO Update(AnswerTO entity)
        {
            throw new NotImplementedException();
        }
    }
}
