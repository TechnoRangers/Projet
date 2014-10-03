Public Class Horaire

    Dim BD As P2014_BDTestFrancoisEntities
    Dim _TypeEmploi As String
    Dim _ChiffreTravail As Date

    Sub New()
        BD = New P2014_BDTestFrancoisEntities
        InitializeComponent()
    End Sub

    Private Sub Hor_Calendrier_Loaded(sender As Object, e As RoutedEventArgs) Handles Hor_Calendrier.Loaded

        _ChiffreTravail = Date.Today

    End Sub

    Private Sub Hor_CmbTypeEmploi_Loaded(sender As Object, e As RoutedEventArgs) Handles Hor_CmbTypeEmploi.Loaded

        Dim res = From Em In BD.tblEmploye Select Em.TypeEmploi Distinct

        Hor_CmbTypeEmploi.ItemsSource = res.ToList()

    End Sub

    Private Sub Hor_DtgChiffreTravail_Loaded(sender As Object, e As RoutedEventArgs) Handles Hor_DtgChiffreTravail.Loaded

        Dim Date_ = Date.Today

        Dim _ChiffreTravail = From Ct In BD.tblChiffreTravail Join Em In BD.tblEmploye On Ct.NoEmploye Equals Em.NoEmploye
        Where Ct.DateChiffre = Date_
        Select New With {Em.NoEmploye, Em.PrenomEmploye, Em.NomEmploye, Ct.HeureDebut, Ct.HeureFin}


        Hor_DtgChiffreTravail.DataContext = _ChiffreTravail.ToList()
        Hor_DtgChiffreTravail.ItemsSource = _ChiffreTravail.ToList()


    End Sub

    Private Sub Hor_Calendrier_SelectedDatesChanged(sender As Object, e As SelectionChangedEventArgs) Handles Hor_Calendrier.SelectedDatesChanged

        _ChiffreTravail = Hor_Calendrier.SelectedDate

        FiltrerDatagrid()

    End Sub

    Private Sub Hor_CmbTypeEmploi_SelectionChanged(sender As Object, e As SelectionChangedEventArgs) Handles Hor_CmbTypeEmploi.SelectionChanged

        _TypeEmploi = Hor_CmbTypeEmploi.SelectedItem

        FiltrerDatagrid()

    End Sub

    Private Sub Hor_BtnQuitter_Click(sender As Object, e As RoutedEventArgs) Handles Hor_BtnQuitter.Click

        Me.Close()
    End Sub

    Sub FiltrerDatagrid()

        Dim resChiffre = From ct In BD.tblChiffreTravail Join Em In BD.tblEmploye On ct.NoEmploye Equals Em.NoEmploye
        Where ct.DateChiffre = _ChiffreTravail And Em.TypeEmploi = _TypeEmploi
        Select Em.NoEmploye, Em.PrenomEmploye, Em.NomEmploye, ct.HeureDebut, ct.HeureFin

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
            MessageBox.Show("Aucune row selectionné")
        End Try
    End Sub
End Class
'LOL LOL LOL TEST !
