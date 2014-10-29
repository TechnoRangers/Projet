Public Class ConsoleAdmin

    Dim MaBD As P2014_BD_GestionHotelEntities

    Sub New(ByRef _MaBD As P2014_BD_GestionHotelEntities)
        InitializeComponent()
        MaBD = _MaBD
    End Sub

    Private Sub btn_Pays_Click(sender As Object, e As RoutedEventArgs) Handles btn_Pays.Click
        Dim FenetrePays As Pays
        FenetrePays = New Pays(MaBD)
        FenetrePays.ShowDialog()
    End Sub

    Private Sub btn_Hotel_Click(sender As Object, e As RoutedEventArgs) Handles btn_Hotel.Click
        Dim FenetreHotel As Hotel
        FenetreHotel = New Hotel(MaBD)
        FenetreHotel.ShowDialog()
    End Sub

    Private Sub btn_Salle_Click(sender As Object, e As RoutedEventArgs) Handles btn_Salle.Click
        Dim FenetreSalle As Salle
        FenetreSalle = New Salle(MaBD)
        FenetreSalle.ShowDialog()
    End Sub

    Private Sub btn_Chambre_Click(sender As Object, e As RoutedEventArgs) Handles btn_Chambre.Click
        Dim FenetreChambre As Chambre
        FenetreChambre = New Chambre(MaBD)
        FenetreChambre.ShowDialog()
    End Sub

    Private Sub btn_Facture_Click(sender As Object, e As RoutedEventArgs) Handles btn_Facture.Click
        Dim FenetreFacture As Facture
        FenetreFacture = New Facture(MaBD)
        FenetreFacture.ShowDialog()
    End Sub

    Private Sub btn_Forfait_Click(sender As Object, e As RoutedEventArgs) Handles btn_Forfait.Click
        Dim FenetreForfait As Forfait
        FenetreForfait = New Forfait(MaBD)
        FenetreForfait.ShowDialog()
    End Sub


    Private Sub btn_TypeChambre_Click(sender As Object, e As RoutedEventArgs) Handles btn_TypeChambre.Click
        Dim FenetreTypeChambre As TypeChambre
        FenetreTypeChambre = New TypeChambre(MaBD)
        FenetreTypeChambre.ShowDialog()
    End Sub

 

    Private Sub btn_Fournisseur_Click(sender As Object, e As RoutedEventArgs) Handles btn_Fournisseur.Click
        Dim FenetreFournisseur As Fournisseur
        FenetreFournisseur = New Fournisseur(MaBD)
        FenetreFournisseur.ShowDialog()
    End Sub

    Private Sub btn_Fourniture_Click(sender As Object, e As RoutedEventArgs) Handles btn_Fourniture.Click
        Dim FenetreFourniture As Fourniture
        FenetreFourniture = New Fourniture(MaBD)
        FenetreFourniture.ShowDialog()
    End Sub

    Private Sub btn_CategorieFourniture_Click(sender As Object, e As RoutedEventArgs) Handles btn_CategorieFourniture.Click
        Dim FenetreCategorieFourniture As CategorieFourniture
        FenetreCategorieFourniture = New CategorieFourniture(MaBD)
        FenetreCategorieFourniture.ShowDialog()
    End Sub

    Private Sub btn_Employe_Click(sender As Object, e As RoutedEventArgs) Handles btn_Employe.Click
        Dim FenetreEmploye As Employe
        FenetreEmploye = New Employe(MaBD)
        FenetreEmploye.ShowDialog()
    End Sub

    Private Sub btn_Ville_Click(sender As Object, e As RoutedEventArgs) Handles btn_Ville.Click
        Dim FenetreVille As Ville
        FenetreVille = New Ville(MaBD)
        FenetreVille.ShowDialog()
    End Sub

    Private Sub btn_Province_Click(sender As Object, e As RoutedEventArgs) Handles btn_Province.Click
        Dim FenetreProvince As Province
        FenetreProvince = New Province(MaBD)
        FenetreProvince.ShowDialog()
    End Sub

    Private Sub consadm_btnRetour_Click(sender As Object, e As RoutedEventArgs) Handles consadm_btnRetour.Click
        Me.Close()
    End Sub
End Class
