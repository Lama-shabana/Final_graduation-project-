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
                    Username = entity.Username,
                    Email=entity.Email,
                    Age=entity.Age,
                    Gender=entity.Gender,
                    UserType=entity.UserType,
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
                Username = entity.Username,
                Email = entity.Email,
                Age = entity.Age,
                Gender = entity.Gender,
                UserType = entity.UserType,
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
                Username=user.Username,
                 Email = user.Email,
                Age = user.Age,
                Gender = user.Gender,
                UserType = user.UserType,
            };

            _mindCologyContext.Add<UserEntity>(entity);
            _mindCologyContext.SaveChanges();
            var ViewModel = new UserViewModel() { 
                Id=entity.Id,
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                PhoneNumber = entity.PhoneNumber,
                Username = entity.Username,
                Email = entity.Email,
                Age = entity.Age,
                Gender = entity.Gender,
                UserType = entity.UserType,

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

            if (user.FirstName!=null) {
                entity.FirstName = user.FirstName;
            }
            if (user.LastName != null)
            {
                entity.LastName = user.LastName;
            }

            if (user.Password != null)
            {
                entity.Password = user.Password;
            }

            if (user.PhoneNumber != null)
            {
                entity.PhoneNumber = user.PhoneNumber;
            }
            if (user.Username!=null) {
                entity.Username = user.Username;

            }

            if (user.Email != null)
            {
                entity.Email = user.Email;

            }
            if (user.Age != 0)
            {
                entity.Age = user.Age;

            }
            if (user.Gender != null)
            {
                entity.Gender = user.Gender;

            }
            if (user.UserType != null)
            {
                entity.UserType = user.UserType;

            }



            _mindCologyContext.Update<UserEntity>(entity);
            _mindCologyContext.SaveChanges();
            var ViewModel = new UserViewModel()
            {
                Id = entity.Id,
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                PhoneNumber = entity.PhoneNumber,
                Username = entity.Username,
                Email = entity.Email,
                Age = entity.Age,
                Gender = entity.Gender,
                UserType = entity.UserType,


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
