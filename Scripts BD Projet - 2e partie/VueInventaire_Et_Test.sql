USE P2014_BD_GestionHotel
GO

--INSERT INTO Approvisionnement.tblFourniture VALUES('ZZZ','FOURNITURETEST',NULL,'AUT');

--INSERT INTO Approvisionnement.tblFournitureHotel VALUES('HMR','ZZZ',10,100,10);
--INSERT INTO Approvisionnement.tblFournitureFournisseur VALUES('ZZZ','101',100);
--INSERT INTO Approvisionnement.tblFournitureCommande VALUES(1001,'ZZZ',5);

--SELECT *
--FROM Approvisionnement.tblFourniture

--SELECT *
--FROM Approvisionnement.tblFournitureHotel

--SELECT *
--FROM Approvisionnement.tblFournitureFournisseur

--SELECT *
--FROM Approvisionnement.VueInventaire


--DELETE FROM Approvisionnement.tblFourniture
--WHERE NoSeqFourniture = 'ZZZ'

CREATE PROC Reservation.VerificationDispo(@DateDebut date, @DateFin date)
AS
SELECT *
FROM Reservation.tblChambre
WHERE NoSeqChambre NOT IN (SELECT CRC.NoSeqChambre
							FROM Reservation.tblChambreReservationChambre AS CRC
							WHERE ((DateDebutReservation BETWEEN @DateDebut AND @DateFin)
								OR (DateFinReservation BETWEEN @DateDebut AND @DateFin)) 
								OR ((@DateDebut BETWEEN DateDebutReservation AND DateFinReservation) 
								OR (@DateFin BETWEEN DateDebutReservation AND DateFinReservation))
						   )
GO


CREATE TRIGGER TestSupprimerFourniture 
ON Approvisionnement.tblFourniture
INSTEAD OF DELETE
AS
BEGIN

DECLARE @NoSeqFourniture varchar(10)

SELECT @NoSeqFourniture = NoSeqFourniture
FROM deleted

DELETE FROM Approvisionnement.tblFournitureCommande
WHERE NoSeqFourniture = @NoSeqFourniture

DELETE FROM Approvisionnement.tblFournitureFournisseur
WHERE NoSeqFourniture = @NoSeqFourniture

DELETE FROM Approvisionnement.tblFournitureHotel
WHERE NoSeqFourniture = @NoSeqFourniture

DELETE FROM Approvisionnement.tblFourniture
WHERE NoSeqFourniture = @NoSeqFourniture

END
GO


CREATE VIEW Approvisionnement.VueInventaire AS
SELECT FH.CodeHotel, F.NoSeqFourniture, CodeFourniture, DescFourniture, F.CodeCategorie, NomCategorie, QuantiteFournitureHotel, PrixFournitureFournisseur , QuantiteMin, QuantiteMax , Four.CodeFournisseur, NomFournisseur
FROM Approvisionnement.tblFourniture AS F
JOIN Approvisionnement.tblFournitureHotel AS FH
	ON F.NoSeqFourniture = FH.NoSeqFourniture
JOIN Approvisionnement.tblFournitureFournisseur AS FF
	ON F.NoSeqFourniture = FF.NoSeqFourniture
JOIN Approvisionnement.tblFournisseur AS Four
	ON FF.CodeFournisseur = Four.CodeFournisseur
JOIN Approvisionnement.tblCategorieFourniture AS CF
	ON F.CodeCategorie = CF.CodeCategorie


--SELECT *
--FROM Approvisionnement.VueInventaire
--ORDER BY NoSeqFourniture

--DROP VIEW Approvisionnement.VueInventaire