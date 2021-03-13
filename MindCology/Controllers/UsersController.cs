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
        public ActionResult Get()
        {
            var entities = _mindCologyContext.User.ToList();
            var ViewModels = new List<UserViewModel>();

            foreach (var entity in entities)
            {
                ViewModels.Add(new UserViewModel()
                {
                    Id = entity.Id,
                    FirstName = entity.FirstName,
                    LastName = entity.LastName,
                    PhoneNumber = entity.PhoneNumber,
                    Username = entity.Username
                });
            }

            return Ok(ViewModels);
        }

        // GET api/<UsersController>/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {

            var entity = _mindCologyContext.User.FirstOrDefault(x=>x.Id==id);
            if (entity == null) {
                return NotFound();
            }

            var ViewModel = new UserViewModel()
            {
                Id = entity.Id,
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                PhoneNumber = entity.PhoneNumber,
                Username = entity.Username
            };
            return Ok(ViewModel);
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
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                PhoneNumber = entity.PhoneNumber,
                Username = entity.Username
            };
            return ViewModel;
        }

        // PUT api/<UsersController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] UserModel user)
        {
            var entity = _mindCologyContext.User.FirstOrDefault(x => x.Id == id);

            if (entity==null) {
                return NotFound();
            }

            entity.FirstName = user.FirstName;
            entity.LastName = user.LastName;
            entity.Password = user.Password;
            entity.PhoneNumber = user.PhoneNumber;
            entity.Username = user.Username;
            

            _mindCologyContext.Update<UserEntity>(entity);
            _mindCologyContext.SaveChanges();
            var ViewModel = new UserViewModel()
            {
                Id = entity.Id,
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                PhoneNumber = entity.PhoneNumber,
                Username = entity.Username
            };
            return Ok(ViewModel);
        }

        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var entity = _mindCologyContext.User.FirstOrDefault(x => x.Id == id);
            if (entity == null)
            {
                return NotFound();
            }
            _mindCologyContext.User.Remove(entity);
            _mindCologyContext.SaveChanges();
            return NoContent();

        }
    }
}
