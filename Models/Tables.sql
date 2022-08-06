CREATE TABLE [dbo].[Notes] (
    [Id]          INT primary key IDENTITY (1, 1) NOT NULL,
    [Name]        NVARCHAR (50) NULL,
    [SurName]     NVARCHAR (50) NULL,
    [Patronymic]  NVARCHAR (50) NULL,
    [PhoneNumber] INT           NULL,
    [Address]     NVARCHAR (50) NULL
);

SET IDENTITY_INSERT [dbo].[Notes] ON
INSERT INTO [dbo].[Notes] ([Id], [Name], [SurName], [Patronymic], [PhoneNumber], [Address]) VALUES (1, N'Карл', N'Карлов', N'Карлович', 555888444, N'Москва, Россиийская федерация')
SET IDENTITY_INSERT [dbo].[Notes] OFF