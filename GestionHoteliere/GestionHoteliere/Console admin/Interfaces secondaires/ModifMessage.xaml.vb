Public Class ModifMessage
    Dim MaBD As P2014_BD_GestionHotelEntities
    Dim MonMessage As tblMessage

    Public Sub New(ByRef _MaBD As P2014_BD_GestionHotelEntities, Optional ByRef _MonMessage As tblMessage = Nothing)
        InitializeComponent()
        MonMessage = _MonMessage
        MaBD = _MaBD
        mess_txtTitreMessage.DataContext = MonMessage
        mess_txtDateMessage.DataContext = MonMessage
        mess_txtMessage.DataContext = MonMessage
    End Sub

    Private Sub mess_btnConfirmer_Click(sender As Object, e As RoutedEventArgs) Handles mess_btnConfirmer.Click
        Try
            If MonMessage Is Nothing Then
                MonMessage = New tblMessage()
                MonMessage.Titre = mess_txtTitreMessage.Text
                MonMessage.DateM = mess_txtDateMessage.Text
                MonMessage.MessageM = mess_txtMessage.Text

                MaBD.tblMessage.Add(MonMessage)
            End If
            MaBD.SaveChanges()
        Catch ex As Exception
            MaBD.tblMessage.Remove(MonMessage)
            MessageBox.Show("Erreur ou existe deja")
        End Try

        Me.Close()
    End Sub
End Class
