using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.ComponentModel.DataAnnotations;
namespace Clinic_1.Models
{
    public class Appointment
    {
        public int AppointmentID { get; set; }
       
   
        public int PatientID { get; set; }
        public string PatientName { get; set; }
        
        public string Specialization { get; set; }
       
        public string Doctor { get; set; }
      
        public string VisitDate { get; set; }
      
        public string AppointmentTime { get; set; }
    }
}
