Public Class ModifFournisseur
    Dim MaBD As P2014_BDTestFrancoisEntities
    Dim MonFournisseur As tblFournisseur
    Sub New(ByRef _MaBD As P2014_BDTestFrancoisEntities, Optional ByRef _MonFournisseur As tblFournisseur = Nothing)
        InitializeComponent()
        MaBD = _MaBD
        MonFournisseur = _MonFournisseur

        four_txtCodeFournisseur.DataContext = MonFournisseur
        four_txtNomFournisseur.DataContext = MonFournisseur
        four_txtAdresseFournisseur.DataContext = MonFournisseur
        four_txtNomRepresentant.DataContext = MonFournisseur
        four_txtPrenomRepresentant.DataContext = MonFournisseur

        If MonFournisseur IsNot Nothing Then
            four_txtCodeFournisseur.IsEnabled = False
        Else
            four_txtCodeFournisseur.IsEnabled = True
        End If
    End Sub

    Private Sub four_btnConfirmer_Click(sender As Object, e As RoutedEventArgs) Handles four_btnConfirmer.Click
        Try
            If MonFournisseur Is Nothing Then
                MonFournisseur = New tblFournisseur()
                MonFournisseur.CodeFournisseur = four_txtCodeFournisseur.Text
                MonFournisseur.NomFournisseur = four_txtNomFournisseur.Text
                MonFournisseur.AdresseFournisseur = four_txtAdresseFournisseur.Text
                MonFournisseur.NomFournisseur = four_txtNomRepresentant.Text
                MonFournisseur.PrenomRepresentant = four_txtPrenomRepresentant.Text
            

                MaBD.tblFournisseur.Add(MonFournisseur)
            End If
            MaBD.SaveChanges()
        Catch ex As Exception
            MaBD.tblFournisseur.Remove(MonFournisseur)
            MessageBox.Show("Existe deja")
        End Try

        Me.Close()
    End Sub
End Class
