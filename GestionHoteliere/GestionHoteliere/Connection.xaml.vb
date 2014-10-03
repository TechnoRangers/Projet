Class Connection

    Private Sub Con_btnConnexion_Click(sender As Object, e As RoutedEventArgs) Handles Con_btnConnexion.Click

        ConnectionEmploye()

        Dim Menu_ As New Menu
        Menu_.Show()
        Con_frmConnection.Close()

    End Sub

    Sub ConnectionEmploye()
        Dim Employe As tblEmploye

        Employe = From tabEmploye In MaBD.
    End Sub

End Class
