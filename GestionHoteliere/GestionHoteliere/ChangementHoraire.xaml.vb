Public Class ChangementHoraire

    Private Sub Cha_BtnAnnuler_Click(sender As Object, e As RoutedEventArgs) Handles Cha_BtnAnnuler.Click

        Dim Horaire_ As New Horaire
        Horaire_.Show()
        Me.Close()
    End Sub
End Class
