create trigger stokazalt on siparis
After Insert
As
Begin
Declare @pcid int
Declare @miktar int

Select @pcid=pcid from siparis
Select @miktar=miktar from siparis

Update bilgisayar set stokadeti=stokadeti-@miktar where pcid=@pcid
End