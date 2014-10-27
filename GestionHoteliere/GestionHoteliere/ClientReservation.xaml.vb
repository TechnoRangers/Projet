Public Class ClientReservation
    Dim BD As P2014_BD_GestionHotelEntities
    Dim Client As tblClient

    Sub New(ByRef _BD As P2014_BD_GestionHotelEntities)
        InitializeComponent()
        BD = _BD
    End Sub

    Private Sub Cli_BtnContinuer_Click(sender As Object, e As RoutedEventArgs) Handles Cli_BtnContinuer.Click
        If Client IsNot Nothing Then
            Dim Dispo_ As New DispoChambre(BD, Client)
            Dispo_.Show()
            Me.Close()
        Else
            MessageBox.Show("Sélectionnez un client avant de poursuivre.")
        End If
    End Sub

    Private Sub Cli_BtnRechercher_Click(sender As Object, e As RoutedEventArgs) Handles Cli_BtnRechercher.Click
        FiltrerDatagrid()
    End Sub

    Private Sub Cli_BtnAnnuler_Click(sender As Object, e As RoutedEventArgs) Handles Cli_BtnAnnuler.Click
        Me.Close()
    End Sub

    Sub FiltrerDatagrid()

        Dim Nom As String = Res_TextBoxNom.Text
        Dim Prenom As String = Res_TextBoxPren.Text
        Dim CodePostal As String = Res_TextBoxCodePostal.Text

        Client = (From tabClient In BD.tblClient
                     Where tabClient.PrenomClient = Prenom And tabClient.NomClient = Nom And tabClient.CodePostal = CodePostal
                     Select tabClient).ToList.First

        If Client Is Nothing Then
            MessageBox.Show("Le client n'est jamais venu à l'hôtel avant")
        Else
            Dim res = From tabChambre In BD.tblChambre
                      Join tabChambReservChamb In BD.tblChambreReservationChambre On tabChambReservChamb.NoSeqChambre Equals tabChambre.NoSeqChambre
                      Join tabReservChambre In BD.tblReservationChambre On tabChambReservChamb.NoSeqReservChambre Equals tabReservChambre.NoSeqReservChambre
                      Where tabReservChambre.NoSeqClient = Client.NoSeqClient
                      Select tabChambre

            Cli_DtgHistorique.ItemsSource = res.ToList
            Res_TextBoxAdresse.DataContext = Client
            Res_TxtEmail.DataContext = Client
            Res_NoTelephone.DataContext = Client
        End If
    End Sub

    Private Sub Res_BtnModifier_Click(sender As Object, e As RoutedEventArgs) Handles Res_BtnModifier.Click

        Dim LstReservation As New ListeReservation(BD)
        LstReservation.Show()

    End Sub
End Class

