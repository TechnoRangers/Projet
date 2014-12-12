Public Class ModifCategorieFourniture
    Dim MaBD As P2014_BD_GestionHotelEntities
    Dim MaCategorieFourniture As tblCategorieFourniture

    Sub New(ByRef _MaBD As P2014_BD_GestionHotelEntities, Optional ByRef _MaCategorieFourniture As tblCategorieFourniture = Nothing)
        InitializeComponent()
        MaBD = _MaBD
        MaCategorieFourniture = _MaCategorieFourniture

        catfour_txtCodeCategorie.DataContext = MaCategorieFourniture
        catfour_txtNomCategorie.DataContext = MaCategorieFourniture

        If MaCategorieFourniture IsNot Nothing Then
            catfour_txtCodeCategorie.IsEnabled = False
        Else
            catfour_txtCodeCategorie.IsEnabled = True
        End If

    End Sub

    Private Sub catfour_btnConfirmer_Click(sender As Object, e As RoutedEventArgs) Handles catfour_btnConfirmer.Click
        Try
            If MaCategorieFourniture Is Nothing Then
                MaCategorieFourniture = New tblCategorieFourniture()
                MaCategorieFourniture.CodeCategorie = catfour_txtCodeCategorie.Text
                MaCategorieFourniture.NomCategorie = catfour_txtNomCategorie.Text

                MaBD.tblCategorieFourniture.Add(MaCategorieFourniture)
            End If
            MaBD.SaveChanges()
        Catch ex As Exception
            MaBD.tblCategorieFourniture.Remove(MaCategorieFourniture)
            MessageBox.Show("Existe deja")
        End Try

        Me.Close()
    End Sub
End Class
