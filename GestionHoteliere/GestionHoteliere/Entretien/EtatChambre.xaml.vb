Public Class EtatChambre

    Dim MaBD As P2014_BD_GestionHotelEntities
    Dim _maChambre As tblChambre
    Dim HotelConnexion As tblHotel
    Dim EmployeConnexion As tblEmploye

    Sub New(ByRef _BD As P2014_BD_GestionHotelEntities, ByRef _MonHotel As tblHotel, ByRef _MonEmploye As tblEmploye)
        InitializeComponent()
        MaBD = _BD
        EmployeConnexion = _MonEmploye
        HotelConnexion = _MonHotel
        _maChambre = New tblChambre

    End Sub
    Private Sub Eta_FrmEta_Loaded(sender As Object, e As RoutedEventArgs) Handles Eta_FrmEta.Loaded
        'Remplir ComboBoxNoChambre
        Dim NoChambre = From tabChambre In MaBD.tblChambre
                        Where tabChambre.CodeHotel = HotelConnexion.CodeHotel
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
        Dim Fourniture = From t1 In MaBD.tblFourniture Join t2 In MaBD.tblEntretienFournitureChambre On t1.CodeFourniture Equals t2.CodeFourniture
                        Where t1.CodeFourniture = t2.CodeFourniture And t2.NoSeqChambre = _maChambre.NoSeqChambre And t2.EtatFourniture <> "Bon"
                     Select t1.DescFourniture

        Eta_ComboBoxFourniture.ItemsSource = Fourniture.ToList


        Dim Commentaires As New TextRange(Eta_RichTexBoxCom.Document.ContentStart, Eta_RichTexBoxCom.Document.ContentEnd)
        If _maChambre.NoSeqChambre <> 0 Then
            Dim res = From t1 In MaBD.tblEntretienFournitureChambre Join t2 In MaBD.tblFourniture On t1.CodeFourniture Equals t2.CodeFourniture
                                Where t1.CodeFourniture = t2.CodeFourniture And t1.NoSeqChambre = _maChambre.NoSeqChambre And t1.EtatFourniture <> "Bon"
                                Select t2.DescFourniture, t1.EtatFourniture
            eta_Datagrid.ItemsSource = res.ToList

            Dim res2 = From t3 In MaBD.tblEntretienFournitureChambre Join t4 In MaBD.tblFourniture On t3.CodeFourniture Equals t4.CodeFourniture
                       Where t3.CodeFourniture = t4.CodeFourniture And t3.NoSeqChambre = _maChambre.NoSeqChambre And t3.EtatFourniture <> "Bon"
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
        Dim Inventaire As New Inventaire(MaBD, EmployeConnexion, HotelConnexion)
        Inventaire.Show()
        Me.Close()
    End Sub

    Private Sub Eta_BtnAnnuler_Click(sender As Object, e As RoutedEventArgs) Handles Eta_BtnAnnuler.Click
        Me.Close()
    End Sub


    Private Sub Eta_BtnValider_Click(sender As Object, e As RoutedEventArgs) Handles Eta_BtnValider.Click

        Dim update = (From t1 In MaBD.tblEntretienFournitureChambre Join t2 In MaBD.tblFourniture On t1.CodeFourniture Equals t2.CodeFourniture
                  Where t2.DescFourniture = Eta_ComboBoxFourniture.Text And t1.NoSeqChambre = _maChambre.NoSeqChambre Select t1)


        update.First().EtatFourniture = "Bon"
        update.First().DateEffectue = Date.Today
        update.First().StatutEntretien = "Terminé"

        Try
            MaBD.SaveChanges()
            MessageBox.Show("La fourniture à été remplacé")
        Catch
            MessageBox.Show("Erreur")
        End Try

        Dim res = From t1 In MaBD.tblFourniture
                  Where t1.DescFourniture = Eta_ComboBoxFourniture.Text
                  Select t1.CodeFourniture

        MaBD.RemplacerFourniture("NFN", res.First.ToString)

        FiltrerDatagrid()


    End Sub
End Class
