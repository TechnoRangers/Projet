Public Class CheckUp

    Dim MaBD As P2014_BDTestFrancoisEntities
    Dim _maChambre As tblChambre

    Sub New()
        MaBD = New P2014_BDTestFrancoisEntities
        _maChambre = New tblChambre
        InitializeComponent()
    End Sub



    Private Sub Che_FrmChe_Loaded(sender As Object, e As RoutedEventArgs) Handles Che_FrmChe.Loaded

        'Remplir ComboBoxNoChambre
        Dim NoChambre = From tabChambre In MaBD.tblChambre
                     Select tabChambre

        Che_ComboBoxNoChambre.ItemsSource = NoChambre.ToList
        Che_ComboBoxNoChambre.DisplayMemberPath = "NoSeqChambre"
        Che_ComboBoxNoChambre.SelectedValue = NoChambre.ToList

    End Sub
End Class
