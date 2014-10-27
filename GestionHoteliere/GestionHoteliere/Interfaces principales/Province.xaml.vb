Public Class Province
    Dim MaBD As P2014_BD_GestionHotelEntities

    Sub New(ByRef _MaBD As P2014_BD_GestionHotelEntities)
        InitializeComponent()
        MaBD = _MaBD
    End Sub

    Private Sub pro_frmProvince_Loaded(sender As Object, e As RoutedEventArgs) Handles pro_frmProvince.Loaded
        Dim res = From tabProvince In MaBD.tblProvince
                  Select tabProvince

        pro_dtgProvince.ItemsSource = res.ToList
    End Sub

    Private Sub pro_btnAjouter_Click(sender As Object, e As RoutedEventArgs) Handles pro_btnAjouter.Click
        Dim FenetreModifProvince As ModifProvince
        FenetreModifProvince = New ModifProvince(MaBD)
        FenetreModifProvince.ShowDialog()

        Dim res = From tabProvince In MaBD.tblProvince
                  Select tabProvince

        pro_dtgProvince.ItemsSource = res.ToList
    End Sub

    Private Sub pro_btnModifier_Click(sender As Object, e As RoutedEventArgs) Handles pro_btnModifier.Click
        Try
            Dim ProvinceSelection As tblProvince = CType(pro_dtgProvince.SelectedItem, tblProvince)

            Dim FenetreModifProvince As ModifProvince
            FenetreModifProvince = New ModifProvince(MaBD, ProvinceSelection)
            FenetreModifProvince.ShowDialog()
        Catch
            MessageBox.Show("Aucune row selectionné")
        End Try
    End Sub

    Private Sub pro_btnSupprimer_Click(sender As Object, e As RoutedEventArgs) Handles pro_btnSupprimer.Click
        Try
            Dim ProvinceSelection As tblProvince = pro_dtgProvince.SelectedItem

            MaBD.tblProvince.Remove(ProvinceSelection)
            MaBD.SaveChanges()
        Catch
            MessageBox.Show("Aucune row selectionné")
        End Try

        Dim res = From tabProvince In MaBD.tblProvince
                  Select tabProvince

        pro_dtgProvince.ItemsSource = res.ToList
    End Sub
End Class
