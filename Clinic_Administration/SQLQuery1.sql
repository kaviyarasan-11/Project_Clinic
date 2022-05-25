use trail
go

exec staffdata

go 
create proc InsertStaff
@P_Word varchar(20)
as
select * from staff
where password=@P_Word
exec InsertStaff @P_Word='0711k'
drop proc InsertStaff
drop table doctor

create table Staff(
UserName varchar(20) ,
FirstName varchar(20),
LastName varchar(30),
password varchar(30)
constraint U_staff unique(UserName)
)
drop table doctor

insert into staff values('Kavi0711','Kavi','B','0711k')

select * from patient

create table Doctor(
DoctorID int identity(1,1) not null,
FirstName varchar(20),
LastName varchar(20),
Sex varchar(20),
Specialization varchar(20),

constraint PK_DocID primary key(DoctorID)
)

create proc doct
as
select DoctorID,FirstName,LastName,Sex,Specialization from doctor

drop proc doct

drop table Doctor

create proc InsertDoctor
@FirstName varchar(20),
@LastName varchar(20),
@sex varchar(20),
@specialization varchar(20)
as
insert into Doctor(FirstName,LastName,Sex,Specialization)
values(@FirstName,@LastName,@sex,@specialization)
drop proc insertdoctor


create table Patient(
PatientID int identity not null,
FirstName varchar(20),
LastName varchar(20),
Sex varchar(20),
Age varchar(20),
DOB varchar(20),
constraint PK_PatID primary key(PatientID)
)

select * from Patient
exec InsertPatient
create proc InsertPatient
@FirstName varchar(20),
@LastName varchar(20),
@sex varchar(20),
@Age varchar(20),
@DOB varchar(20)
as
insert into Patient(FirstName,LastName,Sex,Age,DOB)
values(@FirstName,@LastName,@sex,@Age,@DOB)
drop table patient
drop proc InsertPatient

create table Appointment(
AppointmentID int identity (1,1),
PatientID int,
PatientName varchar(20),
Doctor varchar(20),
Specialization varchar(20),
VisitDate varchar(20),
AppointmentTime varchar(20)

)
drop table Appointment
select * from Appointment

create proc InsertAppointment
@patientid int,
@patname varchar(20),
@doctor varchar(20),
@specialization varchar(20),
@visit Varchar(20),
@appointmenttime varchar(20)
as 
insert into Appointment(PatientID,Doctor,PatientName,Specialization,VisitDate,AppointmentTime)
values(@patientid,@patname,@doctor,@specialization,@visit,@appointmenttime)

drop proc InsertAppointment

create proc DelAppoint
as
select AppointmentID,PatientID,Doctor,Specialization,VisitDate,AppointmentTime
from Appointment

drop proc DelAppoint

create proc DeleteSchedule
@patid int
as
Delete from Appointment
where Appointment.PatientID=@Patid

exec DeleteSchedule
drop proc DeleteSchedule

create proc ShowSchedule
as
select AppointmentID, PatientID,PatientName, Doctor,Specialization, VisitDate, AppointmentTime from Appointment
where convert(date, GETDATE()) <= convert (date,VisitDate )

drop proc ShowSchedule