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
    public class Question_ArchiveTests
    {
        [TestMethod]
        public void Question_ArchiveSuccesfull()
        {
            var options = new DbContextOptionsBuilder<QAndAContext>().UseInMemoryDatabase(MethodBase.GetCurrentMethod().Name).Options;
            var context = new QAndAContext(options);
            IQuestionRepository QRepo = new QuestionRepository(context);

            var question = new QuestionTO
            {
                Questioning = "Gif or Gif ?",
                CreationDate = DateTime.Now,
                State = State.Pending,
                IsArchived = false,
                LostSoul = new UserTO { FirstName = "William", LastName = "Shake" }
            };

            var added = QRepo.Insert(question);
            QRepo.Save();

            var result = QRepo.Archive(added);
            QRepo.Save();

            Assert.IsTrue(QRepo.Get(added.Id).IsArchived);
        }
        [TestMethod]
        public void Question_ArchiveAlreadyArchived()
        {
            var options = new DbContextOptionsBuilder<QAndAContext>().UseInMemoryDatabase(MethodBase.GetCurrentMethod().Name).Options;
            var context = new QAndAContext(options);
            IQuestionRepository QRepo = new QuestionRepository(context);

            var question = new QuestionTO
            {
                Questioning = "Crèpes sucré ou salé ?",
                CreationDate = DateTime.Now,
                State = State.Pending,
                IsArchived = true,
                LostSoul = new UserTO { FirstName = "Top", LastName = "Chef" }
            };

            var test = QRepo.Insert(question);
            QRepo.Save();

            Assert.ThrowsException<ArgumentException>(() => QRepo.Archive(test));
        }
    }
}
