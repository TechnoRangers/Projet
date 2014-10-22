Public Class ListeReservation
    Dim MaBD As P2014_BDTestFrancoisEntities

    Sub New(ByRef _MaBD As P2014_BDTestFrancoisEntities)
        InitializeComponent()
        MaBD = _MaBD
    End Sub

    Private Sub lres_frmReservation_Loaded(sender As Object, e As RoutedEventArgs) Handles lres_frmReservation.Loaded
        Dim res = From tabReserv In MaBD.tblReservationChambre
                  Select tabReserv

        lres_dtgreservation.ItemsSource = res.ToList
    End Sub



    Private Sub lres_btnModifier_Click(sender As Object, e As RoutedEventArgs) Handles lres_btnModifier.Click
        Try
            Dim ReservSelection As tblReservationChambre = CType(lres_dtgreservation.SelectedItem, tblReservationChambre)

            Dim FenetreModifReserv As ModifReservation
            FenetreModifReserv = New ModifReservation(MaBD, ReservSelection)
            FenetreModifReserv.ShowDialog()
        Catch
            MessageBox.Show("Aucune row selectionné")
        End Try
    End Sub
    Private Sub lres_btnSupprimer_Click(sender As Object, e As RoutedEventArgs) Handles lres_btnSupprimer.Click
        Try
            Dim ReservSelection As tblReservationChambre = lres_dtgreservation.SelectedItem

            MaBD.tblReservationChambre.Remove(ReservSelection)
            MaBD.SaveChanges()
        Catch
            MessageBox.Show("Aucune row selectionné")
        End Try

        Dim res = From tabReservationChambre In MaBD.tblReservationChambre
                  Select tabReservationChambre

        lres_dtgreservation.ItemsSource = res.ToList
    End Sub

    Private Sub lres_btnQuitter_Click(sender As Object, e As RoutedEventArgs) Handles lres_btnQuitter.Click
        Me.Close()
    End Sub
End Class
