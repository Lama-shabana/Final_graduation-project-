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


        public TherapistEntity Therapist { get; set; }
        public int TherapistId { get; set; }

        public PatientEntity Patient { get; set; }
        public int PatientId { get; set; }



        public int MeetingID { get; set; }
        public string Password { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }



    }
}
