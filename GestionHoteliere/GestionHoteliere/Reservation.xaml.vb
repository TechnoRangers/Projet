Public Class Reservation
    Dim MaBD As P2014_BD_GestionHotelEntities

    Dim Selection As tblChambre
    Dim MonForfait As tblForfait
    Dim ListeChambreReservation As New List(Of tblChambre)
    Dim ListeReservationChambre As New List(Of tblChambreReservationChambre)
    Dim ReservationChambre As tblReservationChambre
    Dim PrixForfait As Double

    Sub New(ByRef _MaBD As P2014_BD_GestionHotelEntities, ByRef _ListeChambreReservation As List(Of tblChambre), Optional ByRef _MonForfait As tblForfait = Nothing)
        InitializeComponent()
        MaBD = _MaBD
        MonForfait = _MonForfait
        ListeChambreReservation = _ListeChambreReservation
        ReservationChambre = New tblReservationChambre

        For Each Chambre In ListeChambreReservation
            Dim ChambReservChambre As New tblChambreReservationChambre
            ChambReservChambre.NoSeqChambre = Chambre.NoSeqChambre
            ChambReservChambre.NoSeqReservChambre = ReservationChambre.NoSeqReservChambre
            ListeReservationChambre.Add(ChambReservChambre)
            'PrixReservation += Chambre.PrixChambre
            If MonForfait IsNot Nothing Then
                PrixForfait += _MonForfait.PrixForfait
            Else
                PrixForfait = 0
            End If

        Next
        If _MonForfait IsNot Nothing Then
            Res_DatePickerArr.IsEnabled = False
            Res_DatePikerDep.IsEnabled = False
            Res_DatePickerArr.SelectedDate = _MonForfait.DateDebut
            Res_DatePikerDep.SelectedDate = _MonForfait.DateFin
            Res_TxtBoxNomForfait.Text = _MonForfait.NomForfait
            Res_TextBoxMontant.Text = PrixForfait.ToString
        Else
            Res_DatePickerArr.SelectedDate = System.DateTime.Today
            Res_DatePikerDep.SelectedDate = DateAdd("d", 1, Now)
        End If

        Res_TextBoxNbChambre.Text = ListeReservationChambre.Count
        res_lbvChambres.SelectedItem = ListeChambreReservation.ToList.First

    End Sub

    Private Sub Res_frmReservation_Loaded(sender As Object, e As RoutedEventArgs) Handles Res_frmReservation.Loaded
        res_lbvChambres.ItemsSource = ListeChambreReservation.ToList
    End Sub

    Private Sub res_lbvChambres_SelectionChanged(sender As Object, e As SelectionChangedEventArgs) Handles res_lbvChambres.SelectionChanged
        Dim Chambre As tblChambre = CType(res_lbvChambres.SelectedItem, tblChambre)
        Dim Reservation_ As New tblChambreReservationChambre

        'Pogne la réservation de la chambre sélectionné
        For Each Reserv As tblChambreReservationChambre In ListeReservationChambre
            If Chambre.NoSeqChambre = Reserv.NoSeqChambre Then
                Reservation_ = Reserv
            End If
        Next

        'Sauvegarde les données de la réservation de la chambre sélectionnée.
        If Selection IsNot Nothing Then
            For Each Reserv As tblChambreReservationChambre In ListeReservationChambre
                If Reserv.NoSeqChambre = Selection.NoSeqChambre Then
                    Reserv.NomLocataire = Res_TextBoxNomLocataire.Text
                    Reserv.PrenomLocataire = Res_TextBoxPrenomLocataire.Text
                    Reserv.NbPersonne = Res_TextBoxNbAdulte.Text
                    Reserv.DateDebutReservation = Res_DatePickerArr.SelectedDate
                    Reserv.DateFinReservation = Res_DatePikerDep.SelectedDate
                End If
            Next
        End If

        'Rempli les champs avec la réservation selectionnée
        Res_TextBoxNoChambre.DataContext = Chambre
        Res_TextBoxTypeChambre.DataContext = Chambre
        Res_TextBoxNomLocataire.Text = Reservation_.NomLocataire
        Res_TextBoxPrenomLocataire.Text = Reservation_.PrenomLocataire
        Res_TextBoxNbAdulte.Text = Reservation_.NbPersonne
        If Reservation_.DateDebutReservation <> Nothing And Reservation_.DateFinReservation <> Nothing Then
            Res_DatePickerArr.SelectedDate = Reservation_.DateDebutReservation
            Res_DatePikerDep.SelectedDate = Reservation_.DateFinReservation
        End If

        'Garde la sélection précédante
        Selection = Chambre
    End Sub

    Private Sub Res_btnReserver_Click(sender As Object, e As RoutedEventArgs) Handles Res_btnReserver.Click

        'Validation que tous les champs on été remplis
        For Each Reserv As tblChambreReservationChambre In ListeReservationChambre
            If Reserv.DateDebutReservation = Nothing Or Reserv.DateFinReservation = Nothing Or Reserv.NomLocataire = Nothing Or Reserv.PrenomLocataire = Nothing Then
                MessageBox.Show("Certains champs de réservation n'ont pas été remplis.")
                Exit Sub
            End If
        Next

        'Enregistrement de la réservation
        Try
            ReservationChambre.StatutReservChambre = "En cours"
            ReservationChambre.ModePaiement = Res_ComboBoxMoyenPaiement.SelectionBoxItem.ToString
            ReservationChambre.PrixReservChambre = CType(Res_TextBoxMontant.Text, Integer)
            ReservationChambre.NoSeqClient = 1000

            'ReservationChambre.NbPersonne = 0
            'For Each Reserv As tblChambreReservationChambre In ListeReservationChambre
            '    ReservationChambre.NbPersonne += Reserv.NbPersonne
            'Next

            MaBD.tblReservationChambre.Add(ReservationChambre)
            MaBD.SaveChanges()

            Try
                For Each Reserv As tblChambreReservationChambre In ListeReservationChambre
                    Reserv.NoSeqReservChambre = ReservationChambre.NoSeqReservChambre
                    Reserv.StatutChambreReservChambre = "Occupe"
                    MaBD.tblChambreReservationChambre.Add(Reserv)
                    Reserv.tblForfait.Add(MonForfait)
                Next
                MaBD.SaveChanges()
            Catch ex As Exception
                MessageBox.Show("Erreur dans l'ajout des chambre dans la réservation")
            End Try
            MessageBox.Show("La réservation a été enregistrée.")
        Catch ex As Exception
            MessageBox.Show("Erreur dans l'ajout de la réservation.")
        End Try

        Me.Close()
    End Sub

    Private Sub Res_btnAnnuler_Click(sender As Object, e As RoutedEventArgs) Handles Res_btnAnnuler.Click
        Me.Close()
    End Sub
End Class
