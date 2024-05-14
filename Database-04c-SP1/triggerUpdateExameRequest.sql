-- calculation trigger for the payment amount in the exame_request table
create trigger UpdateExameRequest on exame_request after insert as
    begin 
		SET NOCOUNT ON
		declare @request_number as integer;
		-- capture inserted exame request number
		select @request_number = exame_request.number from inserted;
		declare @consulting_number as integer;
		-- capture inserted consulting number
		select @consulting_number = fk_consulting_number from inserted;
		declare @exame_code as integer;
		-- capture inserted exame code
		select @exame_code = fk_exame_code from inserted;
		declare @price as money;
		-- catch exame price 
		select @price = price from exame where code = @exame_code;
		declare @cpf_pac as varchar(20);
		-- catch patient CPF
		select @patient_cpf = patient_cpf from consulting where consulting_number = @consulting_number;
		declare @plan_type as varchar(20);
		-- catch patient health plan type
		select @plan_type = plan_type from patient where cpf = @patient_cpf;

		-- Special Plan
		if @plan_type = 'Special'
		begin
			update exame_request set price = @price - @price * 100 / 100 where request_number = @request_number;
		end
		-- Commom Plan
		if @plan_type = 'Commom'
		begin
			update exame_request set price = @price - @price * 30 / 100 where request_number = @request_number;
		end
		-- Basic PLan
		if @plan_type = 'Basic'
		begin
			update exame_request set price = @price - @price * 10 / 100 where request_number = @request_number;
		end
		print 'Trigger (Update Request Exame) Finished';

	end
	-- drop trigger UpdateExameRequest;
