GO
CREATE TABLE Apartment(
	Id bigint IDENTITY(1,1) NOT NULL,
	RoomsCount int NOT NULL,
	Url varchar(1024) NOT NULL,
	CONSTRAINT PK_Apartment PRIMARY KEY CLUSTERED 
	(
		Id ASC
	)ON [PRIMARY]) ON [PRIMARY]
GO

CREATE TABLE ApartmentPriceHistory(
	Id bigint IDENTITY(1,1) NOT NULL,
	ApartmentId bigint NOT NULL,
	Price money NOT NULL,
	Date datetime NOT NULL,
	CONSTRAINT PK_ApartmentPriceHistory PRIMARY KEY CLUSTERED 
	(
		Id ASC
	)ON [PRIMARY]) ON [PRIMARY]

GO
ALTER TABLE ApartmentPriceHistory WITH CHECK 
	ADD CONSTRAINT FK_ApartmentPriceHistory_Apartment_ApartmentId
	FOREIGN KEY (ApartmentId) REFERENCES Apartment (Id)

GO
ALTER TABLE ApartmentPriceHistory CHECK CONSTRAINT FK_ApartmentPriceHistory_Apartment_ApartmentId

GO

INSERT INTO [dbo].[Apartment]
           ([RoomsCount]
           ,[Url])
     VALUES
           (1
           ,'https://ekb.cian.ru/sale/flat/298037646/');

INSERT INTO [dbo].[Apartment]
           ([RoomsCount]
           ,[Url])
     VALUES
           (2
           ,'https://ekb.cian.ru/sale/flat/298038338/');

INSERT INTO [dbo].[Apartment]
           ([RoomsCount]
           ,[Url])
     VALUES
           (3
           ,'https://ekb.cian.ru/sale/flat/294194908/');

INSERT INTO [dbo].[Apartment]
           ([RoomsCount]
           ,[Url])
     VALUES
           (1
           ,'https://ekb.cian.ru/sale/flat/292711542/');


INSERT INTO [dbo].[ApartmentPriceHistory]
           ([ApartmentId]
           ,[Price]
           ,[Date])
     VALUES
           (1
           ,1337
           ,'01-01-2024');

INSERT INTO [dbo].[ApartmentPriceHistory]
           ([ApartmentId]
           ,[Price]
           ,[Date])
     VALUES
           (1
           ,13337
           ,'02-01-2024');

INSERT INTO [dbo].[ApartmentPriceHistory]
           ([ApartmentId]
           ,[Price]
           ,[Date])
     VALUES
           (2
           ,1
           ,'02-01-2024');

INSERT INTO [dbo].[ApartmentPriceHistory]
           ([ApartmentId]
           ,[Price]
           ,[Date])
     VALUES
           (2
           ,10
           ,'03-01-2024');

INSERT INTO [dbo].[ApartmentPriceHistory]
           ([ApartmentId]
           ,[Price]
           ,[Date])
     VALUES
           (2
           ,100
           ,'04-01-2024');

INSERT INTO [dbo].[ApartmentPriceHistory]
           ([ApartmentId]
           ,[Price]
           ,[Date])
     VALUES
           (4
           ,1
           ,'02-01-2024');

INSERT INTO [dbo].[ApartmentPriceHistory]
           ([ApartmentId]
           ,[Price]
           ,[Date])
     VALUES
           (4
           ,10
           ,'10-01-2024');

INSERT INTO [dbo].[ApartmentPriceHistory]
           ([ApartmentId]
           ,[Price]
           ,[Date])
     VALUES
           (3
           ,1
           ,'02-01-2024');

INSERT INTO [dbo].[ApartmentPriceHistory]
           ([ApartmentId]
           ,[Price]
           ,[Date])
     VALUES
           (3
           ,100
           ,'02-01-2024');