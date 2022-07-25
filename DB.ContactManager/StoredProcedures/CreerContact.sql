CREATE PROCEDURE [dbo].[CreerContact]
	@nom NVARCHAR(50),
	@prenom NVARCHAR(50),
	@email NVARCHAR(384),
	@tel NVARCHAR(20),
	@anniversaire DATE,
	@utilisateur_id INT,
	@categorie_id INT
AS
	INSERT INTO [Contact] ([Nom],[Prenom],[Email],[Tel],[Anniversaire],[UtilisateurId],[CategorieId])
	OUTPUT [inserted].[Id]
	VALUES (@nom,@prenom,@email,@tel,@anniversaire,@utilisateur_id,@categorie_id)
GO