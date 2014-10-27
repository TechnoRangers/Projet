Public Class ModifSalle
    Dim MaBD As P2014_BD_GestionHotelEntities
    Dim MaSalle As tblSalle
    Sub New(ByRef _MaBD As P2014_BD_GestionHotelEntities, Optional ByRef _MaSalle As tblSalle = Nothing)
        InitializeComponent()
        MaBD = _MaBD
        MaSalle = _MaSalle
        sal_txtCodeSalle.DataContext = MaSalle
        sal_txtNomSalle.DataContext = MaSalle
        sal_txtTypeSalle.DataContext = MaSalle
        sal_txtStatutSalle.DataContext = MaSalle
        sal_txtDetailSalle.DataContext = MaSalle
        sal_txtNbPlacesAssis.DataContext = MaSalle
        sal_txtNbPlacesDebout.DataContext = MaSalle
        sal_txtCodeHotel.DataContext = MaSalle

        If MaSalle IsNot Nothing Then
            sal_txtCodeSalle.IsEnabled = False
        Else
            sal_txtCodeSalle.IsEnabled = True
        End If
    End Sub

    Private Sub sal_btnConfirmer_Click(sender As Object, e As RoutedEventArgs) Handles sal_btnConfirmer.Click
        Try
            If MaSalle Is Nothing Then
                MaSalle = New tblSalle()
                MaSalle.CodeSalle = sal_txtCodeSalle.Text
                MaSalle.NomSalle = sal_txtNomSalle.Text
                MaSalle.TypeSalle = sal_txtTypeSalle.Text
                MaSalle.StatutSalle = sal_txtStatutSalle.Text
                MaSalle.DetailSalle = sal_txtDetailSalle.Text
                MaSalle.NbPlacesAssis = sal_txtNbPlacesAssis.Text
                MaSalle.NbPlacesDebout = sal_txtNbPlacesDebout.Text
                MaSalle.CodeHotel = sal_txtCodeHotel.Text
 
                MaBD.tblSalle.Add(MaSalle)
            End If
            MaBD.SaveChanges()
        Catch ex As Exception
            MaBD.tblSalle.Remove(MaSalle)
            MessageBox.Show("Existe deja")
        End Try

        Me.Close()
    End Sub
End Class
