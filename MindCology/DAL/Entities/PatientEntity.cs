using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MindCology.DAL.Entities
{
    public class PatientEntity:UserEntity
    {
        public bool FilledMedicalHistoryForm { get; set; }
        public MedicalHistoryEntity MedicalHistory { get; set; }

    }

}
