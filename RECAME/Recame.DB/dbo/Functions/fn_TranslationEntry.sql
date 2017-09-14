CREATE FUNCTION [dbo].[fn_TranslationEntry] ( @TranslationId INT )
RETURNS TABLE
AS
RETURN
    ( SELECT    l.Id AS LanguageId ,
                te.Modified ,
                te.SessionId ,
                te.[Text] ,
                @TranslationId as TranslationId
                --se.Name
      FROM      dbo.Language l
                LEFT JOIN dbo.TranslationEntry te ON l.Id = te.LanguageId
                                                     AND te.TranslationId = @TranslationId
                --LEFT JOIN dbo.fn_SessionUser() se ON se.Id = te.SessionId
    )
