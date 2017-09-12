CREATE FUNCTION [dbo].[fn_FoodShop] ( @Language CHAR(2) )
RETURNS TABLE
AS
RETURN
    ( SELECT    f.* 
      FROM      FoodShop f

    )
