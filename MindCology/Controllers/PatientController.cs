using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MindCology.DAL;
using MindCology.DAL.Entities;
using MindCology.ViewModels.Patient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MindCology.Controllers { 


    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly MindCologyContext _mindCologyContext;
        public PatientController (MindCologyContext mindCologyContext)
        {
            _mindCologyContext = mindCologyContext;

        }
        // GET: api/<UsersController>
        [HttpGet]
        public ActionResult Get()
        {
            var entities = _mindCologyContext.Patient.ToList();
            var ViewModels = new List<PatientViewModel>();

            foreach (var entity in entities)
            {
                ViewModels.Add(new PatientViewModel()
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
                    FilledMedicalHistoryForm = entity.FilledMedicalHistoryForm,
                    Active = entity.Active,

                });
            }

            return Ok(ViewModels);
        }

        // GET api/<UsersController>/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {

            var entity = _mindCologyContext.Patient.FirstOrDefault(x=>x.Id==id);
            if (entity == null) {
                return NotFound();
            }

            var ViewModel = new PatientViewModel()
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
                FilledMedicalHistoryForm = entity.FilledMedicalHistoryForm,
                Active = entity.Active,

            };
            return Ok(ViewModel);
        }

        // POST api/<UsersController>
        [HttpPost]
        public PatientViewModel Post([FromBody] PatientModel user)
        {
            var entity = new PatientEntity() {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Password = user.Password,
                PhoneNumber = user.PhoneNumber,
                Username = user.Username,
                Email = user.Email,
                Age = user.Age,
                Gender = user.Gender,
                UserType = user.UserType,
                FilledMedicalHistoryForm = user.FilledMedicalHistoryForm,
                Active = user.Active,

            };

            _mindCologyContext.Add<PatientEntity>(entity);
            _mindCologyContext.SaveChanges();
            var ViewModel = new PatientViewModel() {
                Id = entity.Id,
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                PhoneNumber = entity.PhoneNumber,
                Username = entity.Username,
                Email = entity.Email,
                Age = entity.Age,
                Gender = entity.Gender,
                UserType = entity.UserType,
                FilledMedicalHistoryForm = entity.FilledMedicalHistoryForm,
                Active = entity.Active,



            };
            return ViewModel;
        }

        // PUT api/<UsersController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] PatientModel user)
        {
            var entity = _mindCologyContext.Patient.FirstOrDefault(x => x.Id == id);

            if (entity==null) {
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
            if (user.FilledMedicalHistoryForm != null)
            {
                entity.FilledMedicalHistoryForm = user.FilledMedicalHistoryForm;

            }
            entity.Active = user.Active;


            _mindCologyContext.Update<PatientEntity>(entity);
            _mindCologyContext.SaveChanges();
            var ViewModel = new PatientViewModel()
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
                FilledMedicalHistoryForm = entity.FilledMedicalHistoryForm,
                Active = entity.Active,



            };
            return Ok(ViewModel);
        }

        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var entity = _mindCologyContext.Patient.FirstOrDefault(x => x.Id == id);
            if (entity == null)
            {
                return NotFound();
            }
            _mindCologyContext.Patient.Remove(entity);
            _mindCologyContext.SaveChanges();
            return NoContent();

        }
    }
}
