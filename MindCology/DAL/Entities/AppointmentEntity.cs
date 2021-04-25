using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MindCology.DAL.Entities
{
    public class AppointmentEntity
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public DateTime Date { get; set; }


        public TherapistEntity Therapist { get; set; }
        public int TherapistId { get; set; }

        public PatientEntity Patient { get; set; }
        public int PatientId { get; set; }




    }
}
