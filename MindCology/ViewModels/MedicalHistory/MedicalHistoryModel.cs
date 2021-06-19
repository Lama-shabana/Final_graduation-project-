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

        public int PatientId { get; set; }

        public string ProvidedWithMentalHealthServices { get; set; }

        public string SessionsLanguage { get; set; }

        public string TherapistGender { get; set; }


        public string TraumaticExperience { get; set; }

        public string SeekingHelpFor { get; set; }

        public bool MentalOrPhysicalDisorder { get; set; }

        public string MentalOrPhysicalDisorderDetails { get; set; }

        public bool ThinkAboutHarmingYourself { get; set; }

        public string ThinkAboutHarmingYourselfDetails { get; set; }

        public bool UnderMedications { get; set; }

        public string UnderMedicationsDetails { get; set; }


   
    }
}
