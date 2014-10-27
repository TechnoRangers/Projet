Public Class Pays
    Private MaBD As P2014_BD_GestionHotelEntities
    Sub New(ByRef _MaBD As P2014_BD_GestionHotelEntities)
        InitializeComponent()
        MaBD = _MaBD
    End Sub

    Private Sub pays_frmPays_Loaded(sender As Object, e As RoutedEventArgs) Handles pays_frmPays.Loaded
        Dim res = From tabPays In MaBD.tblPays
                  Select tabPays

        pays_dtgPays.ItemsSource = res.ToList
    End Sub

    Private Sub pays_btnAjouter_Click(sender As Object, e As RoutedEventArgs) Handles pays_btnAjouter.Click
        Dim FenetreModifPays As ModifPays
        FenetreModifPays = New ModifPays(MaBD)
        FenetreModifPays.ShowDialog()

        Dim res = From tabPays In MaBD.tblPays
                  Select tabPays

        pays_dtgPays.ItemsSource = res.ToList
    End Sub

    Private Sub pays_btnModifier_Click(sender As Object, e As RoutedEventArgs) Handles pays_btnModifier.Click
        Try
            Dim PaysSelection As tblPays = CType(pays_dtgPays.SelectedItem, tblPays)

            Dim FenetreModifPays As ModifPays
            FenetreModifPays = New ModifPays(MaBD, PaysSelection)
            FenetreModifPays.ShowDialog()
        Catch
            MessageBox.Show("Aucune row selectionné")
        End Try
    End Sub

    Private Sub pays_btnSupprimer_Click(sender As Object, e As RoutedEventArgs) Handles pays_btnSupprimer.Click
        Try
            Dim PaysSelection As tblPays = pays_dtgPays.SelectedItem

            MaBD.tblPays.Remove(PaysSelection)
            MaBD.SaveChanges()
        Catch
            MessageBox.Show("Aucune row selectionné")
        End Try

        Dim res = From tabPays In MaBD.tblPays
                  Select tabPays

        pays_dtgPays.ItemsSource = res.ToList
    End Sub
End Class
