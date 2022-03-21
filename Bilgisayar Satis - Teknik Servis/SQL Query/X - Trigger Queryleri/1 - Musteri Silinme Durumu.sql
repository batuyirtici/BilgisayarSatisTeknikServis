create trigger silinmedurumu on Musteri
After delete
As
Begin
Declare @MusteriID smallint
Declare @KimlikNo char(11)
Declare @Ad varchar(45)
Declare @Soyad varchar(25)
Declare @MailAdres varchar(60)
Declare @TelNo char(11)
Declare @Adres varchar(200)
Declare @sifre nvarchar(40)
Select @MusteriID=MusteriID from deleted
Select @KimlikNo=KimlikNo from deleted
Select @Ad=Ad from deleted
Select @Soyad=Soyad from deleted
Select @MailAdres=MailAdres from deleted
Select @TelNo=TelNo from deleted
Select @Adres=Adres from deleted
Select @sifre=sifre from deleted
Insert into SilinenMusteri values(@MusteriID,@KimlikNo,@Ad,@Soyad,@MailAdres,@TelNo,@Adres,@sifre)

Declare @kullanici_mail varchar(60)
Declare @kullanici_sifre varchar(40)
Declare @okuma int
Declare @yazma int
Declare @guncelleme int
Declare @silme int
Select @kullanici_mail=kullanici_mail from Kullanici where MusteriID=@MusteriID
Select @kullanici_sifre=kullanici_sifre from Kullanici where MusteriID=@MusteriID
Select @okuma=okuma from Kullanici where MusteriID=@MusteriID
Select @yazma=yazma from Kullanici where MusteriID=@MusteriID
Select @guncelleme=guncelleme from Kullanici where MusteriID=@MusteriID
Select @silme=silme from Kullanici where MusteriID=@MusteriID
Insert Into SilinenKullanici values (@MusteriID,@kullanici_mail,@kullanici_sifre,@okuma,@yazma,@guncelleme,@silme)
delete from Kullanici where MusteriID=@MusteriID
End