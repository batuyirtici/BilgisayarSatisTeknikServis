create trigger tekniksilinmedurumu on TeknikServis
After delete
As
Begin
Declare @personelID char(10)
Declare @ad varchar(45)
Declare @soyad varchar(20)
Declare @kimlikNo char (11)
Declare @telNo char (11)
Declare @mail varchar (60)
Declare @adres varchar (150)

Select @personelID=personelID from deleted
Select @ad=ad from deleted
Select @soyad=soyad from deleted
Select @kimlikNo=kimlikNo from deleted
Select @telNo=telNo from deleted
Select @mail=mail from deleted
Select @adres=adres from deleted
Insert into SilinenTeknikServis values (@personelID,@ad,@soyad,@kimlikNo,@telNo,@mail,@adres)
End