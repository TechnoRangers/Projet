Public Class ModifProvince
    Dim MaBD As P2014_BD_GestionHotelEntities
    Dim MaProvince As tblProvince

    Sub New(ByRef _MaBD As P2014_BD_GestionHotelEntities, Optional ByRef _MaProvince As tblProvince = Nothing)
        InitializeComponent()
        MaBD = _MaBD
        MaProvince = _MaProvince

        pro_txtCodeProvince.DataContext = MaProvince
        pro_txtNomProvince.DataContext = MaProvince
        pro_txtCodePays.DataContext = MaProvince

        If MaProvince IsNot Nothing Then
            pro_txtCodePays.IsEnabled = False
        Else
            pro_txtCodePays.IsEnabled = True
        End If
    End Sub

    Private Sub pro_btnConfirmer_Click(sender As Object, e As RoutedEventArgs) Handles pro_btnConfirmer.Click
        Try
            If MaProvince Is Nothing Then
                MaProvince = New tblProvince()
                MaProvince.CodeProvince = pro_txtCodeProvince.Text
                MaProvince.NomProvince = pro_txtNomProvince.Text
                MaProvince.CodePays = pro_txtCodePays.Text

                MaBD.tblProvince.Add(MaProvince)
            End If
            MaBD.SaveChanges()
        Catch ex As Exception
            MaBD.tblProvince.Remove(MaProvince)
            MessageBox.Show("Existe deja")
        End Try

        Me.Close()
    End Sub
End Class
