using Domain;
using Domain.Logging;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Web_API.Controllers;
using Web_API.DTOs.Request;
using Web_API.Services;

namespace Test
{
    [TestClass]
    public class MessageControllerTest
    {
        private MessageController _MessageController;
        private Mock<IMessageService> _MessageService;
        private Mock<ILoggerManager> _logger;

        public MessageControllerTest()
        {
            this._MessageService = new Mock<IMessageService>();
            this._logger = new Mock<ILoggerManager>();
            this._MessageController = new MessageController(this._MessageService.Object, this._logger.Object);
        }

        [TestMethod]
        public void Get_All_Message_Test()
        {
            var result = this._MessageController.GetAllMessage();

            this._MessageService.Verify(m => m.GetAll());
            result.Should().BeEquivalentTo(new List<MessageRequest>());
        }

        [TestMethod]
        [DataRow(1)]
        public void Get_Message_By_Id(long id)
        {
            this._MessageService.Setup(m => m.GetById(id)).Returns(new MessageRequest());

            var result = this._MessageController.GetMessageById(id);

            this._MessageService.Verify(m => m.GetById(id));
            result.Should().BeEquivalentTo(new MessageRequest());
        }

        [TestMethod]
        [DataRow(2)]
        public void Get_Message_By_Sender_Id(long id)
        {
            
            this._MessageService.Setup(m => m.GetMessagesBySenderId(id)).Returns(new List<MessageRequest>());

            var result = this._MessageController.GetMessagesBySenderId(id);

            this._MessageService.Verify(m => m.GetMessagesBySenderId(id));
            result.Should().BeEquivalentTo(new List<MessageRequest>());
        }

        [TestMethod]
        public void Create_Message_Test()
        {
            var model = new MessageRequest();

            this._MessageController.CreateMessage(model);

            this._MessageService.Verify(m => m.Insert(model));
        }

        [TestMethod]
        public void Update_Message_Test()
        {
            var model = new MessageRequest();

            this._MessageController.UpdateMessage(model);

            this._MessageService.Verify(m => m.Update(model));
        }

        [TestMethod]
        [DataRow(1)]
        public void Delete_Message_Test(long id)
        {
            this._MessageController.DeleteMessage(id);

            this._MessageService.Verify(m => m.Delete(id));
        }
    }
}
