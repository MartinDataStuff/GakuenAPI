using System;
using GakuenAPI.Controllers;
using GakuenDLL.Entity;
using GakuenDLL.Facade;
using GakuenDLL.Interface;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GakuenApiTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void NewsMessageControllerPost()
        {
            IRepository<NewsMessage> nm = new RepositoryFacade().GetNewsMessageRepository();
            NewsMessage n = new NewsMessage
            {
                
            };
            var test = nm.Create(n);
            //Assert
            Assert.IsNotNull(test);
            Assert.AreNotEqual(n,test);


        }
    }
}
