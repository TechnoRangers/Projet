Public Class ReservationSalle
    Dim MaBd As P2014_BD_GestionHotelEntities
    Dim NoRes As Int32


    Sub New(ByRef _MaBD As P2014_BD_GestionHotelEntities, ByRef _NoRes As Int32, ByRef type As Int32)
        'va cherche la base de donnée et la connection 
        InitializeComponent()
        MaBd = _MaBD

        If Not _NoRes = 0 Then
            NoRes = _NoRes
        End If
        Select Case type
            Case 1
                LocSal_BtnValider.IsEnabled = True
                LocSal_BtnValider.Visibility = Windows.Visibility.Visible
            Case 2
                LocSal_BtnModiSalle.IsEnabled = True
                LocSal_BtnModiSalle.Visibility = Windows.Visibility.Visible
                LocSal_BtnEqu.IsEnabled = True
            Case Else
                LocSal_BtnEqu.IsEnabled = True
                LocSal_BtnAjout.Visibility = Windows.Visibility.Hidden
                LocSal_BtnRec.Visibility = Windows.Visibility.Hidden
        End Select

    End Sub

    Function Validation()
        'validation shit avant d'envoyer le formulaire
        'Debut de validation pour les champs qui sont obligatoirement des chiffres 
        Dim message As String
        message = "Une erreur est subvenue"
        Try
            Dim Rep = (From it In MaBd.tblReservationSalle
                       Where it.DateDebutReservSalle = LocSal_DatePicker.SelectedDate
                       Select it.CodeSalle)
            Dim res = From it In MaBd.tblSalle Where it.NomSalle.Equals(LocSal_CmbBoxSalle.SelectedItem.ToString) Select it.CodeSalle
            For Each resv In Rep.ToList()
                If resv.Equals(res.First) Then
                    message = "Il y a déja une réservation pour cette salle lors de cette journée"
                    Throw New System.Exception
                End If
            Next
            If LocSal_DatePicker.SelectedDate < Date.Today Then
                message = "Veuillez choisir une date valide"
                Throw New System.Exception
            End If
            If LocSal_TxtBoxClient.Text.Trim.Length = 0 Then
                message = "Veuillez rentrer un client"
                Throw New System.Exception
            End If
            If LocSal_TxtBoxNb.Text.Trim.Length = 0 Then
                message = "Veuillez indiquer le nombre de personne"
                Throw New System.Exception
            End If
            If LocSal_TxtBoxPrix.Text.Trim.Length = 0 Then
                message = "Veuillez indiquer le prix"
                Throw New System.Exception
            End If
            If LocSal_CmbBoxSalle.SelectedIndex = -1 Then
                message = "Veuillez choisir la salle"
                Throw New System.Exception
            End If
            If LocSal_CmbBoxPaiement.SelectedIndex = -1 Then
                message = "Veuillez choisir le mode de paiement"
                Throw New System.Exception
            End If
            If LocSal_TxtBoxCredit.Text.Trim.Length = 0 Then
                message = "Veuillez rentrer une carte de crédit"
                Throw New System.Exception
            End If
            If LocSal_TxtBoxExpi.Text.Trim.Length = 0 Then
                message = "Veuillez rentrer la date d'expiration"
                Throw New System.Exception
            End If
        Catch ex As Exception
            MessageBox.Show(message)
            Return False
        End Try
        Return True
    End Function

    Private Sub LocationSalles_Loaded(sender As Object, e As RoutedEventArgs) Handles MyBase.Loaded
        ' Ajoute les salles dans le comboBox Salle
            Dim rep = From it In MaBd.tblSalle Select it.NomSalle
            For Each Nom In rep.ToList
                LocSal_CmbBoxSalle.Items.Add(Nom)
            Next


            ' Ajoute les objets dans les comboBox
            LocSal_CmbBoxPaiement.Items.Add("Credit")
            LocSal_CmbBoxPaiement.Items.Add("Argent")
            LocSal_CmbBoxEtat.Items.Add("Non-Payé")
            LocSal_CmbBoxEtat.Items.Add("Payé")
            LocSal_CmbBoxEtat.Items.Add("Annulé")

        LocSal_DatePicker.SelectedDate = Date.Today

        recherche()
    End Sub

    Private Sub LocSal_BtnValider_Click(sender As Object, e As RoutedEventArgs) Handles LocSal_BtnValider.Click
        Dim NewEl As tblReservationSalle
        NewEl = New tblReservationSalle

        Dim result As Boolean
        result = Validation()
        If result = True Then
            'remplie les variable de la réservation 
            NewEl.NoSeqClient = Convert.ToInt32(LocSal_TxtBoxClient.Text)
            NewEl.DateDebutReservSalle = LocSal_DatePicker.Text
            NewEl.DateFinReservSalle = LocSal_DatePicker2.Text
            NewEl.ModePaiement = LocSal_CmbBoxPaiement.SelectedItem
            NewEl.NbPersonne = Convert.ToInt32(LocSal_TxtBoxNb.Text)
            NewEl.PrixReservSalle = Convert.ToDecimal(LocSal_TxtBoxPrix.Text)
            If Not IsNothing(LocSal_TxtBoxCredit.Text) Then
                NewEl.NoCarteCredit = LocSal_TxtBoxCredit.Text
            End If
            NewEl.StatutPaiement = LocSal_CmbBoxEtat.SelectedItem

            'Pour lier le code de salle au nom de la salle 
            Dim res = (From it In MaBd.tblSalle
                        Where it.NomSalle.Equals(LocSal_CmbBoxSalle.SelectedItem.ToString)
                        Select it.CodeSalle)
            NewEl.CodeSalle = (res.First()).ToString
            'Enregistrer le Nouvel Item 
            Try
                MaBd.tblReservationSalle.Add(NewEl)
                MaBd.SaveChanges()
                NoRes = NewEl.NoSeqReservSalle
                MessageBox.Show("La réservation a été ajouter")
                LocSal_BtnEqu.IsEnabled = True
                LocSal_BtnValider.Visibility = Windows.Visibility.Hidden
            Catch ex As Exception
                MessageBox.Show("Veuillez verifier tous les champs")
            End Try
        End If

    End Sub

    Private Sub LocSal_BtnCancel_Click(sender As Object, e As RoutedEventArgs) Handles LocSal_BtnCancel.Click
        'fermer la fenetre 
        Me.Close()
    End Sub

    Private Sub LocSal_BtnRec_Click(sender As Object, e As RoutedEventArgs) Handles LocSal_BtnRec.Click
        'Recher du client par le nom de famille et le Tel 
        Dim message As String = "Ce client n'existe pas"
        Try
            If LocSal_TxtBoxClient.Text = "" Then
                If LocSal_TxtBoxNom.Text.Trim.Length = 0 Then
                    message = "Vieullez rentrer un nom "
                    Throw New Exception
                End If
                Dim Res = (From Cl In MaBd.tblClient
                            Where Cl.NoTelephone.Equals(LocSal_TxtBoxTel.Text) And Cl.NomClient.Equals(LocSal_TxtBoxNom.Text)
                            Select Cl)
                'Remplie les donnée client pour que le commis puisse voir si c'est le bon client 
                LocSal_TxtBoxClient.Text = (Res.First.NoSeqClient).ToString
                LocSal_TxtBoxPre.Text = Res.First.PrenomClient
                LocSal_TxtBoxAdr.Text = Res.First.AdresseClient
                LocSal_TxtBoxEmail.Text = Res.First.EmailClient
            Else
                Dim Res = From it In MaBd.tblClient
                          Where it.NoSeqClient = LocSal_TxtBoxClient.Text
                          Select it
                'Remplie les donnée client pour que le commis puisse voir si c'est le bon client 
                LocSal_TxtBoxClient.Text = (Res.First.NoSeqClient).ToString
                LocSal_TxtBoxPre.Text = Res.First.PrenomClient
                LocSal_TxtBoxAdr.Text = Res.First.AdresseClient
                LocSal_TxtBoxEmail.Text = Res.First.EmailClient
                LocSal_TxtBoxTel.Text = Res.First.NoTelephone
                LocSal_TxtBoxNom.Text = Res.First.NomClient
                LocSal_TxtBoxComp.Text = Res.First.NomEntreprise
            End If



        Catch ex As Exception
            MessageBox.Show(message)
        End Try
    End Sub

    Private Sub LocSal_BtnAjout_Click(sender As Object, e As RoutedEventArgs) Handles LocSal_BtnAjout.Click
        'Inscription d'un client si le client n'existe pas 

        If validationClient() Then
            Dim NewCl As tblClient
            NewCl = New tblClient

            NewCl.NomClient = LocSal_TxtBoxNom.Text
            NewCl.PrenomClient = LocSal_TxtBoxPre.Text
            NewCl.NoTelephone = LocSal_TxtBoxTel.Text
            NewCl.AdresseClient = LocSal_TxtBoxAdr.Text
            NewCl.EmailClient = LocSal_TxtBoxEmail.Text
            NewCl.NomEntreprise = LocSal_TxtBoxComp.Text

            MaBd.tblClient.Add(NewCl)
            MaBd.SaveChanges()

            LocSal_TxtBoxClient.Text = NewCl.NoSeqClient.ToString
            MessageBox.Show("Le client a été ajouter")
        End If
    End Sub

    Private Sub OnKeyDownHandler(ByVal sender As Object, ByVal e As KeyEventArgs)
        'Vérifier quel touche l'utilisateur press pour ne prendre que des chiffres 
        Select Case e.Key
            Case Key.D0 To Key.D9
                e.Handled = False
            Case Key.NumPad0 To Key.NumPad9
                e.Handled = False
            Case Else
                e.Handled = True
        End Select
    End Sub
    Private Sub letter_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs)


        Select Case e.Key
            Case Key.D0 To Key.D9
                e.Handled = True
            Case Key.NumPad0 To Key.NumPad9
                e.Handled = True
            Case Else
                e.Handled = False
        End Select
    End Sub

    Private Sub recherche()
        'recherche de réservation de Salle 
        Try
            Dim X As Int16
            Dim El As tblReservationSalle

            Dim Rep = From It In MaBd.tblReservationSalle Where It.NoSeqReservSalle = NoRes Select It
            El = Rep.Single

            LocSal_TxtBoxClient.Text = El.NoSeqClient
            LocSal_TxtBoxNb.Text = El.NbPersonne
            LocSal_CmbBoxEtat.SelectedItem = El.StatutPaiement
            LocSal_CmbBoxPaiement.SelectedItem = El.ModePaiement
            LocSal_TxtBoxPrix.Text = FormatNumber(El.PrixReservSalle, 2)
            LocSal_DatePicker.SelectedDate = El.DateDebutReservSalle
            LocSal_DatePicker2.SelectedDate = El.DateFinReservSalle
            Dim Res = (From Cl In MaBd.tblClient
                        Where Cl.NoSeqClient = El.NoSeqClient
                        Select Cl)
            'Remplie les donnée client pour que le commis puisse voir si c'est le bon client 
            LocSal_TxtBoxNom.Text = Res.First.NomClient
            LocSal_TxtBoxPre.Text = Res.First.PrenomClient
            LocSal_TxtBoxAdr.Text = Res.First.AdresseClient
            LocSal_TxtBoxEmail.Text = Res.First.EmailClient
            LocSal_TxtBoxTel.Text = Res.First.NoTelephone
            'Pour mettre les bonne valeurs dans les combobox 
            X = 0
            For Each item In LocSal_CmbBoxSalle.Items
                If item.Equals(Rep.Single.tblSalle.NomSalle) Then
                    LocSal_CmbBoxSalle.SelectedIndex = X
                Else
                    X += 1
                End If
            Next
            X = 0
            If Not Rep.Single.StatutPaiement = Nothing Then
                For Each item In LocSal_CmbBoxEtat.Items
                    If item.Equals(Rep.Single.StatutPaiement) Then
                        LocSal_CmbBoxEtat.SelectedIndex = X
                    Else
                        X += 1
                    End If
                Next
            End If

        Catch ex As Exception
            If NoRes <> 0 Then
                MessageBox.Show("un erreur est subvenue")
            End If
        End Try
    End Sub

    Private Sub LocSal_BtnModiSalle_Click(sender As Object, e As RoutedEventArgs) Handles LocSal_BtnModiSalle.Click
        Dim rep = (From it In MaBd.tblReservationSalle
           Where it.NoSeqReservSalle = NoRes
           Select it)
        If rep.ToList.Count > 0 Then

            Dim ResChange = (From it In MaBd.tblReservationSalle
                             Where it.NoSeqReservSalle = NoRes
                             Select it).Single()

            ResChange.NbPersonne = LocSal_TxtBoxNb.Text
            If Not IsNothing(LocSal_TxtBoxCredit.Text) Then
                ResChange.NoCarteCredit = LocSal_TxtBoxCredit.Text
            Else
                ResChange.NoCarteCredit = rep.Single.NoCarteCredit
            End If

            ResChange.ModePaiement = LocSal_CmbBoxPaiement.SelectedItem
            ResChange.PrixReservSalle = LocSal_TxtBoxPrix.Text
            If Not LocSal_CmbBoxSalle.SelectedIndex = -1 Then
                Dim res = (From it In MaBd.tblSalle
                Where it.NomSalle.Equals(LocSal_CmbBoxSalle.SelectedItem.ToString)
                Select it.CodeSalle).Single()
                ResChange.CodeSalle = res
            End If


            ResChange.DateDebutReservSalle = LocSal_DatePicker.SelectedDate
            ResChange.DateFinReservSalle = LocSal_DatePicker2.SelectedDate
            Try
                MaBd.SaveChanges()
                MessageBox.Show("La modification a été faite")
            Catch ex As Exception
                MessageBox.Show("Erreur")
            End Try
        Else
            MessageBox.Show("Cette réservation n'existe pas")
        End If
    End Sub

    Private Sub LocSal_BtnEqu_Click(sender As Object, e As RoutedEventArgs) Handles LocSal_BtnEqu.Click

        Dim rep = (From it In MaBd.tblReservationSalle
        Where it.NoSeqReservSalle = NoRes
        Select it)
        If rep.ToList.Count > 0 Then
            Dim asd As New LocationEquipement(MaBd, NoRes)
            asd.Show()
        Else
            MessageBox.Show("Vieullez Valider la réservation avant de gérer l'équipement")
        End If

    End Sub

    Function validationClient()
        Dim message As String = "Une erreur est subvenue à la création du client"
        Try
            Dim cl = From it In MaBd.tblClient Where it.NomClient = LocSal_TxtBoxNom.Text And it.NoTelephone = LocSal_TxtBoxTel.Text Select it
            If cl.tolist.count <> 0 Then
                message = "Ce client existe déja"
                Throw New Exception
            End If
            If LocSal_TxtBoxPre.Text.Trim.Length = 0 Then
                message = "Vieullez rentrer un prénom "
                Throw New Exception
            End If
            If LocSal_TxtBoxNom.Text.Trim.Length = 0 Then
                message = "Vieullez rentrer un nom "
                Throw New Exception
            End If
            If LocSal_TxtBoxTel.Text.Trim.Length = 0 Then
                message = "Vieullez rentrer un numéros de téléphone "
                Throw New Exception
            End If
            If LocSal_TxtBoxAdr.Text.Trim.Length = 0 Then
                message = "Vieullez rentrer une adresse"
                Throw New Exception
            End If
            If LocSal_TxtBoxEmail.Text.Trim.Length = 0 Then
                message = "Vieullez rentrer une adresse courriel "
                Throw New Exception
            End If
        Catch ex As Exception
            MessageBox.Show(message)
            Return False
        End Try
        Return True
    End Function

    Private Sub Window_Closing(sender As Object, e As ComponentModel.CancelEventArgs)
        Dim it As New dispoSalle(MaBd)
        it.Show()
    End Sub


End Class

