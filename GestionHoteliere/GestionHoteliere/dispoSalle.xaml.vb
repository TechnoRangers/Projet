Public Class dispoSalle
    Dim MaBd As P2014_BD_GestionHotelEntities

    Sub New(ByRef _MaBD As P2014_BD_GestionHotelEntities)
        InitializeComponent()
        MaBd = _MaBD

    End Sub
    Private Sub OnKeyDownHandler(ByVal sender As Object, ByVal e As KeyEventArgs)
        'Vérifier quel touche l'utilisateur press pour ne prendre que des chiffres 
        Select Case e.Key
            Case Key.D0 To Key.D9
                e.Handled = False
            Case Key.NumPad0 To Key.NumPad9
                e.Handled = False
            Case Else
                e.Handled = True
        End Select
    End Sub

    Private Sub Dis_SalList_Loaded(sender As Object, e As RoutedEventArgs) Handles Dis_SalList.Loaded
        Dim res = From it In MaBd.tblReservationSalle Where it.DateReservSalle >= Date.Today Select it
        If res.ToList.Count <> 0 Then
            Dis_SalList.ItemsSource = res.ToList
        End If

    End Sub

    Private Sub LocSal_BtnAjout_Click(sender As Object, e As RoutedEventArgs) Handles LocSal_BtnAjout.Click
        Dim Salle As New ReservationSalle(MaBd, Nothing, 1)
        Salle.Show()
        Me.Close()
    End Sub

    Private Sub LocSal_BtnModiSalle_Click(sender As Object, e As RoutedEventArgs) Handles LocSal_BtnModiSalle.Click
        Dim item As tblReservationSalle = Dis_SalList.SelectedItem

        Dim Salle As New ReservationSalle(MaBd, item.NoSeqReservSalle, 2)
        Salle.Show()
        Me.Close()
    End Sub
    Private Sub supprimer()
        'Supprimer une réservation
        Dim res As tblReservationSalle = Dis_SalList.SelectedItem
        Dim Reservation As tblReservationSalle
        Dim rep2 = (From it In MaBd.tblReservationSalle
           Where it.NoSeqReservSalle = res.NoSeqReservSalle
           Select it)
        If rep2.ToList.Count > 0 Then
            Dim Resp As Boolean = MessageBox.Show("Êtes-vous sûr de supprimer cette réservation", "caption", MessageBoxButton.YesNo)

            If Resp Then
                Reservation = (From It In MaBd.tblReservationSalle
                              Where It.NoSeqReservSalle = res.NoSeqReservSalle
                              Select It).Single()
                MaBd.tblReservationSalle.Remove(Reservation)
                MaBd.SaveChanges()


                MessageBox.Show("La réservation a été supprimer")
                rafraichir()
            Else
                MessageBox.Show("la réservation n'a pas été supprimer")
                rafraichir()
            End If
        Else
            MessageBox.Show("Cette réservation n'existe pas")
        End If

    End Sub

    Private Sub LocSal_BtnSuppSalle_Click(sender As Object, e As RoutedEventArgs) Handles LocSal_BtnSuppSalle.Click
        supprimer()
    End Sub

    Private Sub DispoS_btnAfficher_Click(sender As Object, e As RoutedEventArgs) Handles DispoS_btnAfficher.Click
        Dim item As tblReservationSalle = Dis_SalList.SelectedItem

        Dim Salle As New ReservationSalle(MaBd, item.NoSeqReservSalle, 0)
        Salle.Show()
        Me.Close()
    End Sub

    Private Sub rafraichir()
        Dis_SalList.ItemsSource = Nothing

        Dim res = From it In MaBd.tblReservationSalle Where it.DateReservSalle >= Date.Today Select it
        If res.ToList.Count <> 0 Then
            Dis_SalList.ItemsSource = res.ToList
        End If
    End Sub

    Private Sub Men_btnQuitter_Click(sender As Object, e As RoutedEventArgs) Handles Men_btnQuitter.Click
        Me.Close()
    End Sub
End Class
