﻿Public Class Horaire

    Dim BD As P2014_BDTestFrancoisEntities
    Dim _TypeEmploi As String
    Dim MonChiffreTravail As tblChiffreTravail
    Dim _ChiffreTravail As Date

    Sub New()
        BD = New P2014_BDTestFrancoisEntities
        InitializeComponent()
    End Sub

    Private Sub Hor_Calendrier_Loaded(sender As Object, e As RoutedEventArgs) Handles Hor_Calendrier.Loaded

        _ChiffreTravail = Date.Today

    End Sub

    Private Sub Hor_CmbTypeEmploi_Loaded(sender As Object, e As RoutedEventArgs) Handles Hor_CmbTypeEmploi.Loaded

        Dim res = From Em In BD.tblEmploye Select Em.TypeEmploi Distinct

        Hor_CmbTypeEmploi.ItemsSource = res.ToList()

    End Sub

    Private Sub Hor_DtgChiffreTravail_Loaded(sender As Object, e As RoutedEventArgs) Handles Hor_DtgChiffreTravail.Loaded

        Dim Date_ = Date.Today

        Dim _ChiffreTravail = From Ct In BD.tblChiffreTravail Join Em In BD.tblEmploye On Ct.NoEmploye Equals Em.NoEmploye
        Where Ct.DateChiffre = Date_
        Select New With {Em.NoEmploye, Em.PrenomEmploye, Em.NomEmploye, Ct.HeureDebut, Ct.HeureFin, Ct.NoChiffreTravail, Ct.DateChiffre}


        Hor_DtgChiffreTravail.DataContext = _ChiffreTravail.ToList()
        Hor_DtgChiffreTravail.ItemsSource = _ChiffreTravail.ToList()


    End Sub

    Private Sub Hor_Calendrier_SelectedDatesChanged(sender As Object, e As SelectionChangedEventArgs) Handles Hor_Calendrier.SelectedDatesChanged

        _ChiffreTravail = Hor_Calendrier.SelectedDate

        FiltrerDatagrid()

    End Sub

    Private Sub Hor_CmbTypeEmploi_SelectionChanged(sender As Object, e As SelectionChangedEventArgs) Handles Hor_CmbTypeEmploi.SelectionChanged

        _TypeEmploi = Hor_CmbTypeEmploi.SelectedItem

        FiltrerDatagrid()

    End Sub

    Private Sub Hor_BtnQuitter_Click(sender As Object, e As RoutedEventArgs) Handles Hor_BtnQuitter.Click

        Me.Close()
    End Sub

    Sub FiltrerDatagrid()

        Dim resChiffre = From ct In BD.tblChiffreTravail Join Em In BD.tblEmploye On ct.NoEmploye Equals Em.NoEmploye
        Where ct.DateChiffre = _ChiffreTravail And Em.TypeEmploi = _TypeEmploi
        Select Em.NoEmploye, Em.PrenomEmploye, Em.NomEmploye, ct.HeureDebut, ct.HeureFin, ct.NoChiffreTravail, ct.DateChiffre


        Hor_DtgChiffreTravail.ItemsSource = resChiffre.ToList

    End Sub

    Private Sub Hor_BtnAjout_Click(sender As Object, e As RoutedEventArgs) Handles Hor_BtnAjout.Click
        Dim FenetreModifChiffreTravail As ChangementHoraire
        FenetreModifChiffreTravail = New ChangementHoraire(BD)
        FenetreModifChiffreTravail.ShowDialog()

        Dim res = From Ct In BD.tblChiffreTravail
                  Select Ct

        Hor_DtgChiffreTravail.ItemsSource = res.ToList
    End Sub

    Private Sub Hor_BtnChangement_Click(sender As Object, e As RoutedEventArgs) Handles Hor_BtnChangement.Click

        Dim ChiffreSelect_ = Hor_DtgChiffreTravail.SelectedItem
        MonChiffreTravail = New tblChiffreTravail()

        MonChiffreTravail.NoChiffreTravail = ChiffreSelect_.NoChiffreTravail
        MonChiffreTravail.DateChiffre = ChiffreSelect_.DateChiffre
        MonChiffreTravail.HeureDebut = ChiffreSelect_.HeureDebut
        MonChiffreTravail.HeureFin = ChiffreSelect_.HeureFin
        MonChiffreTravail.NoEmploye = ChiffreSelect_.NoEmploye

        Try
            Dim ChiffreSelection As tblChiffreTravail = MonChiffreTravail

            Dim FenetreModifChiffreTravail As ChangementHoraire
            FenetreModifChiffreTravail = New ChangementHoraire(BD, ChiffreSelection)
            FenetreModifChiffreTravail.ShowDialog()
        Catch
            MessageBox.Show("Aucun chiffre de travail sélectionné")
        End Try
    End Sub



End Class

