Public Class ModifForfait
    Dim MaBD As P2014_BD_GestionHotelEntities
    Dim MonForfait As tblForfait

    Sub New(ByRef _MaBD As P2014_BD_GestionHotelEntities, Optional ByRef _MonForfait As tblForfait = Nothing)
        InitializeComponent()
        MaBD = _MaBD
        MonForfait = _MonForfait

        for_txtCodeForfait.DataContext = MonForfait
        for_txtNomForfait.DataContext = MonForfait
        for_txtPrixForfait.DataContext = MonForfait
        for_txtDescForfait.DataContext = MonForfait
        for_txtNbNuit.DataContext = MonForfait

        If MonForfait IsNot Nothing Then
            for_txtCodeForfait.IsEnabled = False
        Else
            for_txtCodeForfait.IsEnabled = True
        End If
    End Sub

    Private Sub for_btnConfirmer_Click(sender As Object, e As RoutedEventArgs) Handles for_btnConfirmer.Click
        Try
            If MonForfait Is Nothing Then
                MonForfait = New tblForfait()
                MonForfait.CodeForfait = for_txtCodeForfait.Text
                MonForfait.NomForfait = for_txtNomForfait.Text
                MonForfait.PrixForfait = for_txtPrixForfait.Text
                MonForfait.DescForfait = for_txtDescForfait.Text
                MonForfait.DescForfait = for_txtDescForfait.Text
                MonForfait.NbNuit = for_txtNbNuit.Text

                MaBD.tblForfait.Add(MonForfait)
            End If
            MaBD.SaveChanges()
        Catch ex As Exception
            MaBD.tblForfait.Remove(MonForfait)
            MessageBox.Show("Existe deja")
        End Try

        Me.Close()
    End Sub
End Class
