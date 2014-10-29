Public Class ModifReservation
    Dim MaBD As P2014_BD_GestionHotelEntities
    Dim MaReserv As tblReservationChambre

    Sub New(ByRef _MaBD As P2014_BD_GestionHotelEntities, Optional ByRef _MaReserv As tblReservationChambre = Nothing)
        InitializeComponent()
        MaBD = _MaBD
        MaReserv = _MaReserv

        mres_txtNoSeqReservChambre.DataContext = MaReserv
        mres_txtPrixReservChambre.DataContext = MaReserv
        mres_txtModePaiement.DataContext = MaReserv
        mres_txtStatutPaiement.DataContext = MaReserv
        mres_txtNbPersonne.DataContext = MaReserv
        mres_txtNoCarteCredit.DataContext = MaReserv
        mres_txtNoSeqClient.DataContext = MaReserv
        mres_txtNoSeqForfait.DataContext = MaReserv
    End Sub

    Private Sub mres_btnConfirmer_Click(sender As Object, e As RoutedEventArgs) Handles mres_btnConfirmer.Click
        Try
            If MaReserv Is Nothing Then
                MaReserv = New tblReservationChambre()
                MaReserv.NoSeqReservChambre = mres_txtNoSeqReservChambre.Text
                MaReserv.PrixReservChambre = mres_txtPrixReservChambre.Text
                MaReserv.ModePaiement = mres_txtModePaiement.Text
                MaReserv.StatutPaiement = mres_txtStatutPaiement.Text
                ' = mres_txtNbPersonne.Text
                MaReserv.NoCarteCredit = mres_txtNoCarteCredit.Text
                MaReserv.NoSeqClient = mres_txtNoSeqClient.Text
                MaReserv.NoSeqRabais = mres_txtNoSeqForfait.Text

                MaBD.tblReservationChambre.Add(MaReserv)
            End If
            MaBD.SaveChanges()
        Catch ex As Exception
            MaBD.tblReservationChambre.Remove(MaReserv)
            MessageBox.Show("Existe deja")
        End Try

        Me.Close()
    End Sub
End Class

