CREATE FUNCTION [dbo].[fn_MenuItemIngredient] ()
RETURNS TABLE
AS
RETURN
    ( SELECT    mii.* 
      FROM      MenuItemIngredient mii

    )
