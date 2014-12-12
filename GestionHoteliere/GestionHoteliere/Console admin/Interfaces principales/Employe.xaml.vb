Public Class Employe
    Dim MaBD As P2014_BD_GestionHotelEntities

    Sub New(ByRef _MaBD As P2014_BD_GestionHotelEntities)
        InitializeComponent()
        MaBD = _MaBD
    End Sub

    Private Sub emp_frmEmploye_Loaded(sender As Object, e As RoutedEventArgs) Handles emp_frmEmploye.Loaded
        Dim res = From tabEmploye In MaBD.tblEmploye
                 Select tabEmploye

        emp_dtgEmploye.ItemsSource = res.ToList
    End Sub

    Private Sub emp_btnAjouter_Click(sender As Object, e As RoutedEventArgs) Handles emp_btnAjouter.Click
        Dim FenetreModifEmploye As ModifEmploye
        FenetreModifEmploye = New ModifEmploye(MaBD)
        FenetreModifEmploye.ShowDialog()

        Dim res = From tabEmploye In MaBD.tblEmploye
                  Select tabEmploye

        emp_dtgEmploye.ItemsSource = res.ToList
    End Sub

    Private Sub emp_btnModifier_Click(sender As Object, e As RoutedEventArgs) Handles emp_btnModifier.Click
        Try
            Dim EmployeSelection As tblEmploye = CType(emp_dtgEmploye.SelectedItem, tblEmploye)

            Dim FenetreModifEmploye As ModifEmploye
            FenetreModifEmploye = New ModifEmploye(MaBD, EmployeSelection)
            FenetreModifEmploye.ShowDialog()
        Catch
            MessageBox.Show("Aucune row selectionné")
        End Try
    End Sub

    Private Sub emp_btnSupprimer_Click(sender As Object, e As RoutedEventArgs) Handles emp_btnSupprimer.Click
        Try
            Dim EmployeSelection As tblEmploye = emp_dtgEmploye.SelectedItem

            MaBD.tblEmploye.Remove(EmployeSelection)
            MaBD.SaveChanges()
        Catch
            MessageBox.Show("Aucune row selectionné")
        End Try

        Dim res = From tabEmploye In MaBD.tblEmploye
                  Select tabEmploye

        emp_dtgEmploye.ItemsSource = res.ToList
    End Sub
End Class
