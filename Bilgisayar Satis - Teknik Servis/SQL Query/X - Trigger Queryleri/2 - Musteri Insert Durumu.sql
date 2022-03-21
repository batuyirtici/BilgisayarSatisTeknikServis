create trigger insertdurumu on Musteri
After Insert
As
Begin
Declare @MusteriID int
Declare @kullanici_mail varchar(50)
Declare @kullanici_sifre varchar(40)
Declare @deger int
Select @MusteriID=MusteriID from Musteri
Select @kullanici_mail=MailAdres from Musteri
Select @kullanici_sifre=sifre from Musteri
Set @deger=0
Insert into Kullanici values(@MusteriID,@kullanici_mail,@kullanici_sifre,@deger,@deger,@deger,@deger)
End