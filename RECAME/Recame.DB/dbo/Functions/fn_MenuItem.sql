CREATE FUNCTION [dbo].[fn_MenuItem] ( )
RETURNS TABLE
AS
RETURN
    ( SELECT    mi.* 
      FROM      MenuItem mi

    )
