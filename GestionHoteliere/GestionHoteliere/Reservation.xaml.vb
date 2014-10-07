Public Class Reservation
    Dim MaBD As P2014_BDTestFrancoisEntities

    Dim ListeChambreReservation As New List(Of tblChambre)
    Dim ListeReservationChambre As New List(Of tblChambreReservationChambre)

    Dim ReservationChambre As tblReservationChambre

    'Dim ListeReservationChambre As New List(Of tblChambre)

    'Dim ListeChambreSelection As ListCollectionView

    Sub New(ByRef _MaBD As P2014_BDTestFrancoisEntities, ByRef _ListeChambreReservation As List(Of tblChambre))
        InitializeComponent()
        MaBD = _MaBD
        ListeChambreReservation = _ListeChambreReservation
        ReservationChambre = New tblReservationChambre

        For Each Chambre In ListeChambreReservation
            Dim ChambReservChambre As New tblChambreReservationChambre
            ChambReservChambre.NoSeqChambre = Chambre.NoSeqChambre
            ChambReservChambre.NoSeqReservChambre = ReservationChambre.NoSeqReservChambre
            ListeReservationChambre.Add(ChambReservChambre)
        Next
    End Sub

    'Public WriteOnly Property LesChambres() As IList

    '    Set(ByVal value As IList)
    '        ListeChambreSelection = New ListCollectionView(value)
    '    End Set
    'End Property

    Private Sub Res_btnAnnuler_Click(sender As Object, e As RoutedEventArgs) Handles Res_btnAnnuler.Click

        Me.Close()

    End Sub

    Private Sub Res_btnReserver_Click(sender As Object, e As RoutedEventArgs) Handles Res_btnReserver.Click

        ReservationChambre.ModePaiement = Res_ComboBoxMoyenPaiement.SelectedItem
        ReservationChambre.PrixReservChambre = Res_TextBoxMontant.Text

        Me.Close()
    End Sub

    Private Sub Res_frmReservation_Loaded(sender As Object, e As RoutedEventArgs) Handles Res_frmReservation.Loaded

        res_lbvChambres.ItemsSource = ListeChambreReservation.ToList


        'Res_TextBoxNoChambre.DataContext = ListeChambreSelection
        'Res_TextBoxTypeChambre.DataContext = ListeChambreSelection

        'For Each Chambre In ListeChambreSelection
        '    Dim ReservChamb As New tblChambreReservationChambre

        '    ReservChamb.NoSeqChambre = Chambre


        'Next


        'Res_TextBoxNbAdulte.DataContext = ListeChambreReservation

        'Res_TextBoxNbChambre.Text = ListeChambreSelection.Count

    End Sub

    Private Sub Res_BtnSuivant_Click(sender As Object, e As RoutedEventArgs) Handles Res_BtnSuivant.Click

        'ListeChambreSelection.MoveCurrentToNext()
        'SauvegardeDonneChambre()

    End Sub

    Private Sub Res_BtnPrecedent_Click(sender As Object, e As RoutedEventArgs) Handles Res_BtnPrecedent.Click

        'ListeChambreSelection.MoveCurrentToPrevious()

    End Sub

    'Sub SauvegardeDonneChambre()
    '    Dim Chambre As tblChambre

    '    Chambre = CType(ListeChambreSelection.CurrentItem(), tblChambre)
    'End Sub

    'Sub InitialiserListeReservationChambre()
    '    For Each Chambre In ListeChambreSelection

    '        Dim ReservChambre As New tblChambreReservationChambre

    '        ReservChambre.NoSeqChambre = Chambre
    '        ReservChambre.NbPersonne = Res_TextBoxNbAdulte.Text
    '        ReservChambre.NomLocataire = Res_TextBoxNomLocataire.Text
    '        ReservChambre.PrenomLocataire = Res_TextBoxPrenomLocataire.Text
    '        ReservChambre.DateDebutReservation = Res_DatePickerArr.SelectedDate
    '        ReservChambre.DateFinReservation = Res_DatePikerDep.SelectedDate

    '    Next
    'End Sub

    Private Sub res_lbvChambres_SelectionChanged(sender As Object, e As SelectionChangedEventArgs) Handles res_lbvChambres.SelectionChanged

        'Dim Chambre As tblChambre = CType(res_lbvChambres.SelectedItem, tblChambre)


        For Each Chamb As tblChambre In ListeChambreReservation

            For Each Reserv As tblChambreReservationChambre In ListeReservationChambre

                If Chamb.NoSeqChambre = Reserv.NoSeqChambre Then

                    'Stuff ici

                End If

            Next

        Next

        'For Each Chambre in ListeChambreReservation

        'For Each ChambReservChamb In ListeReservationChambre

        'Next

        'Next


        'Res_TextBoxMontant.DataContext = ListeChambreReservation.Item(Chambre)


        'Dim ChambreReservation As New tblChambreReservationChambre

        'ChambreReservation.NoSeqChambre = Chambre.NoSeqChambre


        'ReservationChambre.tblChambreReservationChambre.Add(ChambreReservation)



        'Res_TextBoxNoChambre.DataContext = Chambre
        'Res_TextBoxTypeChambre.DataContext = Chambre
    End Sub
End Class
