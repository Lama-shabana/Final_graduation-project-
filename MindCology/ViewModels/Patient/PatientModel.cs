using MindCology.ViewModels.User;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MindCology.ViewModels.Patient
{
    public class PatientModel:UserModel
    {

        public bool FilledMedicalHistoryForm { get; set; }
        //public MedicalHistoryEntity MedicalHistory { get; set; }
    }
}
