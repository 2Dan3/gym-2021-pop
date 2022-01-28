/****** Object:  Database [fitness_center]    Script Date: 27.1.2022. 17:55:39 ******/
CREATE DATABASE [fitness_center]
 
USE [fitness_center]

/****** Object:  Table [dbo].[adresa]    Script Date: 27.1.2022. 17:55:31 ******/

CREATE TABLE [dbo].[adresa](
	[adresa_id] [int] IDENTITY(1,1) NOT NULL,
	[ulica] [varchar](150) NOT NULL,
	[broj] [int] NULL,
	[grad] [varchar](50) NULL,
	[drzava] [varchar](50) NULL,
 CONSTRAINT [PK_adresa] PRIMARY KEY CLUSTERED 
(
	[adresa_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

USE [fitness_center]

/****** Object:  Table [dbo].[fitness_center]    Script Date: 27.1.2022. 17:58:55 ******/

CREATE TABLE [dbo].[fitness_center](
	[fitness_id] [int] IDENTITY(1,1) NOT NULL,
	[naziv] [varchar](150) NOT NULL,
	[adresa_id] [int] NULL,
 CONSTRAINT [PK_fitness_center] PRIMARY KEY CLUSTERED 
(
	[fitness_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

ALTER TABLE [dbo].[fitness_center]  WITH CHECK ADD  CONSTRAINT [fk_adresa_cen] FOREIGN KEY([adresa_id])
REFERENCES [dbo].[adresa] ([adresa_id])

ALTER TABLE [dbo].[fitness_center] CHECK CONSTRAINT [fk_adresa_cen]

USE [fitness_center]

/****** Object:  Table [dbo].[korisnik]    Script Date: 27.1.2022. 17:59:44 ******/

CREATE TABLE [dbo].[korisnik](
	[korisnik_id] [int] IDENTITY(1,1) NOT NULL,
	[ime] [varchar](50) NOT NULL,
	[prezime] [varchar](50) NOT NULL,
	[jmbg] [bigint] NULL,
	[pol] [varchar](1) NULL,
	[adresa_id] [int] NULL,
	[email] [varchar](50) NULL,
	[lozinka] [varchar](50) NULL,
	[tip] [varchar](10) NULL,
	[obrisan] [varchar](1) NULL,
 CONSTRAINT [PK_korisnik] PRIMARY KEY CLUSTERED 
(
	[korisnik_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

ALTER TABLE [dbo].[korisnik]  WITH CHECK ADD  CONSTRAINT [fk_adresa_kor] FOREIGN KEY([adresa_id])
REFERENCES [dbo].[adresa] ([adresa_id])

ALTER TABLE [dbo].[korisnik] CHECK CONSTRAINT [fk_adresa_kor]

USE [fitness_center]

/****** Object:  Table [dbo].[trening]    Script Date: 27.1.2022. 18:00:19 ******/

CREATE TABLE [dbo].[trening](
	[trening_id] [int] IDENTITY(1,1) NOT NULL,
	[datum] [date] NOT NULL,
	[vreme] [time](7) NOT NULL,
	[trajanje] [int] NULL,
	[status] [varchar](5) NULL,
	[instruktor_id] [int] NULL,
	[polaznik_id] [int] NULL,
	[obrisan] [varchar](1) NULL,
PRIMARY KEY CLUSTERED 
(
	[trening_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

ALTER TABLE [dbo].[trening]  WITH CHECK ADD  CONSTRAINT [fk_kor_instr] FOREIGN KEY([instruktor_id])
REFERENCES [dbo].[korisnik] ([korisnik_id])

ALTER TABLE [dbo].[trening] CHECK CONSTRAINT [fk_kor_instr]

ALTER TABLE [dbo].[trening]  WITH CHECK ADD  CONSTRAINT [fk_kor_polaz] FOREIGN KEY([polaznik_id])
REFERENCES [dbo].[korisnik] ([korisnik_id])

ALTER TABLE [dbo].[trening] CHECK CONSTRAINT [fk_kor_polaz]

USE [fitness_center]

/****** Object:  Table [dbo].[trening_korisnik]    Script Date: 27.1.2022. 18:01:04 ******/

CREATE TABLE [dbo].[trening_korisnik](
	[trening_id] [int] NOT NULL,
	[korisnik_id] [int] NOT NULL,
 CONSTRAINT [PK_trening_korisnik] PRIMARY KEY CLUSTERED 
(
	[trening_id] ASC,
	[korisnik_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

ALTER TABLE [dbo].[trening_korisnik]  WITH CHECK ADD  CONSTRAINT [fk_korisnik] FOREIGN KEY([korisnik_id])
REFERENCES [dbo].[korisnik] ([korisnik_id])

ALTER TABLE [dbo].[trening_korisnik] CHECK CONSTRAINT [fk_korisnik]

ALTER TABLE [dbo].[trening_korisnik]  WITH CHECK ADD  CONSTRAINT [fk_trening] FOREIGN KEY([trening_id])
REFERENCES [dbo].[trening] ([trening_id])

ALTER TABLE [dbo].[trening_korisnik] CHECK CONSTRAINT [fk_trening]






