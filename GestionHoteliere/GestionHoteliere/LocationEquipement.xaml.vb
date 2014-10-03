Public Class LocationEquipement
    Dim MaBd As P2014_BDTestFrancoisEntities



    Private Sub LocEqui_BtnAjout_Click(sender As Object, e As RoutedEventArgs) Handles LocEqui_BtnAjout.Click
        LocEqui_ListBoxReserv.Items.Add(LocEqui_ListBoxInventaire.SelectedItem)
    End Sub

    Private Sub LocEqui_BtnEnl_Click(sender As Object, e As RoutedEventArgs) Handles LocEqui_BtnEnl.Click
        LocEqui_ListBoxReserv.Items.Remove(LocEqui_ListBoxReserv.SelectedItem)
    End Sub

    Private Sub LocEqui_BtnValider_Click(sender As Object, e As RoutedEventArgs) Handles LocEqui_BtnValider.Click

    End Sub

    Private Sub LocEqui_BtnAnnuler_Click(sender As Object, e As RoutedEventArgs) Handles LocEqui_BtnAnnuler.Click

    End Sub
End Class
