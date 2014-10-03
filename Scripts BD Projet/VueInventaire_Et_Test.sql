USE P2014_BDTestFrancois
GO

INSERT INTO Approvisionnement.tblFourniture VALUES('ZZZ','FOURNITURETEST',NULL,'AUT');

INSERT INTO Approvisionnement.tblFournitureHotel VALUES('HMR','ZZZ',10,100,10);
INSERT INTO Approvisionnement.tblFournitureFournisseur VALUES('ZZZ','101',100);
INSERT INTO Approvisionnement.tblFournitureCommande VALUES(1001,'ZZZ',5);

SELECT *
FROM Approvisionnement.tblFourniture

SELECT *
FROM Approvisionnement.tblFournitureHotel

SELECT *
FROM Approvisionnement.tblFournitureFournisseur

SELECT *
FROM Approvisionnement.VueInventaire


DELETE FROM Approvisionnement.tblFourniture
WHERE CodeFourniture = 'ZZZ'


CREATE TRIGGER TestSupprimerFourniture 
ON Approvisionnement.tblFourniture
INSTEAD OF DELETE
AS
BEGIN

DECLARE @CodeFourniture varchar(10)

SELECT @CodeFourniture = CodeFourniture
FROM deleted

DELETE FROM Approvisionnement.tblFournitureCommande
WHERE CodeFourniture = @CodeFourniture

DELETE FROM Approvisionnement.tblFournitureFournisseur
WHERE CodeFourniture = @CodeFourniture

DELETE FROM Approvisionnement.tblFournitureHotel
WHERE CodeFourniture = @CodeFourniture

DELETE FROM Approvisionnement.tblFourniture
WHERE CodeFourniture = @CodeFourniture

END
GO


CREATE VIEW Approvisionnement.VueInventaire AS
SELECT FH.CodeHotel, F.CodeFourniture, DescFourniture, F.CodeCategorie, NomCategorie, QuantiteFournitureHotel, PrixFournitureFournisseur , QuantiteMin, QuantiteMax , Four.CodeFournisseur, NomFournisseur
FROM Approvisionnement.tblFourniture AS F
JOIN Approvisionnement.tblFournitureHotel AS FH
	ON F.CodeFourniture = FH.CodeFourniture
JOIN Approvisionnement.tblFournitureFournisseur AS FF
	ON F.CodeFourniture = FF.CodeFourniture
JOIN Approvisionnement.tblFournisseur AS Four
	ON FF.CodeFournisseur = Four.CodeFournisseur
JOIN Approvisionnement.tblCategorieFourniture AS CF
	ON F.CodeCategorie = CF.CodeCategorie


SELECT *
FROM Approvisionnement.VueInventaire
ORDER BY CodeFourniture

DROP VIEW Approvisionnement.VueInventaire