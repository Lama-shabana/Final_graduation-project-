using MindCology.DAL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MindCology.ViewModels.MedicalHistory
{
    public class MedicalHistoryModel
    {

        [Required]
        public int UserId { get; set; }

        [Required]
        public string ProvidedWithMentalHealthServices { get; set; }

        [Required]
        public string SessionsLanguage { get; set; }

        [Required]
        public string TherapistGender { get; set; }


        [Required]
        public string TraumaticExperience { get; set; }

        [Required]
        public string SeekingHelpFor { get; set; }

        [Required]
        public bool MentalOrPhysicalDisorder { get; set; }

        [Required]
        public string MentalOrPhysicalDisorderDetails { get; set; }

        [Required]
        public bool ThinkAboutHarmingYourself { get; set; }

        [Required]
        public string ThinkAboutHarmingYourselfDetails { get; set; }

        [Required]
        public bool UnderMedications { get; set; }

        [Required]
        public string UnderMedicationsDetails { get; set; }


   
    }
}
