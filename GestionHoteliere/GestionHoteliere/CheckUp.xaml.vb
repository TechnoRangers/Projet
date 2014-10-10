Public Class CheckUp

    Dim MaBD As P2014_BDTestFrancoisEntities
    Dim _maChambre As tblChambre

    Sub New()
        MaBD = New P2014_BDTestFrancoisEntities
        _maChambre = New tblChambre
        InitializeComponent()
    End Sub



    Private Sub Che_FrmChe_Loaded(sender As Object, e As RoutedEventArgs) Handles Che_FrmChe.Loaded

        'Remplir ComboBoxNoChambre
        Dim NoChambre = From tabChambre In MaBD.tblChambre
                     Select tabChambre

        Che_ComboBoxNoChambre.ItemsSource = NoChambre.ToList
        Che_ComboBoxNoChambre.DisplayMemberPath = "NoSeqChambre"
        Che_ComboBoxNoChambre.SelectedValue = NoChambre.ToList

    End Sub

 
    Private Sub Che_ComboBoxNoChambre_SelectionChanged(sender As Object, e As SelectionChangedEventArgs) Handles Che_ComboBoxNoChambre.SelectionChanged

        _maChambre = CType(Che_ComboBoxNoChambre.SelectedItem, tblChambre)

        FiltrerDatagrid()

    End Sub

    Sub FiltrerDatagrid()
        If _maChambre.NoSeqChambre <> 0 Then
            Dim res = From t1 In MaBD.tblFourniture
                                Where t1.NoSeqChambre = _maChambre.NoSeqChambre
                                Select t1

            Dim res2 = From t1 In MaBD.tblEntretienFourniture, t2 In res
                                Where t1.NoSeqFourniture = t2.NoSeqFourniture And t1.EtatFourniture = "A remplacer"
                                Select t2

            Dim aLaFin = From el In res.Except(res2) Select New With {.Fourniture = el, .EstCocher = False}

            Che_Datagrid.ItemsSource = aLaFin.ToList

        End If
    End Sub


    Private Sub Che_BtnEnregistrer_Click(sender As Object, e As RoutedEventArgs) Handles Che_BtnEnregistrer.Click

        Dim Commentaires As New TextRange(Che_RichTxtBoxCom.Document.ContentStart, Che_RichTxtBoxCom.Document.ContentEnd)

        If Che_ComboBoxNoChambre.SelectedItem IsNot Nothing Then

            Dim res = From el In Che_Datagrid.ItemsSource Where el.EstCocher = True Select el.Fourniture

            For Each f As tblFourniture In res
                Dim res2 = From t1 In MaBD.tblEntretienFourniture
                           Where f.NoSeqFourniture = t1.NoSeqFourniture
                           Select t1

                If res2.Count <> 0 Then
                    Dim update = (From t1 In MaBD.tblEntretienFourniture
                 Where f.NoSeqFourniture = t1.NoSeqFourniture Select t1)


                    update.First().EtatFourniture = "A remplacer"
                    update.First().CommentaireFourniture = Commentaires.Text

                    Try
                        MaBD.SaveChanges()
                    Catch
                        MessageBox.Show("Erreur")
                    End Try

                Else
                    Dim MonItem As New tblEntretienFourniture()
                    Try


                        MonItem.NoSeqFourniture = f.NoSeqFourniture
                        MonItem.NoEmploye = 1009
                        MonItem.EtatFourniture = "A remplacer"
                        MonItem.CommentaireFourniture = Commentaires.Text
                        MaBD.tblEntretienFourniture.Add(MonItem)
                        MaBD.SaveChanges()

                    Catch ex As Exception
                        MaBD.tblEntretienFourniture.Remove(MonItem)
                        MessageBox.Show("Erreur lors de l'ajout de l'item.")
                    End Try
                End If
            Next


            If res.ToList.Count <> 0 Then

                MessageBox.Show("L'enregistrement a bien été effectuer")
            Else
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
