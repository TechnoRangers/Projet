Public Class ModifChambre
    Dim MaBD As P2014_BD_GestionHotelEntities
    Dim MaChambre As tblChambre

    Sub New(ByRef _MaBD As P2014_BD_GestionHotelEntities, Optional ByRef _MaChambre As tblChambre = Nothing)
        InitializeComponent()
        MaBD = _MaBD
        MaChambre = _MaChambre

        chamb_txtNoSeqChambre.DataContext = MaChambre
        chamb_txtEtageChambre.DataContext = MaChambre
        chamb_txtStatutChambre.DataContext = MaChambre
        chamb_txtDescChambre.DataContext = MaChambre
        chamb_txtTypeLit.DataContext = MaChambre
        chamb_txtNbLit.DataContext = MaChambre
        chamb_txtCodeHotel.DataContext = MaChambre
        chamb_txtCodeTypeChambre.DataContext = MaChambre
    End Sub

    Private Sub chamb_btnConfirmer_Click(sender As Object, e As RoutedEventArgs) Handles chamb_btnConfirmer.Click
        Try
            If MaChambre Is Nothing Then
                MaChambre = New tblChambre()
                MaChambre.EtageChambre = chamb_txtEtageChambre.Text
                MaChambre.StatutChambre = chamb_txtStatutChambre.Text
                MaChambre.DescChambre = chamb_txtDescChambre.Text
                MaChambre.TypeLit = chamb_txtTypeLit.Text
                MaChambre.NbLit = chamb_txtNbLit.Text
                MaChambre.CodeHotel = chamb_txtCodeHotel.Text
                MaChambre.CodeTypeChambre = chamb_txtCodeTypeChambre.Text

                MaBD.tblChambre.Add(MaChambre)
            End If
            MaBD.SaveChanges()
        Catch ex As Exception
            MaBD.tblChambre.Remove(MaChambre)
            MessageBox.Show("Existe deja")
        End Try

        Me.Close()
    End Sub
End Class
