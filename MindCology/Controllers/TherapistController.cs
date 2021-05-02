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
                    Description=entity.Description,
                    Active = entity.Active,

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
                Description = entity.Description,
                Active = entity.Active,

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
                Description = user.Description,
                Active = user.Active,

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
                Description = entity.Description,
                Active = entity.Active,


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

            if (user.FirstName != null)
            {
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
            if (user.Username != null)
            {
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
            if (user.Specialization != null)
            {
                entity.Specialization = user.Specialization;

            }
            if (user.EducationLevel != null)
            {
                entity.EducationLevel = user.EducationLevel;

            }
            if (user.Description != null)
            {
                entity.Description = user.Description;

            }




            entity.Active = user.Active;


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
                Description = entity.Description,
                Active = entity.Active,


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
