Public Class TypeChambre
    Dim MaBD As P2014_BD_GestionHotelEntities

    Sub New(ByRef _MaBD As P2014_BD_GestionHotelEntities)
        InitializeComponent()
        MaBD = _MaBD
    End Sub

    Private Sub typchamb_frmTypeChambre_Loaded(sender As Object, e As RoutedEventArgs) Handles typchamb_frmTypeChambre.Loaded
        Dim res = From tabTypeChambre In MaBD.tblTypeChambre
                  Select tabTypeChambre

        typchamb_dtgTypeChambre.ItemsSource = res.ToList
    End Sub

    Private Sub typchamb_btnAjouter_Click(sender As Object, e As RoutedEventArgs) Handles typchamb_btnAjouter.Click
        Dim FenetreModifTypeChambre As ModifTypeChambre
        FenetreModifTypeChambre = New ModifTypeChambre(MaBD)
        FenetreModifTypeChambre.ShowDialog()

        Dim res = From tabTypeChambre In MaBD.tblTypeChambre
                  Select tabTypeChambre

        typchamb_dtgTypeChambre.ItemsSource = res.ToList
    End Sub

    Private Sub typchamb_btnModifier_Click(sender As Object, e As RoutedEventArgs) Handles typchamb_btnModifier.Click
        Try
            Dim TypeChambreSelection As tblTypeChambre = CType(typchamb_dtgTypeChambre.SelectedItem, tblTypeChambre)

            Dim FenetreModifTypeChambre As ModifTypeChambre
            FenetreModifTypeChambre = New ModifTypeChambre(MaBD, TypeChambreSelection)
            FenetreModifTypeChambre.ShowDialog()
        Catch
            MessageBox.Show("Aucune row selectionné")
        End Try
    End Sub

    Private Sub typchamb_btnSupprimer_Click(sender As Object, e As RoutedEventArgs) Handles typchamb_btnSupprimer.Click
        Try
            Dim TypeChambreSelection As tblTypeChambre = typchamb_dtgTypeChambre.SelectedItem

            MaBD.tblTypeChambre.Remove(TypeChambreSelection)
            MaBD.SaveChanges()
        Catch
            MessageBox.Show("Aucune row selectionné")
        End Try

        Dim res = From tabTypeChambre In MaBD.tblTypeChambre
                  Select tabTypeChambre

        typchamb_dtgTypeChambre.ItemsSource = res.ToList
    End Sub
End Class
