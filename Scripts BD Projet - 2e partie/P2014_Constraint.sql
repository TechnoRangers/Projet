USE P2014_BD_GestionHotel
GO

/**************************************** Primary key Personnel ****************************************/ 
ALTER TABLE Personnel.tblEmploye ADD CONSTRAINT PK_Emp_NoEmp PRIMARY KEY(NoEmploye)
ALTER TABLE Personnel.tblChiffreTravail ADD CONSTRAINT PK_ChHo_NoChHo PRIMARY KEY(NoChiffreTravail)
ALTER TABLE Personnel.tblEntretienFourniture ADD CONSTRAINT PK_EmpFour_NoSeqFourNoEmp PRIMARY KEY(CodeFourniture,NoEmploye)
GO


/**************************************** Primary key Approvisionnement ****************************************/ 
ALTER TABLE Approvisionnement.tblCommande ADD CONSTRAINT PK_Com_NoCom PRIMARY KEY(NoCommande)
ALTER TABLE Approvisionnement.tblFournisseur ADD CONSTRAINT PK_Fournisseur_CodeFournisseur PRIMARY KEY(CodeFournisseur)
ALTER TABLE Approvisionnement.tblFournitureCommande ADD CONSTRAINT PK_FourCom_NoComCodeFour PRIMARY KEY(NoCommande,CodeFourniture)
ALTER TABLE Approvisionnement.tblFournitureFournisseur ADD CONSTRAINT PK_FourFour_CodeFourCodeFour PRIMARY KEY(CodeFourniture,CodeFournisseur)
ALTER TABLE Approvisionnement.tblFournitureHotel ADD CONSTRAINT PK_HotFour_CodHotNoSeqFour PRIMARY KEY(CodeHotel,CodeFourniture)
ALTER TABLE Approvisionnement.tblFourniture ADD CONSTRAINT PK_Fourniture_NoSeqFourniture PRIMARY KEY(CodeFourniture)
ALTER TABLE Approvisionnement.tblCategorieFourniture ADD CONSTRAINT PK_CategFour_CodeCateg PRIMARY KEY (CodeCategorie)
GO


/**************************************** Primary key Reservation ****************************************/ 
ALTER TABLE Reservation.tblPays ADD CONSTRAINT PK_Pays_CodPays PRIMARY KEY(CodePays)
ALTER TABLE Reservation.tblProvince ADD CONSTRAINT PK_Prov_CodProv PRIMARY KEY(CodeProvince)
ALTER TABLE Reservation.tblVille ADD CONSTRAINT PK_Vill_CodVill PRIMARY KEY(CodeVille)
ALTER TABLE Reservation.tblEquipementRecreatifHotel ADD CONSTRAINT PK_HoteEqRec_CodEq_CodHot PRIMARY KEY(CodeEquipementRecreatif,CodeHotel)
ALTER TABLE Reservation.tblEquipementRecreatif ADD CONSTRAINT PK_EqRecre_CodeEqRec PRIMARY KEY(CodeEquipementRecreatif)
ALTER TABLE Reservation.tblHotel ADD CONSTRAINT PK_Hot_CodHot PRIMARY KEY(CodeHotel)
ALTER TABLE Reservation.tblSalle ADD CONSTRAINT PK_Salle_CodSalle PRIMARY KEY(CodeSalle)
ALTER TABLE Reservation.tblReservationSalle ADD CONSTRAINT PK_ReservSalle_NoReservSalle PRIMARY KEY(NoSeqReservSalle)
ALTER TABLE Reservation.tblChambre ADD CONSTRAINT PK_Chambre_NoSeqChamb PRIMARY KEY(NoSeqChambre)
ALTER TABLE Reservation.tblReservationChambre ADD CONSTRAINT PK_ReservChamb_NoSeqReservCham PRIMARY KEY(NoSeqReservChambre)
ALTER TABLE Reservation.tblClient ADD CONSTRAINT PK_Cli_NoCli PRIMARY KEY(NoSeqClient)
ALTER TABLE Reservation.tblTypeChambre ADD CONSTRAINT PK_TypChamb_CodTypChamb PRIMARY KEY(CodeTypeChambre)
ALTER TABLE Reservation.tblFacture ADD CONSTRAINT PK_Fact_NoSeqFact PRIMARY KEY(NoSeqFacture)
ALTER TABLE Reservation.tblEquipementGeneriqueTypeChambre ADD CONSTRAINT PK_EqTypChamb_CodTypChamb_CodEqChamb PRIMARY KEY(CodeTypeChambre,CodeEquipementGenChambre)
ALTER TABLE Reservation.tblForfaitTypeChambre ADD CONSTRAINT PK_ForfTypChamb_CodTypChamb_CodForf PRIMARY KEY(CodeTypeChambre,CodeForfait)
ALTER TABLE Reservation.tblEquipementGeneriqueChambre ADD CONSTRAINT PK_EqChamb_CodEqChamb PRIMARY KEY(CodeEquipementGenChambre)
ALTER TABLE Reservation.tblForfait ADD CONSTRAINT PK_Forf_CodForf PRIMARY KEY(CodeForfait)
ALTER TABLE Reservation.tblEquipementRecreatifForfait ADD CONSTRAINT PK_EqRecForf_CodForf_CodEqRec PRIMARY KEY(CodeForfait,CodeEquipementRecreatif)
ALTER TABLE Reservation.tblChambreReservationChambre ADD CONSTRAINT PK_ChambReservChamb_NoChamb_NoReserv PRIMARY KEY (NoSeqChambre,NoSeqReservChambre)
ALTER TABLE Reservation.tblRabais ADD CONSTRAINT PK_Rab_NoSeqRab PRIMARY KEY (NoSeqRabais)
GO



