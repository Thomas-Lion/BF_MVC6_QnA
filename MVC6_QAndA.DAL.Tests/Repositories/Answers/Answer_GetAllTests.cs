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
    public class Answer_GetAllTests
    {
        [TestMethod]
        public void GetAllAnswers_Correct()
        {
            var options = new DbContextOptionsBuilder<QAndAContext>().UseInMemoryDatabase(MethodBase.GetCurrentMethod().Name).Options;
            var context = new QAndAContext(options);
            IAnswerRepository ARepo = new AnswerRepository(context);
            IQuestionRepository QRepo = new QuestionRepository(context);

            var question1 = new QuestionTO
            {
                Questioning = "How can I stop being Rickrolled ?",
                CreationDate = DateTime.Now,
                State = State.Pending,
                IsArchived = false,
                LostSoul = new UserTO { FirstName = "Don't wanna", LastName = "Eat" }
            };
            var question2 = new QuestionTO
            {
                Questioning = "Never Gonna what?",
                CreationDate = DateTime.Now,
                State = State.Pending,
                IsArchived = false,
                LostSoul = new UserTO { FirstName = "Rick", LastName = "Ashley" }
            };

            var addedQuestion1 = QRepo.Insert(question1);
            var addedQuestion2 = QRepo.Insert(question2);
            QRepo.Save();

            var answer1 = new AnswerTO
            {
                Answering = "Maybe Someone Else know this",
                AnswerTime = DateTime.Now.AddHours(1),
                QuestionId = addedQuestion1.Id,
                Savior = new UserTO { FirstName = "Random", LastName = "Joe" }
            };
            var answer2 = new AnswerTO
            {
                Answering = "Why should I know this ? ",
                AnswerTime = DateTime.Now.AddHours(1),
                QuestionId = addedQuestion1.Id,
                Savior = new UserTO { FirstName = "Someone", LastName = "Else" }
            };
            var answer3 = new AnswerTO
            {
                Answering = "Give you up, Let you down",
                AnswerTime = DateTime.Now.AddHours(1),
                QuestionId = addedQuestion2.Id,
                Savior = new UserTO { FirstName = "A specific", LastName = "Asshole" }
            };

            var addedAnswer1 = ARepo.Insert(answer1);
            var addedAnswer2 = ARepo.Insert(answer2);
            var addedAnswer3 = ARepo.Insert(answer3);
            ARepo.Save();

            Assert.AreEqual(3, ARepo.GetAll().Count());
        }
    }
}
