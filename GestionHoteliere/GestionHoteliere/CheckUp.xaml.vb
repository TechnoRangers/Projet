Public Class CheckUp

    Dim MaBD As P2014_BD_GestionHotelEntities
    Dim _maChambre As tblChambre

    Sub New()
        MaBD = New P2014_BD_GestionHotelEntities
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
            Dim res = From t1 In _maChambre.tblFournitureChambre Select t1.tblFourniture

            Dim res2 = From el In res Select New With {.Fourniture = el, .EstCocher = False}

            Che_Datagrid.ItemsSource = res2.ToList
            'Dim res = From t1 In MaBD.tblFournitureChambre Join t2 In MaBD.tblFourniture On t1.CodeFourniture Equals t2.CodeFourniture
            '                    Where t1.NoSeqChambre = _maChambre.NoSeqChambre
            '                    Select New With {.t1 = t1, .t2 = t2}

            '    Dim res2 = From t1 In MaBD.tblEntretienFourniture, t2 In res.
            'Where t1.CodeFourniture = t2.CodeFourniture And t1.EtatFourniture = "A remplacer"
            '                   Select t2

            ' Dim aLaFin = From el In res.Except(res2) Select New With {.Fourniture = el, .EstCocher = False}

            ' Che_Datagrid.ItemsSource = aLaFin.ToList

            'Remplir DataGrid Liste entretien

            Dim res3 = From t1 In MaBD.tblEntretienFournitureChambre Join t2 In MaBD.tblFourniture On t2.CodeFourniture Equals t1.CodeFourniture
                      Where t1.CodeFourniture = t2.CodeFourniture And t1.NoSeqChambre = _maChambre.NoSeqChambre
                      Select t1.NoEmploye, t2.DescFourniture, t1.EtatFourniture, t1.DateDemande, t1.DateEffectue, t1.StatutEntretien

            Che_DatagridLstEntretien.ItemsSource = res3.ToList

        End If
    End Sub


    Private Sub Che_BtnEnregistrer_Click(sender As Object, e As RoutedEventArgs) Handles Che_BtnEnregistrer.Click

        Dim Commentaires As New TextRange(Che_RichTxtBoxCom.Document.ContentStart, Che_RichTxtBoxCom.Document.ContentEnd)

        If Che_ComboBoxNoChambre.SelectedItem IsNot Nothing Then

            Dim res = From el In Che_Datagrid.ItemsSource Where el.EstCocher = True Select el.Fourniture

            For Each f As tblFourniture In res
                Dim res2 = From t1 In MaBD.tblEntretienFournitureChambre
                           Where f.CodeFourniture = t1.CodeFourniture And t1.NoSeqChambre = _maChambre.NoSeqChambre
                           Select t1

                If res2.Count <> 0 Then
                    Dim update = (From t1 In MaBD.tblEntretienFournitureChambre
                 Where f.CodeFourniture = t1.CodeFourniture Select t1)


                    update.First().EtatFourniture = "A remplacer"
                    update.First().CommentaireFourniture = Commentaires.Text
                    update.First().DateDemande = Date.Today
                    update.First().StatutEntretien = "En cours"

                    Try
                        MaBD.SaveChanges()
                    Catch
                        MessageBox.Show("Erreur")
                    End Try

                Else
                    Dim MonItem As New tblEntretienFournitureChambre()
                    Try

                        MonItem.EtatFourniture = "A remplacer"
                        MonItem.CommentaireFourniture = Commentaires.Text
                        MonItem.DateDemande = Date.Today
                        MonItem.StatutEntretien = "En cours"
                        MonItem.CodeFourniture = f.CodeFourniture
                        MonItem.NoSeqChambre = _maChambre.NoSeqChambre
                        MonItem.NoEmploye = 1009


                        MaBD.tblEntretienFournitureChambre.Add(MonItem)
                        MaBD.SaveChanges()

                    Catch ex As Exception
                        MaBD.tblEntretienFournitureChambre.Remove(MonItem)
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
