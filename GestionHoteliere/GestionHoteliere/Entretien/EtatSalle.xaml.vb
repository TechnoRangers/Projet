Public Class EtatSalle

    Dim BD As P2014_BD_GestionHotelEntities
    Dim _MaReservationSalle As tblReservationSalle
    Dim HotelConnexion As tblHotel
    Dim EmployeConnexion As tblEmploye

    Sub New(ByRef _BD As P2014_BD_GestionHotelEntities, ByRef _MonHotel As tblHotel, ByRef _MonEmploye As tblEmploye)
        InitializeComponent()
        BD = _BD
        HotelConnexion = _MonHotel
    End Sub

    Private Sub Eta_FrmEtatSalle_Loaded(sender As Object, e As RoutedEventArgs) Handles Eta_FrmEtatSalle.Loaded

        'Remplir ComboBoxNomSalle
        Dim NoReservation = From tabReservSalle In BD.tblReservationSalle
                            Join tabSalle In BD.tblSalle On tabReservSalle.CodeSalle Equals tabSalle.CodeSalle
                            Where tabSalle.CodeHotel = HotelConnexion.CodeHotel
                            Select tabReservSalle

        Eta_CmbBoxNoReservation.ItemsSource = NoReservation.ToList
        Eta_CmbBoxNoReservation.DisplayMemberPath = "NoSeqReservSalle"
        Eta_CmbBoxNoReservation.SelectedValue = NoReservation.ToList

    End Sub



    Private Sub Eta_CmbBoxNoReservation_SelectionChanged(sender As Object, e As SelectionChangedEventArgs) Handles Eta_CmbBoxNoReservation.SelectionChanged
        _MaReservationSalle = CType(Eta_CmbBoxNoReservation.SelectedItem, tblReservationSalle)

        FiltrerDatagrid()
    End Sub

    Sub FiltrerDatagrid()

        'Remplir ComboBoxFourniture
        Dim Fourniture = From t1 In BD.tblFourniture Join t2 In BD.tblEntretienFournitureSalle On t1.CodeFourniture Equals t2.CodeFourniture
                        Where t1.CodeFourniture = t2.CodeFourniture And t2.NoSeqReservSalle = _MaReservationSalle.NoSeqReservSalle And t2.EtatFourniture <> "Bon"
                     Select t1.DescFourniture

        Eta_ComboBoxFourniture.ItemsSource = Fourniture.ToList

        Dim Commentaires As New TextRange(Eta_RichTexBoxCom.Document.ContentStart, Eta_RichTexBoxCom.Document.ContentEnd)
        If _MaReservationSalle.NoSeqReservSalle <> 0 Then
            Dim res = From t1 In BD.tblEntretienFournitureSalle Join t2 In BD.tblFourniture On t1.CodeFourniture Equals t2.CodeFourniture
                                Where t1.CodeFourniture = t2.CodeFourniture And t1.NoSeqReservSalle = _MaReservationSalle.NoSeqReservSalle And t1.EtatFourniture <> "Bon"
                                Select t2.DescFourniture, t1.EtatFourniture
            eta_Datagrid.ItemsSource = res.ToList

            Dim res2 = From t3 In BD.tblEntretienFournitureSalle Join t4 In BD.tblFourniture On t3.CodeFourniture Equals t4.CodeFourniture
                       Where t3.CodeFourniture = t4.CodeFourniture And t3.NoSeqReservSalle = _MaReservationSalle.NoSeqReservSalle And t3.EtatFourniture <> "Bon"
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
        Dim Inventaire As New Inventaire(BD, EmployeConnexion, HotelConnexion)
        Inventaire.Show()
        Me.Close()
    End Sub

    Private Sub Eta_BtnAnnuler_Click(sender As Object, e As RoutedEventArgs) Handles Eta_BtnAnnuler.Click
        Me.Close()
    End Sub


    Private Sub Eta_BtnValider_Click(sender As Object, e As RoutedEventArgs) Handles Eta_BtnValider.Click
        If Eta_ComboBoxFourniture.SelectedItem IsNot Nothing Then
            Dim update = (From t1 In BD.tblEntretienFournitureSalle Join t2 In BD.tblFourniture On t1.CodeFourniture Equals t2.CodeFourniture
                      Where t2.DescFourniture = Eta_ComboBoxFourniture.Text And t1.NoSeqReservSalle = _MaReservationSalle.NoSeqReservSalle Select t1)


            update.First().EtatFourniture = "Bon"
            update.First().DateEffectue = Date.Today
            update.First().StatutEntretien = "Terminé"

            Try
                BD.SaveChanges()
                MessageBox.Show("La fourniture à été remplacé")
            Catch
                MessageBox.Show("Erreur")
            End Try

            Dim res = From t1 In BD.tblFourniture
                  Where t1.DescFourniture = Eta_ComboBoxFourniture.Text
                  Select t1.CodeFourniture

            BD.RemplacerFourniture("NFN", res.First.ToString)

            FiltrerDatagrid()

        Else
            MessageBox.Show("Aucune fourniture n'a été selectionéé")
        End If
    End Sub
End Class
