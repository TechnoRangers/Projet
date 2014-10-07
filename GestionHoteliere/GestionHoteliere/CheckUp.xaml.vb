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
                                Select New With {.Fourniture = t1, .EstCocher = False}
            Che_Datagrid.ItemsSource = res.ToList

        End If
    End Sub


    Private Sub Che_BtnEnregistrer_Click(sender As Object, e As RoutedEventArgs) Handles Che_BtnEnregistrer.Click


        Dim res = From el In Che_Datagrid.ItemsSource Where el.EstCocher = True Select el.Fourniture

        For Each f As tblFourniture In res
            Dim MonItem As New tblEntretienFourniture()
            Try


                MonItem.NoSeqFourniture = f.NoSeqFourniture
                MonItem.NoEmploye = 1009
                MonItem.EtatFourniture = "A remplacer"
                MonItem.CommentaireFourniture = "Thats it"
                MaBD.tblEntretienFourniture.Add(MonItem)
                MaBD.SaveChanges()

            Catch ex As Exception
                MaBD.tblEntretienFourniture.Remove(MonItem)
                MessageBox.Show("Erreur lors de l'ajout de l'item.")
            End Try
        Next

        MessageBox.Show("L'enregistrement a bien été effectuer")

    End Sub
End Class
