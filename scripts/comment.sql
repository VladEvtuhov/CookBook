USE [cookbook.mdf]
GO

INSERT INTO [dbo].[Comments]
           ([CreatorId]
           ,[RecipeId]
           ,[Content]
		   ,[CreationDate])
     VALUES
           ('21899d0a-ad28-4994-b861-74137932108b', 9, 'hmm.', GETUTCDATE()),('ada2b561-06f8-41c0-a10d-a3c425b1cded', 9, 'test', GETUTCDATE());
GO


