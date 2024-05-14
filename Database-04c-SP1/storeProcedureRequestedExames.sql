-- store procedure: Requested exames ordered by doctor
create procedure RequestedExames as
begin
	select doctor.name, doctor.expertise, doctor.crm, consulting.number, 
		exame_request.number, exame_request.date, exame.code, exame.especification
	from doctor
	inner join consulting on doctor.crm = consulting.fk_doctor_crm 
	inner join exame_request on consulting.number = exame_request.fk_consulting_number
	inner join exame on exame_request.fk_exame_code = exame.code 
		order by doctor.name, exame_request.date;
end

execute RequestedExames;
-- drop procedure RequestedExames;