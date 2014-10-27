Public Class AjoutItemHotel
    Dim MaBD As P2014_BD_GestionHotelEntities
    Dim MonHotel As tblHotel
    Dim Fournisseur As tblFournisseur
    Dim FournitureSelection As tblFourniture
    Dim FournitureHotel As New tblFournitureHotel

    Sub New(ByRef _MaBD As P2014_BD_GestionHotelEntities, ByRef _MonHotel As tblHotel)
        InitializeComponent()
        MaBD = _MaBD
        MonHotel = _MonHotel
    End Sub

    Private Sub ajoutitemhot_btnConfirmer_Click(sender As Object, e As RoutedEventArgs) Handles ajoutitemhot_btnConfirmer.Click
        Try
            If FournitureSelection IsNot Nothing Then
                FournitureHotel.CodeFourniture = FournitureSelection.CodeFourniture
                FournitureHotel.CodeHotel = MonHotel.CodeHotel
                FournitureHotel.QuantiteMin = ajoutitemhot_txtQuantiteMin.Text
                FournitureHotel.QuantiteMax = ajoutitemhot_txtQuantiteMax.Text
                FournitureHotel.QuantiteFournitureHotel = ajoutitemhot_txtQuantite.Text

                MaBD.tblFournitureHotel.Add(FournitureHotel)
                MaBD.SaveChanges()
            Else
                MessageBox.Show("Aucun item sélectionné.")
            End If

            MessageBox.Show("L'item a été ajouté correctement.")
        Catch ex As Exception
            MaBD.tblFournitureHotel.Remove(FournitureHotel)

            FournitureHotel = (From tabfourhot In MaBD.tblFournitureHotel
                              Where FournitureHotel.CodeFourniture = FournitureSelection.CodeFourniture
                              Select tabfourhot).ToList.First

            FournitureHotel.QuantiteFournitureHotel += ajoutitemhot_txtQuantite.Text
            MaBD.SaveChanges()
            MessageBox.Show("L'item existait déjà, la quantité à été additionnée.")
        End Try
        Me.Close()
    End Sub

    Private Sub ajoutitemhot_lbvFourniture_SelectionChanged(sender As Object, e As SelectionChangedEventArgs) Handles ajoutitemhot_lbvFourniture.SelectionChanged
        FournitureSelection = CType(ajoutitemhot_lbvFourniture.SelectedItem, tblFourniture)
    End Sub

    Sub FiltrerDatagrid()
        If Fournisseur IsNot Nothing Then
            Fournisseur = CType(ajoutitemhot_cmbFournisseur.SelectedValue, tblFournisseur)

            Dim Fournitures = From tabFourniture In MaBD.tblFourniture
                              Join tabFournitureFournisseur In MaBD.tblFournitureFournisseur On tabFourniture.CodeFourniture Equals tabFournitureFournisseur.CodeFourniture
                              Join tabFournisseur In MaBD.tblFournisseur On tabFournisseur.CodeFournisseur Equals tabFournitureFournisseur.CodeFournisseur
                              Where tabFournisseur.CodeFournisseur = Fournisseur.CodeFournisseur
                              Select tabFourniture

            ajoutitemhot_lbvFourniture.ItemsSource = Fournitures.ToList
        End If
    End Sub

    Private Sub ajoutitemhot_cmbFournisseur_SelectionChanged(sender As Object, e As SelectionChangedEventArgs) Handles ajoutitemhot_cmbFournisseur.SelectionChanged
        FiltrerDatagrid()
    End Sub

    Private Sub ajoutitemhot_frmAjoutItemHotel_Loaded(sender As Object, e As RoutedEventArgs) Handles ajoutitemhot_frmAjoutItemHotel.Loaded
        Dim res = From tabFournisseur In MaBD.tblFournisseur
                  Select tabFournisseur

        ajoutitemhot_cmbFournisseur.ItemsSource = res.ToList
        ajoutitemhot_cmbFournisseur.DisplayMemberPath = "NomFournisseur"
        ajoutitemhot_cmbFournisseur.SelectedValue = res.ToList.First
        Fournisseur = ajoutitemhot_cmbFournisseur.SelectedValue
        FiltrerDatagrid()
    End Sub
End Class
