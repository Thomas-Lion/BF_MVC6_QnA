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

namespace MVC6_QAndA.DAL.Tests.Repositories.Answers
{
    [TestClass]
    public class Answer_ArchiveTests
    {
        [TestMethod]
        public void ArchiveAnswer_Correct()
        {
            var options = new DbContextOptionsBuilder<QAndAContext>().UseInMemoryDatabase(MethodBase.GetCurrentMethod().Name).Options;
            var context = new QAndAContext(options);
            IAnswerRepository ARepo = new AnswerRepository(context);
            IQuestionRepository QRepo = new QuestionRepository(context);

            var question = new QuestionTO
            {
                Questioning = "Not hungry",
                CreationDate = DateTime.Now,
                State = State.Pending,
                IsArchived = false,
                LostSoul = new UserTO { FirstName = "Don't wanna", LastName = "Eat" }
            };

            var addedQuestion = QRepo.Insert(question);
            QRepo.Save();

            var answer = new AnswerTO
            {
                Answering = "must be the donuts",
                AnswerTime = DateTime.Now.AddHours(1),
                QuestionId = addedQuestion.Id,
                Savior = new UserTO { FirstName = "Any", LastName = "Officer" }
            };

            var addedAnswer = ARepo.Insert(answer);
            ARepo.Save();

            Assert.AreEqual(1, ARepo.GetAll().Count());

            ARepo.Delete(addedAnswer);
            ARepo.Save();

            Assert.IsTrue(ARepo.Get(addedAnswer.Id).IsDeleted);
        }
    }
}
