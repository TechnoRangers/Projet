Public Class DispoChambre

    Dim BD As P2014_BDTestFrancoisEntities
    Dim _TypeChambre As tblTypeChambre
    Dim _Chambre As tblChambre
    Dim _Chambre2 As tblChambre

    Sub New(ByRef _MaBD As P2014_BDTestFrancoisEntities)
        InitializeComponent()
        BD = _MaBD
    End Sub

    Private Sub Dis_BtnAnnuler_Click(sender As Object, e As RoutedEventArgs) Handles Dis_BtnAnnuler.Click

        Me.Close()

    End Sub

    Private Sub Dis_BtnRéserver_Click(sender As Object, e As RoutedEventArgs) Handles Dis_BtnRéserver.Click

        Dim Reservation_ As New Reservation(BD)



        Reservation_.LesChambres = Dis_GrtChambre.SelectedItems
        Reservation_.Show()
        Me.Close()

    End Sub

    Private Sub Dis_CmbChoix1_SelectionChanged(sender As Object, e As SelectionChangedEventArgs) Handles Dis_CmbChoix1.SelectionChanged
        If Dis_CmbChoix1.SelectedItem IsNot Nothing Then
            _Chambre = CType(Dis_CmbChoix1.SelectedItem, tblChambre)


            Dim _Chambre1 = From Ch In BD.tblChambre Join Tc In BD.tblTypeChambre On Ch.CodeTypeChambre Equals Tc.CodeTypeChambre
            Where Ch.EtageChambre= _Chambre.EtageChambre
            Select New With {.CodeChambre = Ch.EtageChambre, .StatutChambre = Ch.StatutChambre, .NomTypeChambre = Tc.NomTypeChambre, .NbLit = Ch.NbLit, .TypeLit = Ch.TypeLit, .DescChambre = Ch.DescChambre}

            Dis_GrtChambre.DataContext = _Chambre1.ToList()
            Dis_GrtChambre.ItemsSource = _Chambre1.ToList()

        End If

    End Sub


    Private Sub Dis_CmbChoix2_SelectionChanged(sender As Object, e As SelectionChangedEventArgs) Handles Dis_CmbChoix2.SelectionChanged
        If Dis_CmbChoix2.SelectedItem IsNot Nothing Then
            _TypeChambre = CType(Dis_CmbChoix2.SelectedItem, tblTypeChambre)


            Dim _Chambre2 = From Ch In BD.tblChambre Join Tc In BD.tblTypeChambre On Ch.CodeTypeChambre Equals Tc.CodeTypeChambre
            Where Tc.CodeTypeChambre = _TypeChambre.CodeTypeChambre
            Select New With {.CodeChambre = Ch.EtageChambre, .StatutChambre = Ch.StatutChambre, .NomTypeChambre = Tc.NomTypeChambre, .NbLit = Ch.NbLit, .TypeLit = Ch.TypeLit, .DescChambre = Ch.DescChambre}

            Dis_GrtChambre.DataContext = _Chambre2.ToList()
            Dis_GrtChambre.ItemsSource = _Chambre2.ToList()

        End If

    End Sub

    Private Sub Dis_CmbChoix3_SelectionChanged(sender As Object, e As SelectionChangedEventArgs) Handles Dis_CmbChoix3.SelectionChanged
        If Dis_CmbChoix3.SelectedItem IsNot Nothing Then
            _Chambre2 = CType(Dis_CmbChoix3.SelectedItem, tblChambre)


            Dim _Chambre3 = From Ch In BD.tblChambre Join Tc In BD.tblTypeChambre On Ch.CodeTypeChambre Equals Tc.CodeTypeChambre
            Where Ch.NbLit = _Chambre2.NbLit
            Select New With {.CodeChambre = Ch.EtageChambre, .StatutChambre = Ch.StatutChambre, .NomTypeChambre = Tc.NomTypeChambre, .NbLit = Ch.NbLit, .TypeLit = Ch.TypeLit, .DescChambre = Ch.DescChambre}

            Dis_GrtChambre.DataContext = _Chambre3.ToList()
            Dis_GrtChambre.ItemsSource = _Chambre3.ToList()

        End If

    End Sub

    Private Sub Dis_GrdDispo_Loaded(sender As Object, e As RoutedEventArgs) Handles Dis_GrdDispo.Loaded

        Dim res1 = From Ch In BD.tblChambre Select Ch

        Dim res2 = From Tc In BD.tblTypeChambre Select Tc

        Dim res3 = From Ch In BD.tblChambre Select Ch

 

        Dis_CmbChoix1.ItemsSource = res1.ToList()
        Dis_CmbChoix2.ItemsSource = res2.ToList()
        Dis_CmbChoix3.ItemsSource = res3.ToList()

        Dis_CmbChoix1.DisplayMemberPath = "EtageChambre"
        Dis_CmbChoix1.SelectedItem = res1.FirstOrDefault()
        Dis_CmbChoix2.DisplayMemberPath = "NomTypeChambre"
        Dis_CmbChoix2.SelectedItem = res2.FirstOrDefault()
        Dis_CmbChoix3.DisplayMemberPath = "NbLit"
        Dis_CmbChoix3.SelectedItem = res3.FirstOrDefault()

    End Sub


    Private Sub Dis_GrtChambre_Loaded(sender As Object, e As RoutedEventArgs) Handles Dis_GrtChambre.Loaded




        Dim _Chambre = From Ch In BD.tblChambre Join Tc In BD.tblTypeChambre On Ch.CodeTypeChambre Equals Tc.CodeTypeChambre
        Select New With {.CodeChambre = Ch.EtageChambre, .StatutChambre = Ch.StatutChambre, .NomTypeChambre = Tc.NomTypeChambre, .NbLit = Ch.NbLit, .TypeLit = Ch.TypeLit, .DescChambre = Ch.DescChambre}

        Dis_GrtChambre.DataContext = _Chambre.ToList()
        Dis_GrtChambre.ItemsSource = _Chambre.ToList()

    End Sub

End Class




