-- store procedure: doctor planner
create procedure DoctorPlanner as 
begin
	select doctor.name, doctor.expertise, doctor.crm, consulting.number, consulting.date, 
			consulting.schedule, patient.name, patient.cpf,  
			patient.plan_name, patient.plan_type 	
		from doctor
		inner join consulting on doctor.crm = consulting.fk_doctor_crm 
		inner join patient on consulting.fk_patient_cpf = patient.cpf 
			order by doctor.name, consulting.date;
end

execute DoctorPlanner;
-- drop procedure DoctorPlanner;

