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

        AjtInv_CmbCategorie.ItemsSource = resCategorie.ToList
        AjtInv_CmbCategorie.DisplayMemberPath = "NomCategorie"
        AjtInv_CmbCategorie.SelectedValue = resCategorie.ToList.First
        MaCategorie = resCategorie.ToList.First

        'Remplir ComboBox Fournisseur
        Dim resFournisseur = From tabFournisseur In MaBD.tblFournisseur
                            Select tabFournisseur

        AjtInv_CmbFournisseur.ItemsSource = resFournisseur.ToList
        AjtInv_CmbFournisseur.DisplayMemberPath = "NomFournisseur"
        AjtInv_CmbFournisseur.SelectedValue = resFournisseur.ToList.First
        MonFournisseur = resFournisseur.ToList.First
    End Sub

    Private Sub AjtInv_btnConfirmer_Click(sender As Object, e As RoutedEventArgs) Handles AjtInv_btnConfirmer.Click
        Dim NouvProduit As New tblFourniture

        Try
            NouvProduit.CodeFourniture = AjtInv_TxtCodeFourniture.Text
            NouvProduit.CodeCategorie = MaCategorie.CodeCategorie
            NouvProduit.DescFourniture = AjtInv_txtDesc.Text

            MaBD.tblFourniture.Add(NouvProduit)
            MaBD.SaveChanges()

            Try
                Dim FournitureFournisseur As New tblFournitureFournisseur

                FournitureFournisseur.CodeFourniture = NouvProduit.CodeFourniture
                FournitureFournisseur.CodeFournisseur = MonFournisseur.CodeFournisseur
                FournitureFournisseur.PrixFournitureFournisseur = AjtInv_txtPrix.Text

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

    Private Sub AjtInv_cmbFournisseur_SelectionChanged(sender As Object, e As SelectionChangedEventArgs) Handles AjtInv_cmbFournisseur.SelectionChanged
        MonFournisseur = CType(AjtInv_cmbFournisseur.SelectedValue, tblFournisseur)
    End Sub

    Private Sub AjtInv_cmbCategorie_SelectionChanged(sender As Object, e As SelectionChangedEventArgs) Handles AjtInv_cmbCategorie.SelectionChanged
        MaCategorie = CType(AjtInv_cmbCategorie.SelectedValue, tblCategorieFourniture)
    End Sub

End Class
