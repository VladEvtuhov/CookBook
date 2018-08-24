SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE GetUsersRecipes AS
BEGIN
	SET NOCOUNT ON;
SELECT       AspNetUsers.Email, Recipes.Title, Recipes.ShortDescription, Recipes.Content
FROM            AspNetUsers LEFT JOIN Recipes ON Recipes.CreatorId = AspNetUsers.Id
END
GO
