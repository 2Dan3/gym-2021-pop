-- ADRESE

USE [fitness_center]

INSERT INTO [dbo].[adresa]
           ([ulica]
           ,[broj]
           ,[grad]
           ,[drzava])
     VALUES
           ('Bulevar Mihajla Pupina'
           ,7
           ,'Novi Sad'
           ,'Srbija');

INSERT INTO [dbo].[adresa]
           ([ulica]
           ,[broj]
           ,[grad]
           ,[drzava])
     VALUES
           ('Tozin sokak'
           ,14
           ,'Novi Sad'
           ,'Srbija');

INSERT INTO [dbo].[adresa]
           ([ulica]
           ,[broj]
           ,[grad]
           ,[drzava])
     VALUES
           ('Trifkovićev trg'
           ,74
           ,'Novi Sad'
           ,'Srbija');

INSERT INTO [dbo].[adresa]
           ([ulica]
           ,[broj]
           ,[grad]
           ,[drzava])
     VALUES
           ('Bulevar Evrope'
           ,130
           ,'Novi Sad'
           ,'Srbija');

INSERT INTO [dbo].[adresa]
           ([ulica]
           ,[broj]
           ,[grad]
           ,[drzava])
     VALUES
           ('Futoska'
           ,146
           ,'Novi Sad'
           ,'Srbija');

INSERT INTO [dbo].[adresa]
           ([ulica]
           ,[broj]
           ,[grad]
           ,[drzava])
     VALUES
           ('Dunavska'
           ,17
           ,'Beograd'
           ,'Srbija');

INSERT INTO [dbo].[adresa]
           ([ulica]
           ,[broj]
           ,[grad]
           ,[drzava])
     VALUES
           ('Cika Stevina'
           ,2
           ,'Novi Sad'
           ,'Srbija');

INSERT INTO [dbo].[adresa]
           ([ulica]
           ,[broj]
           ,[grad]
           ,[drzava])
     VALUES
           ('Avijaticarska'
           ,55
           ,'Novi Sad'
           ,'Srbija');

-- FITNES CENTAR

INSERT INTO [dbo].[fitness_center]
           ([naziv]
           ,[adresa_id])
     VALUES
           ('Atomski mrav'
           ,1);

-- KORISNIK
INSERT INTO [dbo].[korisnik]
           ([ime]
           ,[prezime]
           ,[jmbg]
           ,[pol]
           ,[adresa_id]
           ,[email]
           ,[lozinka]
           ,[tip]
           ,[obrisan])
     VALUES
           ('Maja'
           ,'Majkic'
           ,2312000800022
           ,'Z'
           ,2
           ,'maja@gmail.com'
           ,'pass123'
           ,'ADMIN'
           ,'N');

INSERT INTO [dbo].[korisnik]
           ([ime]
           ,[prezime]
           ,[jmbg]
           ,[pol]
           ,[adresa_id]
           ,[email]
           ,[lozinka]
           ,[tip]
           ,[obrisan])
     VALUES
           ('Pera'
           ,'Peric'
           ,1010002800025
           ,'M'
           ,3
           ,'pera@gmail.com'
           ,'pass123'
           ,'TRAINEE'
           ,'N');

INSERT INTO [dbo].[korisnik]
           ([ime]
           ,[prezime]
           ,[jmbg]
           ,[pol]
           ,[adresa_id]
           ,[email]
           ,[lozinka]
           ,[tip]
           ,[obrisan])
     VALUES
           ('Ivana'
           ,'Ivanovic'
           ,1109000800125
           ,'Z'
           ,4
           ,'ivana@gmail.com'
           ,'pass123'
           ,'TRAINEE'
           ,'N');

INSERT INTO [dbo].[korisnik]
           ([ime]
           ,[prezime]
           ,[jmbg]
           ,[pol]
           ,[adresa_id]
           ,[email]
           ,[lozinka]
           ,[tip]
           ,[obrisan])
     VALUES
           ('Mila'
           ,'Milic'
           ,2112000800325
           ,'Z'
           ,5
           ,'mila@gmail.com'
           ,'pass123'
           ,'TRAINEE'
           ,'N');


INSERT INTO [dbo].[korisnik]
           ([ime]
           ,[prezime]
           ,[jmbg]
           ,[pol]
           ,[adresa_id]
           ,[email]
           ,[lozinka]
           ,[tip]
           ,[obrisan])
     VALUES
           ('Dimitrije'
           ,'Dimic'
           ,1412000800328
           ,'M'
           ,6
           ,'dima@gmail.com'
           ,'pass123'
           ,'INSTRUCTOR'
           ,'N');

INSERT INTO [dbo].[korisnik]
           ([ime]
           ,[prezime]
           ,[jmbg]
           ,[pol]
           ,[adresa_id]
           ,[email]
           ,[lozinka]
           ,[tip]
           ,[obrisan])
     VALUES
           ('Tamara'
           ,'Tamaric'
           ,1503000800001
           ,'Z'
           ,7
           ,'tamara@gmail.com'
           ,'pass123'
           ,'INSTRUCTOR'
           ,'N');

INSERT INTO [dbo].[korisnik]
           ([ime]
           ,[prezime]
           ,[jmbg]
           ,[pol]
           ,[adresa_id]
           ,[email]
           ,[lozinka]
           ,[tip]
           ,[obrisan])
     VALUES
           ('Jadranko'
           ,'Jadranovic'
           ,1612998800328
           ,'M'
           ,8
           ,'jadranko@gmail.com'
           ,'pass123'
           ,'TRAINEE'
           ,'N');

--TRENING
INSERT INTO [dbo].[trening]
           ([datum]
           ,[vreme]
           ,[trajanje]
           ,[status]
           ,[instruktor_id]
           ,[polaznik_id]
           ,[obrisan])
     VALUES
           ('2022-01-30'
           ,'14:15'
           ,45
           ,'FREE'
           ,5
           ,null
           ,'N');

INSERT INTO [dbo].[trening]
           ([datum]
           ,[vreme]
           ,[trajanje]
           ,[status]
           ,[instruktor_id]
           ,[polaznik_id]
           ,[obrisan])
     VALUES
           ('2022-01-30'
           ,'15:15'
           ,45
           ,'FREE'
           ,6
           ,null
           ,'N');


INSERT INTO [dbo].[trening]
           ([datum]
           ,[vreme]
           ,[trajanje]
           ,[status]
           ,[instruktor_id]
           ,[polaznik_id]
           ,[obrisan])
     VALUES
           ('2022-01-31'
           ,'07:30'
           ,45
           ,'TAKEN'
           ,5
           ,3
           ,'N');


INSERT INTO [dbo].[trening]
           ([datum]
           ,[vreme]
           ,[trajanje]
           ,[status]
           ,[instruktor_id]
           ,[polaznik_id]
           ,[obrisan])
     VALUES
           ('2022-02-01'
           ,'07:30'
           ,45
           ,'TAKEN'
           ,5
           ,3
           ,'N');