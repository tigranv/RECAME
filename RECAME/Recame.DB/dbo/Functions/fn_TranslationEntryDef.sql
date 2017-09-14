CREATE FUNCTION [dbo].[fn_TranslationEntryDef] ( @Language CHAR(2) )
RETURNS TABLE
AS
RETURN
    ( SELECT    de.TranslationId ,
                ISNULL(e.[Text], de.[Text]) AS [Text]
      FROM      dbo.TranslationEntry de
                LEFT JOIN dbo.TranslationEntry e ON de.TranslationId = e.TranslationId
                                                    AND e.LanguageId = @Language
      WHERE     de.LanguageId = 'en'
    )
