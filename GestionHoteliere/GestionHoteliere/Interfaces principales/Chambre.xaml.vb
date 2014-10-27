Public Class Chambre
    Dim MaBD As P2014_BD_GestionHotelEntities

    Sub New(ByRef _MaBD As P2014_BD_GestionHotelEntities)
        InitializeComponent()
        MaBD = _MaBD
    End Sub

    Private Sub chamb_frmChambre_Loaded(sender As Object, e As RoutedEventArgs) Handles chamb_frmChambre.Loaded
        Dim res = From tabChambre In MaBD.tblChambre
                  Select tabChambre

        chamb_dtgChambre.ItemsSource = res.ToList
    End Sub

    Private Sub chamb_btnAjouter_Click(sender As Object, e As RoutedEventArgs) Handles chamb_btnAjouter.Click
        Dim FenetreModifChambre As ModifChambre
        FenetreModifChambre = New ModifChambre(MaBD)
        FenetreModifChambre.ShowDialog()

        Dim res = From tabChambre In MaBD.tblChambre
                  Select tabChambre

        chamb_dtgChambre.ItemsSource = res.ToList
    End Sub

    Private Sub chamb_btnModifier_Click(sender As Object, e As RoutedEventArgs) Handles chamb_btnModifier.Click
        Try
            Dim ChambreSelection As tblChambre = CType(chamb_dtgChambre.SelectedItem, tblChambre)

            Dim FenetreModifChambre As ModifChambre
            FenetreModifChambre = New ModifChambre(MaBD, ChambreSelection)
            FenetreModifChambre.ShowDialog()
        Catch
            MessageBox.Show("Aucune row selectionné")
        End Try
    End Sub

    Private Sub chamb_btnSupprimer_Click(sender As Object, e As RoutedEventArgs) Handles chamb_btnSupprimer.Click
        Try
            Dim ChambreSelection As tblChambre = chamb_dtgChambre.SelectedItem

            MaBD.tblChambre.Remove(ChambreSelection)
            MaBD.SaveChanges()
        Catch
            MessageBox.Show("Aucune row selectionné")
        End Try

        Dim res = From tabChambre In MaBD.tblChambre
                  Select tabChambre

        chamb_dtgChambre.ItemsSource = res.ToList
    End Sub
End Class
