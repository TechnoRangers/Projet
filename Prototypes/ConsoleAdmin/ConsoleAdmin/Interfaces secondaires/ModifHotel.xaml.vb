Public Class ModifHotel
    Dim MaBD As P2014_BDTestFrancoisEntities
    Dim MonHotel As tblHotel
    Sub New(ByRef _MaBD As P2014_BDTestFrancoisEntities, Optional ByRef _MonHotel As tblHotel = Nothing)
        InitializeComponent()
        MaBD = _MaBD
        MonHotel = _MonHotel
        hot_txtCodeHotel.DataContext = MonHotel
        hot_txtNomHotel.DataContext = MonHotel
        hot_txtNbChambre.DataContext = MonHotel
        hot_txtAdresseHotel.DataContext = MonHotel
        hot_txtNbEtoiles.DataContext = MonHotel
        hot_txtTypeService.DataContext = MonHotel


        Dim res = From tabVille In MaBD.tblVille
                  Select tabVille.CodeVille

        hot_cmbCodeVille.ItemsSource = res.ToList

        If MonHotel IsNot Nothing Then
            hot_txtCodeHotel.IsEnabled = False
            hot_cmbCodeVille.IsEnabled = False
            hot_cmbCodeVille.SelectedValue = MonHotel.CodeVille
        Else
            hot_txtCodeHotel.IsEnabled = True
            hot_cmbCodeVille.IsEnabled = True
        End If

    End Sub

    Private Sub hot_btnConfirmer_Click(sender As Object, e As RoutedEventArgs) Handles hot_btnConfirmer.Click
        Try
            If MonHotel Is Nothing Then
                MonHotel = New tblHotel()
                MonHotel.CodeHotel = hot_txtCodeHotel.Text
                MonHotel.NomHotel = hot_txtNomHotel.Text
                MonHotel.NbChambre = hot_txtNbChambre.Text
                MonHotel.AdresseHotel = hot_txtAdresseHotel.Text
                MonHotel.NbEtoiles = hot_txtNbEtoiles.Text
                MonHotel.TypeService = hot_txtTypeService.Text
                MonHotel.NomHotel = hot_txtNomHotel.Text
                MonHotel.CodeVille = hot_cmbCodeVille.Text

                MaBD.tblHotel.Add(MonHotel)
            End If
            MaBD.SaveChanges()
        Catch ex As Exception
            MaBD.tblHotel.Remove(MonHotel)
            MessageBox.Show("Existe deja")
        End Try

        Me.Close()
    End Sub
End Class
