Public Class ReservationSalle
    Dim MaBd As P2014_BDTestFrancoisEntities

    Function Validation()
        'validation shit avant d'envoyer le formulaire
        'Debut de validation pour les champs qui sont obligatoirement des chiffres 
        Try
            If LocSal_TxtBoxClient.Text.Trim.Length = 0 Then
                Throw New System.Exception
            End If
            If LocSal_TxtBoxNb.Text.Trim.Length = 0 Then
                Throw New System.Exception
            End If
            If LocSal_TxtBoxCredit.Text.Trim.Length = 0 Then
                Throw New System.Exception
            End If
            If LocSal_TxtBoxPrix.Text.Trim.Length = 0 Then
                Throw New System.Exception
            End If
            If LocSal_CmbBoxSalle.SelectedIndex = 0 Then
                Throw New System.Exception
            End If
            If LocSal_CmbBoxPaiement.SelectedIndex = 0 Then
                Throw New System.Exception
            End If
            '   If LocSal_DatePicker.SelectedDateThen
            'Throw New System.Exception
            'End If
        Catch ex As Exception
            MessageBox.Show("La réservation n'a pu être ajouter, vérifier tous les champs")
            Return False
        End Try
        Return True
    End Function

    Private Sub LocationSalles_Loaded(sender As Object, e As RoutedEventArgs) Handles MyBase.Loaded
        MaBd = New P2014_BDTestFrancoisEntities
        ' Ajoute les salles dans le comboBox Salle
        Dim rep = From it In MaBd.tblSalle Select it.NomSalle
        For Each Nom In rep.ToList
            LocSal_CmbBoxSalle.Items.Add(Nom)
        Next
        ' Ajoute les objets dans les comboBox
        LocSal_CmbBoxPaiement.Items.Add("Credit")
        LocSal_CmbBoxPaiement.Items.Add("Argent")
        LocSal_CmbBoxPaiement.Items.Add("Nature")
        LocSal_CmbBoxEtat.Items.Add("Non-Payé")
        LocSal_CmbBoxEtat.Items.Add("Payé")
        LocSal_CmbBoxEtat.Items.Add("Annulé")


    End Sub

    Private Sub LocSal_BtnValider_Click(sender As Object, e As RoutedEventArgs) Handles LocSal_BtnValider.Click
        Dim NewEl As tblReservationSalle
        NewEl = New tblReservationSalle

        Dim result As Boolean
        result = Validation()
        If result = True Then
            'remplie les variable de la réservation 
            NewEl.NoSeqClient = Convert.ToInt32(LocSal_TxtBoxClient.Text)
            NewEl.DateReservSalle = LocSal_DatePicker.Text
            NewEl.ModePaiement = LocSal_CmbBoxPaiement.SelectedItem
            NewEl.NbPersonne = Convert.ToInt32(LocSal_TxtBoxNb.Text)
            NewEl.PrixReservSalle = Convert.ToDecimal(LocSal_TxtBoxPrix.Text)
            NewEl.NoCarteCredit = LocSal_TxtBoxCredit.Text
            NewEl.StatutPaiement = LocSal_CmbBoxEtat.SelectedItem

            'Pour lier le code de salle au nom de la salle 
            Dim res = (From it In MaBd.tblSalle
                        Where it.NomSalle.Equals(LocSal_CmbBoxSalle.SelectedItem.ToString)
                        Select it.CodeSalle)
            NewEl.CodeSalle = (res.First()).ToString

            Try
                MaBd.tblReservationSalle.Add(NewEl)
                MaBd.SaveChanges()
                LocSal_TxtBoxNoRes.Text = NewEl.NoSeqReservSalle
                MessageBox.Show("La réservation a été ajouter")
            Catch ex As Exception
                MessageBox.Show("Veuillez verifier tous les champs")
            End Try
        End If

    End Sub

    Private Sub LocSal_BtnCancel_Click(sender As Object, e As RoutedEventArgs) Handles LocSal_BtnCancel.Click
        'fermer la fenetre pour le moment pourrais eventuellement demander si l'utilisateur veut seulement effacer les données inscrit
        Dim Menu As New Menu
        Menu.Show()
        Me.Close()
    End Sub

    Private Sub LocSal_BtnRec_Click(sender As Object, e As RoutedEventArgs) Handles LocSal_BtnRec.Click
        Try
            'Recher du client par le nom de famille et le Tel 
            Dim Res = (From Cl In MaBd.tblClient
                        Where Cl.NoTelephone.Equals(LocSal_TxtBoxTel.Text) And Cl.NomClient.Equals(LocSal_TxtBoxNom.Text)
                        Select Cl)
            'Remplie les donnée client pour que le commis puisse voir si c'est le bon client 
            LocSal_TxtBoxClient.Text = (Res.First.NoSeqClient).ToString
            LocSal_TxtBoxPre.Text = Res.First.PrenomClient
            LocSal_TxtBoxAdr.Text = Res.First.AdresseClient
            LocSal_TxtBoxEmail.Text = Res.First.EmailClient



        Catch ex As Exception
            MessageBox.Show("le client  n'existe pas")
        End Try
    End Sub

    Private Sub LocSal_BtnAjout_Click(sender As Object, e As RoutedEventArgs) Handles LocSal_BtnAjout.Click
        'Inscription d'un client si le client n'existe pas 
        Dim NewCl As tblClient
        NewCl = New tblClient

        NewCl.NomClient = LocSal_TxtBoxNom.Text
        NewCl.PrenomClient = LocSal_TxtBoxPre.Text
        NewCl.NoTelephone = LocSal_TxtBoxTel.Text
        NewCl.AdresseClient = LocSal_TxtBoxAdr.Text
        NewCl.EmailClient = LocSal_TxtBoxEmail.Text

        MaBd.tblClient.Add(NewCl)
        MaBd.SaveChanges()

        LocSal_TxtBoxClient.Text = NewCl.NoSeqClient.ToString
    End Sub

End Class

