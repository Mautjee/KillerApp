Alter TRIGGER [dbo].[updateSaldo] ON [dbo].[Table_Activiteit] 
FOR INSERT
AS
begin

	-- Declareer alle variablen
	declare @bedrag int;

	-- vul alle variablen		
	select @bedrag = i.Bedrag from inserted i;	

	 -- update tabel met niewe waarden
	Update Table_Tegoed 
	Set Saldo = saldo + @bedrag
	Where StudenthuisID = (select i.StudentenhuisID from inserted i)
	And GebruikerID = (select i.GebruikerID from inserted i);
	print 'Saldo updated'
	end

GO