Public Class CategorieFourniture
    Dim MaBD As P2014_BD_GestionHotelEntities

    Sub New(ByRef _MaBD As P2014_BD_GestionHotelEntities)
        InitializeComponent()
        MaBD = _MaBD
    End Sub

    Private Sub catfour_frmCategorieFourniture_Loaded(sender As Object, e As RoutedEventArgs) Handles catfour_frmCategorieFourniture.Loaded
        Dim res = From tabCategorieFourniture In MaBD.tblCategorieFourniture
                 Select tabCategorieFourniture

        catfour_dtgCategorieFourniture.ItemsSource = res.ToList
    End Sub

    Private Sub catfour_btnAjouter_Click(sender As Object, e As RoutedEventArgs) Handles catfour_btnAjouter.Click
        Dim FenetreModifCategorieFourniture As ModifCategorieFourniture
        FenetreModifCategorieFourniture = New ModifCategorieFourniture(MaBD)
        FenetreModifCategorieFourniture.ShowDialog()

        Dim res = From tabCategorieFourniture In MaBD.tblCategorieFourniture
                  Select tabCategorieFourniture

        catfour_dtgCategorieFourniture.ItemsSource = res.ToList
    End Sub

    Private Sub catfour_btnModifier_Click(sender As Object, e As RoutedEventArgs) Handles catfour_btnModifier.Click
        Try
            Dim CategorieFournitureSelection As tblCategorieFourniture = CType(catfour_dtgCategorieFourniture.SelectedItem, tblCategorieFourniture)

            Dim FenetreModifCategorieFourniture As ModifCategorieFourniture
            FenetreModifCategorieFourniture = New ModifCategorieFourniture(MaBD, CategorieFournitureSelection)
            FenetreModifCategorieFourniture.ShowDialog()
        Catch
            MessageBox.Show("Aucune row selectionné")
        End Try
    End Sub

    Private Sub catfour_btnSupprimer_Click(sender As Object, e As RoutedEventArgs) Handles catfour_btnSupprimer.Click
        Try
            Dim CategorieFournitureSelection As tblCategorieFourniture = catfour_dtgCategorieFourniture.SelectedItem

            MaBD.tblCategorieFourniture.Remove(CategorieFournitureSelection)
            MaBD.SaveChanges()
        Catch
            MessageBox.Show("Aucune row selectionné")
        End Try

        Dim res = From tabCategorieFourniture In MaBD.tblCategorieFourniture
                  Select tabCategorieFourniture

        catfour_dtgCategorieFourniture.ItemsSource = res.ToList
    End Sub
End Class
