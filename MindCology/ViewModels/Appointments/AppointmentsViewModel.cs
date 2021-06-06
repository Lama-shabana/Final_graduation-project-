using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MindCology.ViewModels.Appointments
{
    public class AppointmentsViewModel
    {
        public int Id { get; set; }


        public int TherapistId { get; set; }
        public int PatientId { get; set; }

        public int MeetingID { get; set; }
        public string Password { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }


    }
}
