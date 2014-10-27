Public Class Facture
    Dim MaBd As P2014_BD_GestionHotelEntities

    Sub New(ByRef _MaBD As P2014_BD_GestionHotelEntities)
        InitializeComponent()
        MaBd = _MaBD
    End Sub

    Private Sub fac_frmFacture_Loaded(sender As Object, e As RoutedEventArgs) Handles fac_frmFacture.Loaded
        Dim res = From tabFacture In MaBd.tblFacture
                  Select tabFacture

        fac_dtgFacture.ItemsSource = res.ToList
    End Sub

    Private Sub fac_btnAjouter_Click(sender As Object, e As RoutedEventArgs) Handles fac_btnAjouter.Click
        Dim FenetreModifFacture As ModifFacture
        FenetreModifFacture = New ModifFacture(MaBd)
        FenetreModifFacture.ShowDialog()

        Dim res = From tabFacture In MaBd.tblFacture
                  Select tabFacture

        fac_dtgFacture.ItemsSource = res.ToList
    End Sub

    Private Sub fac_btnModifier_Click(sender As Object, e As RoutedEventArgs) Handles fac_btnModifier.Click
        Try
            Dim FactureSelection As tblFacture = CType(fac_dtgFacture.SelectedItem, tblFacture)

            Dim FenetreModifFacture As ModifFacture
            FenetreModifFacture = New ModifFacture(MaBd, FactureSelection)
            FenetreModifFacture.ShowDialog()
        Catch
            MessageBox.Show("Aucune row selectionné")
        End Try
    End Sub

    Private Sub fac_btnSupprimer_Click(sender As Object, e As RoutedEventArgs) Handles fac_btnSupprimer.Click
        Try
            Dim FactureSelection As tblFacture = fac_dtgFacture.SelectedItem

            MaBd.tblFacture.Remove(FactureSelection)
            MaBd.SaveChanges()
        Catch
            MessageBox.Show("Aucune row selectionné")
        End Try

        Dim res = From tabFacture In MaBd.tblFacture
                  Select tabFacture

        fac_dtgFacture.ItemsSource = res.ToList
    End Sub
End Class
