Public Class Ville
    Dim MaBD As P2014_BD_GestionHotelEntities

    Sub New(ByRef _MaBD As P2014_BD_GestionHotelEntities)
        InitializeComponent()
        MaBD = _MaBD
    End Sub

    Private Sub vil_frmVille_Loaded(sender As Object, e As RoutedEventArgs) Handles vil_frmVille.Loaded
        Dim res = From tabVille In MaBD.tblVille
                  Select tabVille

        vil_dtgVille.ItemsSource = res.ToList
    End Sub

    Private Sub vil_btnAjouter_Click(sender As Object, e As RoutedEventArgs) Handles vil_btnAjouter.Click
        Dim FenetreModifVille As ModifVille
        FenetreModifVille = New ModifVille(MaBD)
        FenetreModifVille.ShowDialog()

        Dim res = From tabVille In MaBD.tblVille
                  Select tabVille

        vil_dtgVille.ItemsSource = res.ToList
    End Sub

    Private Sub vil_btnModifier_Click(sender As Object, e As RoutedEventArgs) Handles vil_btnModifier.Click
        Try
            Dim VilleSelection As tblVille = CType(vil_dtgVille.SelectedItem, tblVille)

            Dim FenetreModifVille As ModifVille
            FenetreModifVille = New ModifVille(MaBD, VilleSelection)
            FenetreModifVille.ShowDialog()
        Catch
            MessageBox.Show("Aucune row selectionné")
        End Try
    End Sub

    Private Sub vil_btnSupprimer_Click(sender As Object, e As RoutedEventArgs) Handles vil_btnSupprimer.Click
        Try
            Dim VilleSelection As tblVille = vil_dtgVille.SelectedItem

            MaBD.tblVille.Remove(VilleSelection)
            MaBD.SaveChanges()
        Catch
            MessageBox.Show("Aucune row selectionné")
        End Try

        Dim res = From tabVille In MaBD.tblVille
                  Select tabVille

        vil_dtgVille.ItemsSource = res.ToList
    End Sub
End Class
