create trigger UreticiFirmaSilinmeDurumu on UreticiFirma
After delete
As
Begin

Declare @firmaID smallint 
Declare @firmaAd varchar(25)
Declare @webAdres varchar(100)
Declare @mailAdres varchar(60)
Declare @telNo char (11)
Declare @firmaAdres varchar(150)

Select @firmaID=firmaID from deleted
Select @firmaAd=firmaAd from deleted
Select @webAdres=webAdres from deleted
Select @mailAdres=mailAdres from deleted
Select @telNo=telNo from deleted
Select @firmaAdres=firmaAdres from deleted
Insert into SilinenUreticiFirma values(@firmaID,@firmaAd,@webAdres,@mailAdres,@telNo,@firmaAdres)
End