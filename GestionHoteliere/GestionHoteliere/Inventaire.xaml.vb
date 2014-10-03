Public Class Inventaire

    Dim MaBD As P2014_BDTestFrancoisEntities
    Dim _monHotel As tblHotel
    Dim _macategorie As tblCategorieFourniture

    Sub New()
        MaBD = New P2014_BDTestFrancoisEntities
        _monHotel = New tblHotel
        _macategorie = New tblCategorieFourniture
        InitializeComponent()
    End Sub

    Private Sub Inv_frmInventaire_Loaded(sender As Object, e As RoutedEventArgs) Handles Inv_frmInventaire.Loaded
        'Remplir ComboBox_Hotel
        Dim Hotels = From tabHotel In MaBD.tblHotel
                     Select tabHotel

        Inv_ComboBoxHotel.ItemsSource = Hotels.ToList
        Inv_ComboBoxHotel.DisplayMemberPath = "NomHotel"
        Inv_ComboBoxHotel.SelectedValue = Hotels.ToList.First

        'Remplir ComboBox_Categorie
        Dim Categories = From tabCategorie In MaBD.tblCategorieFourniture
                         Select tabCategorie

        inv_cmbCategorie.ItemsSource = Categories.ToList
        inv_cmbCategorie.DisplayMemberPath = "NomCategorie"
        inv_cmbCategorie.SelectedValue = Categories.ToList.Last

    End Sub

    Private Sub Inv_ComboBoxHotel_SelectionChanged(sender As Object, e As SelectionChangedEventArgs) Handles Inv_ComboBoxHotel.SelectionChanged
        _monHotel = CType(Inv_ComboBoxHotel.SelectedItem, tblHotel)

        FiltrerDatagrid()
    End Sub

    Private Sub inv_cmbCategorie_SelectionChanged(sender As Object, e As SelectionChangedEventArgs) Handles inv_cmbCategorie.SelectionChanged
        _macategorie = CType(inv_cmbCategorie.SelectedItem, tblCategorieFourniture)

        FiltrerDatagrid()
    End Sub

    Sub FiltrerDatagrid()
        If _macategorie.CodeCategorie IsNot Nothing And _monHotel.CodeHotel IsNot Nothing And _macategorie.CodeCategorie <> "TOU" Then
            Dim resInventaire = From vueinventaire In MaBD.VueInventaire
                                Where vueinventaire.CodeCategorie = _macategorie.CodeCategorie And vueinventaire.CodeHotel = _monHotel.CodeHotel
                                Select vueinventaire

            DatagridInv.ItemsSource = resInventaire.ToList
        Else
            Dim resinventaire = From vueinventaire In MaBD.VueInventaire
                                Where vueinventaire.CodeHotel = _monHotel.CodeHotel
                                Select vueinventaire

            DatagridInv.ItemsSource = resinventaire.ToList
        End If
    End Sub


    Private Sub Inv_btnAnnuler_Click(sender As Object, e As RoutedEventArgs) Handles Inv_btnAnnuler.Click

        Dim Menu_ As New Menu
        Menu_.Show()
        Me.Close()

    End Sub

    Private Sub Inv_btnCommander_Click(sender As Object, e As RoutedEventArgs) Handles Inv_btnCommander.Click

        Dim FenetreCommande As CommanderFourniture
        FenetreCommande = New CommanderFourniture(MaBD)
        FenetreCommande.ShowDialog()

    End Sub

    Private Sub Inv_btnAjouter_Click(sender As Object, e As RoutedEventArgs) Handles Inv_btnAjouter.Click

        Dim FenetreAjouter As AjoutItemInventaire
        FenetreAjouter = New AjoutItemInventaire(MaBD, _monHotel)
        FenetreAjouter.ShowDialog()

        FiltrerDatagrid()
        'Dim FenetreAjouter As Ajouter
        'FenetreAjouter = New Ajouter(MaBD, _monHotel)
        'FenetreAjouter.ShowDialog()

        'If Inv_ComboBoxHotel IsNot Nothing Then

        '    Dim res = From t1 In MaBD.tblFournisseur Join t2 In MaBD.tblFournitureFournisseur On t1.CodeFournisseur Equals t2.CodeFournisseur Join t3 In MaBD.tblFournitureHotel On t3.CodeFourniture Equals t2.CodeFourniture
        '                 Where t3.CodeHotel = _monHotel.CodeHotel
        '                Select New With {.NomFournisseur = t1.NomFournisseur, .codeFourniture = t2.CodeFourniture, .DescFourniture = t2.tblFourniture.DescFourniture, .Prix = t2.PrixFournitureFournisseur, .QuantiteMin = t3.QuantiteMin, .QuantiteMax = t3.QuantiteMax, .Quantite = t3.QuantiteFournitureHotel}
        '    DatagridInv.ItemsSource = res.ToList()

        'End If

    End Sub

    Private Sub Inv_btnSupprimer_Click(sender As Object, e As RoutedEventArgs) Handles Inv_btnSupprimer.Click

        Try
            Dim FournitureSelection As VueInventaire = CType(DatagridInv.SelectedItem, VueInventaire)
            Dim Fourniture As tblFourniture

            Fourniture = (From tabFourniture In MaBD.tblFourniture
                         Where tabFourniture.CodeFourniture = FournitureSelection.CodeFourniture
                         Select tabFourniture).ToList.First

            MaBD.tblFourniture.Remove(Fourniture)
            MaBD.SaveChanges()
            MessageBox.Show("L'item " + FournitureSelection.CodeFourniture + " a été supprimé.")
        Catch ex As Exception
            MessageBox.Show("Erreur lors de la suppression.")
        End Try

        FiltrerDatagrid()

    End Sub

    Private Sub Inv_BtnRechercheCode_Click(sender As Object, e As RoutedEventArgs) Handles Inv_BtnRechercheCode.Click

        Dim Trouver As Boolean
        Trouver = False
        Dim i As Integer
        i = 0

        Dim res = From q1 In MaBD.tblFourniture
                  Select q1.CodeFourniture

        While i < res.Count And Trouver = False
            If Inv_textBoxRechercheCode.Text = res.ToList(i) Then
                Trouver = True
            End If
            i = i + 1
        End While

        If Trouver = True Then
            Dim res2 = From t1 In MaBD.tblFournisseur Join t2 In MaBD.tblFournitureFournisseur On t1.CodeFournisseur Equals t2.CodeFournisseur Join t3 In MaBD.tblFournitureHotel On t3.CodeFourniture Equals t2.CodeFourniture
                          Where t3.CodeHotel = _monHotel.CodeHotel And t3.CodeFourniture = Inv_textBoxRechercheCode.Text
                         Select New With {.NomFournisseur = t1.NomFournisseur, .codeFourniture = t2.CodeFourniture, .DescFourniture = t2.tblFourniture.DescFourniture, .Prix = t2.PrixFournitureFournisseur, .QuantiteMin = t3.QuantiteMin, .QuantiteMax = t3.QuantiteMax, .Quantite = t3.QuantiteFournitureHotel}


            DatagridInv.ItemsSource = res2.ToList()
        ElseIf Trouver = False Then
            MessageBox.Show("Code inexistant")
        End If

    End Sub
End Class
