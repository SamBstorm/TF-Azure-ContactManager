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
	CONSTRAINT UK_Contact_Email UNIQUE ([Email]),
	CONSTRAINT UK_Contact_Tel UNIQUE ([Tel]),
	CONSTRAINT FK_Contact_Utilisateur FOREIGN KEY ([UtilisateurId]) REFERENCES [Utilisateur]([Id]),
	CONSTRAINT FK_Contact_Categorie FOREIGN KEY ([CategorieId]) REFERENCES [Categorie]([Id]),
)
