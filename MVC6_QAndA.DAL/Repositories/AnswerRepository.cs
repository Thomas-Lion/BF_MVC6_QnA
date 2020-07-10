using Microsoft.EntityFrameworkCore;
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
            if (entity is null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            if (entity.Id <= 0)
            {
                throw new ArgumentException(nameof(entity));
            }

            if (entity.IsDeleted)
            {
                throw new ArgumentException(nameof(entity));
            }

            entity.IsDeleted = true;
            var result = Update(entity);

            return result != null;
        }

        public AnswerTO Get(int Id)
        {
            if (Id <= 0)
            {
                throw new ArgumentException();
            }
            var answer = context.Answers.AsNoTracking()
                                        .FirstOrDefault(x => x.Id == Id);
            if (answer == null)
            {
                throw new NullReferenceException();
            }
            return answer.ToTO();
        }

        public ICollection<AnswerTO> GetAll()
        {
            var answers = context.Answers.Where(x => x.IsDeleted == false)
                                         .Select(x => x.ToTO())
                                         .ToList();

            return answers;
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
            if (entity is null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            if (entity.Id <= 0)
            {
                throw new ArgumentException(nameof(entity));
            }

            var updated = context.Answers.FirstOrDefault(e => e.Id == entity.Id);
            if (updated != default)
            {
                updated.UpdateFromDetached(entity.ToEF());
            }
            Save();

            return context.Answers.Update(updated).Entity.ToTO();
        }
    }
}
