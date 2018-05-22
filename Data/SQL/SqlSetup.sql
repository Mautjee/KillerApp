INSERT INTO Table_Gebruiker VALUES (NewID(),'Johnnie','Geheim','John','Doe','1990-05-12',0635248735,'man','john@doe.com'),
('3','JaneDoe','Geheim','Jane','Doe','1995-07-21',0673526374,'vrouw','jane@doe.com'),('4','Saladje','Geheim','Johma','Oet Twente','1996-08-15',0625372539,'Vrouw','saladje@johma.com')

USE [Mauro_SQL];
Select * FROM Table_Gebruiker

alter table Table_Gebruiker add Geslacht int

alter table Table_Gebruiker drop column Geslacht

INSERT INTO Table_Gebruiker(Geslacht) VALUES (1);

Select * FROM Table_Gebruiker WHERE GebruikerID = 1;

INSERT INTO Table_Gebruiker(Gebruikersnaam,Wachtwoord,Voornaam,Achternaam,Geboortedatum,MobielNummer,MailAdress,StudentenHuis,Geslacht)
Values ('Bakje','Geheim','Bak','Doosje','1995-07-21',0623736402,'jane@doe.com',0,1);

UPDATE Table_Gebruiker SET Gebruikersnaam = 'Muatjee'  WHERE GebruikerID = 1;

alter table Table_Studentenhuis add NaamHuis nvarchar(150);
alter table Table_Studentenhuis drop column [NaamStudentenhuis];

Select * FROM Table_Studentenhuis

UPDATE Table_Studentenhuis SET StudentenhuisID = 990 WHERE StudentenhuisID = 0;

INSERT INTO Table_Studentenhuis(StudentenhuisID,NaamHuis) VALUES (0,'GeenHuis')
INsert INTO Table_Studentenhuis(StudentenhuisID,NaamHuis) ValUES (2,'Alfa Huis')

Update Table_Gebruiker Set StudentenhuisID = 0 Where GebruikerID = 8;

Select * FROM Table_Gebruiker Where StudentenhuisID = 1;



UPDATE Table_Studentenhuis SET NaamHuis = 'Broodjes Huis'  WHERE StudentenhuisID = 3;

select Count(StudentenhuisID) From Table_Studentenhuis

Select NaamHuis FROM Table_Studentenhuis 

Select COUNT(GebruikerID) From Table_Gebruiker Where StudentenhuisID = 1

Select * From Table_Gebruiker Where Gebruikersnaam = 'mautjee' And Wachtwoord = '';

CREATE TABLE [dbo].[Table_Gebruiker_Activiteit] (
    [GebruikerID]   INT NOT NULL,
    [StudenthuisID] INT NOT NULL,
    [In]            DATE NOT NULL,
    [Out]           DATE,
    PRIMARY KEY CLUSTERED ([GebruikerID] ASC, [StudenthuisID] ASC),
    FOREIGN KEY ([StudenthuisID]) REFERENCES [dbo].[Table_Studentenhuis] ([StudentenhuisID]),
    FOREIGN KEY ([GebruikerID]) REFERENCES [dbo].[Table_Gebruiker] ([GebruikerID])
);

Select s.NaamHuis From [Table_Studentenhuis] s, [Table_Gebruiker_Activiteit] ga WHERE s.StudentenhuisID = ga.StudenthuisID AND s.StudentenhuisID = 1 And ga.[Out] is NULL;

