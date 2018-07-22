CREATE DATABASE TShirtsDb
GO

USE TShirtsDb
GO

CREATE TABLE TShirts
(
	Id INT IDENTITY(1,1) NOT NULL,
	Color NVARCHAR(100) NOT NULL,
	Quantity INT NOT NULL,
	Size NVARCHAR(10) NOT NULL,
	CONSTRAINT pk_TShirts_Id PRIMARY KEY (Id)
)

USE TShirtsDb
GO

CREATE TABLE Log
(
	Id INT NOT NULL IDENTITY(1,1),
	[Message] NVARCHAR(MAX) NOT NULL,
	Severity INT NOT NULL,
	[Timestamp] datetime2 NOT NULL,

	CONSTRAINT pk_Log_Id PRIMARY KEY (Id)
)

INSERT INTO TShirts(Color, Quantity, Size)
VALUES ('61422-36 Black', 1, 'L'), ('61422-30 White', 1, 'L'), ('61422-94 Heather Grey', 1, 'L'), ('61422-32 Navy', 4, 'L') 
