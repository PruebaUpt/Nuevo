create database Vacunas;
use Vacunas;


create table Mascota(
ClaveM varchar(30) ,
NombreM Varchar(50) not null PRIMARY KEY,
Raza Varchar(50),
Sexo Varchar(20));


create table TipoVacuna(
CVacuna varchar(30),
Descripcion Varchar(50) not null PRIMARY KEY);


create table AplicacionV(
NombreM varchar (50) FOREIGN KEY REFERENCES Mascota(NombreM),
TVacuna varchar(50) FOREIGN KEY REFERENCES TipoVacuna(Descripcion)
);



select * from Mascota;
select * from AplicacionV ;
select * from TipoVacuna;

--select  * from Mascota inner join AplicacionV on dbo.Mascota.NombreM=dbo.AplicacionV.NombreM



------------------------------------------------------------------------------------------------------------
---------------Procedimiento almacenado para ingresar animales ---------------------------------------------
------------------------------------------------------------------------------------------------------------

create procedure AltaAnimales
@ClaveM nvarchar (30),
@NombreM nVarchar(50),
@Raza nVarchar(50),
@Sexo nVarchar(20)
as
begin 
insert into Mascota(ClaveM, NombreM,Raza, Sexo) values (@ClaveM, @NombreM, @Raza, @Sexo)
end 
-----------------------------------------------------------------------------------------------------------
exec AltaAnimales '01', 'Pulgas', 'Beagle','Macho'; 
------------

-------------------------------------------------------------------------------------------------------------
--------------Procedimiento para eliminar Animales ----------------------------------------------------------
-------------------------------------------------------------------------------------------------------------
Create Procedure Eliminar
@NombreM nVarchar(50)
as
delete from Mascota where NombreM=@NombreM;

-------------------------------------------------------------------------------------------------------------
----------------Procedimiento almacenado para tipo de vacuna-------------------------------------------------
-------------------------------------------------------------------------------------------------------------

create procedure tVacuna
@CVacuna nvarchar(30),
@Descripcion nvarchar(50)
as
begin 
insert into TipoVacuna(CVacuna, Descripcion) values(@CVacuna, @Descripcion);
end
------------------------------------------------------------------------------------------------------------
exec tVacuna 'V7','Parainfluenza';
------------------------------------


------------------------------------------------------------------------------------------------------------
--------------------Procedimiento alamcenado para el registro de aplicación de vacuna ---------------------- 
------------------------------------------------------------------------------------------------------------
create procedure Aplicacion
@NombreM nvarchar(50),
@TVacuna nVarchar (50)
as
begin 
insert into AplicacionV (NombreM, TVacuna) values(@NombreM,@TVacuna)
end


--------------------------------------------------------------------------------------------------------------
exec Aplicacion 'Pulgas', 'Ravia';



--------------------------------------------------------------------------------------------------------------
------------------Procedimiento alacenado para llenar el catalogo de vacunas----------------------------------
--------------------------------------------------------------------------------------------------------------
create procedure C_combo
as 
select Descripcion from TipoVacuna;

go


--------------------------------------------------------------------------------------------------------------
-------------------Procedimiento almacenado para llenar el catalogo de nombre de animales---------------------
--------------------------------------------------------------------------------------------------------------
create procedure C_comboM
as 
select NombreM from Mascota;
go

--------------------------------------------------------------------------------------------------------------
---------------Procedimiento almacenado para consulta de vacunas aplicadas por mascota------------------------
--------------------------------------------------------------------------------------------------------------

create procedure ConsultaVM
@NombreM nvarchar(50)
as
select TVacuna from AplicacionV where NombreM=@NombreM;
go
