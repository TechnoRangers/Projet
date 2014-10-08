Public Class EtatChambre

    Dim MaBD As P2014_BDTestFrancoisEntities
    Dim _maChambre As tblChambre

    Sub New()
        MaBD = New P2014_BDTestFrancoisEntities
        _maChambre = New tblChambre
        InitializeComponent()
    End Sub
    Private Sub Eta_FrmEta_Loaded(sender As Object, e As RoutedEventArgs) Handles Eta_FrmEta.Loaded
        'Remplir ComboBoxNoChambre
        Dim NoChambre = From tabChambre In MaBD.tblChambre
                     Select tabChambre

        Eta_CmbBoxNoChambre.ItemsSource = NoChambre.ToList
        Eta_CmbBoxNoChambre.DisplayMemberPath = "NoSeqChambre"
        Eta_CmbBoxNoChambre.SelectedValue = NoChambre.ToList
    End Sub

    Private Sub Eta_CmbBoxNoChambre_SelectionChanged(sender As Object, e As SelectionChangedEventArgs) Handles Eta_CmbBoxNoChambre.SelectionChanged

        _maChambre = CType(Eta_CmbBoxNoChambre.SelectedItem, tblChambre)

        FiltrerDatagrid()

    End Sub

    Sub FiltrerDatagrid()
        ''If _maChambre.NoSeqChambre <> 0 Then
        ''    Dim res = From t1 In MaBD.tblFourniture
        ''                        Where t1.NoSeqChambre = _maChambre.NoSeqChambre
        ''                        Select New With {.Fourniture = t1, .EstCocher = False}
        ''    Che_Datagrid.ItemsSource = res.ToList

        'End If
    End Sub

End Class
