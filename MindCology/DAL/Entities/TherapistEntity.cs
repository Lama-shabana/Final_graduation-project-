using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MindCology.DAL.Entities
{
    public class TherapistEntity:UserEntity
    {

        public string EducationLevel { get; set; }

        public string Specialization { get; set; }

        public string Description { get; set; }


    }
}
