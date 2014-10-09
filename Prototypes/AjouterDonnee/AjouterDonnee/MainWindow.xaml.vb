Class MainWindow 
    Dim MaBD As P2014_BDTestFrancoisEntities

    Private Sub don_dtgChambres_Loaded(sender As Object, e As RoutedEventArgs) Handles don_dtgChambres.Loaded

        Dim res = From tabPays In MaBD.tblPays
                  Select tabPays

        don_dtgChambres.ItemsSource = res.ToList
    End Sub

    Private Sub Window_Loaded(sender As Object, e As RoutedEventArgs)
        MaBD = New P2014_BDTestFrancoisEntities()
    End Sub

    Private Sub don_btnSupprimer_Click(sender As Object, e As RoutedEventArgs) Handles don_btnSupprimer.Click
        Try
            Dim PaysSelection As tblPays = don_dtgChambres.SelectedItem

            MaBD.tblPays.Remove(PaysSelection)
            MaBD.SaveChanges()
        Catch
            MessageBox.Show("Aucune row selectionné")
        End Try

        Dim res = From tabPays In MaBD.tblPays
                  Select tabPays

        don_dtgChambres.ItemsSource = res.ToList

    End Sub

    Private Sub don_btnAjout_Click(sender As Object, e As RoutedEventArgs) Handles don_btnAjout.Click

        Dim FenetreAjouter As Ajouter
        FenetreAjouter = New Ajouter(MaBD)
        FenetreAjouter.ShowDialog()

        Dim res = From tabPays In MaBD.tblPays
                  Select tabPays

        don_dtgChambres.ItemsSource = res.ToList

    End Sub

    Private Sub don_btnModifier_Click(sender As Object, e As RoutedEventArgs) Handles don_btnModifier.Click
        Try
            Dim PaysSelection As tblPays = CType(don_dtgChambres.SelectedItem, tblPays)

            Dim FenetreAjouter As Ajouter
            FenetreAjouter = New Ajouter(MaBD, PaysSelection)
            FenetreAjouter.ShowDialog()
        Catch
            MessageBox.Show("Aucune row selectionné")
        End Try
    End Sub
End Class
