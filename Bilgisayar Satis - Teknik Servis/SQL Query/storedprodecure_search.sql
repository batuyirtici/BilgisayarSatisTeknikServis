Alter PROC arama (@tabloadi nvarchar(30),@aranacakyer nvarchar(30),@aranacakveri nvarchar(30))
AS

Begin 
    declare @SQLKOMUTU nvarchar(1000)
    SET @SQLKOMUTU ='SELECT * FROM '+@tabloadi+' where '+@aranacakyer+' like ''%'+@aranacakveri+'%'''
    EXEC sp_executesql @SQLKOMUTU
End