/**************************************** Foreign key Approvisionnement ****************************************/ 
ALTER TABLE Approvisionnement.tblCommande ADD CONSTRAINT FK_Four_Com_NoSeqFour FOREIGN KEY(CodeFournisseur) REFERENCES Approvisionnement.tblFournisseur(CodeFournisseur) 
ALTER TABLE Approvisionnement.tblCommande ADD CONSTRAINT FK_Emp_Com_NoEmp FOREIGN KEY(NoEmploye) REFERENCES Personnel.tblEmploye(NoEmploye) 
ALTER TABLE Approvisionnement.tblFournitureCommande ADD CONSTRAINT FK_Com_FourCom_NoCom FOREIGN KEY(NoCommande) REFERENCES Approvisionnement.tblCommande(NoCommande) 
ALTER TABLE Approvisionnement.tblFournitureCommande ADD CONSTRAINT FK_Four_FourCom_NoSeqFour FOREIGN KEY(CodeFourniture) REFERENCES Approvisionnement.tblFourniture(CodeFourniture) 
ALTER TABLE Approvisionnement.tblFournitureFournisseur ADD CONSTRAINT FK_Four_FourFour_NoSeqFourniture FOREIGN KEY(CodeFourniture) REFERENCES Approvisionnement.tblFourniture(CodeFourniture) 
ALTER TABLE Approvisionnement.tblFournitureFournisseur ADD CONSTRAINT FK_Four_CourCom_NoSeqFournisseur FOREIGN KEY(CodeFournisseur) REFERENCES Approvisionnement.tblFournisseur(CodeFournisseur) 
ALTER TABLE Approvisionnement.tblFournitureHotel ADD CONSTRAINT FK_Hot_FourHot_CodHot FOREIGN KEY(CodeHotel) REFERENCES Reservation.tblHotel(CodeHotel) 
ALTER TABLE Approvisionnement.tblFournitureHotel ADD CONSTRAINT FK_Four_FourHot_NoSeqFour FOREIGN KEY(CodeFourniture) REFERENCES Approvisionnement.tblFourniture(CodeFourniture) 
ALTER TABLE Approvisionnement.tblFourniture ADD CONSTRAINT FK_Four_Categ_CodeCateg FOREIGN KEY(CodeCategorie) REFERENCES Approvisionnement.tblCategorieFourniture(CodeCategorie) 
GO


/**************************************** Foreign key Personnel ****************************************/ 
ALTER TABLE Personnel.tblEmploye ADD CONSTRAINT FK_Hot_Emp_CodHot FOREIGN KEY(CodeHotel) REFERENCES Reservation.tblHotel(CodeHotel) 
ALTER TABLE Personnel.tblChiffreTravail ADD CONSTRAINT FK_Emp_ChifHor_NoEmp FOREIGN KEY(NoEmploye) REFERENCES Personnel.tblEmploye(NoEmploye) 
ALTER TABLE Personnel.tblEntretienFourniture ADD CONSTRAINT FK_Four_EntFour_NoSeqFour FOREIGN KEY(CodeFourniture) REFERENCES Approvisionnement.tblFourniture(CodeFourniture) 
ALTER TABLE Personnel.tblEntretienFourniture ADD CONSTRAINT FK_Emp_EntFour_NoEmp FOREIGN KEY(NoEmploye) REFERENCES Personnel.tblEmploye(NoEmploye) 
GO


