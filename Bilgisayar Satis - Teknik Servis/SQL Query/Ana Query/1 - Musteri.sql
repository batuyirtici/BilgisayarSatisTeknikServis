create table Musteri(
MusteriID int identity(1000,1) primary key,
KimlikNo char(11),
Ad varchar(45),
Soyad varchar(20),
MailAdres varchar(60),
TelNo char(11),
Adres varchar(200),
sifre nvarchar(40)
)