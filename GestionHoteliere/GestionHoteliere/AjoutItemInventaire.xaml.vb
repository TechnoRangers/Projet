Public Class AjoutItemInventaire
    Dim MaBD As P2014_BDTestFrancoisEntities
    Dim MonHotel As tblHotel
    Dim MonItem As tblFourniture

    Sub New(ByRef _MaBD As P2014_BDTestFrancoisEntities, ByRef _MonHotel As tblHotel)
        InitializeComponent()
        MaBD = _MaBD
        MonHotel = _MonHotel
    End Sub

    Private Sub ajoutinv_frmAjoutInventaire_Loaded(sender As Object, e As RoutedEventArgs) Handles ajoutinv_frmAjoutInventaire.Loaded
        'Remplir comboBox Fournisseur
        Dim resFournisseur = From tabFournisseur In MaBD.tblFournisseur
                             Select tabFournisseur

        ajoutinv_cmbNomFournisseur.ItemsSource = resFournisseur.ToList
        ajoutinv_cmbNomFournisseur.DisplayMemberPath = "NomFournisseur"
        ajoutinv_cmbNomFournisseur.SelectedValue = resFournisseur.ToList.First

        'Remplir comboBox
        Dim resCategorie = From tabCategorie In MaBD.tblCategorieFourniture
                           Where tabCategorie.CodeCategorie <> "TOU"
                           Select tabCategorie

        ajoutinv_cmbNomCategorie.ItemsSource = resCategorie.ToList
        ajoutinv_cmbNomCategorie.DisplayMemberPath = "NomCategorie"
        ajoutinv_cmbNomCategorie.SelectedValue = resCategorie.ToList.First

    End Sub

    Private Sub ajoutinv_btnAjouter_Click(sender As Object, e As RoutedEventArgs) Handles ajoutinv_btnAjouter.Click

        Dim CategorieSelection As tblCategorieFourniture = CType(ajoutinv_cmbNomCategorie.SelectedValue, tblCategorieFourniture)
        Dim FournisseurSelection As tblFournisseur = CType(ajoutinv_cmbNomFournisseur.SelectedValue, tblFournisseur)

        MonItem = New tblFourniture()
        Dim MonItemHotel As New tblFournitureHotel()
        Dim MonItemFournisseur As New tblFournitureFournisseur()

        Try
            'Ajouter la fourniture
            MonItem.CodeFourniture = ajoutinv_txtCodeFourniture.Text
            MonItem.DescFourniture = ajoutinv_txtNomFourniture.Text
            MonItem.CodeCategorie = CategorieSelection.CodeCategorie
            MaBD.tblFourniture.Add(MonItem)
            MaBD.SaveChanges()

            Try
                'Ajouter les liens dans les tables d'intersection
                'tblFournitureHotel
                MonItemHotel.CodeHotel = MonHotel.CodeHotel
                MonItemHotel.CodeFourniture = MonItem.CodeFourniture
                MonItemHotel.QuantiteMin = ajoutinv_txtQuantiteMin.Text
                MonItemHotel.QuantiteMax = ajoutinv_txtQuantiteMax.Text
                MonItemHotel.QuantiteFournitureHotel = ajoutinv_txtQuantiteFourniture.Text
                MaBD.tblFournitureHotel.Add(MonItemHotel)
                MaBD.SaveChanges()

                Try
                    'tblFournitureFournisseur
                    MonItemFournisseur.CodeFourniture = MonItem.CodeFourniture
                    MonItemFournisseur.CodeFournisseur = FournisseurSelection.CodeFournisseur
                    MonItemFournisseur.PrixFournitureFournisseur = ajoutinv_txtPrixFournitureFournisseur.Text
                    MaBD.tblFournitureFournisseur.Add(MonItemFournisseur)
                    MaBD.SaveChanges()
                Catch ex As Exception
                    MaBD.tblFourniture.Remove(MonItem)
                    MaBD.tblFournitureHotel.Remove(MonItemHotel)
                    MaBD.tblFournitureFournisseur.Remove(MonItemFournisseur)
                    MessageBox.Show("Erreur lors de la liaison de l'item au fournisseur.")
                End Try

            Catch ex As Exception
                MaBD.tblFourniture.Remove(MonItem)
                MaBD.tblFournitureHotel.Remove(MonItemHotel)
                MessageBox.Show("Erreur lors de l'ajout de l'item à l'hôtel.")
            End Try

        Catch ex As Exception
            MaBD.tblFourniture.Remove(MonItem)
            MessageBox.Show("Erreur lors de l'ajout de l'item.")
        End Try


        MessageBox.Show("L'item a été ajouté correctement.")
        Me.Close()
    End Sub
End Class
