SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION RecipeCommentsCount (@storeid int)
RETURNS TABLE 
AS
RETURN 
(
	SELECT AspNetUsers.Email, Recipes.Title, Count(Comments.Content) AS 'Comments'  
    FROM Recipes 
    JOIN AspNetUsers ON AspNetUsers.Id = Recipes.CreatorId 
    JOIN Comments ON Comments.RecipeId = Recipes.Id 
    WHERE Recipes.Id = @storeid
	GROUP BY Recipes.Title, AspNetUsers.Email
)
GO
