

create database DBForWebAPI

use DBForWebAPI

create table tblTestEmployee
(
empID int Identity(1,1) Primary key,
empName varchar(50),
empAge int,
empActive int
);

create procedure usp_AddEmployee
(
@empName varchar(50),
@empAge int,
@empActive int
)
as
begin
insert into tblTestEmployee 
(
empName ,
empAge ,
empActive 
)
values
(
@empName ,
@empAge ,
@empActive 
)
end;



create procedure usp_GetAllEmployees
as
begin
select 
empID  ,
empName  ,
empAge  ,
empActive  
from tblTestEmployee;
end;


create procedure usp_GetEmployeeByID
(
@empID int
)
as
begin
select 
empID  ,
empName  ,
empAge  ,
empActive  
from tblTestEmployee  where empID=@empID;
end;



create procedure usp_UpdateEmployee
(
@empID int,
@empName varchar(50),
@empAge int,
@empActive int
)
as
begin
update tblTestEmployee 
set 
empName =@empName ,
empAge= @empAge ,
empActive =@empActive 
where empID =@empID ;

end;

