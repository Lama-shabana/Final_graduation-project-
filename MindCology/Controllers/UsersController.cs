using Microsoft.AspNetCore.Mvc;
using MindCology.DAL;
using MindCology.DAL.Entities;
using MindCology.ViewModels.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MindCology.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {

        private readonly MindCologyContext _mindCologyContext;
        public UsersController (MindCologyContext mindCologyContext)
        {
            _mindCologyContext = mindCologyContext;

        }
        // GET: api/<UsersController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<UsersController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<UsersController>
        [HttpPost]
        public UserViewModel Post([FromBody] UserModel user)
        {
            var entity = new UserEntity() {
                FirstName = user.FirstName,
                LastName=user.LastName,
                Password=user.Password,
                PhoneNumber=user.PhoneNumber,
                Username=user.Username
            };

            _mindCologyContext.Add<UserEntity>(entity);
            _mindCologyContext.SaveChanges();
            var ViewModel = new UserViewModel() { 
                Id=entity.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                PhoneNumber = user.PhoneNumber,
                Username = user.Username
            };
            return ViewModel;
        }

        // PUT api/<UsersController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
