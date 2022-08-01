CREATE PROCEDURE [dbo].[Authentifier]
	@email NVARCHAR(384),
	@password NVARCHAR(32)
AS
	SELECT	[Id],
			[Nom],
			[Prenom],
			[Email],
			'********' AS [Password]
	FROM [Utilisateur]
	WHERE [Email] LIKE @email
		AND [Password] = HASHBYTES('SHA2_512',@password)
GO
