drop database if exists productApi;
create database productApi;
use productApi;

create table product (
    id int primary key auto_increment,
    productName varchar(20),
    price decimal(10, 2),
	expiry date
);

CREATE TABLE supplier (
  id int primary key auto_increment,
  supplierName varchar(255),
  contractTime date,
  status int
);

CREATE TABLE productsupplier (
  id int primary key auto_increment,
  idproduct int ,
  idsupplier int
);

ALTER TABLE productsupplier ADD FOREIGN KEY (idsupplier) REFERENCES supplier (id);

ALTER TABLE productsupplier ADD FOREIGN KEY (idproduct) REFERENCES product (id);