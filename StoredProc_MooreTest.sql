create or alter proc CSVCalculation 
@ColStandarDev varchar(10)  null , 
@ColROC varchar(10)  null , 
@ColRMS varchar(10)  null,
@StandardDevOutput varchar(100)  null, 
@ROCOutput varchar(100)  null, 
@RMSOutput varchar(100)  null 

as 


Begin

declare @StandardCal varchar(20) ,@ROCCal varchar(20) , @RMSCal varchar(20) 

set @StandardCal ='Standard Deviation'
set @ROCCal = 'ROC'
set @RMSCal = 'RMS'

if not exists (select * from sys.tables where name = 'CSV_Calculation_Output' )
begin
create table CSV_Calculation_Output (         ColName varchar(10) not null, OutputResult varchar(100) not null, Calculator varchar(20) not null     )
end 

if not exists(select top 1 * from CSV_Calculation_Output where ColName = @ColStandarDev  and Calculator = @StandardCal )
begin
insert into  CSV_Calculation_Output values (@ColStandarDev,@StandardDevOutput,@StandardCal )
end
else
begin
update CSV_Calculation_Output
set ColName = @ColStandarDev,
OutputResult = @StandardDevOutput
where  ColName = @ColStandarDev  and Calculator = @StandardCal
end 

if not exists(select top 1 * from CSV_Calculation_Output where ColName = @ColROC  and Calculator =  @ROCCal)
begin
insert into CSV_Calculation_Output values(@ColROC,@ROCOutput,@ROCCal )
end
else
begin
update CSV_Calculation_Output
set ColName = @ColROC,
OutputResult = @ROCOutput
where  ColName = @ColROC  and Calculator =  @ROCCal
end 


if not exists(select top 1 * from CSV_Calculation_Output where ColName = @ColRMS  and Calculator =  @RMSCal)
begin
insert into CSV_Calculation_Output values(@ColROC,@ROCOutput,@RMSCal)
end
else
begin
update CSV_Calculation_Output
set ColName = @ColRMS,
OutputResult = @RMSOutput
where  ColName = @ColRMS  and Calculator =  @RMSCal
end 



if not exists(select top 1 * from CSV_Calculation_Output where ColName = @ColRMS  and Calculator =  @RMSCal)
begin
insert into CSV_Calculation_Output values(@ColROC,@ROCOutput,@RMSCal)
end
else
begin
update CSV_Calculation_Output
set ColName = @ColRMS,
OutputResult = @RMSOutput
where  ColName = @ColRMS  and Calculator =  @RMSCal
end 




end


