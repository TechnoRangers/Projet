Public Class Entretien


 
    Private Sub Ent_BtnCheckUp_Click(sender As Object, e As RoutedEventArgs) Handles Ent_BtnCheckUp.Click

        Dim CheckUp As New CheckUp
        CheckUp.Show()
        Me.Close()

    End Sub


    Private Sub Ent_BtnEtatChambre_Click(sender As Object, e As RoutedEventArgs) Handles Ent_BtnEtatChambre.Click

        Dim EtatChambre As New EtatChambre
        EtatChambre.Show()
        Me.Close()

    End Sub
End Class
