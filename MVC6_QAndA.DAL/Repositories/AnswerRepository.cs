using MVC6_QAndA.CC.Interfaces;
using MVC6_QAndA.CC.TransferObject;
using MVC6_QAndA.DAL.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
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
            if (entity is null)
            {
                throw new ArgumentNullException();
            }
            if (entity.Id != 0)
            {
                return entity;
            }

            var question = context.Questions.FirstOrDefault(x=>x.Id == entity.QuestionId);

            var result = context.Answers.Add(entity.ToEF());
            
            question.Answers.Add(result.Entity);
            
            return result.Entity.ToTO();
        }

        public AnswerTO Update(AnswerTO entity)
        {
            throw new NotImplementedException();
        }
    }
}
