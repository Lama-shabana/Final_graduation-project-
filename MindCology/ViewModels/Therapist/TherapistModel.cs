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
        [Required]
        public string EducationLevel { get; set; }
        
        [Required]
        public string Specialization { get; set; }
        
        [Required]
        public string Description { get; set; }

        [Required]
        public string ImagePath { get; set; }
    }
}
