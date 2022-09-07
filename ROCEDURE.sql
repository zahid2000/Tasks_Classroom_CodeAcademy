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