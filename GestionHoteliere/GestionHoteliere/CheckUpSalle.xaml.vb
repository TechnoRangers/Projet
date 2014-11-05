Public Class CheckUpSalle

    Dim BD As P2014_BD_GestionHotelEntities
    Dim _MaReservationSalle As tblReservationSalle

    Sub New(ByRef _BD As P2014_BD_GestionHotelEntities)
        InitializeComponent()
        BD = _BD
    End Sub
    Private Sub Che_FrmSalle_Loaded(sender As Object, e As RoutedEventArgs) Handles Che_FrmSalle.Loaded

        'Remplir ComboBoxNomSalle
        Dim NoReservation = From el In BD.tblReservationSalle
                     Select el

        Che_ComboBoxNoReservationSalle.ItemsSource = NoReservation.ToList
        Che_ComboBoxNoReservationSalle.DisplayMemberPath = "NoSeqReservSalle"
        Che_ComboBoxNoReservationSalle.SelectedValue = NoReservation.ToList

    End Sub

    Private Sub Che_ComboBoxNoReservationSalle_SelectionChanged(sender As Object, e As SelectionChangedEventArgs) Handles Che_ComboBoxNoReservationSalle.SelectionChanged

        _MaReservationSalle = CType(Che_ComboBoxNoReservationSalle.SelectedItem, tblReservationSalle)

        FiltrerDatagrid()
    End Sub

    Sub FiltrerDatagrid()
        If _MaReservationSalle.NoSeqReservSalle <> 0 Then
            Dim res = From t1 In _MaReservationSalle.tblFournitureReservationSalle Select t1.tblFourniture

            Dim res2 = From el In res Select New With {.Fourniture = el, .Salle = _MaReservationSalle.tblSalle, .ARemplacer = False, .AReparer = False}

            Che_Datagrid.ItemsSource = res2.ToList


            Dim res3 = From t1 In BD.tblEntretienFournitureSalle Join t2 In BD.tblFourniture On t2.CodeFourniture Equals t1.CodeFourniture
                      Where t1.CodeFourniture = t2.CodeFourniture And t1.NoSeqReservSalle = _MaReservationSalle.NoSeqReservSalle
                      Select t1.NoEmploye, t2.DescFourniture, t1.EtatFourniture, t1.DateDemande, t1.DateEffectue, t1.StatutEntretien

            Che_DatagridLstEntretien.ItemsSource = res3.ToList

        End If
    End Sub




    Private Sub Che_BtnEnregistrer_Click(sender As Object, e As RoutedEventArgs) Handles Che_BtnEnregistrer.Click

        Dim Commentaires As New TextRange(Che_RichTxtBoxCom.Document.ContentStart, Che_RichTxtBoxCom.Document.ContentEnd)

        If Che_ComboBoxNoReservationSalle.SelectedItem IsNot Nothing Then

            Dim res = From el In Che_Datagrid.ItemsSource Where el.ARemplacer = True Select el.Fourniture

            Dim res2 = From el In Che_Datagrid.ItemsSource Where el.AReparer = True Select el.Fourniture

            For Each f As tblFourniture In res
                Dim res3 = From t1 In BD.tblEntretienFournitureSalle
                           Where f.CodeFourniture = t1.CodeFourniture And t1.NoSeqReservSalle = _MaReservationSalle.NoSeqReservSalle
                           Select t1

                If res3.Count <> 0 Then
                    Dim update = (From t1 In BD.tblEntretienFournitureSalle
                 Where f.CodeFourniture = t1.CodeFourniture Select t1)


                    update.First().EtatFourniture = "A remplacer"
                    update.First().CommentaireFourniture = Commentaires.Text
                    update.First().DateDemande = Date.Today
                    update.First().StatutEntretien = "En cours"

                    Try
                        BD.SaveChanges()
                    Catch
                        MessageBox.Show("Erreur")
                    End Try

                Else
                    Dim MonItem As New tblEntretienFournitureSalle()
                    Try

                        MonItem.EtatFourniture = "A remplacer"
                        MonItem.CommentaireFourniture = Commentaires.Text
                        MonItem.DateDemande = Date.Today
                        MonItem.StatutEntretien = "En cours"
                        MonItem.NoSeqReservSalle = _MaReservationSalle.NoSeqReservSalle
                        MonItem.CodeFourniture = f.CodeFourniture
                        MonItem.CodeSalle = _MaReservationSalle.CodeSalle
                        MonItem.NoEmploye = 1009


                        BD.tblEntretienFournitureSalle.Add(MonItem)
                        BD.SaveChanges()

                    Catch ex As Exception
                        BD.tblEntretienFournitureSalle.Remove(MonItem)
                        MessageBox.Show("Erreur lors de l'ajout de l'item.")
                    End Try
                End If
            Next

            For Each f2 As tblFourniture In res2
                Dim res4 = From t1 In BD.tblEntretienFournitureSalle
                           Where f2.CodeFourniture = t1.CodeFourniture And t1.NoSeqReservSalle = _MaReservationSalle.NoSeqReservSalle
                           Select t1

                If res4.Count <> 0 Then
                    Dim update = (From t1 In BD.tblEntretienFournitureSalle
                 Where f2.CodeFourniture = t1.CodeFourniture Select t1)


                    update.First().EtatFourniture = "A réparer"
                    update.First().CommentaireFourniture = Commentaires.Text
                    update.First().DateDemande = Date.Today
                    update.First().StatutEntretien = "En cours"

                    Try
                        BD.SaveChanges()
                    Catch
                        MessageBox.Show("Erreur")
                    End Try

                Else
                    Dim MonItem As New tblEntretienFournitureSalle()
                    Try

                        MonItem.EtatFourniture = "A réparer"
                        MonItem.CommentaireFourniture = Commentaires.Text
                        MonItem.DateDemande = Date.Today
                        MonItem.StatutEntretien = "En cours"
                        MonItem.NoSeqReservSalle = _MaReservationSalle.NoSeqReservSalle
                        MonItem.CodeFourniture = f2.CodeFourniture
                        MonItem.CodeSalle = _MaReservationSalle.CodeSalle
                        MonItem.NoEmploye = 1009


                        BD.tblEntretienFournitureSalle.Add(MonItem)
                        BD.SaveChanges()

                    Catch ex As Exception
                        BD.tblEntretienFournitureSalle.Remove(MonItem)
                        MessageBox.Show("Erreur lors de l'ajout de l'item.")
                    End Try
                End If
            Next


            If res.ToList.Count <> 0 Or res2.ToList.Count <> 0 Then

                MessageBox.Show("L'enregistrement a bien été effectuer")

            ElseIf res.ToList.Count = 0 And res2.ToList.Count = 0 Then

                MessageBox.Show("Aucune fourniture n'a été cochée")

            End If

        Else
            MessageBox.Show("Veuillez sélectionner une chambre")
        End If

        Commentaires.Text = ""
        FiltrerDatagrid()
    End Sub

    Private Sub Che_BtnAnnuler_Click(sender As Object, e As RoutedEventArgs) Handles Che_BtnAnnuler.Click
        Me.Close()
    End Sub
End Class
