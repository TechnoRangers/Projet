Public Class Horaire

    Dim BD As P2014_BDTestFrancoisEntities
    Dim _TypeEmploi As String
    Dim MonChiffreTravail As tblChiffreTravail
    Dim _ChiffreTravail As Date

    Sub New(ByRef _MaBD As P2014_BDTestFrancoisEntities)
        BD = _MaBD
        InitializeComponent()
        _ChiffreTravail = Date.Today

        'Remplir combobox type emploi
        Dim res = From Em In BD.tblEmploye Select Em.TypeEmploi Distinct

        Hor_CmbTypeEmploi.ItemsSource = res.ToList()
        Hor_CmbTypeEmploi.SelectedValue = res.ToList.First
    End Sub

    Private Sub Hor_Calendrier_SelectedDatesChanged(sender As Object, e As SelectionChangedEventArgs) Handles Hor_Calendrier.SelectedDatesChanged
        _ChiffreTravail = Hor_Calendrier.SelectedDate
        FiltrerDatagrid()
    End Sub

    Private Sub Hor_CmbTypeEmploi_SelectionChanged(sender As Object, e As SelectionChangedEventArgs) Handles Hor_CmbTypeEmploi.SelectionChanged
        _TypeEmploi = Hor_CmbTypeEmploi.SelectedItem
        FiltrerDatagrid()
    End Sub

    Sub FiltrerDatagrid()
        Dim resChiffre = From ct In BD.tblChiffreTravail
                         Join Em In BD.tblEmploye On ct.NoEmploye Equals Em.NoEmploye
                         Where ct.DateChiffre = _ChiffreTravail And Em.TypeEmploi = _TypeEmploi
                         Select ct

        Hor_DtgChiffreTravail.ItemsSource = resChiffre.ToList
    End Sub

    Private Sub Hor_BtnAjout_Click(sender As Object, e As RoutedEventArgs) Handles Hor_BtnAjout.Click
        Dim FenetreModifChiffreTravail As ChangementHoraire
        FenetreModifChiffreTravail = New ChangementHoraire(BD)
        FenetreModifChiffreTravail.ShowDialog()

        Dim res = From Ct In BD.tblChiffreTravail
                  Select Ct

        Hor_DtgChiffreTravail.ItemsSource = res.ToList
    End Sub

    Private Sub Hor_BtnChangement_Click(sender As Object, e As RoutedEventArgs) Handles Hor_BtnChangement.Click

        Try
            Dim ChiffreSelection As tblChiffreTravail = CType(Hor_DtgChiffreTravail.SelectedItem, tblChiffreTravail)

            Dim FenetreModifChiffreTravail As ChangementHoraire
            FenetreModifChiffreTravail = New ChangementHoraire(BD, ChiffreSelection)
            FenetreModifChiffreTravail.ShowDialog()
        Catch
            MessageBox.Show("Aucun chiffre de travail sélectionné")
        End Try
    End Sub

    Private Sub Hor_BtnQuitter_Click(sender As Object, e As RoutedEventArgs) Handles Hor_BtnQuitter.Click
        Me.Close()
    End Sub

    Private Sub Hor_frmChiffreTravail_Loaded(sender As Object, e As RoutedEventArgs) Handles Hor_frmChiffreTravail.Loaded
        FiltrerDatagrid()
    End Sub
End Class

