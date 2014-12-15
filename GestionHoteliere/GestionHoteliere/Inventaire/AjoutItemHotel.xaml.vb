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

    Private Sub AjtIH_btnConfirmer_Click(sender As Object, e As RoutedEventArgs) Handles AjtIH_BtnConfirmer.Click
        Try
            If FournitureSelection IsNot Nothing Then
                FournitureHotel.CodeFourniture = FournitureSelection.CodeFourniture
                FournitureHotel.CodeHotel = MonHotel.CodeHotel
                FournitureHotel.QuantiteMin = AjtIH_TxtQuantiteMin.Text
                FournitureHotel.QuantiteMax = AjtIH_TxtQuantiteMax.Text
                FournitureHotel.QuantiteFournitureHotel = AjtIH_TxtQuantite.Text

                MaBD.tblFournitureHotel.Add(FournitureHotel)
                MaBD.SaveChanges()
            Else
                MessageBox.Show("Aucun item sélectionné.")
            End If

            MessageBox.Show("L'item a été ajouté correctement.")
        Catch ex As Exception
            'MaBD.tblFournitureHotel.Remove(FournitureHotel)
            Dim BD As New P2014_BD_GestionHotelEntities

            BD = MaBD

            Dim FournitureHotel = (From tabfourhot In BD.tblFournitureHotel
                              Where tabfourhot.CodeFourniture = FournitureSelection.CodeFourniture And tabfourhot.CodeHotel = MonHotel.CodeHotel
                              Select tabfourhot)

            Dim MaQuantite As Integer
            Dim TextQuantite As String
            TextQuantite = AjtIH_TxtQuantite.Text.Trim(" ")

            MaQuantite = CType(TextQuantite, Integer)

            FournitureHotel.First().QuantiteFournitureHotel += MaQuantite
            BD.SaveChanges()
            MessageBox.Show("L'item existait déjà, la quantité à été additionnée.")
        End Try
        Me.Close()
    End Sub

    Private Sub AjtIH_lbvFourniture_SelectionChanged(sender As Object, e As SelectionChangedEventArgs) Handles AjtIH_lbvFourniture.SelectionChanged
        FournitureSelection = CType(AjtIH_lbvFourniture.SelectedItem, tblFourniture)
    End Sub

    Sub FiltrerDatagrid()
        If Fournisseur IsNot Nothing Then
            Fournisseur = CType(AjtIH_CmbFournisseur.SelectedValue, tblFournisseur)

            Dim Fournitures = From tabFourniture In MaBD.tblFourniture
                              Join tabFournitureFournisseur In MaBD.tblFournitureFournisseur On tabFourniture.CodeFourniture Equals tabFournitureFournisseur.CodeFourniture
                              Join tabFournisseur In MaBD.tblFournisseur On tabFournisseur.CodeFournisseur Equals tabFournitureFournisseur.CodeFournisseur
                              Where tabFournisseur.CodeFournisseur = Fournisseur.CodeFournisseur
                              Select tabFourniture

            AjtIH_lbvFourniture.ItemsSource = Fournitures.ToList
        End If
    End Sub

    Private Sub AjtIH_CmbFournisseur_SelectionChanged(sender As Object, e As SelectionChangedEventArgs) Handles AjtIH_CmbFournisseur.SelectionChanged
        FiltrerDatagrid()
    End Sub

    Private Sub AjtIH_frmAjoutItemHotel_Loaded(sender As Object, e As RoutedEventArgs) Handles AjtIH_frmAjoutItemHotel.Loaded
        Dim res = From tabFournisseur In MaBD.tblFournisseur
                  Select tabFournisseur

        AjtIH_CmbFournisseur.ItemsSource = res.ToList
        AjtIH_CmbFournisseur.DisplayMemberPath = "NomFournisseur"
        AjtIH_CmbFournisseur.SelectedValue = res.ToList.First
        Fournisseur = AjtIH_CmbFournisseur.SelectedValue
        FiltrerDatagrid()
    End Sub
End Class
