Public Class ClientReservation
    Dim BD As P2014_BDTestFrancoisEntities

    Sub New(ByRef _BD As P2014_BDTestFrancoisEntities)
        InitializeComponent()
        BD = _BD
    End Sub

    Private Sub Cli_BtnContinuer_Click(sender As Object, e As RoutedEventArgs) Handles Cli_BtnContinuer.Click

        Dim Dispo_ As New DispoChambre(BD)
        Dispo_.Show()
        Me.Close()

    End Sub

    Private Sub Cli_BtnRechercher_Click(sender As Object, e As RoutedEventArgs) Handles Cli_BtnRechercher.Click

        'Dim RechercheClient_ As New RechercheClient(BD)
        'RechercheClient_.Show()
        'Me.Close()

    End Sub

    Private Sub Cli_BtnAnnuler_Click(sender As Object, e As RoutedEventArgs) Handles Cli_BtnAnnuler.Click

        Me.Close()

    End Sub
End Class
