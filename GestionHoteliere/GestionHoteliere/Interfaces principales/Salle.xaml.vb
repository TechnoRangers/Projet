Public Class Salle
    Dim MaBD As P2014_BD_GestionHotelEntities
    Sub New(ByRef _MaBD As P2014_BD_GestionHotelEntities)
        InitializeComponent()
        MaBD = _MaBD
    End Sub

    Private Sub sal_frmSalle_Loaded(sender As Object, e As RoutedEventArgs) Handles sal_frmSalle.Loaded
        Dim res = From tabSalle In MaBD.tblSalle
                  Select tabSalle

        sal_dtgSalle.ItemsSource = res.ToList
    End Sub

    Private Sub sal_btnAjouter_Click(sender As Object, e As RoutedEventArgs) Handles sal_btnAjouter.Click
        Dim FenetreModifSalle As ModifSalle
        FenetreModifSalle = New ModifSalle(MaBD)
        FenetreModifSalle.ShowDialog()

        Dim res = From tabSalle In MaBD.tblSalle
                  Select tabSalle

        sal_dtgSalle.ItemsSource = res.ToList
    End Sub

    Private Sub sal_btnModifier_Click(sender As Object, e As RoutedEventArgs) Handles sal_btnModifier.Click
        Try
            Dim SalleSelection As tblSalle = CType(sal_dtgSalle.SelectedItem, tblSalle)

            Dim FenetreModifSalle As ModifSalle
            FenetreModifSalle = New ModifSalle(MaBD, SalleSelection)
            FenetreModifSalle.ShowDialog()
        Catch
            MessageBox.Show("Aucune row selectionné")
        End Try
    End Sub

    Private Sub sal_btnSupprimer_Click(sender As Object, e As RoutedEventArgs) Handles sal_btnSupprimer.Click
        Try
            Dim SalleSelection As tblSalle = sal_dtgSalle.SelectedItem

            MaBD.tblSalle.Remove(SalleSelection)
            MaBD.SaveChanges()
        Catch
            MessageBox.Show("Aucune row selectionné")
        End Try

        Dim res = From tabSalle In MaBD.tblSalle
                  Select tabSalle

        sal_dtgSalle.ItemsSource = res.ToList
    End Sub
End Class
