using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MindCology.DAL;
using MindCology.DAL.Entities;
using MindCology.ViewModels.Appointments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MindCology.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentsController : ControllerBase
    {
        private readonly MindCologyContext _mindCologyContext;
        public AppointmentsController(MindCologyContext mindCologyContext)
        {
            _mindCologyContext = mindCologyContext;

        }
        // GET: api/<UsersController>
        [HttpGet]
        public ActionResult Get()
        {
            var entities = _mindCologyContext.Appointments.ToList();
            var ViewModels = new List<AppointmentsViewModel>();

            foreach (var entity in entities)
            {
                ViewModels.Add(new AppointmentsViewModel()
                {
                    Id = entity.Id,
                    TherapistId = entity.TherapistId,
                    PatientId = entity.PatientId,

                    MeetingID = entity.MeetingID,
                    Password = entity.Password,
                    Date = entity.Date,
                    Time = entity.Time,

                });
            }

            return Ok(ViewModels);
        }

        // GET api/<UsersController>/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {

            var entity = _mindCologyContext.Appointments.FirstOrDefault(x => x.MeetingID == id);
            if (entity == null)
            {
                return NotFound();
            }

            var ViewModel = new AppointmentsViewModel()
            {
                Id = entity.Id,
                TherapistId = entity.TherapistId,
                PatientId = entity.PatientId,

                MeetingID = entity.MeetingID,
                Password = entity.Password,
                Date = entity.Date,
                Time = entity.Time,

            };
            return Ok(ViewModel);
        }

        // POST api/<UsersController>
        [HttpPost]
        public ActionResult Post([FromBody] AppointmentsModel user)
        {
            var userExists = _mindCologyContext.User.Any(x => x.Id == user.PatientId);
            if (!userExists)
            {
                return BadRequest("Appointment not found");
            }
            var entity = new AppointmentEntity()
            {
                TherapistId = user.TherapistId,
                PatientId = user.PatientId,
                MeetingID = user.MeetingID,
                Password = user.Password,
                Date = user.Date,
                Time = user.Time,

            };

            _mindCologyContext.Add<AppointmentEntity>(entity);
            _mindCologyContext.SaveChanges();
            var ViewModel = new AppointmentsViewModel()
            {
                Id = entity.Id,
                TherapistId = entity.TherapistId,
                PatientId = entity.PatientId,
                MeetingID = entity.MeetingID,
                Password = entity.Password,
                Date = entity.Date,
                Time = entity.Time,


            };
            return Ok(ViewModel);
        }

        // PUT api/<UsersController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] AppointmentsModel user)
        {

            var userExists = _mindCologyContext.User.Any(x => x.Id == user.PatientId);
            if (!userExists)
            {
                return BadRequest("User not found");
            }
            var entity = _mindCologyContext.Appointments.FirstOrDefault(x => x.Id == id);

            if (entity == null)
            {
                return NotFound();
            }

        
            entity.TherapistId = user.TherapistId;
            entity.PatientId = user.PatientId;
            entity.MeetingID = user.MeetingID;
            entity.Password = user.Password;
            entity.Date = user.Date;
            entity.Time = user.Time;



            _mindCologyContext.Update<AppointmentEntity>(entity);
            _mindCologyContext.SaveChanges();
            var ViewModel = new AppointmentsViewModel()
            {
                Id = entity.Id,
                TherapistId = entity.TherapistId,
                PatientId = entity.PatientId,


            };
            return Ok(ViewModel);
        }

        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var entity = _mindCologyContext.Appointments.FirstOrDefault(x => x.MeetingID == id);
            if (entity == null)
            {
                return NotFound();
            }
            _mindCologyContext.Appointments.Remove(entity);
            _mindCologyContext.SaveChanges();
            return NoContent();

        }
    }
}
