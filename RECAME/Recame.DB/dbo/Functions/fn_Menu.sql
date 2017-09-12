CREATE FUNCTION [dbo].[fn_Menu] ()
RETURNS TABLE
AS
RETURN
    ( SELECT    m.* 
      FROM      Menu m

    )