/**************************************** Foreign key Reservation ****************************************/ 
ALTER TABLE Reservation.tblEquipementRecreatifHotel ADD CONSTRAINT FK_EqRec_EqHot_CodEqRec FOREIGN KEY(CodeEquipementRecreatif) REFERENCES Reservation.tblEquipementRecreatif(CodeEquipementRecreatif) 
ALTER TABLE Reservation.tblEquipementRecreatifHotel ADD CONSTRAINT FK_Hot_EqHot_CodHot FOREIGN KEY(CodeHotel) REFERENCES Reservation.tblHotel(CodeHotel) 
ALTER TABLE Reservation.tblProvince ADD CONSTRAINT FK_Pays_Prov_CodPays FOREIGN KEY(CodePays) REFERENCES Reservation.tblPays(CodePays) 
ALTER TABLE Reservation.tblVille ADD CONSTRAINT FK_Prov_Vill_CodProv FOREIGN KEY(CodeProvince) REFERENCES Reservation.tblProvince(CodeProvince) 
ALTER TABLE Reservation.tblHotel ADD CONSTRAINT FK_Vill_Hot_CodVill FOREIGN KEY(CodeVille) REFERENCES Reservation.tblVille(CodeVille) 
ALTER TABLE Reservation.tblSalle ADD CONSTRAINT FK_Hot_Salle_CodHot FOREIGN KEY(CodeHotel) REFERENCES Reservation.tblHotel(CodeHotel) 
ALTER TABLE Reservation.tblReservationSalle ADD CONSTRAINT FK_Salle_ReservSalle_CodSalle FOREIGN KEY(CodeSalle) REFERENCES Reservation.tblSalle(CodeSalle) 
ALTER TABLE Reservation.tblReservationSalle ADD CONSTRAINT FK_Cli_ReservSalle_NoCli FOREIGN KEY(NoSeqClient) REFERENCES Reservation.tblClient(NoSeqClient) 
ALTER TABLE Reservation.tblChambre ADD CONSTRAINT FK_Hot_Chamb_CodHot FOREIGN KEY(CodeHotel) REFERENCES Reservation.tblHotel(CodeHotel)
ALTER TABLE Reservation.tblChambre ADD CONSTRAINT FK_Hot_TypChamb_CodTypeChamb FOREIGN KEY(CodeTypeChambre) REFERENCES Reservation.tblTypeChambre(CodeTypeChambre) 
ALTER TABLE Reservation.tblReservationChambre ADD CONSTRAINT FK_Cli_ReservChamb_NoCli FOREIGN KEY(NoSeqClient) REFERENCES Reservation.tblClient(NoSeqClient) 
ALTER TABLE Reservation.tblReservationChambre ADD CONSTRAINT FK_Rab_ReservChamb_NoRab FOREIGN KEY(NoSeqRabais) REFERENCES Reservation.tblRabais(NoSeqRabais) 
ALTER TABLE Reservation.tblChambreReservationChambre ADD CONSTRAINT FK_Chamb_ChambReservChamb_NoSeqReservChamb FOREIGN KEY(NoSeqChambre) REFERENCES Reservation.tblChambre(NoSeqChambre) 
ALTER TABLE Reservation.tblChambreReservationChambre ADD CONSTRAINT FK_ReservChamb_ChambReservChamb_NoSeqReservChamb FOREIGN KEY(NoSeqReservChambre) REFERENCES Reservation.tblReservationChambre(NoSeqReservChambre) 
ALTER TABLE Reservation.tblFacture ADD CONSTRAINT FK_ReservChamb_Fact_NoSeqChamb FOREIGN KEY(NoSeqReservChambre) REFERENCES Reservation.tblReservationChambre(NoSeqReservChambre) 
ALTER TABLE Reservation.tblEquipementGeneriqueTypeChambre ADD CONSTRAINT FK_TypChamb_EqTypChamb_CodTypChamb FOREIGN KEY(CodeTypeChambre) REFERENCES Reservation.tblTypeChambre(CodeTypeChambre) 
ALTER TABLE Reservation.tblEquipementGeneriqueTypeChambre ADD CONSTRAINT FK_EqChamb_EqTypChamb_CodEqChamb FOREIGN KEY(CodeEquipementGenChambre) REFERENCES Reservation.tblEquipementGeneriqueChambre(CodeEquipementGenChambre) 
ALTER TABLE Reservation.tblForfaitTypeChambre ADD CONSTRAINT FK_TypChamb_ForTypChamb_CodTypChamb FOREIGN KEY(CodeTypeChambre) REFERENCES Reservation.tblTypeChambre(CodeTypeChambre) 
ALTER TABLE Reservation.tblForfaitTypeChambre ADD CONSTRAINT FK_Forf_ForTypChamb_CodForf FOREIGN KEY(CodeForfait) REFERENCES Reservation.tblForfait(CodeForfait) 
ALTER TABLE Reservation.tblEquipementRecreatifForfait ADD CONSTRAINT FK_Forf_EqRecFor_CodForf FOREIGN KEY(CodeForfait) REFERENCES Reservation.tblForfait(CodeForfait) 
ALTER TABLE Reservation.tblEquipementRecreatifForfait ADD CONSTRAINT FK_EqRecre_EqRecFor_CodEqRecre FOREIGN KEY(CodeEquipementRecreatif) REFERENCES Reservation.tblEquipementRecreatif(CodeEquipementRecreatif) 

--ALTER TABLE Reservation.tblProvinceVille
--DROP CONSTRAINT FK_Prov_ProvVil_CodProv

--ALTER TABLE Reservation.tblProvinceVille
--DROP CONSTRAINT FK_Vill_ProvVil_CodVill

