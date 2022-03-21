create table bilgisayar(
pcid int identity(100,1) primary key,
modelno varchar(40),
firmaAd varchar(25) foreign key References UreticiFirma(firmaAd),
fiyat int,
CPU varchar(30),
RAM varchar(30),
Depolama varchar(30),
GPU varchar(30),
OS varchar(20),
stokadeti int
)
