create database AutoService
use AutoService

create table register(
id_user int identity(1,1) not null,
login_user varchar(50) not null,
password_user varchar(50) not null,
);

create table workers(
id_worker int identity(1,1) not null,
name_worker varchar(50) not null,
phone_number_worker varchar(50) not null,
);

create table spares (
id_spare int identity(1,1) not null,
title_spare varchar(50) not null,
amount_spare int not null,
price_spare money not null,
mark_car varchar(50) not null,
country varchar(50) not null
);

create table clients (
id_client int identity(1,1) not null,
name_client varchar (50) not null,
phone_number varchar (50) not null,
car_mark varchar(50) not null,
state_number varchar(10) not null
);

create table repairs (
id_repair int identity(1,1) not null,
name_client varchar(50) not null,
car_mark varchar(50) not null,
state_number varchar(50) not null,
phone_number varchar(50) not null,
start_day varchar(50) not null,
end_day varchar(50) not null,
status_repair varchar(50) not null,
price money not null,
worker varchar(50) not null,
);