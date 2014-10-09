Class MainWindow 
    Dim mabd As P2014_BDTestFrancoisEntities

    Private Sub MainWindow_Loaded(sender As Object, e As RoutedEventArgs) Handles Me.Loaded
        mabd = New P2014_BDTestFrancoisEntities()
    End Sub

    Private Sub log_btnConnexion_Click(sender As Object, e As RoutedEventArgs) Handles log_btnConnexion.Click
        Dim IdEmploye As String
        Dim MdpEmploye As String
        IdEmploye = log_txtIdentifiant.Text
        MdpEmploye = log_txtMotPasse.Password


        Dim res = From el In mabd.tblEmploye Where el.identifiantEmploye = IdEmploye And el.motDePasseEmploye = MdpEmploye Select el

        If res.ToList.Count = 0 Then
            log_lblTest.Content = "Fail"
        Else
            log_lblTest.Content = "Success !"
        End If







    End Sub
End Class
