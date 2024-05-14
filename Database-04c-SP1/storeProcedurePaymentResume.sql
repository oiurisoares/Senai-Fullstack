-- store procedure: payment resume by patient
create procedure PaymentResume @patient_name varchar(40) as
begin
	select patient.name, sum(exame_request.price) as total_value
		from patient
		inner join consulting on patient.cpf = consulting.fk_patient_cpf 
		inner join exame_request on consulting.numero_consulta = exame_request.fk_consulting_number
			where patient.name = @patient_name
			group by patient.name;
end

execute PaymentResume 'Leonardo Ribeiro';
-- drop procedure PaymentResume;