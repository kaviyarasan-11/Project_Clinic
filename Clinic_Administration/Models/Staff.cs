using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace Clinic_1.Models
{
    public class Staff
    {

        //[StringLength=15(MinLengthAttribute=5)]
        
        public string UserName { get; set; }
      
        public string FirstName { get; set; }
      
        public string LastName { get; set; }
      
        public string Password { get; set; }
    }
}
