using Clinic_1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Clinic_1.DAL;
namespace Clinic_1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }
        public IActionResult Show()
        {
            return View();
        }
        public IActionResult Verify(Staff L)
        {
            ClinicDAL obj = new ClinicDAL();
            int log = obj.validatelogin(L);
            if (log == 1)
            {
                return RedirectToAction("Show", L);
            }
            else
            {
                return View("Login");
            }

        }
        public IActionResult Doctors()
        {
            ClinicDAL clDAL = new ClinicDAL();
            List<Doctor> doc = new List<Doctor>();
            doc = clDAL.Doctors();
            return View(doc);
           
        }
        public IActionResult AddDoctor()
        {
            return View();
        }
        public IActionResult DoctorList(Doctor L)
        { 
            ClinicDAL obj = new ClinicDAL();
            int log = obj.InsertDoctor(L);

            return RedirectToAction("Success");
        }
        public IActionResult Patients()
        {
            return View();
        }
        public IActionResult AddPatient()
        {
            return View();
        }
        public IActionResult PatientList(Patient L)
        {
            ClinicDAL obj = new ClinicDAL();
            int log = obj.InsertPatient(L);
            return RedirectToAction("Success");
        }
        
        public IActionResult Appointment()
        {
            return View();
        }
        public IActionResult AppointmentList(Appointment L)
        {
            ClinicDAL obj = new ClinicDAL();
            int log = obj.InsertAppointment(L);
            return RedirectToAction("Success");
        }
     
        public IActionResult DeleteList(int id)
        {
            ClinicDAL cobj = new ClinicDAL();
            int result = cobj.DeleteSchedule(id);
            
            return RedirectToAction("Show");
            //int result;
            //int PatientID = obj.PatientID;
            //ClinicDAL cobj = new ClinicDAL();
            //result = cobj.DeleteSchedule(obj);
            //return View("Show");
        }
        public IActionResult CancelAppoint()
        {
            ClinicDAL cDAL = new ClinicDAL();
            List<Appointment> CList = new List<Appointment>();
            CList = cDAL.DelAppoint();
            return View(CList);
           
        }
           public IActionResult Success()
        {
            return View();
        }
        

        


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
