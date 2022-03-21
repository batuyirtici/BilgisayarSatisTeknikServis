create trigger updatedurumu on Musteri
After Update
As
Begin
Declare @MusteriID int
Declare @kullanici_mail varchar(50)
Declare @kullanici_sifre varchar(40)
Select @MusteriID=MusteriID from inserted
Select @kullanici_mail=MailAdres from inserted
Select @kullanici_sifre=sifre from inserted
Update Kullanici set kullanici_mail=@kullanici_mail , kullanici_sifre=@kullanici_sifre where MusteriID=@MusteriID
End