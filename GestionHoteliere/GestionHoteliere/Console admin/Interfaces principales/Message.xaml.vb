Public Class Message

    Dim MaBD As P2014_BD_GestionHotelEntities

    Sub New(ByRef _MaBD As P2014_BD_GestionHotelEntities)
        InitializeComponent()
        MaBD = _MaBD
    End Sub

    Private Sub mess_frmMessage_Loaded(sender As Object, e As RoutedEventArgs) Handles mess_frmMessage.Loaded
        Dim res = From tabMessage In MaBD.tblMessage
                  Select tabMessage

        mess_dtgMessage.ItemsSource = res.ToList
    End Sub

    Private Sub mess_btnAjouter_Click(sender As Object, e As RoutedEventArgs) Handles mess_btnAjouter.Click
        Dim FenetreModifMessage As ModifMessage
        FenetreModifMessage = New ModifMessage(MaBD)
        FenetreModifMessage.ShowDialog()

        Dim res = From tabMessage In MaBD.tblMessage
                  Select tabMessage

        mess_dtgMessage.ItemsSource = res.ToList
    End Sub

    Private Sub mess_btnModifier_Click(sender As Object, e As RoutedEventArgs) Handles mess_btnModifier.Click
        Try
            Dim MessageSelection As tblMessage = CType(mess_dtgMessage.SelectedItem, tblMessage)

            Dim FenetreModifMessage As ModifMessage
            FenetreModifMessage = New ModifMessage(MaBD, MessageSelection)
            FenetreModifMessage.ShowDialog()
        Catch
            MessageBox.Show("Aucune row selectionné")
        End Try
    End Sub

    Private Sub mess_btnSupprimer_Click(sender As Object, e As RoutedEventArgs) Handles mess_btnSupprimer.Click
        Try
            Dim MessageSelection As tblMessage = mess_dtgMessage.SelectedItem

            MaBD.tblMessage.Remove(MessageSelection)
            MaBD.SaveChanges()
        Catch
            MessageBox.Show("Aucune row selectionné")
        End Try

        Dim res = From tabMessage In MaBD.tblMessage
                  Select tabMessage

        mess_dtgMessage.ItemsSource = res.ToList
    End Sub
End Class
