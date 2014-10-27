Public Class EquipementRecreatif
    Dim MaBD As P2014_BD_GestionHotelEntities

    Sub New(ByRef _MaBD As P2014_BD_GestionHotelEntities)
        InitializeComponent()
        MaBD = _MaBD
    End Sub

    Private Sub eqrec_frmEquipementRecreatif_Loaded(sender As Object, e As RoutedEventArgs) Handles eqrec_frmEquipementRecreatif.Loaded
        Dim res = From tabEqRec In MaBD.tblEquipementRecreatif
                  Select tabEqRec

        eqrec_dtgEquipementRecreatif.ItemsSource = res.ToList
    End Sub

    Private Sub eqrec_btnAjouter_Click(sender As Object, e As RoutedEventArgs) Handles eqrec_btnAjouter.Click
        Dim FenetreModifEquipement As ModifEquipementRecreatif
        FenetreModifEquipement = New ModifEquipementRecreatif(MaBD)
        FenetreModifEquipement.ShowDialog()

        Dim res = From tabEqRec In MaBD.tblEquipementRecreatif
                  Select tabEqRec

        eqrec_dtgEquipementRecreatif.ItemsSource = res.ToList
    End Sub

    Private Sub eqrec_btnModifier_Click(sender As Object, e As RoutedEventArgs) Handles eqrec_btnModifier.Click
        Try
            Dim EquipementSelection As tblEquipementRecreatif = CType(eqrec_dtgEquipementRecreatif.SelectedItem, tblEquipementRecreatif)

            Dim FenetreModifEquipement As ModifEquipementRecreatif
            FenetreModifEquipement = New ModifEquipementRecreatif(MaBD, EquipementSelection)
            FenetreModifEquipement.ShowDialog()
        Catch
            MessageBox.Show("Aucune row selectionné")
        End Try
    End Sub

    Private Sub eqrec_btnSupprimer_Click(sender As Object, e As RoutedEventArgs) Handles eqrec_btnSupprimer.Click
        Try
            Dim EquipementSelection As tblEquipementRecreatif = eqrec_dtgEquipementRecreatif.SelectedItem

            MaBD.tblEquipementRecreatif.Remove(EquipementSelection)
            MaBD.SaveChanges()
        Catch
            MessageBox.Show("Aucune row selectionné")
        End Try

        Dim res = From tabEqRec In MaBD.tblEquipementRecreatif
                  Select tabEqRec

        eqrec_dtgEquipementRecreatif.ItemsSource = res.ToList
    End Sub
End Class
