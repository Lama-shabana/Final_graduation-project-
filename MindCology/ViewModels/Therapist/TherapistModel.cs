using MindCology.ViewModels.User;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MindCology.ViewModels.Therapist
{
    public class TherapistModel:UserModel
    {
        public string EducationLevel { get; set; }
        
        public string Specialization { get; set; }
        
        public string Description { get; set; }

        public string ImagePath { get; set; }
    }
}
