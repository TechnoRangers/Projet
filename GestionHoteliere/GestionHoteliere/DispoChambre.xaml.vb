Public Class DispoChambre

    Dim BD As P2014_BD_GestionHotelEntities

    Dim TypeChambre As tblTypeChambre
    Dim Client As tblClient

    Dim ListeChambresDispo As New List(Of tblChambre)

    Sub New(ByRef _MaBD As P2014_BD_GestionHotelEntities, ByRef _Client As tblClient)
        InitializeComponent()
        BD = _MaBD
        Client = _Client
    End Sub

    Private Sub Dis_frmDisponibilite_Loaded(sender As Object, e As RoutedEventArgs) Handles Dis_frmDisponibilite.Loaded

        dis_dtpDateDebut.SelectedDate = System.DateTime.Today
        dis_dtpDateFin.SelectedDate = DateAdd("d", 1, Now)

        Dim res = From tabTypeChambre In BD.tblTypeChambre
                  Select tabTypeChambre

        dis_cmbTypeChambre.ItemsSource = res.ToList
        dis_cmbTypeChambre.DisplayMemberPath = "NomTypeChambre"
        dis_cmbTypeChambre.SelectedValue = res.ToList.Item(1)

        FiltrerDatagrid()
    End Sub

    Private Sub Dis_BtnRéserver_Click(sender As Object, e As RoutedEventArgs) Handles Dis_BtnRéserver.Click
        Dim ChambresSelection As New List(Of tblChambre)

        'Dim temp = From ch In BD.tblChambre, el In cv Where el.NoSeqChambre = ch.NoSeqChambre Select ch

        For Each Chambre In Dis_GrtChambre.SelectedItems
            Dim i As Integer = Chambre.NoSeqChambre
            Dim res = From el In BD.tblChambre Where el.NoSeqChambre = i Select el
            ChambresSelection.Add(res.First)
        Next

        Dim Reservation_ As New Reservation(BD, ChambresSelection)
        Reservation_.Show()
        Me.Close()
    End Sub

    Private Sub Dis_BtnAnnuler_Click(sender As Object, e As RoutedEventArgs) Handles Dis_BtnAnnuler.Click
        Me.Close()
    End Sub

    Private Sub Dis_CmbTypeChambre_SelectionChanged(sender As Object, e As SelectionChangedEventArgs) Handles Dis_CmbTypeChambre.SelectionChanged
        TypeChambre = CType(dis_cmbTypeChambre.SelectedItem, tblTypeChambre)

        FiltrerDatagrid()
    End Sub

    Private Sub dis_txtEtageChambre_TextChanged(sender As Object, e As TextChangedEventArgs) Handles dis_txtEtageChambre.TextChanged
        FiltrerDatagrid()
    End Sub

    Private Sub dis_txtNbLit_TextChanged(sender As Object, e As TextChangedEventArgs) Handles dis_txtNbLit.TextChanged
        FiltrerDatagrid()
    End Sub

    Sub FiltrerDatagrid()

        If dis_dtpDateDebut.SelectedDate IsNot Nothing And dis_dtpDateFin.SelectedDate IsNot Nothing Then
            Dim DateDebut As Date = dis_dtpDateDebut.SelectedDate
            Dim DateFin As Date = dis_dtpDateFin.SelectedDate
            Dim Etage As Integer
            Dim NbLit As Integer

            DateDebut = DateDebut.Date
            DateFin = DateFin.Date

            Dim Chambre = From tabChambre In BD.VerificationDispo(DateDebut, DateFin)
                          Select tabChambre

            If dis_txtEtageChambre.Text <> "" And dis_txtNbLit.Text <> Nothing Then
                Etage = CType(dis_txtEtageChambre.Text, Integer)
                NbLit = CType(dis_txtNbLit.Text, Integer)

                Chambre = From tabChambre In BD.VerificationDispo(DateDebut, DateFin)
                              Where tabChambre.EtageChambre = Etage And tabChambre.NbLit = NbLit
                              Select tabChambre

            ElseIf dis_txtEtageChambre.Text <> "" Then
                Etage = CType(dis_txtEtageChambre.Text, Integer)

                Chambre = From tabChambre In BD.VerificationDispo(DateDebut, DateFin)
                              Where tabChambre.EtageChambre = Etage
                              Select tabChambre

            ElseIf dis_txtNbLit.Text <> "" Then
                NbLit = CType(dis_txtNbLit.Text, Integer)

                Chambre = From tabChambre In BD.VerificationDispo(DateDebut, DateFin)
                              Where tabChambre.NbLit = NbLit
                              Select tabChambre
            End If

            Dis_GrtChambre.ItemsSource = Chambre.ToList
        End If

    End Sub

    Private Sub dis_dtpDateDebut_SelectedDateChanged(sender As Object, e As SelectionChangedEventArgs) Handles dis_dtpDateDebut.SelectedDateChanged
        FiltrerDatagrid()
    End Sub

    Private Sub dis_dtpDateFin_SelectedDateChanged(sender As Object, e As SelectionChangedEventArgs) Handles dis_dtpDateFin.SelectedDateChanged
        FiltrerDatagrid()
    End Sub

    Private Sub Dis_BtnForfait_Click(sender As Object, e As RoutedEventArgs) Handles Dis_BtnForfait.Click
        Dim ForfaitAppli_ As New ForfaitAppli(BD)
        ForfaitAppli_.Show()
    End Sub
End Class




