Public Class ModifFourniture
    Dim MaBD As P2014_BDTestFrancoisEntities
    Dim MaFourniture As tblFourniture

    Sub New(ByRef _MaBD As P2014_BDTestFrancoisEntities, Optional ByRef _MaFourniture As tblFourniture = Nothing)
        InitializeComponent()
        MaBD = _MaBD
        MaFourniture = _MaFourniture

        fournt_txtCodeFourniture.DataContext = MaFourniture
        fournt_txtDescFourniture.DataContext = MaFourniture
        fournt_txtNoSeqChambre.DataContext = MaFourniture
        fournt_txtCodeCategorie.DataContext = MaFourniture

        If MaFourniture IsNot Nothing Then
            fournt_txtCodeFourniture.IsEnabled = False
        Else
            fournt_txtCodeFourniture.IsEnabled = True
        End If
    End Sub

    Private Sub fournt_btnConfirmer_Click(sender As Object, e As RoutedEventArgs) Handles fournt_btnConfirmer.Click
        Try
            If MaFourniture Is Nothing Then
                MaFourniture = New tblFourniture()
                MaFourniture.CodeFourniture = fournt_txtCodeFourniture.Text
                MaFourniture.DescFourniture = fournt_txtDescFourniture.Text
                'MaFourniture.NoSeqChambre = fournt_txtNoSeqChambre.Text
                MaFourniture.CodeCategorie = fournt_txtCodeCategorie.Text

                MaBD.tblFourniture.Add(MaFourniture)
            End If
            MaBD.SaveChanges()
        Catch ex As Exception
            MaBD.tblFourniture.Remove(MaFourniture)
            MessageBox.Show("Existe deja")
        End Try

        Me.Close()
    End Sub
End Class
