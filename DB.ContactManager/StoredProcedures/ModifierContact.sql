CREATE PROCEDURE [dbo].[ModifierContact]
	@id INTEGER,
	@nom NVARCHAR(50),
	@prenom NVARCHAR(50),
	@email NVARCHAR(384),
	@tel NVARCHAR(20),
	@anniversaire DATE,
	@utilisateur_id INT,
	@categorie_id INT
AS
	UPDATE [Contact]
		SET [Nom] = @nom,
			[Prenom] = @prenom,
			[Email] = @email,
			[Tel] = @tel,
			[Anniversaire] = @anniversaire,
			[UtilisateurId] = @utilisateur_id,
			[CategorieId] = @categorie_id
	WHERE [Id] = @id
GO