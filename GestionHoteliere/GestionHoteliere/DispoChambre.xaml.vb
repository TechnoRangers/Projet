Public Class DispoChambre

    Dim BD As P2014_BDTestFrancoisEntities
    Dim _TypeChambre As tblTypeChambre
    Dim EtageSelection As Integer
    Dim NbLitSelection As Integer

    Sub New(ByRef _MaBD As P2014_BDTestFrancoisEntities)
        InitializeComponent()
        BD = _MaBD
    End Sub

    Private Sub Dis_frmDisponibilite_Loaded(sender As Object, e As RoutedEventArgs) Handles Dis_frmDisponibilite.Loaded
        Dim res = From Tc In BD.tblTypeChambre Select Tc

        _TypeChambre = New tblTypeChambre()

        Dis_CmbTypeChambre.ItemsSource = res.ToList
        Dis_CmbTypeChambre.SelectedValue = res.ToList.First
        Dis_CmbTypeChambre.DisplayMemberPath = "NomTypeChambre"

        Dim Etages() As Integer = {1, 2, 3, 4, 5, 6, 7, 8, 9, 10}
        Dis_CmbEtage.ItemsSource = Etages
        Dis_CmbEtage.SelectedIndex = 0

        Dim Lits() As Integer = {1, 2, 3}
        Dis_CmbNbLit.ItemsSource = Lits
        Dis_CmbNbLit.SelectedIndex = 0

    End Sub

    Private Sub Dis_BtnRéserver_Click(sender As Object, e As RoutedEventArgs) Handles Dis_BtnRéserver.Click

        Dim ChambresSelection As New List(Of tblChambre)

        For Each Chambre As tblChambre In Dis_GrtChambre.SelectedItems
            ChambresSelection.Add(Chambre)
        Next

        Dim Reservation_ As New Reservation(BD, ChambresSelection)



        'Reservation_.LesChambres = Dis_GrtChambre.SelectedItems
        Reservation_.Show()
        Me.Close()

    End Sub

    'Private Sub Dis_CmbChoix1_SelectionChanged(sender As Object, e As SelectionChangedEventArgs) Handles Dis_CmbChoix1.SelectionChanged
    '    If Dis_CmbChoix1.SelectedItem IsNot Nothing Then
    '        _Chambre = CType(Dis_CmbChoix1.SelectedItem, tblChambre)


    '        Dim _Chambre1 = From Ch In BD.tblChambre Join Tc In BD.tblTypeChambre On Ch.CodeTypeChambre Equals Tc.CodeTypeChambre
    '        Where Ch.EtageChambre= _Chambre.EtageChambre
    '        Select New With {.CodeChambre = Ch.EtageChambre, .StatutChambre = Ch.StatutChambre, .NomTypeChambre = Tc.NomTypeChambre, .NbLit = Ch.NbLit, .TypeLit = Ch.TypeLit, .DescChambre = Ch.DescChambre}

    '        Dis_GrtChambre.DataContext = _Chambre1.ToList()
    '        Dis_GrtChambre.ItemsSource = _Chambre1.ToList()

    '    End If

    'End Sub


    'Private Sub Dis_CmbChoix2_SelectionChanged(sender As Object, e As SelectionChangedEventArgs) Handles Dis_CmbChoix2.SelectionChanged
    '    If Dis_CmbChoix2.SelectedItem IsNot Nothing Then
    '        _TypeChambre = CType(Dis_CmbChoix2.SelectedItem, tblTypeChambre)


    '        Dim _Chambre2 = From Ch In BD.tblChambre Join Tc In BD.tblTypeChambre On Ch.CodeTypeChambre Equals Tc.CodeTypeChambre
    '        Where Tc.CodeTypeChambre = _TypeChambre.CodeTypeChambre
    '        Select New With {.CodeChambre = Ch.EtageChambre, .StatutChambre = Ch.StatutChambre, .NomTypeChambre = Tc.NomTypeChambre, .NbLit = Ch.NbLit, .TypeLit = Ch.TypeLit, .DescChambre = Ch.DescChambre}

    '        Dis_GrtChambre.DataContext = _Chambre2.ToList()
    '        Dis_GrtChambre.ItemsSource = _Chambre2.ToList()

    '    End If

    'End Sub

    'Private Sub Dis_CmbChoix3_SelectionChanged(sender As Object, e As SelectionChangedEventArgs) Handles Dis_CmbChoix3.SelectionChanged
    '    If Dis_CmbChoix3.SelectedItem IsNot Nothing Then
    '        _Chambre2 = CType(Dis_CmbChoix3.SelectedItem, tblChambre)


    '        Dim _Chambre3 = From Ch In BD.tblChambre Join Tc In BD.tblTypeChambre On Ch.CodeTypeChambre Equals Tc.CodeTypeChambre
    '        Where Ch.NbLit = _Chambre2.NbLit
    '        Select New With {.CodeChambre = Ch.EtageChambre, .StatutChambre = Ch.StatutChambre, .NomTypeChambre = Tc.NomTypeChambre, .NbLit = Ch.NbLit, .TypeLit = Ch.TypeLit, .DescChambre = Ch.DescChambre}

    '        Dis_GrtChambre.DataContext = _Chambre3.ToList()
    '        Dis_GrtChambre.ItemsSource = _Chambre3.ToList()

    '    End If

    'End Sub

    Private Sub Dis_GrtChambre_Loaded(sender As Object, e As RoutedEventArgs) Handles Dis_GrtChambre.Loaded

        'Dim Chambres = From tabChambre In BD.tblChambre
        '               Select tabChambre

        'Dis_GrtChambre.ItemsSource = Chambres.ToList

        'Dim _Chambre = From Ch In BD.tblChambre Join Tc In BD.tblTypeChambre On Ch.CodeTypeChambre Equals Tc.CodeTypeChambre
        'Select New With {.CodeChambre = Ch.EtageChambre, .StatutChambre = Ch.StatutChambre, .NomTypeChambre = Tc.NomTypeChambre, .NbLit = Ch.NbLit, .TypeLit = Ch.TypeLit, .DescChambre = Ch.DescChambre}

        'Dis_GrtChambre.DataContext = _Chambre.ToList()
        'Dis_GrtChambre.ItemsSource = _Chambre.ToList()

    End Sub

    Private Sub Dis_BtnAnnuler_Click(sender As Object, e As RoutedEventArgs) Handles Dis_BtnAnnuler.Click

        Me.Close()

    End Sub

    Sub FiltrerDatagrid()
        If _TypeChambre IsNot Nothing And EtageSelection <> Nothing And NbLitSelection <> Nothing Then
            Dim resChambres = From tabChambre In BD.tblChambre
                              Where tabChambre.CodeTypeChambre = _TypeChambre.CodeTypeChambre And tabChambre.EtageChambre = EtageSelection And tabChambre.NbLit = NbLitSelection
                              Select tabChambre

            Dis_GrtChambre.ItemsSource = resChambres.ToList
        End If
    End Sub


    Private Sub Dis_CmbTypeChambre_SelectionChanged(sender As Object, e As SelectionChangedEventArgs) Handles Dis_CmbTypeChambre.SelectionChanged
        _TypeChambre = CType(Dis_CmbTypeChambre.SelectedItem, tblTypeChambre)

        FiltrerDatagrid()
    End Sub

    Private Sub Dis_CmbEtage_SelectionChanged(sender As Object, e As SelectionChangedEventArgs) Handles Dis_CmbEtage.SelectionChanged
        EtageSelection = Dis_CmbEtage.SelectedValue

        FiltrerDatagrid()
    End Sub

    Private Sub Dis_CmbNbLit_SelectionChanged(sender As Object, e As SelectionChangedEventArgs) Handles Dis_CmbNbLit.SelectionChanged
        NbLitSelection = Dis_CmbNbLit.SelectedValue

        FiltrerDatagrid()
    End Sub

End Class




