Public Class EquipementGeneriqueChambre
    Dim MaBD As P2014_BD_GestionHotelEntities

    Sub New(ByRef _MaBD As P2014_BD_GestionHotelEntities)
        InitializeComponent()
        MaBD = _MaBD
    End Sub

    Private Sub eqgenchamb_frmEquipementGeneriqueChambre_Loaded(sender As Object, e As RoutedEventArgs) Handles eqgenchamb_frmEquipementGeneriqueChambre.Loaded
        Dim res = From tabEqGenChamb In MaBD.tblEquipementGeneriqueChambre
                      Select tabEqGenChamb

        eqgenchamb_dtgEquipementGenChambre.ItemsSource = res.ToList
    End Sub

    Private Sub eqgenchamb_btnAjouter_Click(sender As Object, e As RoutedEventArgs) Handles eqgenchamb_btnAjouter.Click
        Dim FenetreModifEqGenChamb As ModifEquipementGenChambre
        FenetreModifEqGenChamb = New ModifEquipementGenChambre(MaBD)
        FenetreModifEqGenChamb.ShowDialog()

        Dim res = From tabEqGenChamb In MaBD.tblEquipementGeneriqueChambre
                  Select tabEqGenChamb

        eqgenchamb_dtgEquipementGenChambre.ItemsSource = res.ToList
    End Sub

    Private Sub eqgenchamb_btnModifier_Click(sender As Object, e As RoutedEventArgs) Handles eqgenchamb_btnModifier.Click
        Try
            Dim EqGenChambSelection As tblEquipementGeneriqueChambre = CType(eqgenchamb_dtgEquipementGenChambre.SelectedItem, tblEquipementGeneriqueChambre)

            Dim FenetreModifEqGenChamb As ModifEquipementGenChambre
            FenetreModifEqGenChamb = New ModifEquipementGenChambre(MaBD, EqGenChambSelection)
            FenetreModifEqGenChamb.ShowDialog()
        Catch
            MessageBox.Show("Aucune row selectionné")
        End Try
    End Sub

    Private Sub eqgenchamb_btnSupprimer_Click(sender As Object, e As RoutedEventArgs) Handles eqgenchamb_btnSupprimer.Click
        Try
            Dim EqGenChambSelection As tblEquipementGeneriqueChambre = eqgenchamb_dtgEquipementGenChambre.SelectedItem

            MaBD.tblEquipementGeneriqueChambre.Remove(EqGenChambSelection)
            MaBD.SaveChanges()
        Catch
            MessageBox.Show("Aucune row selectionné")
        End Try

        Dim res = From tabEqGenChamb In MaBD.tblEquipementGeneriqueChambre
                  Select tabEqGenChamb

        eqgenchamb_dtgEquipementGenChambre.ItemsSource = res.ToList
    End Sub
End Class
