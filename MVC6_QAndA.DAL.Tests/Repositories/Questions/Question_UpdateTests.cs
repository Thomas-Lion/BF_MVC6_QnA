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

namespace MVC6_QAndA.DAL.Tests.Repositories.Questions
{
    [TestClass]
    public class Question_UpdateTests
    {
        [TestMethod]
        public void Question_UpdateCorrect()
        {
            var options = new DbContextOptionsBuilder<QAndAContext>().UseInMemoryDatabase(MethodBase.GetCurrentMethod().Name).Options;
            var context = new QAndAContext(options);
            IQuestionRepository QRepo = new QuestionRepository(context);

            var question = new QuestionTO
            {
                Questioning = "Am I a construction vehicule ?",
                CreationDate = DateTime.Now,
                State = State.Pending,
                IsArchived = false,
                LostSoul = new UserTO { FirstName = "Stan", LastName = "The Cat" }
            };

            var insertedQuestion = QRepo.Insert(question);
            QRepo.Save();

            insertedQuestion.Questioning = "Stupid Question";
            var result = QRepo.Update(insertedQuestion);
            QRepo.Save();

            Assert.AreEqual("Stupid Question", result.Questioning);
        }

        [TestMethod]
        public void Question_UpdateWrongId()
        {
            var options = new DbContextOptionsBuilder<QAndAContext>().UseInMemoryDatabase(MethodBase.GetCurrentMethod().Name).Options;
            var context = new QAndAContext(options);
            IQuestionRepository QRepo = new QuestionRepository(context);

            var question = new QuestionTO
            {
                Id = 90000000,
                Questioning = "Am I a construction vehicule ?",
                CreationDate = DateTime.Now,
                State = State.Pending,
                IsArchived = false,
                LostSoul = new UserTO { FirstName = "Stan", LastName = "The Cat" }
            };
            Assert.ThrowsException<NullReferenceException>(() => QRepo.Update(question));
        }
    }
}
