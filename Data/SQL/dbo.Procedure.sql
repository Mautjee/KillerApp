/****** Object:  StoredProcedure [dbo].[StudentenhuisbewonerEnSaldo]    Script Date: 5/28/2018 1:05:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[StudentenhuisbewonerEnSaldo]
	@gebrID int
AS
begin
	DECLARE @studID INT
	SELECT @studID = ga.StudenthuisID FROM [Table_Gebruiker_Activiteit] ga 
							WHERE ga.GebruikerID = @gebrID and ga.[Out] is NULL;

 SELECT s.NaamHuis, t.Saldo FROM dbo.Table_Tegoed t Right JOIN dbo.Table_Studentenhuis s 
 ON t.StudenthuisID = s.StudentenhuisID 
 WHERE t.StudenthuisID = @studID AND t.GebruikerID = @gebrID;
end
