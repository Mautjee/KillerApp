/****** Object:  Trigger [dbo].[updateSaldo]    Script Date: 6/1/2018 12:56:05 PM ******/
Use [mauro_sql]
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER TRIGGER [dbo].[updateSaldo] ON [dbo].[Table_Activiteit] 
FOR INSERT
AS
begin

	-- Declareer alle variablen
	declare @gebruikerID int;
	declare @studentenhuisID int;
	declare @bedrag int;
	declare @oudbedrag int;
	declare @niewsaldo int;

	-- vul alle variablen
	select @gebruikerID=i.GebruikerID from inserted i;	
	select @studentenhuisID=i.StudentenhuisID from inserted i;	
	select @bedrag=i.Bedrag from inserted i;	
	
	select @oudbedrag = Saldo From [dbo].Table_Tegoed t Where t.StudenthuisID = @studentenhuisID
	 And t.GebruikerID = @gebruikerID;
	 
	 -- Maak het niewe saldo
	 
	 Select @niewsaldo = @oudbedrag + @bedrag

	 -- update tabel met niewe waarden
	Update Table_Tegoed 
	Set Saldo = @niewsaldo
	Where StudenthuisID = @studentenhuisID And GebruikerID = @gebruikerID;

	end

