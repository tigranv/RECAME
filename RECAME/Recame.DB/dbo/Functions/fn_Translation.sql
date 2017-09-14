CREATE FUNCTION [dbo].[fn_Translation] ( @Language CHAR(2) )
RETURNS TABLE
AS RETURN
    ( SELECT    @Language AS Language ,
                t.Id ,
                t.ObjectType ,
                t.[Key] ,
				t.Modified,
                te.[Text]
      FROM      dbo.Translation t
                INNER JOIN dbo.fn_TranslationEntryDef(@Language) te ON t.Id = te.TranslationId
	  WHERE     t.IsDeleted = 0
    )
