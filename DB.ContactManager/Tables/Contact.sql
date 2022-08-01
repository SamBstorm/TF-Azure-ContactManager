CREATE TABLE [dbo].[Contact]
(
	[Id] INT NOT NULL IDENTITY,
	[Nom] NVARCHAR(50) NOT NULL,
	[Prenom] NVARCHAR(50) NOT NULL,
	[Email] NVARCHAR(384),
	[Tel] NVARCHAR(20),
	[Anniversaire] DATE,
	[UtilisateurId] INT NOT NULL,
	[CategorieId] INT NOT NULL,
	CONSTRAINT PK_Contact PRIMARY KEY ([Id]),
	--CONSTRAINT UK_Contact_Email UNIQUE ([Email],[UtilisateurId]),
	--CONSTRAINT UK_Contact_Tel UNIQUE ([Tel],[UtilisateurId]),
	CONSTRAINT CK_Contact_Email_Tel CHECK ([Email] IS NOT NULL OR [Tel] IS NOT NULL),
	CONSTRAINT FK_Contact_Utilisateur FOREIGN KEY ([UtilisateurId]) REFERENCES [Utilisateur]([Id]),
	CONSTRAINT FK_Contact_Categorie FOREIGN KEY ([CategorieId]) REFERENCES [Categorie]([Id])
)
