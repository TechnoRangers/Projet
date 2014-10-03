﻿Public Class Reservation


    Dim lst As ListCollectionView

    Public WriteOnly Property LesChambres() As IList

        Set(ByVal value As IList)
            lst = New ListCollectionView(value)
        End Set
    End Property

    Private Sub Res_btnAnnuler_Click(sender As Object, e As RoutedEventArgs) Handles Res_btnAnnuler.Click

        Dim Menu_ As New Menu
        Menu_.Show()
        Me.Close()

    End Sub

    Private Sub Res_btnReserver_Click(sender As Object, e As RoutedEventArgs) Handles Res_btnReserver.Click

        Dim Menu_ As New Menu
        Menu_.Show()
        Me.Close()

    End Sub

    Private Sub Res_frmReservation_Loaded(sender As Object, e As RoutedEventArgs) Handles Res_frmReservation.Loaded


        Res_TextBoxNoChambre.DataContext = lst
        Res_TextBoxTypeChambre.DataContext = lst
        Res_TextBoxNbChambre.Text = lst.Count

    End Sub


    Private Sub Res_BtnSuivant_Click(sender As Object, e As RoutedEventArgs) Handles Res_BtnSuivant.Click

        lst.MoveCurrentToNext()

    End Sub

    Private Sub Res_BtnPrecedent_Click(sender As Object, e As RoutedEventArgs) Handles Res_BtnPrecedent.Click

        lst.MoveCurrentToPrevious()

    End Sub
End Class
