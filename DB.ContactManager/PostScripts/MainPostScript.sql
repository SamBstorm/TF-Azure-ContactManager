/*
Modèle de script de post-déploiement							
--------------------------------------------------------------------------------------
 Ce fichier contient des instructions SQL qui seront ajoutées au script de compilation.		
 Utilisez la syntaxe SQLCMD pour inclure un fichier dans le script de post-déploiement.			
 Exemple :      :r .\monfichier.sql								
 Utilisez la syntaxe SQLCMD pour référencer une variable dans le script de post-déploiement.		
 Exemple :      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/

INSERT INTO [Categorie]([Nom]) VALUES (N'Personnel');
INSERT INTO [Categorie]([Nom]) VALUES (N'Professionel');

EXEC Enregistrer N'Legrain', N'Samuel', N'samuel.legrain@bstorm.be',N'Test1234='
