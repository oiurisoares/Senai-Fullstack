-- store procedure: patients payment history
create procedure PaymentHistory as
begin
	select patient.name, patient.cpf, consulting.number, consulting.date,  
			exame_request.date, exame_request.price, exame.code, exame.especification 
		from patient 
		inner join consulting on patient.cpf = consulting.fk_patient_cpf 
		inner join exame_request on consulting.number = exame_request.fk_consulting_number
		inner join exame on exame_request.fk_exame_code = exame.code 
			order by patient.name, exame_request.date;
end

execute PaymentHistory;
-- drop procedure PaymentHistory;