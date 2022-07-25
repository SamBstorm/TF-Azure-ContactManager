CREATE PROCEDURE [dbo].[Enregistrer]
	@nom NVARCHAR(50),
	@prenom NVARCHAR(50),
	@email NVARCHAR(384),
	@password NVARCHAR(32)
AS
	INSERT INTO [Utilisateur] ([Nom],[Prenom],[Email],[Password])
	OUTPUT inserted.Id
	VALUES (@nom, @prenom, @email, HASHBYTES('SHA2_512', @password))
GO
