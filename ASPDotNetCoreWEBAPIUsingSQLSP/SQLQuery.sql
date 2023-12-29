

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




