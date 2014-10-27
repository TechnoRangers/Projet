Public Class AjoutItemInventaire2
    Dim MaBD As P2014_BD_GestionHotelEntities
    Dim MonItem As tblFourniture
    Dim MaCategorie As tblCategorieFourniture
    Dim MonFournisseur As tblFournisseur

    Sub New(ByRef _MaBD As P2014_BD_GestionHotelEntities)
        InitializeComponent()
        MaBD = _MaBD

        'Remplir ComboBox Categorie
        Dim resCategorie = From tabCategorie In MaBD.tblCategorieFourniture
                           Where tabCategorie.CodeCategorie <> "TOU"
                           Select tabCategorie

        ajoutinv_cmbCategorie.ItemsSource = resCategorie.ToList
        ajoutinv_cmbCategorie.DisplayMemberPath = "NomCategorie"
        ajoutinv_cmbCategorie.SelectedValue = resCategorie.ToList.First
        MaCategorie = resCategorie.ToList.First

        'Remplir ComboBox Fournisseur
        Dim resFournisseur = From tabFournisseur In MaBD.tblFournisseur
                            Select tabFournisseur

        ajoutinv_cmbFournisseur.ItemsSource = resFournisseur.ToList
        ajoutinv_cmbFournisseur.DisplayMemberPath = "NomFournisseur"
        ajoutinv_cmbFournisseur.SelectedValue = resFournisseur.ToList.First
        MonFournisseur = resFournisseur.ToList.First
    End Sub

    Private Sub ajoutinv_btnConfirmer_Click(sender As Object, e As RoutedEventArgs) Handles ajoutinv_btnConfirmer.Click
        Dim NouvProduit As New tblFourniture

        Try
            NouvProduit.CodeFourniture = ajoutinv_txtCodeFourniture.Text
            NouvProduit.CodeCategorie = MaCategorie.CodeCategorie
            NouvProduit.DescFourniture = ajoutinv_txtDescription.Text

            MaBD.tblFourniture.Add(NouvProduit)
            MaBD.SaveChanges()

            Try
                Dim FournitureFournisseur As New tblFournitureFournisseur

                FournitureFournisseur.CodeFourniture = NouvProduit.CodeFourniture
                FournitureFournisseur.CodeFournisseur = MonFournisseur.CodeFournisseur
                FournitureFournisseur.PrixFournitureFournisseur = ajoutinv_txtPrix.Text

                MaBD.tblFournitureFournisseur.Add(FournitureFournisseur)
                MaBD.SaveChanges()
            Catch ex As Exception
                MessageBox.Show("Erreur ajout FournitureFournisseur.")
            End Try
        Catch ex As Exception
            MessageBox.Show("Ce produit existe déjà.")
        End Try
        
        Me.Close()
    End Sub

    Private Sub ajoutinv_cmbFournisseur_SelectionChanged(sender As Object, e As SelectionChangedEventArgs) Handles ajoutinv_cmbFournisseur.SelectionChanged
        MonFournisseur = CType(ajoutinv_cmbFournisseur.SelectedValue, tblFournisseur)
    End Sub

    Private Sub ajoutinv_cmbCategorie_SelectionChanged(sender As Object, e As SelectionChangedEventArgs) Handles ajoutinv_cmbCategorie.SelectionChanged
        MaCategorie = CType(ajoutinv_cmbCategorie.SelectedValue, tblCategorieFourniture)
    End Sub
End Class
