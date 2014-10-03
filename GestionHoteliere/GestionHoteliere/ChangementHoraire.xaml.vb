Public Class ChangementHoraire

    Dim BD As P2014_BDTestFrancoisEntities
    Dim ChiffreTravail As tblChiffreTravail
    Dim hreDebut As String
    Dim hreFin As String

    Sub New(ByRef _BD As P2014_BDTestFrancoisEntities, Optional ByRef _ChiffreTravail As tblChiffreTravail = Nothing)
        InitializeComponent()
        BD = _BD
        ChiffreTravail = _ChiffreTravail

        hreDebut = Cha_CmbHreDeb.SelectedItem + ":" + Cha_CmbMinDeb.SelectedItem
        hreFin = Cha_CmbHrefin.SelectedItem + ":" + Cha_CmbMinfin.SelectedItem

        Cha_TxtNoEmp.DataContext = ChiffreTravail.NoEmploye
        Cha_DtpDate.DataContext = ChiffreTravail.DateChiffre
        'hreDebut = ChiffreTravail.HeureDebut
        'hreFin = ChiffreTravail.HeureFin

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
                'ChiffreTravail.HeureDebut = hreDebut
                'ChiffreTravail.HeureFin = hreFin

                BD.tblChiffreTravail.Add(ChiffreTravail)
            End If
            BD.SaveChanges()
        Catch ex As Exception
            BD.tblChiffreTravail.Remove(ChiffreTravail)
            MessageBox.Show("Existe deja")
        End Try

    End Sub
End Class
