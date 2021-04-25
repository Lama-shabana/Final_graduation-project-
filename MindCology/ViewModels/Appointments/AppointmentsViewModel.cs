using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MindCology.ViewModels.Appointments
{
    public class AppointmentsViewModel
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public int TherapistId { get; set; }
        public int PatientId { get; set; }

    }
}
