USE  P2014_BD_GestionHotel
GO

/******************** Personnel **************************/

CREATE TABLE Personnel.tblEmploye
(
	NoEmploye			int				NOT NULL	IDENTITY(1000,1),
	NomEmploye			varchar(20)		NOT NULL,
	PrenomEmploye		varchar(20)		NOT NULL,
	SexeEmploye			char(1)			NOT NULL,
	AdresseEmploye		varchar(30)		NOT NULL,
	TypeEmploi			varchar(15)		NULL,
	NoTelephoneEmploye	varchar(14)		NOT NULL,
	NasEmploye			char(11)		NOT NULL,
	DateNaissance		date			NOT NULL,
	IdentifiantEmploye	char(8)			NULL,
	MdpEmploye			char(8)			NULL,
	NombreHeuresSemaines smallint		NULL,
	CodeHotel			char(3)			NULL
)


CREATE TABLE Personnel.tblChiffreTravail
(
	NoChiffreTravail		int				NOT NULL	IDENTITY(1000,1),
	DateChiffre				date			NOT NULL,
	HeureDebut				char(5)			NOT NULL,
	HeureFin				char(5)			NOT NULL,
	NoEmploye				int				NOT NULL
)


CREATE TABLE Personnel.tblEntretienFournitureChambre
(
	NoSeqEntretienChambre	int				NOT NULL	IDENTITY(1000,1),
	EtatFourniture			varchar(15)		NOT NULL,
	CommentaireFourniture	varchar(300)	NULL,
	DateDemande				date			NOT NULL,
	DateEffectue			date			NULL,
	StatutEntretien			varchar(20)		NULL,
	CodeFourniture			varchar(10)		NOT NULL,
	NoSeqChambre			int				NOT NULL,
	NoEmploye				int				NOT NULL
)


CREATE TABLE Personnel.tblEntretienFournitureSalle
(
	NoSeqEntretienSalle		int				NOT NULL	IDENTITY(1000,1),
	EtatFourniture			varchar(15)		NOT NULL,
	CommentaireFourniture	varchar(300)	NULL,
	DateDemande				date			NOT NULL,
	DateEffectue			date			NULL,
	StatutEntretien			varchar(20)		NULL,
	NoSeqReservSalle		int				NOT NULL,
	CodeFourniture			varchar(10)		NOT NULL,
	CodeSalle				char(3)			NOT NULL,
	NoEmploye				int				NOT NULL
)



/******************** Approvisionnement **************************/

CREATE TABLE Approvisionnement.tblCommande
(
	NoCommande		int				NOT NULL	IDENTITY(1000,1),
	DateCommande	date			NOT NULL,
	StatutCommande	varchar(10)		NOT NULL,
	PrixTotal		money			NULL,
	DateRecu		date			NULL,
	CodeFournisseur	varchar(10)		NOT NULL,
	NoEmploye		int				NOT NULL,
)


CREATE TABLE Approvisionnement.tblFournisseur
(
	CodeFournisseur		varchar(10)		NOT NULL,
	NomFournisseur		varchar(20)		NOT NULL,
	AdresseFournisseur	varchar(40)		NOT NULL,
	NomRepresentant		varchar(20)		NOT NULL,
	PrenomRepresentant	varchar(20)		NOT NULL
)


CREATE TABLE Approvisionnement.tblFournitureFournisseur
(
	CodeFourniture				varchar(10)		NOT NULL,
	CodeFournisseur				varchar(10)		NOT NULL,
	PrixFournitureFournisseur	money			NOT NULL
)


CREATE TABLE Approvisionnement.tblFourniture
(
	CodeFourniture		varchar(10)		NOT NULL,
	DescFourniture		varchar(50)		NOT NULL,
	CodeCategorie		char(3)			NOT NULL
)


CREATE TABLE Approvisionnement.tblCategorieFourniture
(
	CodeCategorie		char(3)			NOT NULL,
	NomCategorie		varchar(20)		NOT NULL,
)


