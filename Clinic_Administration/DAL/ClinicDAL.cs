using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.IO;
using Clinic_1.Models;
using System.Data.SqlClient;
using System.Data;
namespace Clinic_1.DAL
{
    public class ClinicDAL
    {
        public string cnn = "";

        public ClinicDAL()
        {
            var builder = new ConfigurationBuilder().SetBasePath
                    (Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
            cnn = builder.GetSection("ConnectionStrings:ClinicConn").Value;
        }
        public List<Appointment> DelAppoint()
        {
            List<Appointment> listSchedule = new List<Appointment>();
            using (SqlConnection con = new SqlConnection(cnn))
            {
                using (SqlCommand cmd = new SqlCommand("ShowSchedule", con))
                {
                    if (con.State == System.Data.ConnectionState.Closed)
                        con.Open();
                    IDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        listSchedule.Add(new Appointment()
                        {
                            AppointmentID = int.Parse(reader["AppointmentID"].ToString()),
                             PatientID= int.Parse(reader["PatientID"].ToString()),
                             PatientName= reader["PatientName"].ToString(),
                            Doctor = reader["Doctor"].ToString(),
                            Specialization = reader["Specialization"].ToString(),
                            VisitDate = reader["VisitDate"].ToString(),
                            AppointmentTime = reader["AppointmentTime"].ToString()
                        }); ;
                    }

                }
            }
            return listSchedule;
        }
        public int validatelogin(Staff L)
        {

            SqlConnection con = new SqlConnection(cnn);
            SqlCommand cmd = new SqlCommand("InsertStaff", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@P_Word", L.Password);
            con.Open();
            IDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
                return (1);
            con.Close();
            return (0);
        }
        public int InsertDoctor(Doctor L)
        {

            SqlConnection con = new SqlConnection(cnn);
            SqlCommand cmd = new SqlCommand("InsertDoctor", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FirstName", L.FirstName);
            cmd.Parameters.AddWithValue("@LastName", L.LastName);
            cmd.Parameters.AddWithValue("@sex", L.Sex);
            cmd.Parameters.AddWithValue("@specialization", L.Specialization);
            
            con.Open();
            int result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }
        public List<Doctor> Doctors()
        {
            List<Doctor> listdoctor = new List<Doctor>();
            using (SqlConnection con = new SqlConnection(cnn))
            {
                using (SqlCommand cmd = new SqlCommand("doct", con))
                {
                    if (con.State == System.Data.ConnectionState.Closed)
                        con.Open();
                    IDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        listdoctor.Add(new Doctor()
                        {
                            DoctorID = int.Parse(reader["DoctorId"].ToString()),
                            FirstName = reader["FirstName"].ToString(),
                            LastName = reader["LastName"].ToString(),
                            Sex=reader["Sex"].ToString(),
                            Specialization = reader["Specialization"].ToString(),
                            //VistingHours = reader["VisitingTime"].ToString(),

                        });
                    }
                }
            }
            return listdoctor;
        }
        public int InsertPatient(Patient L)
        {

            SqlConnection con = new SqlConnection(cnn);
            SqlCommand cmd = new SqlCommand("InsertPatient", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FirstName", L.FirstName);
            cmd.Parameters.AddWithValue("@LastName", L.LastName);
            cmd.Parameters.AddWithValue("@Sex", L.Sex);
            cmd.Parameters.AddWithValue("@Age", L.Age);
            cmd.Parameters.AddWithValue("@DOB", L.DOB);
            con.Open();
            int result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }

        public int InsertAppointment(Appointment L)
        {

            SqlConnection con = new SqlConnection(cnn);
            SqlCommand cmd = new SqlCommand("InsertAppointment", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@patientid", L.PatientID);
            cmd.Parameters.AddWithValue("@patname", L.PatientName);
            cmd.Parameters.AddWithValue("@specialization", L.Specialization);
            cmd.Parameters.AddWithValue("@doctor", L.Doctor);
            cmd.Parameters.AddWithValue("@visit", L.VisitDate);
            cmd.Parameters.AddWithValue("@appointmenttime", L.AppointmentTime);
            con.Open();
            int result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }
        public int DeleteSchedule(int id)
        {
            SqlConnection con = new SqlConnection(cnn);
            SqlCommand cmd = new SqlCommand("DeleteSchedule", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@patid",id);
            
            con.Open();
            int result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }

    }
}
