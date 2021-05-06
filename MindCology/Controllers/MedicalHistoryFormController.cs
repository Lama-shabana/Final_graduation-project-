using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MindCology.ViewModels.MedicalHistory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MindCology.DAL.Entities
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicalHistoryFormController : ControllerBase
    {
        private readonly MindCologyContext _mindCologyContext;
        public MedicalHistoryFormController(MindCologyContext mindCologyContext)
        {
            _mindCologyContext = mindCologyContext;

        }
        // GET: api/<UsersController>
        [HttpGet]
        public ActionResult Get()
        {
            var entities = _mindCologyContext.MedicalHistory.ToList();
            var ViewModels = new List<MedicalHistoryViewModel>();

            foreach (var entity in entities)
            {
                ViewModels.Add(new MedicalHistoryViewModel()
                {
                    Id = entity.Id,
                    ProvidedWithMentalHealthServices = entity.ProvidedWithMentalHealthServices,
                    SessionsLanguage = entity.SessionsLanguage,
                    TherapistGender = entity.TherapistGender,
                    TraumaticExperience = entity.TraumaticExperience,
                    SeekingHelpFor = entity.SeekingHelpFor,
                    MentalOrPhysicalDisorder = entity.MentalOrPhysicalDisorder,
                    MentalOrPhysicalDisorderDetails = entity.MentalOrPhysicalDisorderDetails,
                    ThinkAboutHarmingYourself = entity.ThinkAboutHarmingYourself,
                    ThinkAboutHarmingYourselfDetails = entity.ThinkAboutHarmingYourselfDetails,
                    UnderMedications = entity.UnderMedications,
                    UnderMedicationsDetails = entity.UnderMedicationsDetails,
                    PatientId=entity.PatientId

                });
            }

            return Ok(ViewModels);
        }

        // GET api/<UsersController>/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {

            var entity = _mindCologyContext.MedicalHistory.FirstOrDefault(x => x.PatientId == id);
            if (entity == null)
            {
                return NotFound();
            }

            var ViewModel = new MedicalHistoryViewModel()
            {
                Id = entity.Id,
                ProvidedWithMentalHealthServices = entity.ProvidedWithMentalHealthServices,
                SessionsLanguage = entity.SessionsLanguage,
                TherapistGender = entity.TherapistGender,
                TraumaticExperience = entity.TraumaticExperience,
                SeekingHelpFor = entity.SeekingHelpFor,
                MentalOrPhysicalDisorder = entity.MentalOrPhysicalDisorder,
                MentalOrPhysicalDisorderDetails = entity.MentalOrPhysicalDisorderDetails,
                ThinkAboutHarmingYourself = entity.ThinkAboutHarmingYourself,
                ThinkAboutHarmingYourselfDetails = entity.ThinkAboutHarmingYourselfDetails,
                UnderMedications = entity.UnderMedications,
                UnderMedicationsDetails = entity.UnderMedicationsDetails,
                PatientId = entity.PatientId

            };
            return Ok(ViewModel);
        }

        // POST api/<UsersController>
        [HttpPost]
        public ActionResult Post([FromBody] MedicalHistoryModel user)
        {
            var userExists = _mindCologyContext.Patient.Any(x => x.Id == user.PatientId);
            if (!userExists) {
                return BadRequest("User not found");
            }
            var entity = new MedicalHistoryEntity()
            {
                ProvidedWithMentalHealthServices = user.ProvidedWithMentalHealthServices,
                SessionsLanguage = user.SessionsLanguage,
                TherapistGender = user.TherapistGender,
                TraumaticExperience = user.TraumaticExperience,
                SeekingHelpFor = user.SeekingHelpFor,
                MentalOrPhysicalDisorder = user.MentalOrPhysicalDisorder,
                MentalOrPhysicalDisorderDetails = user.MentalOrPhysicalDisorderDetails,
                ThinkAboutHarmingYourself = user.ThinkAboutHarmingYourself,
                ThinkAboutHarmingYourselfDetails = user.ThinkAboutHarmingYourselfDetails,
                UnderMedications = user.UnderMedications,
                UnderMedicationsDetails = user.UnderMedicationsDetails,
                PatientId = user.PatientId


            };

            _mindCologyContext.Add<MedicalHistoryEntity>(entity);
            _mindCologyContext.SaveChanges();
            var ViewModel = new MedicalHistoryViewModel()
            {
                Id = entity.Id,
                ProvidedWithMentalHealthServices = entity.ProvidedWithMentalHealthServices,
                SessionsLanguage = entity.SessionsLanguage,
                TherapistGender = entity.TherapistGender,
                TraumaticExperience = entity.TraumaticExperience,
                SeekingHelpFor = entity.SeekingHelpFor,
                MentalOrPhysicalDisorder = entity.MentalOrPhysicalDisorder,
                MentalOrPhysicalDisorderDetails = entity.MentalOrPhysicalDisorderDetails,
                ThinkAboutHarmingYourself = entity.ThinkAboutHarmingYourself,
                ThinkAboutHarmingYourselfDetails = entity.ThinkAboutHarmingYourselfDetails,
                UnderMedications = entity.UnderMedications,
                UnderMedicationsDetails = entity.UnderMedicationsDetails,
                PatientId = entity.PatientId



            };
            return Ok(ViewModel);
        }

        // PUT api/<UsersController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] MedicalHistoryModel user)
        {

            var userExists = _mindCologyContext.Patient.Any(x => x.Id == user.PatientId);
            if (!userExists)
            {
                return BadRequest("User not found");
            }
            var entity = _mindCologyContext.MedicalHistory.FirstOrDefault(x => x.Id == id);

            if (entity == null)
            {
                return NotFound();
            }

            entity.ProvidedWithMentalHealthServices = user.ProvidedWithMentalHealthServices;
            entity.SessionsLanguage = user.SessionsLanguage;
            entity.TherapistGender = user.TherapistGender;
            entity.TraumaticExperience = user.TraumaticExperience;
            entity.SeekingHelpFor = user.SeekingHelpFor;
            entity.MentalOrPhysicalDisorder = user.MentalOrPhysicalDisorder;
            entity.MentalOrPhysicalDisorderDetails = user.MentalOrPhysicalDisorderDetails;
            entity.ThinkAboutHarmingYourself = user.ThinkAboutHarmingYourself;
            entity.ThinkAboutHarmingYourselfDetails = user.ThinkAboutHarmingYourselfDetails;
            entity.UnderMedications = user.UnderMedications;
            entity.UnderMedicationsDetails = user.UnderMedicationsDetails;
            entity.PatientId = user.PatientId;




            _mindCologyContext.Update<MedicalHistoryEntity>(entity);
            _mindCologyContext.SaveChanges();
            var ViewModel = new MedicalHistoryViewModel()
            {
                Id = entity.Id,
                ProvidedWithMentalHealthServices = entity.ProvidedWithMentalHealthServices,
                SessionsLanguage = entity.SessionsLanguage,
                TherapistGender = entity.TherapistGender,
                TraumaticExperience = entity.TraumaticExperience,
                SeekingHelpFor = entity.SeekingHelpFor,
                MentalOrPhysicalDisorder = entity.MentalOrPhysicalDisorder,
                MentalOrPhysicalDisorderDetails = entity.MentalOrPhysicalDisorderDetails,
                ThinkAboutHarmingYourself = entity.ThinkAboutHarmingYourself,
                ThinkAboutHarmingYourselfDetails = entity.ThinkAboutHarmingYourselfDetails,
                UnderMedications = entity.UnderMedications,
                UnderMedicationsDetails = entity.UnderMedicationsDetails,
                PatientId = entity.PatientId


            };
            return Ok(ViewModel);
        }

        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var entity = _mindCologyContext.MedicalHistory.FirstOrDefault(x => x.Id == id);
            if (entity == null)
            {
                return NotFound();
            }
            _mindCologyContext.MedicalHistory.Remove(entity);
            _mindCologyContext.SaveChanges();
            return NoContent();

        }
    }
}
