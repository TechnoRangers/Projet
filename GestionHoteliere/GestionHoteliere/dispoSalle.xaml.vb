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
        Dim rep = From it In MaBd.tblSalle Select it.NomSalle
        For Each Nom In rep.ToList
            DispoS_CmbBoxSalle.Items.Add(Nom)
        Next
        DispoS_CmbBoxSalle.SelectedIndex = -1
        rafraichir()
    End Sub

    Private Sub DispoS_BtnAjout_Click(sender As Object, e As RoutedEventArgs) Handles DispoS_BtnAjout.Click
        Dim Salle As New ReservationSalle(MaBd, Nothing, 1)
        Salle.Show()
        Me.Close()
    End Sub

    Private Sub DispoS_BtnModiSalle_Click(sender As Object, e As RoutedEventArgs) Handles DispoS_BtnModiSalle.Click
        Dim item As tblReservationSalle = Dis_SalList.SelectedItem
        If Not Dis_SalList.SelectedIndex = -1 Then
            Dim Salle As New ReservationSalle(MaBd, item.NoSeqReservSalle, 2)
            Salle.Show()
            Me.Close()
        End If

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

    Private Sub DispoS_BtnSuppSalle_Click(sender As Object, e As RoutedEventArgs) Handles DispoS_BtnSuppSalle.Click
        If Not Dis_SalList.SelectedIndex = -1 Then
            supprimer()
        End If

    End Sub

    Private Sub DispoS_btnAfficher_Click(sender As Object, e As RoutedEventArgs) Handles DispoS_btnAfficher.Click
        Dim item As tblReservationSalle = Dis_SalList.SelectedItem
        If Not Dis_SalList.SelectedIndex = -1 Then
            Dim Salle As New ReservationSalle(MaBd, item.NoSeqReservSalle, 0)
            Salle.Show()
            Me.Close()
        End If

    End Sub

    Private Sub rafraichir()
        Dis_SalList.ItemsSource = Nothing


        If DispoS_CmbBoxSalle.SelectedIndex = -1 And IsNothing(DispoS_DatePicker.SelectedDate) Then
            Dim res = From it In MaBd.tblReservationSalle Where it.DateReservSalle >= Date.Today Select it
            If res.ToList.Count <> 0 Then
                Dis_SalList.ItemsSource = res.ToList
            End If
        End If
        If DispoS_CmbBoxSalle.SelectedIndex = -1 And Not IsNothing(DispoS_DatePicker.SelectedDate) Then
            Dim res = From it In MaBd.tblReservationSalle Where it.DateReservSalle >= DispoS_DatePicker.SelectedDate Select it
            If res.ToList.Count <> 0 Then
                Dis_SalList.ItemsSource = res.ToList
            End If
        End If
        If DispoS_CmbBoxSalle.SelectedIndex <> -1 And IsNothing(DispoS_DatePicker.SelectedDate) Then
            Dim salle = (From el In MaBd.tblSalle Where el.NomSalle = DispoS_CmbBoxSalle.SelectedItem.ToString Select el.CodeSalle).Single

            Dim res = From it In MaBd.tblReservationSalle Where it.CodeSalle = salle Select it
            If res.ToList.Count <> 0 Then
                Dis_SalList.ItemsSource = res.ToList
            End If
        End If
        If DispoS_CmbBoxSalle.SelectedIndex <> -1 And Not IsNothing(DispoS_DatePicker.SelectedDate) Then
            Dim salle = (From el In MaBd.tblSalle Where el.NomSalle = DispoS_CmbBoxSalle.SelectedItem.ToString Select el.CodeSalle).Single

            Dim res = From it In MaBd.tblReservationSalle Where it.CodeSalle = salle And it.DateReservSalle >= DispoS_DatePicker.SelectedDate Select it
            If res.ToList.Count <> 0 Then
                Dis_SalList.ItemsSource = res.ToList
            End If
        End If

    End Sub

    Private Sub Men_btnQuitter_Click(sender As Object, e As RoutedEventArgs) Handles DispoS_btnQuitter.Click
        Me.Close()
    End Sub


    Private Sub DispoS_DatePicker_SelectedDateChanged(sender As Object, e As SelectionChangedEventArgs) Handles DispoS_DatePicker.SelectedDateChanged
        rafraichir()
    End Sub

    Private Sub DispoS_CmbBoxSalle_SelectionChanged(sender As Object, e As SelectionChangedEventArgs) Handles DispoS_CmbBoxSalle.SelectionChanged
        rafraichir()
    End Sub
End Class
