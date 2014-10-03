Public Class ModifEquipementRecreatif
    Dim MaBD As P2014_BDTestFrancoisEntities
    Dim MonEquipement As tblEquipementRecreatif

    Sub New(ByRef _MaBD As P2014_BDTestFrancoisEntities, Optional ByRef _MonEquipement As tblEquipementRecreatif = Nothing)
        InitializeComponent()
        MaBD = _MaBD
        MonEquipement = _MonEquipement

        eqrec_txtCodeEquipementRecreatif.DataContext = MonEquipement
        eqrec_txtNomEquipement.DataContext = MonEquipement
        eqrec_txtCategorieEquipement.DataContext = MonEquipement
        eqrec_dtpDateAquisition.DataContext = MonEquipement
        eqrec_dtpDateFinGarantie.DataContext = MonEquipement

        If MonEquipement IsNot Nothing Then
            eqrec_txtCodeEquipementRecreatif.IsEnabled = False
        Else
            eqrec_txtCodeEquipementRecreatif.IsEnabled = True
        End If
    End Sub

    Private Sub eqrec_btnConfirmer_Click(sender As Object, e As RoutedEventArgs) Handles eqrec_btnConfirmer.Click
        Try
            If MonEquipement Is Nothing Then
                MonEquipement = New tblEquipementRecreatif()
                MonEquipement.CodeEquipementRecreatif = eqrec_txtCodeEquipementRecreatif.Text
                MonEquipement.NomEquipement = eqrec_txtNomEquipement.Text
                MonEquipement.CategorieEquipement = eqrec_txtCategorieEquipement.Text
                MonEquipement.DateAquisition = eqrec_dtpDateAquisition.SelectedDate
                MonEquipement.DateFinGarantie = eqrec_dtpDateFinGarantie.SelectedDate

                MaBD.tblEquipementRecreatif.Add(MonEquipement)
            End If
            MaBD.SaveChanges()
        Catch ex As Exception
            MaBD.tblEquipementRecreatif.Remove(MonEquipement)
            MessageBox.Show("Existe deja")
        End Try

        Me.Close()
    End Sub
End Class
