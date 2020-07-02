using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MVC6_QAndA.CC.Enum;
using MVC6_QAndA.CC.Interfaces;
using MVC6_QAndA.CC.TransferObject;
using MVC6_QAndA.DAL.Entities;
using MVC6_QAndA.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace MVC6_QAndA.DAL.Tests.Repositories
{
    [TestClass]
    public class Question_InsertTests
    {
        [TestMethod]
        public void InsertQuestion_CorrectFormat()
        {
            var options = new DbContextOptionsBuilder<QAndAContext>().UseInMemoryDatabase(MethodBase.GetCurrentMethod().Name).Options;
            var context = new QAndAContext(options);
            IQuestionRepository QRepo = new QuestionRepository(context);

            var question = new QuestionTO
            {
                Questioning = "Maybe it's working",
                CreationDate = DateTime.Now,
                State = State.Pending,
                IsArchived = false,
                LostSoul = new UserTO { FirstName = "Call me", LastName = "Kevin"}
            };

            var result = QRepo.Insert(question);
            QRepo.Save();

            Assert.AreEqual("Maybe it's working", result.Questioning);
        }

        [TestMethod]
        public void InsertQuestion_NullException()
        {
            var options = new DbContextOptionsBuilder<QAndAContext>().UseInMemoryDatabase(MethodBase.GetCurrentMethod().Name).Options;
            var context = new QAndAContext(options);
            IQuestionRepository QRepo = new QuestionRepository(context);

            Assert.ThrowsException<ArgumentNullException>(() => QRepo.Insert(null));
        }
    }
}
