CREATE PROCEDURE [dbo].[SupprimerContact]
	@id INTEGER
AS
	DELETE FROM [Contact]
	WHERE [Id] = @id
GO