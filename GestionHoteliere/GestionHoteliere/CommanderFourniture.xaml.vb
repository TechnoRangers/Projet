﻿Public Class CommanderFourniture
    Dim MaBD As P2014_BDTestFrancoisEntities
    Dim Fournisseur As tblFournisseur
    Dim ItemCommande As New List(Of tblFourniture)
    Dim PrixCommande As Double

    Sub New(ByRef _MaBD As P2014_BDTestFrancoisEntities)
        InitializeComponent()
        com_lblPrixTotal.Content = "0.00 $"
        MaBD = _MaBD
    End Sub

    Private Sub com_frmCommandeFourniture_Loaded(sender As Object, e As RoutedEventArgs) Handles com_frmCommandeFourniture.Loaded
        Dim res = From tabFournisseur In MaBD.tblFournisseur
                  Select tabFournisseur

        com_cmbFournisseur.ItemsSource = res.ToList
        com_cmbFournisseur.DisplayMemberPath = "NomFournisseur"
        com_cmbFournisseur.SelectedValue = res.ToList.First
        Fournisseur = com_cmbFournisseur.SelectedValue
        FiltrerDatagrid()
    End Sub

    Sub FiltrerDatagrid()
        If Fournisseur IsNot Nothing Then
            Fournisseur = CType(com_cmbFournisseur.SelectedValue, tblFournisseur)

            Dim Fournitures = From tabFourniture In MaBD.tblFourniture
                              Join tabFournitureFournisseur In MaBD.tblFournitureFournisseur On tabFourniture.CodeFourniture Equals tabFournitureFournisseur.CodeFourniture
                              Join tabFournisseur In MaBD.tblFournisseur On tabFournisseur.CodeFournisseur Equals tabFournitureFournisseur.CodeFournisseur
                              Where tabFournisseur.CodeFournisseur = Fournisseur.CodeFournisseur
                              Select tabFourniture

            com_dtgFournitureCommande.ItemsSource = Fournitures.ToList
        End If
    End Sub

    Private Sub com_cmbFournisseur_SelectionChanged(sender As Object, e As SelectionChangedEventArgs) Handles com_cmbFournisseur.SelectionChanged
        FiltrerDatagrid()
    End Sub

    Private Sub com_btnAjouterFourniture_Click(sender As Object, e As RoutedEventArgs) Handles com_btnAjouterFourniture.Click
        Dim FournitureSelection As tblFourniture = CType(com_dtgFournitureCommande.SelectedItem, tblFourniture)

        ItemCommande.Add(FournitureSelection)
        CalculPrixTotal()
        com_lbvCommande.ItemsSource = ItemCommande.ToList
    End Sub

    Private Sub com_btnRetirerFourniture_Click(sender As Object, e As RoutedEventArgs) Handles com_btnRetirerFourniture.Click
        Dim FournitureSelection As tblFourniture = CType(com_lbvCommande.SelectedItem, tblFourniture)

        ItemCommande.Remove(FournitureSelection)
        com_lbvCommande.ItemsSource = ItemCommande.ToList
    End Sub



    Sub CalculPrixTotal()
        PrixCommande = 0
        For Each Item As tblFourniture In ItemCommande
            PrixCommande += (From tabFournisseur In MaBD.tblFournisseur
                                  Join tabFournitureFournisseur In MaBD.tblFournitureFournisseur On tabFournitureFournisseur.CodeFournisseur Equals tabFournisseur.CodeFournisseur
                                  Where tabFournitureFournisseur.CodeFourniture = Item.CodeFourniture
                                  Select tabFournitureFournisseur.PrixFournitureFournisseur).ToList.First
        Next

        com_lblPrixTotal.Content = PrixCommande.ToString + " $"

    End Sub

    Private Sub com_btnCommander_Click(sender As Object, e As RoutedEventArgs) Handles com_btnCommander.Click
        Try
            Dim Commande As New tblCommande()

            Commande.NoEmploye = com_txtNoEmploye.Text
            Commande.StatutCommande = "En commande"
            Commande.CodeFournisseur = Fournisseur.CodeFournisseur
            Commande.DateCommande = System.DateTime.Today
            Commande.PrixTotal = PrixCommande

            MaBD.tblCommande.Add(Commande)
            MaBD.SaveChanges()

            Try
                For Each Fourniture As tblFourniture In ItemCommande
                    Dim FournitureCommande As New tblFournitureCommande

                    FournitureCommande.NoCommande = Commande.NoCommande
                    FournitureCommande.CodeFourniture = Fourniture.CodeFourniture
                    FournitureCommande.QuantiteCommande = 1

                    MaBD.tblFournitureCommande.Add(FournitureCommande)
                    MaBD.SaveChanges()
                Next
            Catch ex As Exception
                MessageBox.Show("Erreur ajout table intersect")
            End Try

        Catch ex As Exception
            'MaBD.tblCommande.Remove(Commande)
            MessageBox.Show("Erreur lors de l'ajout de la commande.")
        End Try

        MessageBox.Show("La commande a été complétée avec succès.")
    End Sub
End Class
