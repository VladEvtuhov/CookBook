Create table dbo.Users(
Id int identity(1,1) primary key
,Email varchar NOT NULL
,UserName varchar)
GO
Create table dbo.Rec(
Id int identity(1,1) primary key
,UserId int NOT NULL
,Content varchar)
GO
ALTER TABLE dbo.Rec ADD CONSTRAINT UsersRec FOREIGN KEY (UserId) references Users(Id)