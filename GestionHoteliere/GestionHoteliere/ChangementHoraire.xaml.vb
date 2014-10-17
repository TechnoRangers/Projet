Public Class ChangementHoraire

    Dim BD As P2014_BDTestFrancoisEntities
    Dim ChiffreTravail As tblChiffreTravail
    Dim hreDebut As String
    Dim hreFin As String
    Dim HreD As String
    Dim HreF As String
    Dim MinD As String
    Dim MinF As String
    Dim Test As String

    Sub New(ByRef _BD As P2014_BDTestFrancoisEntities, Optional ByRef _ChiffreTravail As tblChiffreTravail = Nothing)
        InitializeComponent()
        BD = _BD
        ChiffreTravail = _ChiffreTravail

        Cha_TxtNoEmp.DataContext = ChiffreTravail
        Cha_DtpDate.DataContext = ChiffreTravail

    End Sub

    Private Sub Cha_BtnAnnuler_Click(sender As Object, e As RoutedEventArgs) Handles Cha_BtnAnnuler.Click

        Dim Horaire_ As New Horaire
        Horaire_.Show()
        Me.Close()
    End Sub

    Private Sub Cha_BtnValider_Click(sender As Object, e As RoutedEventArgs) Handles Cha_BtnValider.Click


        HreD = DirectCast(Cha_CmbHreDeb.SelectedItem, ComboBoxItem).Content.ToString()
        HreF = DirectCast(Cha_CmbHrefin.SelectedItem, ComboBoxItem).Content.ToString()
        MinD = DirectCast(Cha_CmbMinDeb.SelectedItem, ComboBoxItem).Content.ToString()
        MinF = DirectCast(Cha_CmbMinfin.SelectedItem, ComboBoxItem).Content.ToString()
        Test = ":"

        Try
            If ChiffreTravail Is Nothing Then

                ChiffreTravail = New tblChiffreTravail()
                ChiffreTravail.NoEmploye = Cha_TxtNoEmp.Text
                ChiffreTravail.DateChiffre = Cha_DtpDate.SelectedDate
                ChiffreTravail.HeureDebut = HreD + Test + MinD
                ChiffreTravail.HeureFin = HreF + Test + MinF
                BD.tblChiffreTravail.Add(ChiffreTravail)

            Else
                ChiffreTravail.HeureDebut = HreD + Test + MinD
                ChiffreTravail.HeureFin = HreF + Test + MinF
            End If

            BD.SaveChanges()
        Catch ex As Exception
            BD.tblChiffreTravail.Remove(ChiffreTravail)
            MessageBox.Show("Existe deja")
        End Try

        Me.Close()

    End Sub
End Class
