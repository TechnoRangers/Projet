﻿Public Class CommanderFourniture
    Dim MaBD As P2014_BD_GestionHotelEntities
    Dim Fournisseur As tblFournisseur
    Dim ItemCommande As New List(Of tblFournitureFournisseur)
    Dim PrixCommande As Double
    Dim EmployeConnexion As tblEmploye
    Dim FournitureCommande As List(Of tblFournitureCommande)

    Sub New(ByRef _MaBD As P2014_BD_GestionHotelEntities, ByRef _MonEmploye As tblEmploye)
        InitializeComponent()
        com_lblPrixTotal.Content = "0.00 $"
        MaBD = _MaBD
        EmployeConnexion = _MonEmploye
        com_txtNoEmploye.Text = EmployeConnexion.NoEmploye
        com_txtNoEmploye.IsEnabled = False
        FournitureCommande = New List(Of tblFournitureCommande)
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

        If com_dtgFournitureCommande.SelectedItem IsNot Nothing Then
            Dim FournitureSelection As tblFourniture = CType(com_dtgFournitureCommande.SelectedItem, tblFourniture)

            Dim FournitureFournisseur As tblFournitureFournisseur

            FournitureFournisseur = (From tabFournitureFournisseur In MaBD.tblFournitureFournisseur
                                        Where tabFournitureFournisseur.CodeFourniture = FournitureSelection.CodeFourniture And Fournisseur.CodeFournisseur = tabFournitureFournisseur.CodeFournisseur
                                        Select tabFournitureFournisseur).ToList.First

            ItemCommande.Add(FournitureFournisseur)


            Dim ItemExist As Boolean = False
            Dim MaFournitureCommande As New tblFournitureCommande
            MaFournitureCommande.CodeFourniture = FournitureFournisseur.CodeFourniture
            MaFournitureCommande.QuantiteCommande = 1

            For Each FourCommande As tblFournitureCommande In FournitureCommande
                If MaFournitureCommande.CodeFourniture = FourCommande.CodeFourniture Then
                    ItemExist = True
                End If
            Next

            'Si l'item existe pas ou que la liste est vide, ajoute à la liste
            If Not ItemExist Then
                FournitureCommande.Add(MaFournitureCommande)
            Else
                'Si l'item existe, ajoute la quantitié
                For Each FourCommande As tblFournitureCommande In FournitureCommande
                    If FourCommande.CodeFourniture = MaFournitureCommande.CodeFourniture Then
                        FourCommande.QuantiteCommande += 1
                    End If
                Next
            End If

            CalculPrixTotal()
            com_lbvCommande.ItemsSource = ItemCommande.ToList
        End If

    End Sub

    Private Sub com_btnRetirerFourniture_Click(sender As Object, e As RoutedEventArgs) Handles com_btnRetirerFourniture.Click
        Dim FournitureSelection As tblFournitureFournisseur = CType(com_lbvCommande.SelectedItem, tblFournitureFournisseur)

        ItemCommande.Remove(FournitureSelection)
        com_lbvCommande.ItemsSource = ItemCommande.ToList
    End Sub

    Sub CalculPrixTotal()
        PrixCommande = 0
        For Each Item As tblFournitureFournisseur In ItemCommande
            PrixCommande += Item.PrixFournitureFournisseur
        Next

        com_lblPrixTotal.Content = PrixCommande.ToString + " $"
        PrixCommande = Math.Round(PrixCommande)
    End Sub

    Private Sub com_btnCommander_Click(sender As Object, e As RoutedEventArgs) Handles com_btnCommander.Click
        'Dim FournitureCommande As New List(Of tblFournitureCommande)

        Try
            Dim Commande As New tblCommande()

            Commande.NoEmploye = com_txtNoEmploye.Text
            Commande.StatutCommande = "Commande"
            Commande.CodeFournisseur = Fournisseur.CodeFournisseur
            Commande.DateCommande = System.DateTime.Today
            Commande.PrixTotal = PrixCommande

            MaBD.tblCommande.Add(Commande)
            MaBD.SaveChanges()

            Try
                For Each FourCommande As tblFournitureCommande In FournitureCommande
                    FourCommande.NoCommande = Commande.NoCommande
                    MaBD.tblFournitureCommande.Add(FourCommande)
                Next

                MaBD.SaveChanges()

                MessageBox.Show("La commande a été complétée avec succès.")
                Me.Close()
            Catch ex As Exception
                MessageBox.Show("Erreur ajout table intersect")
            End Try

        Catch ex As Exception
            'MaBD.tblCommande.Remove(Commande)
            MessageBox.Show("Erreur lors de l'ajout de la commande.")
        End Try

    End Sub
End Class
