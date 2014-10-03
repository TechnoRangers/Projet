Public Class Entretien


    Private Sub Window_Loaded(sender As Object, e As RoutedEventArgs)
        Ent_BtnCheckUp.IsEnabled = True
        Ent_BtnEtatChambre.IsEnabled = True
    End Sub
    Private Sub Ent_BtnCheckUp_Click(sender As Object, e As RoutedEventArgs) Handles Ent_BtnCheckUp.Click

        Dim CheckUp As New CheckUp
        CheckUp.Show()
        Me.Close()

    End Sub


End Class
