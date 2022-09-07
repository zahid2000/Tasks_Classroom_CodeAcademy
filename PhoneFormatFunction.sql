
--Phone Format Function
CREATE FUNCTION PhoneFormat(@VALUE AS NVARCHAR(20)) RETURNS NVARCHAR(MAX) AS
BEGIN
    DECLARE @LEN AS BIGINT
    DECLARE @RESULT AS NVARCHAR(MAX)
	SET @RESULT = ''

	SET @VALUE = LTRIM(RTRIM(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(@VALUE,'-',''),'\r\n',' '),'\r',' '),'\n',' '),CHAR(13),' '), CHAR(10), ' '), CHAR(9),' '),CHAR(13)+CHAR(10),' ')))
    
	IF ISNUMERIC(@VALUE)=1
		BEGIN
			SET @LEN = LEN(@VALUE)

			IF @LEN > 0
				BEGIN
	
					IF @LEN <10
						BEGIN
							SET @RESULT = @RESULT+'Er: Mob.Phone can''t Less than 10 Digits; '
						END

					ELSE IF @LEN >13
						BEGIN
							SET @RESULT = @RESULT+'Er: Mob.Phone can''t More than 13 Digits; '
						END

					
					IF LEFT(CAST(@VALUE AS VARCHAR), 1)='0' AND @LEN=10
						BEGIN
							SET @RESULT = @RESULT+'Er: Mob.Phone can''t Start with 0 -> '+@VALUE
						END
					ELSE IF LEFT(CAST(@VALUE AS VARCHAR), 1)!='0' AND @LEN=11
						BEGIN
							SET @RESULT = @RESULT+'Er: Mob.Phone must be Start with 0 -> '+@VALUE
						END
					ELSE IF LEFT(CAST(@VALUE AS VARCHAR), 2)!='90' AND @LEN=12
						BEGIN
							SET @RESULT = @RESULT+'Er: Mob.Phone must be Start with 90 -> '+@VALUE
						END
					ELSE IF LEFT(CAST(@VALUE AS VARCHAR), 3)!='+90' AND @LEN=13
					BEGIN
						SET @RESULT = @RESULT+'Er: Mob.Phone must be Start with +90  -> '+@VALUE
					END
				END
			ELSE
				BEGIN
					SET @RESULT = @RESULT+'Er: Mob.Phone can''t  0 | NULL; '
				END

		END
	ELSE
		BEGIN
			SET @RESULT = @RESULT+'Er: This is not a valid Mob.Phone; '
		END
	
	IF @RESULT=''
		BEGIN
			IF @LEN=10
				BEGIN
					SET @RESULT='+90'+@VALUE
				END
			ELSE IF @LEN=11
				BEGIN
					SET @RESULT='+9'+@VALUE
				END
			ELSE IF @LEN=12
				BEGIN
					SET @RESULT='+'+@VALUE
				END
			ELSE IF @LEN=13
				BEGIN
					SET @RESULT=@VALUE
				END					
		END		
RETURN dbo.CorrectPhoneFormat(@RESULT)	
END
GO
--Phone Correct Function
CREATE FUNCTION CorrectPhoneFormat(@VALUE NVARCHAR(MAX)) RETURNS NVARCHAR(MAX) AS
	BEGIN
	DECLARE @RESULT NVARCHAR(MAX)
	IF ISNUMERIC(@VALUE)=1
		BEGIN			
			SET @RESULT=SUBSTRING(@VALUE,1,3)+' ('+SUBSTRING(@VALUE,4,3)+') '+SUBSTRING(@VALUE,7,3)+' '+SUBSTRING(@VALUE,10,2)+' '+SUBSTRING(@VALUE,12,2)
		END
	ELSE
	SET @RESULT=@VALUE
RETURN @RESULT
END
GO



SELECT dbo.PhoneFormat( '+905323521245' ) 
SELECT dbo.PhoneFormat( '905321234578' ) 
SELECT dbo.PhoneFormat( '05321234578' ) 
SELECT dbo.PhoneFormat('5321234578' ) 

 
  
--Insert Trigger

create Trigger InsertShipper on Shippers
 instead of insert
 as
 begin
 Declare @CompanyName nvarchar(40)=(select CompanyName from inserted)
 Declare @Phone nvarchar(24)=(select Phone from inserted)

	 insert into Shippers(CompanyName,Phone) values( @CompanyName,dbo.PhoneFormat(@Phone))

 end
 go


 insert into Shippers values ('Code Academy1','+905321234578')
 insert into Shippers values ('Code Academy2','905321234578')
 insert into Shippers values ('Code Academy3','05321234578')
 insert into Shippers values ('Code Academy4','5321234578')
 select * from Shippers