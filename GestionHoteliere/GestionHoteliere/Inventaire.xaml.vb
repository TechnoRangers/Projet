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
                                Where vueinventaire.CodeCategorie = _macategorie.CodeCategorie And vueinventaire.CodeHotel = _monHotel.CodeHotel And vueinventaire.CodeFourniture.StartsWith(Inv_textBoxRechercheCode.Text)
                                Select vueinventaire

            DatagridInv.ItemsSource = resInventaire.ToList
        Else
            Dim resinventaire = From vueinventaire In MaBD.VueInventaire
                                Where vueinventaire.CodeHotel = _monHotel.CodeHotel And vueinventaire.CodeFourniture.StartsWith(Inv_textBoxRechercheCode.Text)
                                Select vueinventaire

            DatagridInv.ItemsSource = resinventaire.ToList
        End If
    End Sub


    Private Sub Inv_btnAnnuler_Click(sender As Object, e As RoutedEventArgs) Handles Inv_btnAnnuler.Click

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

    End Sub

    Private Sub Inv_btnSupprimer_Click(sender As Object, e As RoutedEventArgs) Handles Inv_btnSupprimer.Click

        Try
            Dim FournitureSelection As VueInventaire = CType(DatagridInv.SelectedItem, VueInventaire)
            Dim Fourniture As tblFourniture

            Fourniture = (From tabFourniture In MaBD.tblFourniture
                         Where tabFourniture.NoSeqFourniture = FournitureSelection.NoSeqFourniture
                         Select tabFourniture).ToList.First

            MaBD.tblFourniture.Remove(Fourniture)
            MaBD.SaveChanges()
            MessageBox.Show("L'item " + FournitureSelection.NoSeqFourniture + " a été supprimé.")
        Catch ex As Exception
            MessageBox.Show("Erreur lors de la suppression.")
        End Try

        FiltrerDatagrid()

    End Sub


    Private Sub Inv_textBoxRechercheCode_TextChanged(sender As Object, e As TextChangedEventArgs) Handles Inv_textBoxRechercheCode.TextChanged
        FiltrerDatagrid()
    End Sub
End Class
