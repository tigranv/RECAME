CREATE FUNCTION [dbo].[fn_FoodShop]
(
	@lang CHAR(3)
)
RETURNS TABLE
AS RETURN
(
	SELECT	f.[Id],
			f.[Type],
			f.[NameId],
			f.[DescriptionId],
			n.[Text] AS Name,
			d.[Text] AS Description 
	FROM	dbo.FoodShop f
			INNER JOIN dbo.fn_TranslationEntryDef(@lang) n ON f.NameId = n.TranslationId
			INNER JOIN dbo.fn_TranslationEntryDef(@lang) d ON f.DescriptionId = d.TranslationId
)
