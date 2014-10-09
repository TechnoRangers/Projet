Public Class ModifTypeChambre
    Dim MaBD As P2014_BDTestFrancoisEntities
    Dim MonTypeChambre As tblTypeChambre

    Sub New(ByRef _MaBD As P2014_BDTestFrancoisEntities, Optional ByRef _MonTypeChambre As tblTypeChambre = Nothing)
        InitializeComponent()
        MaBD = _MaBD
        MonTypeChambre = _MonTypeChambre

        typchamb_txtCodeTypeChambre.DataContext = MonTypeChambre
        typchamb_txtNomTypeChamb.DataContext = MonTypeChambre
        typchamb_txtDescTypeChambre.DataContext = MonTypeChambre

        If MonTypeChambre IsNot Nothing Then
            typchamb_txtCodeTypeChambre.IsEnabled = False
        Else
            typchamb_txtCodeTypeChambre.IsEnabled = True
        End If
    End Sub

    Private Sub typchamb_btnConfirmer_Click(sender As Object, e As RoutedEventArgs) Handles typchamb_btnConfirmer.Click
        Try
            If MonTypeChambre Is Nothing Then
                MonTypeChambre = New tblTypeChambre()
                MonTypeChambre.CodeTypeChambre = typchamb_txtCodeTypeChambre.Text
                MonTypeChambre.NomTypeChambre = typchamb_txtNomTypeChamb.Text

                MaBD.tblTypeChambre.Add(MonTypeChambre)
            End If
            MaBD.SaveChanges()
        Catch ex As Exception
            MaBD.tblTypeChambre.Remove(MonTypeChambre)
            MessageBox.Show("Existe deja")
        End Try

        Me.Close()
    End Sub
End Class
