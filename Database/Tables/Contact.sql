CREATE TABLE [dbo].[Contact]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1), 
    [LastName] NVARCHAR(50) NOT NULL, 
    [FirstName] NVARCHAR(50) NOT NULL, 
    [Email] NVARCHAR(50) NOT NULL, 
    [IdCategory] INT NOT NULL, 
    CONSTRAINT [FK_Contact_Catgory] FOREIGN KEY ([IdCategory]) REFERENCES [Category]([Id])
)
