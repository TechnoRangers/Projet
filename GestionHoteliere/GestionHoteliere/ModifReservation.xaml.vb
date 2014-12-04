Public Class ModifReservation
    Dim MaBD As P2014_BD_GestionHotelEntities
    Dim MaReserv As tblReservationChambre
    Dim Selection As tblChambre

    Dim ListeChambreReservation As List(Of tblChambreReservationChambre)
    Dim ListeChambre As List(Of tblChambre)

    Sub New(ByRef _MaBD As P2014_BD_GestionHotelEntities, ByRef _MaReserv As tblReservationChambre)
        InitializeComponent()
        MaBD = _MaBD
        MaReserv = _MaReserv


        mres_txtNoSeqReservChambre.DataContext = MaReserv
        mres_txtPrixReservChambre.DataContext = MaReserv
        mres_txtStatutPaiement.DataContext = MaReserv
        mres_txtNoSeqClient.DataContext = MaReserv

        mres_txtNoCarteCredit.DataContext = MaReserv
        mres_txtDateExpiration.DataContext = MaReserv
        mres_txtTypeCarte.DataContext = MaReserv
        mres_txtNomDetenteur.DataContext = MaReserv

        Select Case MaReserv.ModePaiement
            Case "Carte de crédit"
                mres_cmbModePaiement.SelectedIndex = 0
            Case "Argent"
                mres_cmbModePaiement.SelectedIndex = 1
            Case "Chèque"
                mres_cmbModePaiement.SelectedIndex = 2
            Case Else
        End Select


    End Sub

    Private Sub mres_frmModifReservation_Loaded(sender As Object, e As RoutedEventArgs) Handles mres_frmModifReservation.Loaded
        ListeChambreReservation = New List(Of tblChambreReservationChambre)
        ListeChambre = New List(Of tblChambre)

        ListeChambreReservation = (From tabChambreReservChambre In MaBD.tblChambreReservationChambre
                                    Where tabChambreReservChambre.NoSeqReservChambre = MaReserv.NoSeqReservChambre
                                    Select tabChambreReservChambre).ToList

        For Each ChambreReserv As tblChambreReservationChambre In ListeChambreReservation
            Dim Chambre As New tblChambre
            Chambre = (From tabChambre In MaBD.tblChambre
                      Where tabChambre.NoSeqChambre = ChambreReserv.NoSeqChambre
                      Select tabChambre).ToList.First

            ListeChambre.Add(Chambre)
        Next

        mres_lstChambre.ItemsSource = ListeChambre
        mres_lstChambre.SelectedItem = ListeChambre.First

    End Sub

    Private Sub mres_lstChambre_SelectionChanged(sender As Object, e As SelectionChangedEventArgs) Handles mres_lstChambre.SelectionChanged
        Dim ChambreSelection As tblChambre = CType(mres_lstChambre.SelectedItem, tblChambre)
        Dim ChambreReservation As New tblChambreReservationChambre

        'Prend le tblChambreReservationChambre correspondant à la chambre sélectionné.
        For Each ChambreReserv As tblChambreReservationChambre In ListeChambreReservation
            If ChambreReserv.NoSeqChambre = ChambreSelection.NoSeqChambre Then
                ChambreReservation = ChambreReserv
            End If
        Next

        'Sauvegarder les info de la chambre sélectionnée avant de passer à la prochaine.
        If Selection IsNot Nothing Then
            For Each Reserv As tblChambreReservationChambre In ListeChambreReservation
                If Reserv.NoSeqChambre = Selection.NoSeqChambre Then
                    Reserv.DateDebutReservation = mres_dtpDateDebut.SelectedDate
                    Reserv.DateFinReservation = mres_dtpDateFin.SelectedDate
                    Reserv.NbPersonne = mres_txtNbPersonne.Text
                    Reserv.PrenomLocataire = mres_txtPrenomLocataire.Text
                    Reserv.NomLocataire = mres_txtNomLocataire.Text
                    Reserv.StatutChambreReservChambre = mres_txtStatutChambre.Text
                End If
            Next
            MaBD.SaveChanges()
        End If

        'Afficher les info de ChambreReservationChambre
        mres_dtpDateDebut.SelectedDate = ChambreReservation.DateDebutReservation
        mres_dtpDateFin.SelectedDate = ChambreReservation.DateFinReservation
        mres_txtNbPersonne.DataContext = ChambreReservation
        mres_txtPrenomLocataire.DataContext = ChambreReservation
        mres_txtNomLocataire.DataContext = ChambreReservation
        mres_txtStatutChambre.DataContext = ChambreReservation

        'Garde la sélection précédante
        Selection = ChambreSelection
    End Sub

    'Private Sub mres_btnConfirmer_Click(sender As Object, e As RoutedEventArgs) Handles mres_btnConfirmer.Click
    '    Try
    '        If MaReserv Is Nothing Then
    '            MaReserv = New tblReservationChambre()
    '            MaReserv.NoSeqReservChambre = mres_txtNoSeqReservChambre.Text
    '            MaReserv.PrixReservChambre = mres_txtPrixReservChambre.Text
    '            'MaReserv.ModePaiement = mres_txtModePaiement.Text
    '            MaReserv.StatutPaiement = mres_txtStatutPaiement.Text

    '            MaReserv.NoCarteCredit = mres_txtNoCarteCredit.Text
    '            MaReserv.NoSeqClient = mres_txtNoSeqClient.Text
    '            'MaReserv.NoSeqRabais = mres_txtNoSeqForfait.Text

    '            MaBD.tblReservationChambre.Add(MaReserv)
    '        End If
    '        MaBD.SaveChanges()
    '    Catch ex As Exception
    '        MaBD.tblReservationChambre.Remove(MaReserv)
    '        MessageBox.Show("Existe deja")
    '    End Try

    '    Me.Close()
    'End Sub

    Private Sub mres_btnSauvegarderReservation_Click(sender As Object, e As RoutedEventArgs) Handles mres_btnSauvegarderReservation.Click
        Try
            'Sauvegarder les informations de la réservation
            'MaReserv.PrixReservChambre = mres_txtPrixReservChambre.Text
            MaReserv.ModePaiement = mres_cmbModePaiement.SelectedValue
            MaReserv.StatutPaiement = mres_txtStatutPaiement.Text
            MaReserv.NoCarteCredit = mres_txtNoCarteCredit.Text
            MaReserv.DateExpirationCarteCredit = mres_txtDateExpiration.Text
            MaReserv.TypeCarteCredit = mres_txtTypeCarte.Text
            MaReserv.NomCarteCredit = mres_txtNomDetenteur.Text
            MaBD.SaveChanges()
            MessageBox.Show("Les informations de la réservation ont été correctement enregistrées.")
        Catch ex As Exception
            MessageBox.Show("Erreur lors de l'enregistrement de la réservation.")
        End Try
    End Sub

    Private Sub mres_btnSauvegarderChambres_Click(sender As Object, e As RoutedEventArgs) Handles mres_btnSauvegarderChambres.Click
        Try
            If Selection IsNot Nothing Then
                For Each Reserv As tblChambreReservationChambre In ListeChambreReservation
                    If Reserv.NoSeqChambre = Selection.NoSeqChambre Then
                        Reserv.DateDebutReservation = mres_dtpDateDebut.SelectedDate
                        Reserv.DateFinReservation = mres_dtpDateFin.SelectedDate
                        Reserv.NbPersonne = mres_txtNbPersonne.Text
                        Reserv.PrenomLocataire = mres_txtPrenomLocataire.Text
                        Reserv.NomLocataire = mres_txtNomLocataire.Text
                        Reserv.StatutChambreReservChambre = mres_txtStatutChambre.Text
                    End If
                Next
                MaBD.SaveChanges()
            End If
            MessageBox.Show("Les informations de la chambre ont été correctement enregistrées.")
        Catch ex As Exception
            MessageBox.Show("Erreur lors de l'enregistrement des informations de la chambre.")
        End Try
    End Sub

    Private Sub mres_btnRetour_Click(sender As Object, e As RoutedEventArgs) Handles mres_btnRetour.Click
        Me.Close()
    End Sub

    Private Sub mres_btnAnnulerReservation_Click(sender As Object, e As RoutedEventArgs) Handles mres_btnAnnulerReserv.Click
        MaReserv.StatutReservChambre = "Annulé"
        MaBD.SaveChanges()
        MessageBox.Show("La réservation a été annulée.")
        Me.Close()
    End Sub
End Class

