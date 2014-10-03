Class Connection

    Dim MaBD As P2014_BDTestFrancoisEntities

    Private Sub Con_btnConnexion_Click(sender As Object, e As RoutedEventArgs) Handles Con_btnConnexion.Click

        'ConnectionEmploye()

        MaBD = New P2014_BDTestFrancoisEntities
        Dim Menu_ As New Menu(MaBD)
        Menu_.Show()
        Con_frmConnection.Close()

    End Sub

    Sub ConnectionEmploye()
        'Dim Employe As tblEmploye

        'Employe = From tabEmploye In MaBD.
    End Sub

End Class
