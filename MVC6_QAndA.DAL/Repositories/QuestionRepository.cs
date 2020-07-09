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
    public class QuestionRepository : IQuestionRepository
    {
        private readonly QAndAContext context;

        public QuestionRepository(QAndAContext context)
        {
            this.context = context;
        }

        public int Save()
        {
            return context.SaveChanges();
        }

        public bool Archive(QuestionTO entity)
        {
            if (entity is null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            if (entity.Id <= 0)
            {
                throw new ArgumentException(nameof(entity));
            }

            if (entity.IsArchived)
            {
                throw new ArgumentException(nameof(entity));
            }

            entity.IsArchived = true;
            var result = Update(entity);

            return result != null;
        }

        public QuestionTO Get(int Id)
        {
            if (Id <= 0)
            {
                throw new ArgumentException();
            }
            var question = context.Questions.AsNoTracking()
                                            .Include(x => x.LostSoul)
                                            .Include(x => x.Answers)
                                            .ThenInclude(x => x.Savior)
                                            .FirstOrDefault(x => x.Id == Id);
            if (question == null)
            {
                throw new NullReferenceException();
            }
            return question.ToTO();
        }

        public ICollection<QuestionTO> GetAll()
        {
            //var questionsTO = new List<QuestionTO>();

            var questions = context.Questions//.AsEnumerable()
                                             //.Include(x => x.LostSoul)
                                             //.Include(x => x.Answers)
                                             //.ThenInclude(x => x.Savior)
                                             .Where(x => x.IsArchived == false)
                                             .Select(x => x.ToTO())
                                             .ToList()
                                             ;

            //foreach (var q in questions)
            //{
            //    questionsTO.Add(q.ToTO());
            //}

            return questions;
        }

        public QuestionTO Insert(QuestionTO entity)
        {
            if (entity is null)
            {
                throw new ArgumentNullException();
            }
            if (entity.Id != 0)
            {
                return entity;
            }
            entity.Answers = new List<AnswerTO>();
            var result = context.Questions.Add(entity.ToEF());
            return result.Entity.ToTO();
        }

        public QuestionTO Update(QuestionTO entity)
        {
            if (entity is null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            if (entity.Id <= 0)
            {
                throw new ArgumentException(nameof(entity));
            }

            var updated = //Get(entity.Id).ToEF();
            context.Questions.FirstOrDefault(e => e.Id == entity.Id);
            if (updated != default)
            {
                updated.UpdateFromDetached(entity.ToEF());
            }
            Save();

            return context.Questions.Update(updated).Entity.ToTO();
        }

        public ICollection<QuestionTO> GetArchived()
        {
            var archive = context.Questions.Where(x => x.IsArchived == true)
                                           .Select(x => x.ToTO())
                                           .ToList();
            return archive;
        }
    }
}
