Public Class ChangementHoraire
    Dim BD As P2014_BDTestFrancoisEntities
    Dim ChiffreTravail As tblChiffreTravail
    Sub New(ByRef _BD As P2014_BDTestFrancoisEntities, Optional ByRef _ChiffreTravail As tblChiffreTravail = Nothing)
        InitializeComponent()
        BD = _BD
        ChiffreTravail = _ChiffreTravail

        Cha_TxtNoEmp.DataContext = ChiffreTravail
        Cha_DtpDate.DataContext = ChiffreTravail
        Cha_TxtHreDeb.DataContext = ChiffreTravail
        Cha_TxtHrefin.DataContext = ChiffreTravail

    End Sub
    Private Sub Cha_BtnAnnuler_Click(sender As Object, e As RoutedEventArgs) Handles Cha_BtnAnnuler.Click

        Dim Horaire_ As New Horaire
        Horaire_.Show()
        Me.Close()
    End Sub

    Private Sub Cha_BtnValider_Click(sender As Object, e As RoutedEventArgs) Handles Cha_BtnValider.Click

        Try
            If ChiffreTravail Is Nothing Then
                ChiffreTravail = New tblChiffreTravail()
                ChiffreTravail.NoEmploye = Cha_TxtNoEmp.Text
                ChiffreTravail.DateChiffre = Cha_DtpDate.SelectedDate
                ChiffreTravail.HeureDebut = Cha_TxtHreDeb.Text
                ChiffreTravail.HeureFin = Cha_TxtHrefin.Text

                BD.tblChiffreTravail.Add(ChiffreTravail)
            End If
            BD.SaveChanges()
        Catch ex As Exception
            BD.tblChiffreTravail.Remove(ChiffreTravail)
            MessageBox.Show("Existe deja")
        End Try

    End Sub

End Class

