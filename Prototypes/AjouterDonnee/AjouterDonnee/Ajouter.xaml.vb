Public Class Ajouter

    Private _maBD As P2014_BDTestFrancoisEntities
    Dim Pays As tblPays

    Sub New(ByRef MaBD As P2014_BDTestFrancoisEntities, Optional ByRef _MonPays As tblPays = Nothing)
        InitializeComponent()
        _maBD = MaBD
        Pays = _MonPays
        txtCodePays.DataContext = Pays
        txtNomPays.DataContext = Pays
    End Sub

    Private Sub btnConfirm_Click(sender As Object, e As RoutedEventArgs) Handles btnConfirm.Click

        Try
            If Pays Is Nothing Then
                Pays = New tblPays()
                Pays.CodePays = txtCodePays.Text
                Pays.NomPays = txtNomPays.Text
                _maBD.tblPays.Add(Pays)
            End If
            _maBD.SaveChanges()
        Catch ex As Exception
            _maBD.tblPays.Remove(Pays)
            MessageBox.Show("Existe deja")
        End Try

        Me.Close()
    End Sub

End Class
