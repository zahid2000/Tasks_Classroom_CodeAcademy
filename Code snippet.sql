Alter function CheckBirthDay(@Age int,@OldDate date) Returns nvarchar(Max)

as
	begin
		Declare	@NowDate date=GetDate()
		Declare	@NowYear int=(Select YEAR(@NowDate) as Year)
		Declare	@NowMonth int=(Select MONTH(@NowDate) as MONTH)
		Declare	@NowDay int=(Select Day(@NowDate) as Day)
		
		Declare	@OldYear int=(Select YEAR(@OldDate) as Year)
		Declare @OldMonth int=(Select MONTH(@OldDate) as MONTH)
		Declare @OldDay int=(Select Day(@OldDate) as Day)

		Declare @ResultYear int =@NowYear-@OldYear
	
																																		--09-08-2022<-->01-08-2022
		If @Age<@ResultYear
			return N'Sizin artıq' +Cast(@Age as nvarchar)+N' yaşınız bitib'  
		Else If @Age=@ResultYear			
			Begin		
				If @NowMonth>@OldMonth
					return N'Sizin artıq' +Cast(@Age as nvarchar)+N' yaşınız bitib'  
				Else If @NowMonth=@OldMonth
					Begin
						If @NowDay>@OldDay
							return N'Sizin artıq' +Cast(@Age as nvarchar)+N' yaşınız bitib'  
						Else If @NowDay=@OldDay
							Begin
								return N'Təbriklər bugün sizin ad gününüzdür!'
							End
						Else
							Begin
								return N'Sizin ' +Cast(@Age as nvarchar)+N'  yaşınız bitməyə '+Cast((@OldDay-@NowDay) as nvarchar) +N' gün qalıb'
							End
					End
				Else
					Begin
						If @NowDay<@OldDay
							return  N'Sizin ' +Cast(@Age as nvarchar)+N'  yaşınız bitməyə '+Cast((@OldMonth-@NowMonth) as nvarchar) +N' ay '+Cast((@OldDay-@NowDay) as nvarchar) +N' gün qalıb'
						Else If @NowDay=@OldDay
							Begin
								return  N'Sizin ' +Cast(@Age as nvarchar)+N'  yaşınız bitməyə '+Cast((@OldMonth-@NowMonth) as nvarchar) +N' ay qalıb'
							End
						Else
							Begin
								return  N'Sizin ' +Cast(@Age as nvarchar)+N'  yaşınız bitməyə '+Cast((@OldMonth-@NowMonth-1) as nvarchar) +N' ay '+Cast(((@OldDay+dbo.GetMonthDays(@OldMonth-@NowMonth))) -@NowDay as nvarchar) +N' gün qalıb'
							End
					End					
			End
		Else
			Begin
				return @ResultYear
			End


		return @OldYear
	end
	
go

Alter function GetMonthDays(@MonthNum int) returns int
as
	Begin
		Return	CASE 
			WHEN @MonthNum IN(1,3,5,7,8,10,12) THEN  31
			WHEN @MonthNum IN(4,6,9,11) THEN  30
			WHEN @MonthNum=2 THEN  28
		ELSE  31
		END;
	End
go

select dbo.CheckBirthday(18,'09/08/2004')

--