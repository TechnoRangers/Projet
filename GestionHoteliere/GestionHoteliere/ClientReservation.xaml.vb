Public Class ClientReservation

    Private Sub Cli_BtnContinuer_Click(sender As Object, e As RoutedEventArgs) Handles Cli_BtnContinuer.Click

        Dim Dispo_ As New DispoChambre
        Dispo_.Show()
        Me.Close()

    End Sub

    Private Sub Cli_BtnRechercher_Click(sender As Object, e As RoutedEventArgs) Handles Cli_BtnRechercher.Click

    End Sub

    Private Sub Cli_BtnAnnuler_Click(sender As Object, e As RoutedEventArgs) Handles Cli_BtnAnnuler.Click

        Dim Menu_ As New Menu
        Menu_.Show()
        Me.Close()

    End Sub
End Class
