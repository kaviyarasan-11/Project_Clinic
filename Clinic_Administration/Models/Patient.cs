using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace Clinic_1.Models
{
    public class Patient
    {
        public int PaitentID { get; set; }
        public string FirstName { get; set; }
        
        public string LastName { get; set; }
       
        public string Sex { get; set; }
       
        public int Age { get; set; }
     
        public DateTime DOB { get; set; }
    }
}
