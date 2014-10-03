Public Class Horaire

    Dim BD As P2014_BDTestFrancoisEntities

    Private Sub Hor_BtnQuitter_Click(sender As Object, e As RoutedEventArgs) Handles Hor_BtnQuitter.Click

        Dim Menu_ As New Menu
        Menu_.Show()
        Me.Close()
    End Sub
End Class
