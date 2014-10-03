﻿Class Connection

    Dim MaBD As P2014_BDTestFrancoisEntities
    Dim HotelSelection As tblHotel
    Dim Employe As tblEmploye

    Private Sub Con_btnConnexion_Click(sender As Object, e As RoutedEventArgs) Handles Con_btnConnexion.Click

        Try
            'ConnectionEmploye()
            Dim Menu_ As New Menu(MaBD)
            con_lblErreurConnexion.Visibility = Windows.Visibility.Hidden
            Menu_.Show()
            Con_frmConnection.Close()
        Catch ex As Exception
            con_lblErreurConnexion.Visibility = Windows.Visibility.Visible
        End Try

    End Sub

    Sub ConnectionEmploye()

            Employe = (From tabEmploye In MaBD.tblEmploye
                    Where tabEmploye.IdentifiantEmploye = Con_TxtIdentifiant.Text And tabEmploye.MdpEmploye = Con_TxtMotPasse.Password
                    Select tabEmploye).ToList.First

    End Sub

    Private Sub Con_frmConnection_Loaded(sender As Object, e As RoutedEventArgs) Handles Con_frmConnection.Loaded
        con_lblErreurConnexion.Visibility = Windows.Visibility.Hidden
        MaBD = New P2014_BDTestFrancoisEntities

        Dim Hotels = From tabHotel In MaBD.tblHotel
                     Select tabHotel

        Con_CmbHotel.ItemsSource = Hotels.ToList
        Con_CmbHotel.DisplayMemberPath = "NomHotel"
        Con_CmbHotel.SelectedValue = Hotels.ToList.First
    End Sub

    Private Sub Con_CmbHotel_SelectionChanged(sender As Object, e As SelectionChangedEventArgs) Handles Con_CmbHotel.SelectionChanged

    End Sub
End Class
