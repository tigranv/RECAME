CREATE FUNCTION [dbo].[fn_Ingredient] ()
RETURNS TABLE
AS
RETURN
    ( SELECT    I.* 
      FROM      Ingredient I

    )
