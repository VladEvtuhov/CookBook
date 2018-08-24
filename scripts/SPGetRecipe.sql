SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE GetRecipeById
		@identifier INT 
AS
BEGIN
	SET NOCOUNT ON;
SELECT        Recipes.ImageUrl, Recipes.AverageRating, Recipes.Title, Recipes.ShortDescription, Recipes.[Content], IngredientTypes.Name AS Ingredient_types, Categories.Name AS Categories, —uisine—ountry.Name AS Cuisine_Countries, 
                         Comments.CreationDate, CookingMethods.Name AS Cooking_Methods, Comments.[Content] AS Comments, AspNetUsers.Email AS Comment_Creator
FROM            Recipes INNER JOIN
                         Comments ON Comments.RecipeId = Recipes.Id INNER JOIN
                         CookingMethods ON Recipes.CookingMethodId = CookingMethods.Id INNER JOIN
                         IngredientTypes ON Recipes.IngredientTypeId = IngredientTypes.Id INNER JOIN
                         —uisine—ountry ON Recipes.CountryId = —uisine—ountry.Id INNER JOIN
                         Categories ON Recipes.CategoryId = Categories.Id INNER JOIN
						 AspNetUsers ON Comments.CreatorId = AspNetUsers.Id WHERE Recipes.Id = @identifier
END
GO