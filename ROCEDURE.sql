-- Tablo Adı = " Country ", Parametreler = Id, CountryName,Code
-- Tablo Adı = " City",     Parametreler = Id, CityName, CountryId,Code
-- Tablo Adı = " District", Parametreler = Id, DistrictName, CountryId, CityId,Code
-- Tablo Adı = " Town",     Parametreler = Id, TownName, CountryId, CityId, DistrictId,code
create database Countries
use Countries
create table Country
(
	Id int  Primary key not null Identity(1,1),
	CountryName nvarchar(40) not null,
	Code nvarchar(20) 
)
create table City
(
	Id int  Primary key not null Identity(1,1),
	CityName nvarchar(40) not null,
	Code nvarchar(20) ,
	CountryId int foreign key  (Id) references Country(Id) not null
)
create table District
(
	Id int  Primary key not null Identity(1,1),
	DistrictName nvarchar(40) not null,
	Code nvarchar(20) ,
	CountryId int foreign key  (Id) references Country(Id) not null,
	CityId int foreign key  (Id) references City(Id) not null
)
create table Town
(
	Id int  Primary key not null Identity(1,1),
	TownName nvarchar(40) not null,
	Code nvarchar(20) ,
	CountryId int foreign key  (Id) references Country(Id) not null,
	CityId int foreign key  (Id) references City(Id) not null,
	DistrictId int foreign key  (Id) references District(Id) not null
)


Create procedure CheckCountries @CountryName nvarchar(40),@CityName nvarchar(40),@DistrictName nvarchar(40),@TownName nvarchar(40)
as
begin
 

	Declare @CountryId int,@CityId int,@DistrictId int,@TownId int,@CountryCount int,@CityCount int,@DistrictCount int,@TownCount int

	set @CountryCount=(select Count(*) from Country where CountryName=@CountryName)
	if @CountryCount=0
		begin 
			Print('Country is not found')
			insert into Country(CountryName) values(@CountryName)
			set @CountryId=(select Id from Country where CountryName=@CountryName)
		end
	Else
		set @CountryId=(select Id from Country where CountryName=@CountryName)

	set @CityCount=(select Count(*) from City where Exists(select CountryName from Country where Id=@CountryId) and CityName=@CityName) 
	if @CityCount=0
		begin 
			Print('City is not found')
			insert into City(CityName,CountryId) values(@CityName,@CountryId)
			set @CityId=(select Id from City where CityName=@CityName)
		end
	Else
		set @CityId=(select Id from City where CityName=@CityName)

	set @DistrictCount=(select Count(*) from District where Exists(select Id from City where Id=@CityId) and DistrictName=@DistrictName) 
	if @DistrictCount=0
		begin 
			Print('District is not found')
			insert into District(DistrictName,CityId,CountryId) values(@DistrictName,@CityId,@CountryId)
			set @DistrictId=(select Id from District where DistrictName=@DistrictName)
		end
	Else
		set @DistrictId=(select Id from District where DistrictName=@DistrictName)

	set @TownCount=(select Count(*) from Town where Exists(select Id from District where Id=@DistrictId) and TownName=@TownName) 
	if @TownCount=0
		begin 
			Print('Town is not found')
			insert into Town(TownName,DistrictId,CityId,CountryId) values(@TownName,@DistrictId,@CityId,@CountryId)
			set @TownId=(select Id from Town where TownName=@TownName)
		end
	Else
		set @TownId=(select Id from Town where TownName=@TownName)
	
		Select * from Country cn  left join City cy on cy.CountryId=cn.Id left join District dt on dt.CityId=cy.Id
		and dt.CountryId=cn.Id left join Town tn on tn.CityId=cy.id and tn.CountryId=cn.Id and tn.DistrictId=dt.Id where cn.Id=@CountryId and cy.Id=@CityId and dt.Id=@DistrictId and tn.Id=@TownId
	end
go

exec CheckCountries @CountryName=N'Azerbaycan',@CityName=N'Baki',@DistrictName=N'Nizami',@TownName=N'28 May'
