Public Class ModifVille
    Dim MaBD As P2014_BD_GestionHotelEntities
    Dim MaVille As tblVille

    Sub New(ByRef _MaBD As P2014_BD_GestionHotelEntities, Optional ByRef _MaVille As tblVille = Nothing)
        InitializeComponent()
        MaBD = _MaBD
        MaVille = _MaVille

        vil_txtCodeVille.DataContext = MaVille
        vil_txtNomVille.DataContext = MaVille
        vil_txtCodeProvince.DataContext = MaVille

        If MaVille IsNot Nothing Then
            vil_txtCodeVille.IsEnabled = False
        Else
            vil_txtCodeVille.IsEnabled = True
        End If
    End Sub

    Private Sub vil_btnConfirmer_Click(sender As Object, e As RoutedEventArgs) Handles vil_btnConfirmer.Click
        Try
            If MaVille Is Nothing Then
                MaVille = New tblVille()
                MaVille.CodeVille = vil_txtCodeVille.Text
                MaVille.NomVille = vil_txtNomVille.Text
                MaBD.tblVille.Add(MaVille)
            End If
            MaBD.SaveChanges()
        Catch ex As Exception
            MaBD.tblVille.Remove(MaVille)
            MessageBox.Show("Existe deja")
        End Try

        Me.Close()
    End Sub
End Class
