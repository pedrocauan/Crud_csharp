use bd_turmaB
-- comando pra criação de database
create database db_turmaB

-- criando tabela de funcionario
create table tbl_funcionario
(
  cd_func int primary key,
  nm_func varchar(80) not null,
  no_CPF char(11) null unique
)

-- insira na tabela funcionário
insert into tbl_funcionario

--insira na tabela computador
insert into tbl_computador
(cd_comp, ds_comp, ds_marca)
values
(1, 'Notebook', 'semptochiba')

-- nos seguinte campos 
(cd_func, nm_func, no_CPF)
-- os seguintes valores
values(1, 'Joel Batista', '11122233345')


create table tbl_computador 
(
	cd_comp int primary key identity(1,1), --identify coloca a chave primaria automaticamente
	ds_comp varchar(20) not null,
	ds_marca varchar(20) not null,
	cd_func int null unique, --unique deixa o campo unico (0,1)
	--references referencia a tabela que a chave estrangeira está como chave primária
	foreign key(cd_func) references tbl_funcionario(cd_func) 	 
)

insert into tbl_computador
(ds_comp, ds_marca, cd_func)
values
('Notebook', 'Asus', 3)

select * from tbl_funcionario where cd_func = 100

-- Alterando um registro de uma tabela
update tbl_computador --atualize a tabela 
set ds_comp = 'Netbook', ds_marca = 'Dell'  -- nos os campos ds_comp coloque  Notebook
where cd_comp = 1 -- altere só o registro com o código 3

--excluindo registro da tabela
delete from tbl_funcionario
where cd_func = 0

--comando para consultar registros
select * from tbl_funcionario
select * from tbl_computador		

-- comando para excluir objetos de banco de dados
drop table tbl_funcionario
drop table tbl_computador