CREATE TABLE Approvisionnement.tblFournitureCommande
(
	NoCommande			int			NOT NULL,
	CodeFourniture		varchar(10)	NOT NULL,
	QuantiteCommande	int			NOT NULL
)


CREATE TABLE Approvisionnement.tblFournitureHotel
(
	CodeHotel				char(3)			NOT NULL,
	CodeFourniture			varchar(10)		NOT NULL,
	QuantiteMin				smallint		NOT NULL,
	QuantiteMax				int				NOT NULL,
	QuantiteFournitureHotel	int				NULL
)


CREATE TABLE Approvisionnement.tblFournitureChambre
(
	NoSeqChambre		int				NOT NULL,
	CodeFourniture		varchar(10)		NOT NULL,
	QuantiteChambre		smallint		NOT NULL
)



/******************** Reservation **************************/

CREATE TABLE Reservation.tblPays
(
	CodePays	char(3)		NOT NULL,
	NomPays		varchar(50)	NOT NULL
)


CREATE TABLE Reservation.tblProvince
(
	CodeProvince	char(3)		NOT NULL,
	NomProvince		varchar(50)	NOT NULL,
	CodePays		char(3)		NOT NULL
)


CREATE TABLE Reservation.tblVille
(
	CodeVille		char(3)		NOT NULL,
	NomVille		varchar(50)	NOT NULL,
	CodeProvince	char(3)		NOT NULL
)


CREATE TABLE Reservation.tblHotel
(
	CodeHotel			char(3)			NOT NULL,
	NomHotel			varchar(80)		NOT NULL,
	NbChambre			smallint		NOT NULL,
	AdresseHotel		varchar(50)		NOT NULL,
	NbEtoiles			tinyint			NOT NULL,
	TypeService			varchar(50)		NOT NULL,
	CodePostal			char(6)			NOT NULL,
	NoTelephoneHotel	varchar(14)		NOT NULL,
	NoTelecopieurHotel	varchar(14)		NOT NULL,
	NoTelReservation	char(14)		NOT NULL,
	HeureLimiteDepart	char(3)			NOT NULL,
	HeureLimiteArrive	char(3)			NOT NULL,		
	CodeVille			char(3)			NOT NULL
)


CREATE TABLE Reservation.tblSalle
(
	CodeSalle		char(3)		NOT NULL,
	NomSalle		varchar(30)	NOT NULL,
	TypeSalle		varchar(20)	NOT NULL,
	StatutSalle		varchar(15)	NULL,
	DetailSalle		text		NOT NULL,
	NbPlacesAssis	smallint	NOT NULL,
	NbPlacesDebout	smallint	NOT NULL,
	CodeHotel		char(3)		NOT NULL
)


CREATE TABLE Reservation.tblReservationSalle
(
	NoSeqReservSalle	int			NOT NULL	IDENTITY(1000,1),
	DateReservSalle		date		NOT NULL,
	PrixReservSalle		money		NULL,
	ModePaiement		varchar(20)	NOT NULL,
	StatutPaiement		varchar(10)	NULL,
	NbPersonne			smallint	NULL,
	NoCarteCredit		varchar(16)	NULL,
	CodeSalle			char(3)		NOT NULL,
	NoSeqClient			int			NOT NULL
)


CREATE TABLE Reservation.tblChambre
(
	NoSeqChambre	int			NOT NULL	IDENTITY(1000,1),
	CodeChambre		char(4)		NOT NULL,
	EtageChambre	smallint	NOT NULL,
	StatutChambre	varchar(15)	NULL,
	DescChambre		text		NULL,
	TypeLit			varchar(30)	NOT NULL,
	NbLit			tinyint		NOT NULL,
	CodeHotel		char(3)		NOT NULL,	
	CodeTypeChambre	char(3)		NOT NULL	
)


CREATE TABLE Reservation.tblChambreReservationChambre
(
	NoSeqChambre				int			NOT NULL,
	NoSeqReservChambre			int			NOT NULL,
	NbPersonne					smallint	NOT NULL,
	NomLocataire				varchar(20)	NOT NULL,
	PrenomLocataire				varchar(20)	NOT NULL,
	DateDebutReservation		date		NOT NULL,
	DateFinReservation			date		NOT NULL,
	StatutChambreReservChambre	varchar(15)	NOT NULL
)


