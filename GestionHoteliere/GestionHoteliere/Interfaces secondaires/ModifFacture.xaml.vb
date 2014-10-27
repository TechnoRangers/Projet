Public Class ModifFacture
    Dim MaBD As P2014_BD_GestionHotelEntities
    Dim MaFacture As tblFacture

    Sub New(ByRef _MaBD As P2014_BD_GestionHotelEntities, Optional ByRef _MaFacture As tblFacture = Nothing)
        InitializeComponent()
        MaBD = _MaBD
        MaFacture = _MaFacture

        fac_txtNoSeqFacture.DataContext = MaFacture
        fac_txtMontantFacture.DataContext = MaFacture
        fac_txtTypeFacture.DataContext = MaFacture
        fac_txtNoSeqReservChambre.DataContext = MaFacture
        fac_txtNoEmploye.DataContext = MaFacture
    End Sub

    Private Sub fac_btnConfirmer_Click(sender As Object, e As RoutedEventArgs) Handles fac_btnConfirmer.Click
        Try
            If MaFacture Is Nothing Then
                MaFacture = New tblFacture()
                MaFacture.MontantFacture = fac_txtMontantFacture.Text
                MaFacture.TypeFacture = fac_txtTypeFacture.Text
                MaFacture.NoSeqReservChambre = fac_txtNoSeqReservChambre.Text
                MaFacture.NoEmploye = fac_txtNoEmploye.Text

                MaBD.tblFacture.Add(MaFacture)
            End If
            MaBD.SaveChanges()
        Catch ex As Exception
            MaBD.tblFacture.Remove(MaFacture)
            MessageBox.Show("Existe deja")
        End Try

        Me.Close()
    End Sub
End Class
