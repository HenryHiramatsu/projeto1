-- Criando banco de dados
create database bdExemplo;
-- Usando o banco de dados
use bdExemplo;

-- Criando as tabelas do banco
create table Usuarios(
Id int primary key auto_increment,
Nome varchar(50) not null,
Email varchar(50) not null,
Senha varchar(50) not null
);

-- Constultando os dados do banco
select * from Usuarios;

