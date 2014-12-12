Public Class Fournisseur
    Dim MaBD As P2014_BD_GestionHotelEntities

    Sub New(ByRef _MaBD As P2014_BD_GestionHotelEntities)
        InitializeComponent()
        MaBD = _MaBD
    End Sub

    Private Sub four_frmFournisseur_Loaded(sender As Object, e As RoutedEventArgs) Handles four_frmFournisseur.Loaded
        Dim res = From tabFournisseur In MaBD.tblFournisseur
                  Select tabFournisseur

        four_dtgFournisseur.ItemsSource = res.ToList
    End Sub

    Private Sub four_btnAjouter_Click(sender As Object, e As RoutedEventArgs) Handles four_btnAjouter.Click
        Dim FenetreModifFournisseur As ModifFournisseur
        FenetreModifFournisseur = New ModifFournisseur(MaBD)
        FenetreModifFournisseur.ShowDialog()

        Dim res = From tabFournisseur In MaBD.tblFournisseur
                  Select tabFournisseur

        four_dtgFournisseur.ItemsSource = res.ToList
    End Sub

    Private Sub four_btnModifier_Click(sender As Object, e As RoutedEventArgs) Handles four_btnModifier.Click
        Try
            Dim FournisseurSelection As tblFournisseur = CType(four_dtgFournisseur.SelectedItem, tblFournisseur)

            Dim FenetreModifFournisseur As ModifFournisseur
            FenetreModifFournisseur = New ModifFournisseur(MaBD, FournisseurSelection)
            FenetreModifFournisseur.ShowDialog()
        Catch
            MessageBox.Show("Aucune row selectionné")
        End Try
    End Sub

    Private Sub four_btnSupprimer_Click(sender As Object, e As RoutedEventArgs) Handles four_btnSupprimer.Click
        Try
            Dim FournisseurSelection As tblFournisseur = four_dtgFournisseur.SelectedItem

            MaBD.tblFournisseur.Remove(FournisseurSelection)
            MaBD.SaveChanges()
        Catch
            MessageBox.Show("Aucune row selectionné")
        End Try

        Dim res = From tabFournisseur In MaBD.tblFournisseur
                  Select tabFournisseur

        four_dtgFournisseur.ItemsSource = res.ToList
    End Sub
End Class
