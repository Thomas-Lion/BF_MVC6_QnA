using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MVC6_QAndA.CC.Enum;
using MVC6_QAndA.CC.Interfaces;
using MVC6_QAndA.CC.TransferObject;
using MVC6_QAndA.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace MVC6_QAndA.DAL.Tests.Repositories.Questions
{
    [TestClass]
    public class Question_GetAllTests
    {
        [TestMethod]
        public void Question_GetAll()
        {
            var options = new DbContextOptionsBuilder<QAndAContext>().UseInMemoryDatabase(MethodBase.GetCurrentMethod().Name).Options;
            var context = new QAndAContext(options);
            IQuestionRepository QRepo = new QuestionRepository(context);

            var question1 = new QuestionTO
            {
                Questioning = "Great Power Blah blah blah",
                CreationDate = DateTime.Now,
                State = State.Resolved,
                IsArchived = false,
                LostSoul = new UserTO { FirstName = "Peter", LastName = "Pan" }
            };
            var question2 = new QuestionTO
            {
                Questioning = "How to cure RDR2",
                CreationDate = DateTime.Now,
                State = State.Pending,
                IsArchived = false,
                LostSoul = new UserTO { FirstName = "Arthur", LastName = "Morgan" }
            };
            var question3 = new QuestionTO
            {
                Questioning = "Why no tracking ?",
                CreationDate = DateTime.Now,
                State = State.Pending,
                IsArchived = true,
                LostSoul = new UserTO { FirstName = "Pro", LastName = "Stalker" }
            };

            QRepo.Insert(question1);
            QRepo.Insert(question2);
            QRepo.Insert(question3);
            QRepo.Save();

            var result = QRepo.GetAll();

            Assert.AreEqual(2, result.Count());
        }
    }
}
