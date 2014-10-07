Public Class ClientReservation
    Dim BD As P2014_BDTestFrancoisEntities

    Sub New(ByRef _BD As P2014_BDTestFrancoisEntities)
        InitializeComponent()
        BD = _BD


    End Sub

    Private Sub Cli_BtnContinuer_Click(sender As Object, e As RoutedEventArgs) Handles Cli_BtnContinuer.Click

        Dim Dispo_ As New DispoChambre(BD)
        Dispo_.Show()
        Me.Close()

    End Sub

    Private Sub Cli_BtnRechercher_Click(sender As Object, e As RoutedEventArgs) Handles Cli_BtnRechercher.Click

        'FiltrerDatagrid()

    End Sub

    Private Sub Cli_BtnAnnuler_Click(sender As Object, e As RoutedEventArgs) Handles Cli_BtnAnnuler.Click

        Me.Close()

    End Sub

    'Sub FiltrerDatagrid()

    '    Dim resChambre = From rc In BD.tblReservationChambre Join Rcr In BD.tblChambreReservationChambre On rc.NoSeqReservChambre Equals Rcr.NoSeqReservChambre Join Ch In BD.tblChambre On Rcr.NoSeqChambre Equals Ch.NoSeqChambre Join Cl In BD.tblClient On Cl.NoSeqClient Equals rc.NoSeqClient
    '    Where Cl.PrenomClient = Res_TextBoxPren.Text And Cl.NomClient = Res_TextBoxNom.Text And Cl.codepostal = Res_TextBoxCodePostal
    '    Select Ch.tblTypeChambre, Ch.TypeLit, Ch.NbLit, Ch.EtageChambre, Ch.StatutChambre, Ch.DescChambre



    '    If resChambre.toList = Nothing Then

    '        MessageBox.Show("Le client n'est jamais venu à l'hôtel avant")

    '    Else
    '        Cli_DtgHistorique.ItemsSource = resChambre.ToList
    '        Res_TextBoxAdresse.Text = resChambre
    '        Res_TxtEmail.Text = resChambre
    '        Res_NoTelephone.Text = resChambre
    '    End If

    'End Sub
End Class

