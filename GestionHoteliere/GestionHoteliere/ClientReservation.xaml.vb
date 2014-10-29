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

        Dim Nom As String = cli_txtNomClient.Text
        Dim Prenom As String = cli_txtPrenomClient.Text
        Dim CodePostal As String = cli_txtCodePostalClient.Text

        Try
            Client = (From tabClient In BD.tblClient
                     Where tabClient.PrenomClient = Prenom And tabClient.NomClient = Nom And tabClient.CodePostal = CodePostal
                     Select tabClient).ToList.First

            Dim res = From tabChambre In BD.tblChambre
                      Join tabChambReservChamb In BD.tblChambreReservationChambre On tabChambReservChamb.NoSeqChambre Equals tabChambre.NoSeqChambre
                      Join tabReservChambre In BD.tblReservationChambre On tabChambReservChamb.NoSeqReservChambre Equals tabReservChambre.NoSeqReservChambre
                      Where tabReservChambre.NoSeqClient = Client.NoSeqClient
                      Select tabChambre

            Cli_DtgHistorique.ItemsSource = res.ToList
            cli_txtAdresseClient.DataContext = Client
            cli_txtEmailClient.DataContext = Client
            cli_txtNoTelephoneClient.DataContext = Client
        Catch ex As Exception
            MessageBox.Show("Le client n'est jamais venu à l'hôtel avant")
        End Try
        

        'If Client Is Nothing Then
        '    MessageBox.Show("Le client n'est jamais venu à l'hôtel avant")
        'Else
        '    Dim res = From tabChambre In BD.tblChambre
        '              Join tabChambReservChamb In BD.tblChambreReservationChambre On tabChambReservChamb.NoSeqChambre Equals tabChambre.NoSeqChambre
        '              Join tabReservChambre In BD.tblReservationChambre On tabChambReservChamb.NoSeqReservChambre Equals tabReservChambre.NoSeqReservChambre
        '              Where tabReservChambre.NoSeqClient = Client.NoSeqClient
        '              Select tabChambre

        '    Cli_DtgHistorique.ItemsSource = res.ToList
        '    cli_txtAdresseClient.DataContext = Client
        '    cli_txtEmailClient.DataContext = Client
        '    cli_txtNoTelephoneClient.DataContext = Client
        'End If
    End Sub

    Private Sub Res_BtnModifier_Click(sender As Object, e As RoutedEventArgs) Handles Res_BtnModifier.Click

        Dim LstReservation As New ListeReservation(BD)
        LstReservation.Show()

    End Sub

    Private Sub cli_btnAjouterClient_Click(sender As Object, e As RoutedEventArgs) Handles cli_btnAjouterClient.Click

        Dim NewClient As New tblClient

        Dim NomClient As String = cli_txtNomClient.Text
        Dim PrenomClient As String = cli_txtPrenomClient.Text
        Dim NoTelephone As String = cli_txtNoTelephoneClient.Text
        Dim AdresseClient As String = cli_txtAdresseClient.Text
        Dim EmailClient As String = cli_txtEmailClient.Text
        Dim CodePostal As String = cli_txtCodePostalClient.Text

        If NomClient <> "" And PrenomClient <> "" And NoTelephone <> "" And AdresseClient <> "" And EmailClient <> "" And CodePostal <> "" Then
            NewClient.NomClient = NomClient
            NewClient.PrenomClient = PrenomClient
            NewClient.NoTelephone = NoTelephone
            NewClient.AdresseClient = AdresseClient
            NewClient.EmailClient = EmailClient
            NewClient.CodePostal = CodePostal

            Try
                Dim res = From tabClient In BD.tblClient
                          Where NomClient = tabClient.NomClient And PrenomClient = tabClient.PrenomClient And CodePostal = tabClient.CodePostal
                          Select tabClient

                If res.ToList.Count = 0 Then
                    BD.tblClient.Add(NewClient)
                    BD.SaveChanges()
                    MessageBox.Show("Le nouveau client a été créé avec succès.")
                Else
                    MessageBox.Show("Ce client existe déjà.")
                End If

            Catch ex As Exception
                MessageBox.Show("Erreur lors de la création du client.")
            End Try

        Else
            MessageBox.Show("Vous devez remplir tous les champs pour créer un client.")
        End If

    End Sub

End Class

