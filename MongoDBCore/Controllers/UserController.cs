using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using WebAPICoreMongoDb.Models;

namespace WebAPICoreMongoDb.Controllers
{
    [Produces("application/json")]
    [Route("api/User")]
    public class UserController : Controller
    {
        private MongoContext<User> _context;
        public UserController()
        {
            _context = new MongoContext<User>();
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                List<User> news = _context.Users.Find(x => true).ToList();
                return Ok(news);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(string id)
        {
            try
            {
                var user = _context.Users.Find(x => x.Id == id).First();
                return Ok(user);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody]User user)
        {
            try
            {
                _context.Users.InsertOne(user);

                return new ObjectResult(user.Id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(string id, [FromBody]User user)
        {
            try
            {
                var filter = Builders<User>.Filter.Eq(s => s.Id, id);
                var update = Builders<User>.Update
                                .Set(s => s.FistName, user.FistName)
                                .Set(s => s.LastName, user.LastName)
                                .Set(s => s.Document, user.Document)
                                .Set(s => s.Age, user.Age);

                _context.Users.UpdateOne(filter, update);

                user.Id = id;
                return new ObjectResult(user);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            try
            {
                _context.Users.DeleteOneAsync(Builders<User>.Filter.Eq("Id", id));
                return new NoContentResult();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
