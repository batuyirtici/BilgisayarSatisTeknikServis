create table siparis(
siparisno int identity(2000,1) primary key,
pcid int foreign key References bilgisayar(pcid),
miktar tinyint,
kargosirketi varchar(25),
kargoid varchar(30),
alisveristarih nvarchar(20),
MusteriID int foreign key References Musteri(MusteriID)
)