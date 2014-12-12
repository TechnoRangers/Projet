﻿Public Class Entretien

    Dim MaBD As P2014_BD_GestionHotelEntities
    Dim HotelConnexion As tblHotel

    Sub New(ByRef _MaBD As P2014_BD_GestionHotelEntities, ByRef _MonHotel As tblHotel)
        InitializeComponent()
        MaBD = _MaBD
        HotelConnexion = _MonHotel
    End Sub

    Private Sub Ent_BtnCheckUp_Click(sender As Object, e As RoutedEventArgs) Handles Ent_BtnCheckUp.Click

        Dim CheckUp As New CheckUp(MaBD, HotelConnexion)
        CheckUp.Show()
        Me.Close()

    End Sub


    Private Sub Ent_BtnEtatChambre_Click(sender As Object, e As RoutedEventArgs) Handles Ent_BtnEtatChambre.Click

        Dim EtatChambre As New EtatChambre(MaBD, HotelConnexion)
        EtatChambre.Show()
        Me.Close()

    End Sub

    Private Sub Ent_BtnCheckUpSalle_Click(sender As Object, e As RoutedEventArgs) Handles Ent_BtnCheckUpSalle.Click
        Dim CheckUpSalle As New CheckUpSalle(MaBD, HotelConnexion)
        CheckUpSalle.Show()
        Me.Close()
    End Sub

    Private Sub Ent_BtnEtatSalle_Click(sender As Object, e As RoutedEventArgs) Handles Ent_BtnEtatSalle.Click
        Dim EtatSalle As New EtatSalle(MaBD, HotelConnexion)
        EtatSalle.Show()
        Me.Close()
    End Sub
End Class
