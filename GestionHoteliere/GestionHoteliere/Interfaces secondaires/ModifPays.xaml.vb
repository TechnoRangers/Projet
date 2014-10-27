Public Class ModifPays
    Private MaBD As P2014_BD_GestionHotelEntities
    Dim Pays As tblPays

    Sub New(ByRef _MaBD As P2014_BD_GestionHotelEntities, Optional ByRef _MonPays As tblPays = Nothing)
        InitializeComponent()
        MaBD = _MaBD
        Pays = _MonPays
        pays_txtCodePays.DataContext = Pays
        pays_txtNomPays.DataContext = Pays

        If Pays IsNot Nothing Then
            pays_txtCodePays.IsEnabled = False
        Else
            pays_txtCodePays.IsEnabled = True
        End If
    End Sub

    Private Sub pays_btnConfimer_Click(sender As Object, e As RoutedEventArgs) Handles pays_btnConfimer.Click
        Try
            If Pays Is Nothing Then
                Pays = New tblPays()
                Pays.CodePays = pays_txtCodePays.Text
                Pays.NomPays = pays_txtNomPays.Text
                MaBD.tblPays.Add(Pays)
            End If
            MaBD.SaveChanges()
        Catch ex As Exception
            MaBD.tblPays.Remove(Pays)
            MessageBox.Show("Existe deja")
        End Try

        Me.Close()
    End Sub
End Class