CREATE TABLE Reservation.tblReservationChambre
(
	NoSeqReservChambre			int			NOT NULL	IDENTITY(1000,1),
	StatutReservChambre			varchar(15)	NOT NULL,
	PrixReservChambre			money		NULL,
	ModePaiement				varchar(20)	NOT NULL,
	StatutPaiement				varchar(10)	NULL,
	NoCarteCredit				varchar(16)	NULL,
	DateExpirationCarteCredit	char(4)		NULL,
	TypeCarteCredit				varchar(20)	NULL,
	NomCarteCredit				varchar(40)	NULL,				
	NoSeqClient					int			NOT NULL,
	NoSeqRabais					int			NULL
)


CREATE TABLE Reservation.tblRabais
(
	NoSeqRabais			int			NOT NULL	IDENTITY(1000,1),
	DescRabais			varchar(50)	NOT NULL,
	DateDebutRabais		date		NOT NULL,
	DateFinRabais		date		NOT NULL,
	PourcentageRabais	smallint	NOT NULL
)


CREATE TABLE Reservation.tblClient
(
	NoSeqClient				int			NOT NULL	IDENTITY(1000,1),	
	NomClient				varchar(20)	NOT NULL,
	PrenomClient			varchar(20)	NOT NULL,
	NoTelephone				varchar(14)	NOT NULL,
	NoCellulaire			varchar(14)	NULL,
	AdresseClient			varchar(30)	NOT NULL,
	AdresseSecondaireClient	varchar(30)	NULL,
	EmailClient				varchar(30)	NOT NULL,
	CodePostal				char(6)		NULL,
	NomEntreprise			varchar(50)	NULL,
	CodeVille				char(3)		NULL	
)


CREATE TABLE Reservation.tblFacture
(
	NoSeqFacture		int			NOT NULL	IDENTITY(1000,1),
	MontantFacture		money		NULL,
	TypeFacture			varchar(10)	NOT NULL,
	NoSeqReservChambre	int			NOT NULL,
	NoEmploye			int			NOT NULL
)


CREATE TABLE Reservation.tblTypeChambre
(
	CodeTypeChambre		char(3)			NOT NULL,
	NomTypeChambre		varchar(20)		NOT NULL,
	DescTypeChambre		varchar(200)	NOT NULL
)


CREATE TABLE Reservation.tblForfait
(
	CodeForfait		varchar(10)		NOT NULL,
	NomForfait		varchar(30)		NOT NULL,
	PrixForfait		money			NOT NULL,
	DescForfait		text			NOT NULL,
	NbNuit			tinyint			NOT NULL,
	DateDebut		date			NOT NULL,
	DateFin			date			NOT NULL,
	CodeTypeChambre	char(3)			NOT NULL
)


CREATE TABLE Reservation.tblPrixTypeChambre
(
	NoSeqPrixTypeChambre	int				NOT NULL	IDENTITY(1000,1),
	DescPrixTypeChambre		varchar(200)	NOT NULL,
	PrixTypeChambre			money			NOT NULL,
	DateDebutPrix			date			NOT NULL,
	DateFinPrix				date			NOT NULL,
	CodeTypeChambre			char(3)			NOT NULL,
	CodeHotel				char(3)			NOT NULL
)


CREATE TABLE Reservation.tblForfaitReservationChambre
(
	NoSeqChambre		int			NOT NULL,
	NoSeqReservChambre	int			NOT NULL,
	CodeForfait			varchar(10)	NOT NULL	
)


CREATE TABLE Reservation.tblFournitureReservationSalle
(
	NoSeqReservSalle		int			NOT NULL,
	CodeFourniture			varchar(10)	NOT NULL,
	CodeSalle				char(3)		NOT NULL,
	QuantiteFourniture		smallint	NOT NULL
)