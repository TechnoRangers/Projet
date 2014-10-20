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
        'Remplir ComboBoxFourniture
        Dim Fourniture = From t1 In MaBD.tblEntretienFourniture Join t2 In MaBD.tblFourniture On t1.NoSeqFourniture Equals t2.NoSeqFourniture
                        Where t1.NoSeqFourniture = t2.NoSeqFourniture And t2.NoSeqChambre = _maChambre.NoSeqChambre And t1.EtatFourniture <> "Bon"
                     Select t2.DescFourniture

        Eta_ComboBoxFourniture.ItemsSource = Fourniture.ToList


        Dim Commentaires As New TextRange(Eta_RichTexBoxCom.Document.ContentStart, Eta_RichTexBoxCom.Document.ContentEnd)
        If _maChambre.NoSeqChambre <> 0 Then
            Dim res = From t1 In MaBD.tblEntretienFourniture Join t2 In MaBD.tblFourniture On t1.NoSeqFourniture Equals t2.NoSeqFourniture
                                Where t1.NoSeqFourniture = t2.NoSeqFourniture And t2.NoSeqChambre = _maChambre.NoSeqChambre And t1.EtatFourniture <> "Bon"
                                Select t2.DescFourniture, t1.EtatFourniture
            eta_Datagrid.ItemsSource = res.ToList

            Dim res2 = From t3 In MaBD.tblEntretienFourniture Join t4 In MaBD.tblFourniture On t3.NoSeqFourniture Equals t4.NoSeqFourniture
                       Where t3.NoSeqFourniture = t4.NoSeqFourniture And t4.NoSeqChambre = _maChambre.NoSeqChambre And t3.EtatFourniture <> "Bon"
                       Select t3.CommentaireFourniture

            Dim i As Integer

            If res2.ToList.Count <> 0 Then
                Dim com As String

                com = res2.ToList(0)
                For i = 0 To (res2.ToList.Count - 1)
                    If i > 0 Then
                        If res2.ToList(i) <> res2.ToList(i - 1) Then
                            com += res2.ToList(i)
                        End If
                    End If
                Next

                Commentaires.Text = com
            Else
                Commentaires.Text = ""
            End If

        End If
    End Sub

    Private Sub Eta_BtnInventaire_Click(sender As Object, e As RoutedEventArgs) Handles Eta_BtnInventaire.Click
        Dim Inventaire As New Inventaire(MaBD)
        Inventaire.Show()
        Me.Close()
    End Sub

    Private Sub Eta_BtnAnnuler_Click(sender As Object, e As RoutedEventArgs) Handles Eta_BtnAnnuler.Click
        Me.Close()
    End Sub

 
    Private Sub Eta_BtnValider_Click(sender As Object, e As RoutedEventArgs) Handles Eta_BtnValider.Click

        Dim update = (From t1 In MaBD.tblEntretienFourniture Join t2 In MaBD.tblFourniture On t1.NoSeqFourniture Equals t2.NoSeqFourniture
                  Where t2.DescFourniture = Eta_ComboBoxFourniture.Text And t2.NoSeqChambre = _maChambre.NoSeqChambre Select t1)


        update.First().EtatFourniture = "Bon"

        Try
            MaBD.SaveChanges()
            MessageBox.Show("La fourniture à été remplacé")
        Catch
            MessageBox.Show("Erreur")
        End Try

        FiltrerDatagrid()

    End Sub
End Class
