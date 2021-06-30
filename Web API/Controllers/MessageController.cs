using Domain;
using Domain.Logging;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web_API.DTOs.Request;
using Web_API.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Web_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private IMessageService _messageService;
        private ILoggerManager _loggerManager;

        public MessageController(IMessageService messageService, ILoggerManager loggerManager)
        {
            this._messageService = messageService;
            this._loggerManager = loggerManager;
        }
        // GET: api/<MessageController>
        [HttpGet]
        public IEnumerable<List<MessageRequest>> GetAllMessage()
        {
            try
            {
                this._loggerManager.LogInfo("Fetching all the message from the storage");
                return this._messageService.GetAll();
            }
            catch (Exception)
            {
                throw new Exception("Exception while fetching all the message from the storage.");
            }
           
        }

        [HttpGet("senderId={id}")]
        public List<MessageRequest> GetMessagesBySenderId(long id)
        {
            try
            {
                this._loggerManager.LogInfo("Fetching all the message send by senderId from the storage");
                return this._messageService.GetMessagesBySenderId(id);
            }
            catch (Exception)
            {
                throw new Exception("Exception while fetching all the message send by senderId from the storage.");
            }
            
        }

        // GET api/<MessageController>/5
        [HttpGet("{id}")]
        public MessageRequest GetMessageById(long id)
        {
            try
            {
                this._loggerManager.LogInfo("Fetching a message from the storage");
                return this._messageService.GetById(id);
            }
            catch (Exception)
            {
                throw new Exception("Exception while fetching a message from the storage.");
            }
            
        }

        // POST api/<MessageController>
        [HttpPost]
        public void CreateMessage([FromBody] MessageRequest req)
        {
            try
            {
                this._loggerManager.LogInfo("Creating a message to the storage");
                this._messageService.Insert(req);
            }
            catch (Exception)
            {
                throw new Exception("Exception while creating a news to the storage.");
            }
            
        }

        // PUT api/<MessageController>
        [HttpPut]
        public void UpdateMessage([FromBody] MessageRequest req)
        {
            try
            {
                this._loggerManager.LogInfo("Updating a message to the storage");
                this._messageService.Update(req);
            }
            catch (Exception)
            {
                throw new Exception("Exception while updating a message to the storage.");
            }
            
        }

        // DELETE api/<MessageController>/5
        [HttpDelete("{id}")]
        public void DeleteMessage(long id)
        {
            try
            {
                this._loggerManager.LogInfo("Deleting a the message to the storage");
                this._messageService.Delete(id);
            }
            catch (Exception)
            {
                throw new Exception("Exception while deleting a message to the storage.");
            }
            
        }
    }
}
