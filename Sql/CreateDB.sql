drop database if exists productApi;
create database productApi;
use productApi;

create table product (
    id int primary key auto_increment,
    productName varchar(20),
    price decimal(10, 2),
	expiry date
);