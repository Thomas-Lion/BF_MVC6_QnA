using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MVC6_QAndA.CC.Enum;
using MVC6_QAndA.CC.Interfaces;
using MVC6_QAndA.CC.TransferObject;
using MVC6_QAndA.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace MVC6_QAndA.DAL.Tests.Repositories
{
    [TestClass]
    public class Question_GetTests
    {
        [TestMethod]
        public void Question_Get()
        {
            var options = new DbContextOptionsBuilder<QAndAContext>().UseInMemoryDatabase(MethodBase.GetCurrentMethod().Name).Options;
            var context = new QAndAContext(options);
            IQuestionRepository QRepo = new QuestionRepository(context);

            var question = new QuestionTO
            {
                Questioning = "How can i make money with that ?",
                CreationDate = DateTime.Now,
                State = State.Resolved,
                IsArchived = false,
                LostSoul = new UserTO { FirstName = "Captain", LastName = "Krabs" }
            };

            var added = QRepo.Insert(question);
            QRepo.Save();
            var result = QRepo.Get(added.Id);

            Assert.AreEqual("How can i make money with that ?", result.Questioning);
        }

        [TestMethod]
        public void Question_Get_NothingToGet()
        {
            var options = new DbContextOptionsBuilder<QAndAContext>().UseInMemoryDatabase(MethodBase.GetCurrentMethod().Name).Options;
            var context = new QAndAContext(options);
            IQuestionRepository QRepo = new QuestionRepository(context);

            Assert.ThrowsException<ArgumentException>(() => QRepo.Get(-15));
        }
    }
}
