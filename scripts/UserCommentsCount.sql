SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION UserCommentsCount
(
	@userId int
)
RETURNS int
AS
BEGIN
	DECLARE @ret int;
	SELECT @ret = Count(Comments.Content)
	FROM Comments WHERE Comments.CreatorId = @userId;
	IF (@ret IS NULL)   
        SET @ret = 0;  
    RETURN @ret;  
END
GO

