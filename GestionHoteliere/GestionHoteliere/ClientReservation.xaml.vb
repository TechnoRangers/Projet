Public Class ClientReservation
    Dim BD As P2014_BD_GestionHotelEntities
    Dim VilleSelection As tblVille
    Dim ProvinceSelection As tblProvince
    Dim PaysSelection As tblPays
    Dim Client As tblClient

    Sub New(ByRef _BD As P2014_BD_GestionHotelEntities)
        InitializeComponent()
        BD = _BD

        Dim res = From tabReserv In BD.tblReservationChambre
                  Select tabReserv

        cli_dtgReservationClient.ItemsSource = res.ToList

        cli_cmbPays.DisplayMemberPath = "NomPays"
        cli_cmbProvince.DisplayMemberPath = "NomProvince"
        cli_cmbVille.DisplayMemberPath = "NomVille"

    End Sub

    Private Sub cli_frmClienReservation_Loaded(sender As Object, e As RoutedEventArgs) Handles cli_frmClienReservation.Loaded

        'Remplir les combobox. Par défaut sur canada, quebec, montreal
        VilleSelection = (From tabVille In BD.tblVille
                         Where tabVille.CodeVille = "MRL"
                         Select tabVille).ToList.First

        ProvinceSelection = (From tabProvince In BD.tblProvince
                            Where tabProvince.CodeProvince = VilleSelection.CodeProvince
                            Select tabProvince).ToList.First

        PaysSelection = (From tabPays In BD.tblPays
                        Where tabPays.CodePays = ProvinceSelection.CodePays
                        Select tabPays).ToList.First

        cli_cmbPays.ItemsSource = (From tabPays In BD.tblPays
                                  Select tabPays).ToList

        cli_cmbPays.SelectedValue = PaysSelection

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
        Dim Nom As String = cli_txtNomClient.Text
        Dim Prenom As String = cli_txtPrenomClient.Text
        Dim CodePostal As String = cli_txtCodePostalClient.Text

        'Si un autre client a été recherché avant, il faut reset le datacontext des champs
        If Client IsNot Nothing Then
            ViderChampsClient()
        End If


        If Nom = "" Or Prenom = "" Or CodePostal = "" Then
            MessageBox.Show("Informations insuffisantes pour la recherche.")
        Else
            Try
                Client = (From tabClient In BD.tblClient
                         Where Nom = tabClient.NomClient And Prenom = tabClient.PrenomClient And CodePostal = tabClient.CodePostal
                         Select tabClient).ToList.First

                cli_txtNomClient.DataContext = Client
                cli_txtPrenomClient.DataContext = Client
                cli_txtAdresseClient.DataContext = Client
                cli_txtAdresseClient2.DataContext = Client
                cli_txtNoTelephoneClient.DataContext = Client
                cli_txtNoCellulaireClient.DataContext = Client
                cli_txtEmailClient.DataContext = Client
                cli_txtCodePostalClient.DataContext = Client
                cli_txtNomEntreprise.DataContext = Client

                Dim VilleClient As tblVille = (From tabVille In BD.tblVille
                                              Where tabVille.CodeVille = Client.CodeVille
                                              Select tabVille).ToList.First

                Dim ProvinceClient As tblProvince = (From tabProvince In BD.tblProvince
                                                    Where tabProvince.CodeProvince = VilleClient.CodeProvince
                                                    Select tabProvince).ToList.First

                Dim PaysClient As tblPays = (From tabPays In BD.tblPays
                                            Where tabPays.CodePays = ProvinceClient.CodePays
                                            Select tabPays).ToList.First


                cli_cmbPays.SelectedValue = PaysClient
                cli_cmbProvince.SelectedValue = ProvinceClient
                cli_cmbVille.SelectedValue = VilleClient

            Catch ex As Exception
                MessageBox.Show("Ce client n'est jamais venu à l'hôtel avant.")
            End Try
        End If
    End Sub

    Private Sub Cli_BtnAnnuler_Click(sender As Object, e As RoutedEventArgs) Handles Cli_BtnAnnuler.Click
        Me.Close()
    End Sub

    Private Sub cli_btnAfficherReservClient_Click(sender As Object, e As RoutedEventArgs) Handles cli_btnAfficherReservClient.Click

        If Client Is Nothing Then
            MessageBox.Show("Aucun client selectionné. Vous devez rechercher un client pour afficher ses réservations.")
        Else
            Dim ReservationsClient = From tabReserv In BD.tblReservationChambre
                                 Where tabReserv.NoSeqClient = Client.NoSeqClient
                                 Select tabReserv

            cli_dtgReservationClient.ItemsSource = ReservationsClient.ToList
        End If
    End Sub

    Private Sub Res_BtnModifier_Click(sender As Object, e As RoutedEventArgs) Handles Res_BtnModifier.Click
        If cli_dtgReservationClient.SelectedItem Is Nothing Then
            MessageBox.Show("Aucune réservation selectionnée.")
        Else
            Dim ReservationSelection As New tblReservationChambre
            ReservationSelection = CType(cli_dtgReservationClient.SelectedItem, tblReservationChambre)
            Dim FenetreModifReserv As New ModifReservation(BD, ReservationSelection)
            FenetreModifReserv.ShowDialog()
        End If
    End Sub

    Private Sub cli_btnAjouterClient_Click(sender As Object, e As RoutedEventArgs) Handles cli_btnAjouterClient.Click

        Dim NewClient As New tblClient

        'Champs obligatoire
        Dim NomClient As String = cli_txtNomClient.Text
        Dim PrenomClient As String = cli_txtPrenomClient.Text
        Dim NoTelephone As String = cli_txtNoTelephoneClient.Text
        Dim AdresseClient As String = cli_txtAdresseClient.Text
        Dim EmailClient As String = cli_txtEmailClient.Text
        Dim CodePostal As String = cli_txtCodePostalClient.Text
        Dim VilleClient As String = VilleSelection.CodeVille

        'Champs facultatifs
        Dim AdresseSecondaire As String = cli_txtAdresseClient2.Text
        Dim NoCellulaire As String = cli_txtNoCellulaireClient.Text
        Dim EntrepriseClient As String = cli_txtNomEntreprise.Text

        If NomClient <> "" And PrenomClient <> "" And NoTelephone <> "" And AdresseClient <> "" And EmailClient <> "" And CodePostal <> "" And VilleClient <> Nothing Then
            NewClient.NomClient = NomClient
            NewClient.PrenomClient = PrenomClient
            NewClient.NoTelephone = NoTelephone
            NewClient.AdresseClient = AdresseClient
            NewClient.EmailClient = EmailClient
            NewClient.CodePostal = CodePostal

            NewClient.AdresseSecondaireClient = AdresseSecondaire
            NewClient.NoCellulaire = NoCellulaire
            NewClient.NomEntreprise = EntrepriseClient

            Try
                Dim res = From tabClient In BD.tblClient
                          Where NomClient = tabClient.NomClient And PrenomClient = tabClient.PrenomClient And CodePostal = tabClient.CodePostal
                          Select tabClient

                If res.ToList.Count = 0 Then
                    BD.tblClient.Add(NewClient)
                    BD.SaveChanges()
                    Client = NewClient
                    MessageBox.Show("Le nouveau client a été créé avec succès.")
                Else
                    MessageBox.Show("Ce client existe déjà.")
                End If

            Catch ex As Exception
                MessageBox.Show("Erreur lors de la création du client.")
            End Try

        Else
            MessageBox.Show("Informations incomplètes pour la création du client.")
        End If

    End Sub

    Private Sub cli_cmbPays_SelectionChanged(sender As Object, e As SelectionChangedEventArgs) Handles cli_cmbPays.SelectionChanged    
        FiltrerPays()
    End Sub

    Private Sub cli_cmbProvince_SelectionChanged(sender As Object, e As SelectionChangedEventArgs) Handles cli_cmbProvince.SelectionChanged
        FiltrerVilles()
    End Sub

    Private Sub cli_cmbVille_SelectionChanged(sender As Object, e As SelectionChangedEventArgs) Handles cli_cmbVille.SelectionChanged
        VilleSelection = CType(cli_cmbVille.SelectedItem, tblVille)
    End Sub

    Sub FiltrerPays(Optional ByRef _VilleClient As tblVille = Nothing)
        PaysSelection = CType(cli_cmbPays.SelectedItem, tblPays)

        FiltrerProvinces()
    End Sub

    Sub FiltrerProvinces()
        Dim resProvince = From tabProvinces In BD.tblProvince
                          Where tabProvinces.CodePays = PaysSelection.CodePays
                          Select tabProvinces

        ProvinceSelection = resProvince.ToList.First
        cli_cmbProvince.ItemsSource = resProvince.ToList
        cli_cmbProvince.SelectedValue = resProvince.ToList.First
    End Sub

    Sub FiltrerVilles()

        If cli_cmbProvince.SelectedItem Is Nothing Then
            Dim resVille = From tabVille In BD.tblVille
                       Where tabVille.CodeProvince = ProvinceSelection.CodeProvince
                       Select tabVille

            cli_cmbVille.ItemsSource = resVille.ToList
            VilleSelection = resVille.ToList.First
            cli_cmbVille.SelectedValue = resVille.ToList.First

        Else
            ProvinceSelection = CType(cli_cmbProvince.SelectedItem, tblProvince)

            Dim resVille = From tabVille In BD.tblVille
                           Where tabVille.CodeProvince = ProvinceSelection.CodeProvince
                           Select tabVille

            cli_cmbVille.ItemsSource = resVille.ToList
            VilleSelection = resVille.ToList.First
            cli_cmbVille.SelectedValue = resVille.ToList.First
        End If

    End Sub

    Private Sub cli_btnVider_Click(sender As Object, e As RoutedEventArgs) Handles cli_btnVider.Click

        ViderChampsClient()

    End Sub

    Sub ViderChampsClient()
        cli_txtNomClient.DataContext = Nothing
        cli_txtPrenomClient.DataContext = Nothing
        cli_txtCodePostalClient.DataContext = Nothing
        cli_txtAdresseClient.DataContext = Nothing
        cli_txtAdresseClient2.DataContext = Nothing
        cli_txtNoTelephoneClient.DataContext = Nothing
        cli_txtNoCellulaireClient.DataContext = Nothing
        cli_txtEmailClient.DataContext = Nothing
        cli_txtNomEntreprise.DataContext = Nothing

        cli_txtPrenomClient.Text = ""
        cli_txtNomClient.Text = ""
        cli_txtCodePostalClient.Text = ""
        cli_txtAdresseClient.Text = ""
        cli_txtAdresseClient2.Text = ""
        cli_txtNoTelephoneClient.Text = ""
        cli_txtNoCellulaireClient.Text = ""
        cli_txtEmailClient.Text = ""
        cli_txtNomEntreprise.Text = ""

        Dim PaysDefaut As tblPays

        PaysDefaut = (From tabPays In BD.tblPays
                      Where tabPays.CodePays = "CAN"
                      Select tabPays).ToList.First

        cli_cmbPays.SelectedValue = PaysDefaut

        Client = Nothing

        Dim Reserv = From tabReserv In BD.tblReservationChambre
                     Select tabReserv

        cli_dtgReservationClient.ItemsSource = Reserv.ToList
    End Sub

End Class

