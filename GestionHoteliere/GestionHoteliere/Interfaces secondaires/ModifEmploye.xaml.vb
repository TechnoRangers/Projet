Public Class ModifEmploye
    Dim MaBD As P2014_BD_GestionHotelEntities
    Dim MonEmploye As tblEmploye
    Dim EnModif As Boolean

    Sub New(ByRef _MaBD As P2014_BD_GestionHotelEntities, Optional ByRef _MonEmploye As tblEmploye = Nothing)
        InitializeComponent()
        MaBD = _MaBD
        MonEmploye = _MonEmploye

        emp_txtNoEmploye.DataContext = MonEmploye
        emp_txtNomEmploye.DataContext = MonEmploye
        emp_txtPrenomEmploye.DataContext = MonEmploye
        emp_txtSexeEmploye.DataContext = MonEmploye
        emp_txtAdresseEmploye.DataContext = MonEmploye
        emp_txtTypeEmploi.DataContext = MonEmploye
        emp_txtNoTelephoneEmploye.DataContext = MonEmploye
        emp_txtNasEmploye.DataContext = MonEmploye
        emp_dtpDateNaissance.DataContext = MonEmploye
        emp_txtIdentifiantEmploye.DataContext = MonEmploye
        emp_txtMdpEmploye.DataContext = MonEmploye
        emp_txtCodeHotel.DataContext = MonEmploye
    End Sub

    Private Sub emp_btnConfirmer_Click(sender As Object, e As RoutedEventArgs) Handles emp_btnConfirmer.Click
        Try
            If MonEmploye Is Nothing Then
                MonEmploye = New tblEmploye()
                MonEmploye.NomEmploye = emp_txtNomEmploye.Text
                MonEmploye.PrenomEmploye = emp_txtPrenomEmploye.Text
                MonEmploye.SexeEmploye = emp_txtSexeEmploye.Text
                MonEmploye.AdresseEmploye = emp_txtAdresseEmploye.Text
                MonEmploye.TypeEmploi = emp_txtTypeEmploi.Text
                MonEmploye.NoTelephoneEmploye = emp_txtNoTelephoneEmploye.Text
                MonEmploye.NasEmploye = emp_txtNasEmploye.Text
                MonEmploye.DateNaissance = emp_dtpDateNaissance.SelectedDate
                MonEmploye.IdentifiantEmploye = emp_txtIdentifiantEmploye.Text
                MonEmploye.MdpEmploye = emp_txtMdpEmploye.Text
                MonEmploye.CodeHotel = emp_txtCodeHotel.Text

                MaBD.tblEmploye.Add(MonEmploye)
            End If
            MaBD.SaveChanges()
        Catch ex As Exception
            MaBD.tblEmploye.Remove(MonEmploye)
            MessageBox.Show("Erreur d'ajout de l'employe")
        End Try

        Me.Close()
    End Sub
End Class
