Public Class ForfaitAppli

    Dim BD As P2014_BD_GestionHotelEntities
    Dim _MonForfait As tblForfait
    Dim ListeChambresDispo As New List(Of tblChambre)
    Dim Client As tblClient

    Sub New(ByRef _BD As P2014_BD_GestionHotelEntities, ByRef _Client As tblClient)
        InitializeComponent()
        BD = _BD
        Client = _Client
    End Sub
    Private Sub For_FrmFor_Loaded(sender As Object, e As RoutedEventArgs) Handles For_FrmFor.Loaded

        Dim Forfait = From el In BD.tblForfait
                      Select el

        For_dataGridForfait.ItemsSource = Forfait.ToList

        Dim res = From el In BD.tblForfait
                  Select el

        For_CmbBoxForfait.ItemsSource = res.ToList
        For_CmbBoxForfait.DisplayMemberPath = "NomForfait"

        Dim res2 = From el In BD.tblChambreReservationChambre, el2 In BD.tblForfait, el3 In BD.tblClient Where el.tblForfait.Contains(el2) And el.tblReservationChambre.NoSeqClient = el3.NoSeqClient
                   Select New With {.NoChambre = el.NoSeqChambre, .NomForfait = el2.NomForfait, .NomClient = el3.NomClient, .PrenomClient = el3.PrenomClient, .DateDebut = el2.DateDebut, .DateFin = el2.DateFin}

        For_DataGridForfaitReserve.ItemsSource = res2.ToList


    End Sub

    Private Sub For_CmbBoxForfait_SelectionChanged(sender As Object, e As SelectionChangedEventArgs) Handles For_CmbBoxForfait.SelectionChanged

        _MonForfait = CType(For_CmbBoxForfait.SelectedItem, tblForfait)

        FiltrerDatagrid()

    End Sub

    Sub FiltrerDatagrid()

        If _MonForfait.NomForfait IsNot Nothing Then
            Dim DateDebut As Date
            Dim DateFin As Date
            Dim Etage As Integer
            Dim NbLit As Integer

            DateDebut = _MonForfait.DateDebut
            DateFin = _MonForfait.DateFin

            Dim Chambre = From tabChambre In BD.VerificationDispo(DateDebut, DateFin)
                          Where tabChambre.CodeTypeChambre = _MonForfait.CodeTypeChambre
                             Select tabChambre

            If For_TxtBoxEtage.Text <> "" And For_TxtBoxNbLit.Text <> Nothing Then
                Etage = CType(For_TxtBoxEtage.Text, Integer)
                NbLit = CType(For_TxtBoxNbLit.Text, Integer)

                Chambre = From tabChambre In BD.VerificationDispo(DateDebut, DateFin)
                              Where tabChambre.EtageChambre = Etage And tabChambre.NbLit = NbLit And tabChambre.CodeTypeChambre = _MonForfait.CodeTypeChambre
                              Select tabChambre

            ElseIf For_TxtBoxEtage.Text <> "" Then
                Etage = CType(For_TxtBoxEtage.Text, Integer)

                Chambre = From tabChambre In BD.VerificationDispo(DateDebut, DateFin)
                              Where tabChambre.EtageChambre = Etage And tabChambre.CodeTypeChambre = _MonForfait.CodeTypeChambre
                              Select tabChambre

            ElseIf For_TxtBoxNbLit.Text <> "" Then
                NbLit = CType(For_TxtBoxNbLit.Text, Integer)

                Chambre = From tabChambre In BD.VerificationDispo(DateDebut, DateFin)
                              Where tabChambre.NbLit = NbLit And tabChambre.CodeTypeChambre = _MonForfait.CodeTypeChambre
                              Select tabChambre
            End If

            For_DateGridDispoChambre.ItemsSource = Chambre.ToList
        End If
    End Sub



    Private Sub For_TxtBoxEtage_TextChanged(sender As Object, e As TextChangedEventArgs) Handles For_TxtBoxEtage.TextChanged
        FiltrerDatagrid()
    End Sub

    Private Sub For_TxtBoxNbLit_TextChanged(sender As Object, e As TextChangedEventArgs) Handles For_TxtBoxNbLit.TextChanged
        FiltrerDatagrid()
    End Sub

    Private Sub For_BtnReserver_Click(sender As Object, e As RoutedEventArgs) Handles For_BtnReserver.Click

        Dim ChambresSelection As New List(Of tblChambre)

        For Each Chambre In For_DateGridDispoChambre.SelectedItems
            Dim i As Integer = Chambre.NoSeqChambre
            Dim res = From el In BD.tblChambre Where el.NoSeqChambre = i Select el
            ChambresSelection.Add(res.First)
        Next
        Try
            BD.SaveChanges()
        Catch ex As Exception
            Dim i As Integer

            i = 9
        End Try
        Dim Reservation_ As New Reservation(BD, ChambresSelection, _MonForfait.DateDebut, _MonForfait.DateFin, _MonForfait, Client)
        Reservation_.Show()
        Me.Close()
    End Sub

    Private Sub For_BtnAnnuler_Click(sender As Object, e As RoutedEventArgs) Handles For_BtnAnnuler.Click
        Me.Close()
    End Sub
End Class
