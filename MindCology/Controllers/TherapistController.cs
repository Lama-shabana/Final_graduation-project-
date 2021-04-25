using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MindCology.DAL;
using MindCology.DAL.Entities;
using MindCology.ViewModels.Therapist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MindCology.Controllers
{


    [Route("api/[controller]")]
    [ApiController]
    public class TherapistController : ControllerBase
    {
        private readonly MindCologyContext _mindCologyContext;
        public TherapistController(MindCologyContext mindCologyContext)
        {
            _mindCologyContext = mindCologyContext;

        }
        // GET: api/<UsersController>
        [HttpGet]
        public ActionResult Get()
        {
            var entities = _mindCologyContext.Therapist.ToList();
            var ViewModels = new List<TherapistViewModel>();

            foreach (var entity in entities)
            {
                ViewModels.Add(new TherapistViewModel()
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
                    EducationLevel=entity.EducationLevel,
                    Specialization=entity.Specialization,
                    Description=entity.Description
                });
            }

            return Ok(ViewModels);
        }

        // GET api/<UsersController>/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {

            var entity = _mindCologyContext.Therapist.FirstOrDefault(x => x.Id == id);
            if (entity == null)
            {
                return NotFound();
            }

            var ViewModel = new TherapistViewModel()
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
                EducationLevel = entity.EducationLevel,
                Specialization = entity.Specialization,
                Description = entity.Description
            };
            return Ok(ViewModel);
        }

        // POST api/<UsersController>
        [HttpPost]
        public TherapistViewModel Post([FromBody] TherapistModel user)
        {
            var entity = new TherapistEntity()
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Password = user.Password,
                PhoneNumber = user.PhoneNumber,
                Username = user.Username,
                Email = user.Email,
                Age = user.Age,
                Gender = user.Gender,
                UserType = user.UserType,
                EducationLevel = user.EducationLevel,
                Specialization = user.Specialization,
                Description = user.Description
            };

            _mindCologyContext.Add<TherapistEntity>(entity);
            _mindCologyContext.SaveChanges();
            var ViewModel = new TherapistViewModel()
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
                EducationLevel = entity.EducationLevel,
                Specialization = entity.Specialization,
                Description = entity.Description

            };
            return ViewModel;
        }

        // PUT api/<UsersController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] TherapistModel user)
        {
            var entity = _mindCologyContext.Therapist.FirstOrDefault(x => x.Id == id);

            if (entity == null)
            {
                return NotFound();
            }

            entity.FirstName = user.FirstName;
            entity.LastName = user.LastName;
            entity.Password = user.Password;
            entity.PhoneNumber = user.PhoneNumber;
            entity.Username = user.Username;
            entity.Email = user.Email;
            entity.Age = user.Age;
            entity.Gender = user.Gender;
            entity.UserType = user.UserType;
            entity.EducationLevel = user.EducationLevel;
            entity.Specialization = user.Specialization;
            entity.Description = user.Description;

            _mindCologyContext.Update<TherapistEntity>(entity);
            _mindCologyContext.SaveChanges();
            var ViewModel = new TherapistViewModel()
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
                EducationLevel = entity.EducationLevel,
                Specialization = entity.Specialization,
                Description = entity.Description

            };
            return Ok(ViewModel);
        }

        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var entity = _mindCologyContext.Therapist.FirstOrDefault(x => x.Id == id);
            if (entity == null)
            {
                return NotFound();
            }
            _mindCologyContext.Therapist.Remove(entity);
            _mindCologyContext.SaveChanges();
            return NoContent();

        }
    }
}
