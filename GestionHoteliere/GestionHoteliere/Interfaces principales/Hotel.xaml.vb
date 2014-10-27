Public Class Hotel
    Dim MaBD As P2014_BD_GestionHotelEntities
    Sub New(ByRef _MaBD As P2014_BD_GestionHotelEntities)
        InitializeComponent()
        MaBD = _MaBD
    End Sub

    Private Sub hot_frmHotel_Loaded(sender As Object, e As RoutedEventArgs) Handles hot_frmHotel.Loaded
        Dim res = From tabHotel In MaBD.tblHotel
                  Select tabHotel

        hot_dtgHotel.ItemsSource = res.ToList
    End Sub

    Private Sub hot_btnAjouter_Click(sender As Object, e As RoutedEventArgs) Handles hot_btnAjouter.Click
        Dim FenetreModifHotel As ModifHotel
        FenetreModifHotel = New ModifHotel(MaBD)
        FenetreModifHotel.ShowDialog()

        Dim res = From tabHotel In MaBD.tblHotel
                  Select tabHotel

        hot_dtgHotel.ItemsSource = res.ToList
    End Sub

    Private Sub hot_btnModifier_Click(sender As Object, e As RoutedEventArgs) Handles hot_btnModifier.Click
        Try
            Dim HotelSelection As tblHotel = CType(hot_dtgHotel.SelectedItem, tblHotel)

            Dim FenetreModifHotel As ModifHotel
            FenetreModifHotel = New ModifHotel(MaBD, HotelSelection)
            FenetreModifHotel.ShowDialog()
        Catch
            MessageBox.Show("Aucune row selectionné")
        End Try
    End Sub

    Private Sub hot_btnSupprimer_Click(sender As Object, e As RoutedEventArgs) Handles hot_btnSupprimer.Click
        Try
            Dim HotelSelection As tblHotel = hot_dtgHotel.SelectedItem

            MaBD.tblHotel.Remove(HotelSelection)
            MaBD.SaveChanges()
        Catch
            MessageBox.Show("Aucune row selectionné")
        End Try

        Dim res = From tabHotel In MaBD.tblHotel
                  Select tabHotel

        hot_dtgHotel.ItemsSource = res.ToList
    End Sub
End Class
