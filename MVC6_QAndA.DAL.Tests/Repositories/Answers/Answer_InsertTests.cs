﻿using Microsoft.EntityFrameworkCore;
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
    public class Answer_InsertTests
    {
        [TestMethod]
        public void InsertAnswer_CorrectFormat()
        {
            var options = new DbContextOptionsBuilder<QAndAContext>().UseInMemoryDatabase(MethodBase.GetCurrentMethod().Name).Options;
            var context = new QAndAContext(options);
            IAnswerRepository ARepo = new AnswerRepository(context);
            IQuestionRepository QRepo = new QuestionRepository(context);

            var question = new QuestionTO
            {
                Questioning = "Maybe it's working",
                CreationDate = DateTime.Now,
                State = State.Pending,
                IsArchived = false,
                LostSoul = new UserTO { FirstName = "Call me", LastName = "Kevin" }
            };

            var addedQuestion = QRepo.Insert(question);
            QRepo.Save();

            var answer = new AnswerTO
            {
                Answering = "No shit Sherlock",
                AnswerTime = DateTime.Now.AddHours(1),
                QuestionId = addedQuestion.Id,
                Savior = new UserTO { FirstName = "Dr", LastName = "Watson" }
            };

            var addedAnswer = ARepo.Insert(answer);
            ARepo.Save();

            Assert.AreEqual(1,addedAnswer.QuestionId);
            Assert.AreEqual(1,QRepo.Get(addedAnswer.QuestionId).Answers.Count());
            Assert.AreEqual("No shit Sherlock", addedAnswer.Answering);
        }
        
        [TestMethod]
        public void InsertAnswer_NonExistingQuestion()
        {
            var options = new DbContextOptionsBuilder<QAndAContext>().UseInMemoryDatabase(MethodBase.GetCurrentMethod().Name).Options;
            var context = new QAndAContext(options);
            IAnswerRepository ARepo = new AnswerRepository(context);
                        
            var answer = new AnswerTO
            {
                Answering = "No shit Sherlock",
                AnswerTime = DateTime.Now.AddHours(1),
                QuestionId = 20,
                Savior = new UserTO { FirstName = "Dr", LastName = "Watson" }
            };

            Assert.ThrowsException<NullReferenceException>(()=>ARepo.Insert(answer));
        }
    }
}
