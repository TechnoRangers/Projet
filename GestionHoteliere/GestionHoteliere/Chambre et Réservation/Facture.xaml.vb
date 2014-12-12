Public Class Facture
    Dim MaBD As P2014_BD_GestionHotelEntities
    Dim MaReserv As tblReservationChambre
    Dim Employe As tblEmploye
    Dim NewFacture As tblFacture

    Sub New(ByRef _MaBD As P2014_BD_GestionHotelEntities, ByRef _MaReserv As tblReservationChambre, ByRef _Employe As tblEmploye)
        InitializeComponent()
        MaBD = _MaBD
        MaReserv = _MaReserv
        Employe = _Employe

        fac_txtNoEmploye.DataContext = Employe
        fac_txtNoReservation.DataContext = MaReserv
        fac_cmbTypeFacture.SelectedIndex = 0
    End Sub

    Private Sub fac_btnConfirmer_Click(sender As Object, e As RoutedEventArgs) Handles fac_btnConfirmer.Click
        Try
            NewFacture = New tblFacture()

            NewFacture.MontantFacture = CType(fac_txtMontantFacture.Text, Double)
            NewFacture.TypeFacture = fac_cmbTypeFacture.SelectedValue
            NewFacture.NoSeqReservChambre = MaReserv.NoSeqReservChambre
            NewFacture.NoEmploye = Employe.NoEmploye

            MaBD.tblFacture.Add(NewFacture)
            MaBD.SaveChanges()
            MessageBox.Show("La facture a été enregistrée avec succès.")
        Catch ex As Exception
            'MaBD.tblFacture.Remove(NewFacture)
            MessageBox.Show("Erreur lors de l'ajout de la facture")
        End Try

        Me.Close()
    End Sub
End Class
