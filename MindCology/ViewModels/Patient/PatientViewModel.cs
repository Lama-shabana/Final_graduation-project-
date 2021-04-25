using MindCology.ViewModels.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MindCology.ViewModels.Patient
{
    public class PatientViewModel:UserViewModel
    {
        //public int Id { get; set; }
        public bool FilledMedicalHistoryForm { get; set; }

    }
}
