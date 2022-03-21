create trigger siparissilinmedurumu on siparis
After delete
As
Begin

Declare @siparisno varchar(10)
Declare @pcid int
Declare @miktar tinyint
Declare @kargosirketi varchar(25)
Declare @kargoid varchar(30)
Declare @alisveristarih nvarchar(20)
Declare @MusteriID int

Select @siparisno=siparisno from deleted
Select @pcid=pcid from deleted
Select @miktar=miktar from deleted
Select @kargosirketi=kargosirketi from deleted
Select @kargoid=kargoid from deleted
Select @alisveristarih=alisveristarih from deleted
Select @MusteriID=MusteriID from deleted
Insert into Silinensiparis values(@siparisno,@pcid,@miktar,@kargosirketi,@kargoid,@alisveristarih,@MusteriID)
End