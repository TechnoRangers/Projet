Public Class Reservation
    Dim MaBD As P2014_BD_GestionHotelEntities

    Dim Selection As tblChambre
    Dim MonForfait As tblForfait
    Dim Client As tblClient
    Dim ListeChambreReservation As New List(Of tblChambre)
    Dim ListeReservationChambre As New List(Of tblChambreReservationChambre)
    Dim ReservationChambre As tblReservationChambre
    Dim PrixForfait As Double
    Dim DateDebut As Date
    Dim DateFin As Date
    Dim PrixReservation As Double
    Dim compteur As Integer


    Sub New(ByRef _MaBD As P2014_BD_GestionHotelEntities, ByRef _ListeChambreReservation As List(Of tblChambre), Optional ByRef _DateDebut As Date = Nothing, Optional ByRef _DateFin As Date = Nothing, Optional ByRef _MonForfait As tblForfait = Nothing, Optional ByRef _Client As tblClient = Nothing)
        InitializeComponent()
        MaBD = _MaBD
        DateDebut = _DateDebut
        DateFin = _DateFin
        Client = _Client
        compteur = 0

        MonForfait = _MonForfait
        ListeChambreReservation = _ListeChambreReservation

        For Each t In _ListeChambreReservation
            t.tblChambreReservationChambre.Clear()
        Next

        ReservationChambre = New tblReservationChambre

        ReservationChambre.tblChambreReservationChambre.Clear()

        If _MonForfait IsNot Nothing Then
            Res_DatePickerArr.IsEnabled = False
            Res_DatePikerDep.IsEnabled = False
            Res_DatePickerArr.SelectedDate = _MonForfait.DateDebut
            Res_DatePikerDep.SelectedDate = _MonForfait.DateFin
            Res_TxtBoxNomForfait.Text = _MonForfait.NomForfait
            Res_TextBoxMontant.Text = PrixForfait.ToString
        Else
            Res_DatePickerArr.SelectedDate = DateDebut
            Res_DatePikerDep.SelectedDate = DateFin
        End If


        For Each Chambre In ListeChambreReservation
            Dim ChambReservChambre As New tblChambreReservationChambre
            ChambReservChambre.NoSeqChambre = Chambre.NoSeqChambre
            ChambReservChambre.DateDebutReservation = Res_DatePickerArr.SelectedDate
            ChambReservChambre.DateFinReservation = Res_DatePikerDep.SelectedDate
            Chambre.tblChambreReservationChambre.Add(ChambReservChambre)
            ReservationChambre.tblChambreReservationChambre.Add(ChambReservChambre)
            compteur += 1
            Dim PrixChambre = From t1 In MaBD.tblPrixTypeChambre
                              Where Chambre.CodeTypeChambre = t1.CodeTypeChambre And (ChambReservChambre.DateDebutReservation > t1.DateDebutPrix And ChambReservChambre.DateFinReservation < t1.DateFinPrix) And t1.CodeHotel = "NFN"
                              Select t1.PrixTypeChambre
            PrixReservation += PrixChambre.First * DateDiff("d", ChambReservChambre.DateDebutReservation, ChambReservChambre.DateFinReservation)

            If MonForfait IsNot Nothing Then
                PrixForfait += _MonForfait.PrixForfait
            Else
                PrixForfait = 0
            End If
        Next


        Res_TextBoxNbChambre.Text = ListeChambreReservation.Count
        res_lbvChambres.SelectedItem = ListeChambreReservation.ToList.First
        Res_TextBoxMontant.Text = PrixReservation.ToString

    End Sub

    Private Sub Res_frmReservation_Loaded(sender As Object, e As RoutedEventArgs) Handles Res_frmReservation.Loaded

        res_lbvChambres.ItemsSource = ListeChambreReservation.ToList

        Dim Rabais = From t1 In MaBD.tblRabais
                            Select t1

        Res_CmbRabais.ItemsSource = Rabais.ToList
        Res_CmbRabais.DisplayMemberPath = "PourcentageRabais"
        Res_CmbRabais.SelectedValue = Rabais.ToList

    End Sub

    Private Sub res_lbvChambres_SelectionChanged(sender As Object, e As SelectionChangedEventArgs) Handles res_lbvChambres.SelectionChanged
        Dim Chambre As tblChambre = CType(res_lbvChambres.SelectedItem, tblChambre)

        Dim lien = Chambre.tblChambreReservationChambre(0)

        Res_TextBoxNoChambre.DataContext = Chambre
        Res_TextBoxTypeChambre.DataContext = Chambre

        Res_TextBoxNomLocataire.DataContext = Chambre.tblChambreReservationChambre(0)
        Res_TextBoxPrenomLocataire.DataContext = Chambre.tblChambreReservationChambre(0)
        Res_TextBoxNbAdulte.DataContext = Chambre.tblChambreReservationChambre(0)

        lien.StatutChambreReservChambre = "Occupée"


    End Sub

    Private Sub Res_btnReserver_Click(sender As Object, e As RoutedEventArgs) Handles Res_btnReserver.Click

        If Res_DatePickerArr.SelectedDate > Res_DatePikerDep.SelectedDate Or Res_DatePikerDep.SelectedDate < Res_DatePickerArr.SelectedDate Or Res_TextBoxNomLocataire.Text = "" Or Res_TextBoxPrenomLocataire.Text = "" Or Res_TextBoxNbAdulte.Text = "" Or Res_ComboBoxMoyenPaiement.SelectedItem Is Nothing Then
            MessageBox.Show("Erreur. Vérifier la compatibilité des dates et si les champs sont bien remplis")
        Else
            Dim MaBD = New P2014_BD_GestionHotelEntities
            Dim cli = From el In MaBD.tblClient Where el.NoSeqClient = Client.NoSeqClient Select el


            Dim i As Integer = 0

            'Validation que tous les champs on été remplis
            For Each chamb In ListeChambreReservation
                Dim Reserv As tblChambreReservationChambre = chamb.tblChambreReservationChambre(i)
                If Reserv.DateDebutReservation = Nothing Or Reserv.DateFinReservation = Nothing Or Reserv.NomLocataire = Nothing Or Reserv.PrenomLocataire = Nothing Then
                    MessageBox.Show("Certains champs de réservation n'ont pas été remplis.")
                    Exit Sub
                    i += 1
                End If
            Next

            'Enregistrement de la réservation
            Try

                If Res_TxtBoxNomForfait.Text <> "" Then
                    Dim ff = (From el In MaBD.tblForfait Where el.CodeForfait = MonForfait.CodeForfait Select el).First
                    'MonForfait.tblChambreReservationChambre.Add(ReservationChambre.tblChambreReservationChambre(ReservationChambre.tblChambreReservationChambre.Count - 1))
                    For Each crc In ReservationChambre.tblChambreReservationChambre
                        ff.tblChambreReservationChambre.Add(crc)
                    Next
                End If


                ReservationChambre.StatutReservChambre = "En cours"
                ReservationChambre.PrixReservChambre = CDbl(Res_TextBoxMontant.Text)
                ReservationChambre.ModePaiement = Res_ComboBoxMoyenPaiement.SelectionBoxItem.ToString
                ReservationChambre.StatutPaiement = "Payé"
                ReservationChambre.NoCarteCredit = Res_TxtNoCarte.Text
                ReservationChambre.DateExpirationCarteCredit = Res_TxtDateExp.Text
                ReservationChambre.TypeCarteCredit = Res_CmbTypeCarte.Text
                ReservationChambre.NomCarteCredit = Res_TxtNomProprio.Text
                cli.First.tblReservationChambre.Add(ReservationChambre)

                MaBD.SaveChanges()

                MessageBox.Show("La réservation a été enregistrée.")
            Catch ex As Exception
                MessageBox.Show("Erreur dans l'ajout de la réservation. Vérifier la compatibilité des dates et si les champs sont bien remplis")
            End Try

            Me.Close()
        End If

    End Sub

    Private Sub Res_btnAnnuler_Click(sender As Object, e As RoutedEventArgs) Handles Res_btnAnnuler.Click
        Me.Close()
    End Sub

    Private Sub Res_DatePikerDep_SelectedDateChanged(sender As Object, e As SelectionChangedEventArgs) Handles Res_DatePikerDep.SelectedDateChanged

        Dim i As Integer
        Dim Nb As Integer

        i = 0

        If Res_DatePikerDep.SelectedDate < Res_DatePickerArr.SelectedDate Then
            MessageBox.Show("Erreur. La date de départ doit être après la date d'arrivé")
        Else
            If compteur > 0 Then
                For Each NoChambre In ListeChambreReservation
                    If NoChambre.NoSeqChambre = Res_TextBoxNoChambre.Text Then
                        Nb = i
                    Else
                        i += 1
                    End If
                Next

                Dim Chambre As tblChambre = ListeChambreReservation(Nb)
                Dim chambreReservationChambre As tblChambreReservationChambre
                For Each Chamb In ListeChambreReservation
                    If Chamb.NoSeqChambre = Res_TextBoxNoChambre.Text Then
                        chambreReservationChambre = Chamb.tblChambreReservationChambre(0)
                    End If
                Next



                Dim PrixChambre = From t1 In MaBD.tblPrixTypeChambre
                                  Where Chambre.CodeTypeChambre = t1.CodeTypeChambre And (chambreReservationChambre.DateDebutReservation > t1.DateDebutPrix And chambreReservationChambre.DateFinReservation < t1.DateFinPrix) And t1.CodeHotel = "NFN"
                                  Select t1.PrixTypeChambre

                PrixReservation -= PrixChambre.First * DateDiff("d", chambreReservationChambre.DateDebutReservation, chambreReservationChambre.DateFinReservation)

                For Each Chamb In ListeChambreReservation
                    If Chamb.NoSeqChambre = Res_TextBoxNoChambre.Text Then
                        chambreReservationChambre = Chamb.tblChambreReservationChambre(0)
                        chambreReservationChambre.DateDebutReservation = Res_DatePickerArr.SelectedDate
                        chambreReservationChambre.DateFinReservation = Res_DatePikerDep.SelectedDate
                    End If
                Next


                Dim PrixChambre2 = From t1 In MaBD.tblPrixTypeChambre
                                  Where Chambre.CodeTypeChambre = t1.CodeTypeChambre And (chambreReservationChambre.DateDebutReservation > t1.DateDebutPrix And chambreReservationChambre.DateFinReservation < t1.DateFinPrix) And t1.CodeHotel = "NFN"
                                  Select t1.PrixTypeChambre

                PrixReservation += PrixChambre2.First * DateDiff("d", chambreReservationChambre.DateDebutReservation, chambreReservationChambre.DateFinReservation)
            End If

            Res_TextBoxMontant.Text = PrixReservation.ToString
        End If

    End Sub


    Private Sub Res_BtnAppliquerRabais_Click(sender As Object, e As RoutedEventArgs) Handles Res_BtnAppliquerRabais.Click
        Dim MontantTot As Double
        Dim PrixRabais As Double
        Dim Rabais As Double

        If Res_CmbRabais.Text <> "" Then
            Rabais = CDbl(Res_CmbRabais.Text)
            MontantTot = CDbl(Res_TextBoxMontant.Text)
            PrixRabais = MontantTot - (MontantTot * (Rabais / 100))
            Res_TextBoxMontant.Text = PrixRabais.ToString
            Res_BtnAppliquerRabais.Visibility = Windows.Visibility.Hidden
        Else
            MessageBox.Show("Aucun rabais sélectionné")
        End If

    End Sub
End Class
