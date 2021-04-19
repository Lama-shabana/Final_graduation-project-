using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MindCology.DAL.Entities
{
    public class UserEntity
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        public string Username { get; set; }

        public string Email { get; set; }
        public string Gender { get; set; }

        public string FilledMedicalForm { get; set; }

        public string UserType { get; set; }


        public int Age { get; set; }


        public MedicalHistoryEntity MedicalHistory { get; set; }



    }
}
