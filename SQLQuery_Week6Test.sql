create database Agenti

create table Agente(
IdAgente int primary key identity(1,1),
Nome varchar(50) not null,
Cognome varchar(50) not null,
CodiceFiscale varchar(20) not null,
AnnoInizioAttivita int not null)

insert into Agente values('Matteo', 'Rossi', 'MTTRSS00B04A794N', 2021, 'sud')
insert into Agente values('Enrico', 'Ricci', 'RCCNRC80P06L682K', 2010, 'est')
insert into Agente values('Paola', 'Bianchi', 'BNCPLA90E46F205F', 2015, 'nord')

ALTER TABLE Agente Add AreaGeografica varchar(20)

drop table Agente




