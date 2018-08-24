USE [cookbook.mdf]
GO

INSERT INTO [dbo].[Recipes]
           ([Title]
           ,[ShortDescription]
           ,[Content]
		   ,[AverageRating]
		   ,[CreationDate]
		   ,[UpdateDate]
           ,[CategoryId]
           ,[ImageUrl]
           ,[CreatorId]
           ,[CookingMethodId]
           ,[CountryId]
           ,[IngredientTypeId])
     VALUES
           ('Turkey Wraps', 'These light and tasty wraps are great for lunch, or slice them smaller and they make wonderful party appetizers or great little after-school snacks.',
		   'Mix together the cream cheese and Dijon mustard until smooth. Spread each tortilla with about 2 tablespoons of the cream cheese mixture, spreading to within 1/4 inch of the edge of the tortillas.',
		   0, GETUTCDATE(), GETUTCDATE(), 1,'http://image.jpg', '21899d0a-ad28-4994-b861-74137932108b', 2, 1, 2),
		   ('School Lunch Bagel Sandwich', 'This sandwich mixes the goodness of bagels with the crunch of dill pickles. I came up with this sandwich for my son who loves bagels and cream cheese but I felt his favorite needed
		    something extra to really make it a lunch. This is kid-tested good, and you can alter the veggies according to what your child likes.',
			'Spread the cream cheese on the toasted bagel. Layer the Cheddar cheese, pickle slices, carrot, and lettuce onto one half of the bagel, then top with the remaining bagel half. Cut the sandwich in half and wrap
			 with plastic wrap or aluminum foil. Place the sandwich in a lunch bag with an ice pack.',0, GETUTCDATE(), GETUTCDATE(), 2, 'http://image2.jpg', 'ada2b561-06f8-41c0-a10d-a3c425b1cded', 2, 2, 1);

GO


