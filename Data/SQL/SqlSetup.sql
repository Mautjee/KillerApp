INSERT INTO Table_Gebruiker VALUES ('2','Johnnie','Geheim','John','Doe','1990-05-12',0635248735,'man','john@doe.com'),
('3','JaneDoe','Geheim','Jane','Doe','1995-07-21',0673526374,'vrouw','jane@doe.com'),('4','Saladje','Geheim','Johma','Oet Twente','1996-08-15',0625372539,'Vrouw','saladje@johma.com')

USE [Mauro_SQL];
Select * FROM Table_Gebruiker

alter table Table_Gebruiker add Geslacht int

alter table Table_Gebruiker drop column Geslacht

INSERT INTO Table_Gebruiker(Geslacht) VALUES (1);