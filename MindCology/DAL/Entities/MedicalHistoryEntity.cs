using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MindCology.DAL.Entities
{
    public class MedicalHistoryEntity
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string ProvidedWithMentalHealthServices { get; set; }
        public string SessionsLanguage { get; set; }
        public string TherapistGender { get; set; }
        public string TraumaticExperience { get; set; }
        public string SeekingHelpFor { get; set; }

        public bool MentalOrPhysicalDisorder { get; set; }
        public string MentalOrPhysicalDisorderDetails { get; set; }

        public bool ThinkAboutHarmingYourself { get; set; }

        public string ThinkAboutHarmingYourselfDetails { get; set; }


        public bool  UnderMedications { get; set; }

        public string UnderMedicationsDetails { get; set; }

        public PatientEntity Patient { get; set; }

        public int PatientId { get; set; }

    }
}
