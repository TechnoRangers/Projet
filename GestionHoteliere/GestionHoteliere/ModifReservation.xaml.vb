﻿Public Class ModifReservation
    Dim MaBD As P2014_BD_GestionHotelEntities
    Dim MaReserv As tblReservationChambre

    Sub New(ByRef _MaBD As P2014_BD_GestionHotelEntities, ByRef _MaReserv As tblReservationChambre)
        InitializeComponent()
        MaBD = _MaBD
        MaReserv = _MaReserv

        'WIP: faire afficher le mode de paiement dans la combobox
        'mres_cmbModePaiement.SelectedValue = MaReserv.ModePaiement

        mres_txtNoSeqReservChambre.DataContext = MaReserv
        mres_txtPrixReservChambre.DataContext = MaReserv
        mres_txtStatutPaiement.DataContext = MaReserv
        mres_txtNoSeqClient.DataContext = MaReserv

        mres_txtNoCarteCredit.DataContext = MaReserv
        mres_txtDateExpiration.DataContext = MaReserv
        mres_txtTypeCarte.DataContext = MaReserv
        mres_txtNomDetenteur.DataContext = MaReserv

    End Sub

    Private Sub mres_frmModifReservation_Loaded(sender As Object, e As RoutedEventArgs) Handles mres_frmModifReservation.Loaded
        Dim ListeChambreReservation As New List(Of tblChambreReservationChambre)
        Dim ListeChambre As New List(Of tblChambre)

        ListeChambreReservation = (From tabChambreReservChambre In MaBD.tblChambreReservationChambre
                                    Where tabChambreReservChambre.NoSeqReservChambre = MaReserv.NoSeqReservChambre
                                    Select tabChambreReservChambre).ToList

        For Each ChambreReserv As tblChambreReservationChambre In ListeChambreReservation
            Dim Chambre As New tblChambre
            Chambre = From tabChambre In MaBD.tblChambre
                      Where tabChambre.NoSeqChambre = ChambreReserv.NoSeqChambre
                      Select tabChambre

            ListeChambre.Add(Chambre)
        Next



        mres_lstChambre.ItemsSource = ListeChambre

    End Sub

    Private Sub mres_btnConfirmer_Click(sender As Object, e As RoutedEventArgs) Handles mres_btnConfirmer.Click
        Try
            If MaReserv Is Nothing Then
                MaReserv = New tblReservationChambre()
                MaReserv.NoSeqReservChambre = mres_txtNoSeqReservChambre.Text
                MaReserv.PrixReservChambre = mres_txtPrixReservChambre.Text
                'MaReserv.ModePaiement = mres_txtModePaiement.Text
                MaReserv.StatutPaiement = mres_txtStatutPaiement.Text

                MaReserv.NoCarteCredit = mres_txtNoCarteCredit.Text
                MaReserv.NoSeqClient = mres_txtNoSeqClient.Text
                'MaReserv.NoSeqRabais = mres_txtNoSeqForfait.Text

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

