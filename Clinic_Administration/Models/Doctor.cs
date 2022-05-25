using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace Clinic_1.Models
{
    public class Doctor
    {
        public int DoctorID { get; set; }
      
        public string FirstName { get; set; }
        
        public string LastName { get; set; }
        
        public string Sex { get; set; }
       
        public string Specialization { get; set; }
       
        public string ScheduleTime { get; set; }
    }
}
