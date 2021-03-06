﻿Public Class ReservationSalle
    Dim MaBd As P2014_BDTestFrancoisEntities
    Dim NoRes As Int32
    Dim Connexion As tblEmploye

    Sub New(ByRef _MaBD As P2014_BDTestFrancoisEntities, ByRef _Connexion As tblEmploye)
        'va cherche la base de donnée et la connection 
        InitializeComponent()
        MaBd = _MaBD
        Connexion = _Connexion
    End Sub

    Function Validation()
        'validation shit avant d'envoyer le formulaire
        'Debut de validation pour les champs qui sont obligatoirement des chiffres 
        Dim message As String
        message = "Une erreur est subvenue"
        Try
            Dim Rep = (From it In MaBd.tblReservationSalle
                       Where it.DateReservSalle = LocSal_DatePicker.SelectedDate
                       Select it.CodeSalle)
            Dim res = From it In MaBd.tblSalle Where it.NomSalle.Equals(LocSal_CmbBoxSalle.SelectedItem.ToString) Select it.CodeSalle
            For Each resv In Rep.ToList()
                If resv.Equals(res.First) Then
                    message = "Il y a déja une réservation pour cette salle lors de cette journée"
                    Throw New System.Exception
                End If
            Next
            If LocSal_TxtBoxClient.Text.Trim.Length = 0 Then
                message = "Veuillez remplir le champs"
                Throw New System.Exception
            End If
            If LocSal_TxtBoxNb.Text.Trim.Length = 0 Then
                message = "Veuillez remplir le champs"
                Throw New System.Exception
            End If
            If LocSal_TxtBoxPrix.Text.Trim.Length = 0 Then
                message = "Veuillez remplir le champs"
                Throw New System.Exception
            End If
            If LocSal_CmbBoxSalle.SelectedIndex = 0 Then
                message = "Veuillez remplir le champs"
                Throw New System.Exception
            End If
            If LocSal_CmbBoxPaiement.SelectedIndex = 0 Then
                message = "Veuillez remplir le champs"
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
        If IsNothing(Connexion) Then
            Dim rep = From it In MaBd.tblSalle Select it.NomSalle
            For Each Nom In rep.ToList
                LocSal_CmbBoxSalle.Items.Add(Nom)
            Next
        Else
            Dim rep = From it In MaBd.tblSalle Where it.CodeHotel.Equals(Connexion.CodeHotel) Select it.NomSalle
            For Each Nom In rep.ToList
                LocSal_CmbBoxSalle.Items.Add(Nom)
            Next
        End If
        ' Ajoute les objets dans les comboBox
        LocSal_CmbBoxPaiement.Items.Add("Credit")
        LocSal_CmbBoxPaiement.Items.Add("Argent")
        LocSal_CmbBoxPaiement.Items.Add("Nature")
        LocSal_CmbBoxEtat.Items.Add("Non-Payé")
        LocSal_CmbBoxEtat.Items.Add("Payé")
        LocSal_CmbBoxEtat.Items.Add("Annulé")

        LocSal_DatePicker.SelectedDate = Date.Today
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
                LocSal_TxtBoxNoRes.Text = NewEl.NoSeqReservSalle
                NoRes = NewEl.NoSeqReservSalle
                MessageBox.Show("La réservation a été ajouter")
                ' LocSal_Equi.IsEnabled = True
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

    Private Sub LocSal_Equi_Click(sender As Object, e As RoutedEventArgs) Handles LocSal_Equi.Click
        'pour montrer l'Équipement
        Dim Locequ As New LocationEquipement(MaBd, NoRes)
        Locequ.Show()
    End Sub

    Private Sub LocSal_RecSal_Click(sender As Object, e As RoutedEventArgs) Handles LocSal_RecSal.Click
        'recherche de réservation de Salle 
        If Not IsNothing(LocSal_TxtBoxNoRes.Text) Then
            Try
                Dim X As Int16
                Dim El As tblReservationSalle
                Dim Rep = From It In MaBd.tblReservationSalle Where It.NoSeqReservSalle = LocSal_TxtBoxNoRes.Text Select It
                El = Rep.First

                LocSal_TxtBoxClient.Text = El.NoSeqClient
                LocSal_TxtBoxNb.Text = El.NoCarteCredit
                LocSal_CmbBoxEtat.SelectedItem = El.StatutPaiement
                LocSal_CmbBoxPaiement.SelectedItem = El.ModePaiement
                LocSal_TxtBoxPrix.Text = El.PrixReservSalle
                LocSal_DatePicker.SelectedDate = El.DateReservSalle

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
                    If item.Equals(Rep.First.tblSalle.NomSalle) Then
                        LocSal_CmbBoxSalle.SelectedIndex = X
                    Else
                        X += 1
                    End If
                Next

                X = 0
                For Each item In LocSal_CmbBoxEtat.Items
                    If item.Equals(Rep.First.StatutPaiement) Then
                        LocSal_CmbBoxEtat.SelectedIndex = X
                    Else
                        X += 1
                    End If
                Next
                LocSal_BtnAjout.IsEnabled = False
            Catch ex As Exception
                'Si le responsable ne rentre pas de réservation existant
                MessageBox.Show("La réservation N'existe pas")
                LocSal_TxtBoxNoRes.Text = ""
                LocSal_TxtBoxNoRes.Focus()
            End Try
        Else
            'Si le champs est vide 
            MessageBox.Show("Veuillez rentré un numéros de réservation pour la recherche")
            LocSal_TxtBoxNoRes.Focus()
        End If

    End Sub
End Class

