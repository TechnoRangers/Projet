Public Class Forfait
    Dim MaBD As P2014_BD_GestionHotelEntities
    Sub New(ByRef _MaBD As P2014_BD_GestionHotelEntities)
        InitializeComponent()
        MaBD = _MaBD
    End Sub

    Private Sub for_frmForfait_Loaded(sender As Object, e As RoutedEventArgs) Handles for_frmForfait.Loaded
        Dim res = From tabForfait In MaBD.tblForfait
                      Select tabForfait

        for_dtgForfait.ItemsSource = res.ToList
    End Sub

    Private Sub for_btnAjouter_Click(sender As Object, e As RoutedEventArgs) Handles for_btnAjouter.Click
        Dim FenetreModifForfait As ModifForfait
        FenetreModifForfait = New ModifForfait(MaBD)
        FenetreModifForfait.ShowDialog()

        Dim res = From tabForfait In MaBD.tblForfait
                  Select tabForfait

        for_dtgForfait.ItemsSource = res.ToList
    End Sub

    Private Sub for_btnModifier_Click(sender As Object, e As RoutedEventArgs) Handles for_btnModifier.Click
        Try
            Dim ForfaitSelection As tblForfait = CType(for_dtgForfait.SelectedItem, tblForfait)

            Dim FenetreModifForfait As ModifForfait
            FenetreModifForfait = New ModifForfait(MaBD, ForfaitSelection)
            FenetreModifForfait.ShowDialog()
        Catch
            MessageBox.Show("Aucune row selectionné")
        End Try
    End Sub

    Private Sub for_btnSupprimer_Click(sender As Object, e As RoutedEventArgs) Handles for_btnSupprimer.Click
        Try
            Dim ForfaitSelection As tblForfait = for_dtgForfait.SelectedItem

            MaBD.tblForfait.Remove(ForfaitSelection)
            MaBD.SaveChanges()
        Catch
            MessageBox.Show("Aucune row selectionné")
        End Try

        Dim res = From tabForfait In MaBD.tblForfait
                  Select tabForfait

        for_dtgForfait.ItemsSource = res.ToList
    End Sub
End Class
