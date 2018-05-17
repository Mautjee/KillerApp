CREATE PROCEDURE [dbo].[StudentenhuisEnBewoners]
	@param1 varchar(50),
	@StudentenhuisID int
	
AS
	If Object_Id('Tempdb..#temp') Is Not Null
		Drop Table #temp1
		create table #temp(NaamHuis varchar(255),AantalBewoners int)




	DECLARE @lastId INT
	SELECT @lastId = Count(StudentenhuisID) From Table_Studentenhuis

	declare @i int
	set @i = 0

	

WHILE(@i <= (@lastId))
		BEGIN
			
			Declare @Studenthuinaam varchar(255)
			set @Studenthuinaam = NaamHuis FROM Table_Studentenhuis WHERE StudentenhuisID = @i
			
			declare @Aantalbewoners int 
			Set @Aantalbewoners = COUNT(GebruikerID) From Table_Gebruiker Where StudentenhuisID = @i
			
			INSERT INTO #temp1
			VALUES(@Studenthuinaam, @Aantalbewoners)
			
			SET @i = @i + 1
		END
		
RETURN 0