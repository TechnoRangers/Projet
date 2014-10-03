Public Class Fourniture
    Dim MaBD As P2014_BDTestFrancoisEntities

    Sub New(ByRef _MaBD As P2014_BDTestFrancoisEntities)
        InitializeComponent()
        MaBD = _MaBD
    End Sub

    Private Sub fournt_frmFourniture_Loaded(sender As Object, e As RoutedEventArgs) Handles fournt_frmFourniture.Loaded
        Dim res = From tabFourniture In MaBD.tblFourniture
                 Select tabFourniture

        fournt_dtgFourniture.ItemsSource = res.ToList
    End Sub

    Private Sub fournt_btnAjouter_Click(sender As Object, e As RoutedEventArgs) Handles fournt_btnAjouter.Click
        Dim FenetreModifFourniture As ModifFourniture
        FenetreModifFourniture = New ModifFourniture(MaBD)
        FenetreModifFourniture.ShowDialog()

        Dim res = From tabFourniture In MaBD.tblFourniture
                  Select tabFourniture

        fournt_dtgFourniture.ItemsSource = res.ToList
    End Sub

    Private Sub fournt_btnModifier_Click(sender As Object, e As RoutedEventArgs) Handles fournt_btnModifier.Click
        Try
            Dim FournitureSelection As tblFourniture = CType(fournt_dtgFourniture.SelectedItem, tblFourniture)

            Dim FenetreModifFourniture As ModifFourniture
            FenetreModifFourniture = New ModifFourniture(MaBD, FournitureSelection)
            FenetreModifFourniture.ShowDialog()
        Catch
            MessageBox.Show("Aucune row selectionné")
        End Try
    End Sub

    Private Sub fournt_btnSupprimer_Click(sender As Object, e As RoutedEventArgs) Handles fournt_btnSupprimer.Click
        Try
            Dim FournitureSelection As tblFourniture = fournt_dtgFourniture.SelectedItem

            MaBD.tblFourniture.Remove(FournitureSelection)
            MaBD.SaveChanges()
        Catch
            MessageBox.Show("Aucune row selectionné")
        End Try

        Dim res = From tabFourniture In MaBD.tblFourniture
                  Select tabFourniture

        fournt_dtgFourniture.ItemsSource = res.ToList
    End Sub
End Class
