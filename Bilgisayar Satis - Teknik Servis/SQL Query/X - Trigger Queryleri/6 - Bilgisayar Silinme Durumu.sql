create trigger bilgisayarsilmedurumu on bilgisayar
After delete
As
Begin

Declare @pcid nvarchar(10)
Declare @modelno varchar(15)
Declare @firmaAd varchar(25)
Declare @fiyat int
Declare @CPU varchar(30)
Declare @RAM varchar(30)
Declare @Depolama varchar(30)
Declare @GPU varchar (30)
Declare @OS varchar(20)
Declare @stokadeti int

select @pcid=pcid From deleted
select @modelno=modelno From deleted
select @firmaAd=firmaAd From deleted
select @fiyat=fiyat From deleted
select @CPU=CPU from deleted
select @RAM=RAM From deleted
select @Depolama=Depolama From deleted
select @GPU=GPU From deleted
select @OS=OS From deleted
select @stokadeti=stokadeti From deleted
insert into Silinenbilgisayar values(@pcid,@modelno,@firmaAd,@fiyat,@CPU,@RAM,@Depolama,@GPU,@OS,@stokadeti)
End