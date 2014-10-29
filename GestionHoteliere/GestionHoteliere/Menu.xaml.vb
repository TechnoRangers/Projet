Public Class Menu
    Dim MaBD As P2014_BD_GestionHotelEntities
    Dim EmployeConnexion As tblEmploye
    Dim HotelConnexion As tblHotel

    Sub New(ByRef _MaBD As P2014_BD_GestionHotelEntities, Optional ByRef _EmployeConnexion As tblEmploye = Nothing)
        InitializeComponent()
        MaBD = _MaBD
        EmployeConnexion = _EmployeConnexion

        If _EmployeConnexion Is Nothing Then
            Men_LblHotel.Visibility = Windows.Visibility.Hidden
            Men_LbltypeEmploi.Visibility = Windows.Visibility.Hidden
            Men_LblNomEmploye.Visibility = Windows.Visibility.Hidden
        Else
            Men_LblNomEmploye.Content = _EmployeConnexion.NomEmploye
            Men_LbltypeEmploi.Content = _EmployeConnexion.TypeEmploi

            If _EmployeConnexion.TypeEmploi = "Gestion" Then
                Men_btnResChambre.IsEnabled = False
                Men_btnResSalle.IsEnabled = False
                Men_BtnConsoleAdmin.IsEnabled = False
                Men_BtnEntretien.IsEnabled = False
            ElseIf _EmployeConnexion.TypeEmploi = "Reception" Then
                Men_BtnConsoleAdmin.IsEnabled = False
                Men_btnInventaire.IsEnabled = False
                Men_BtnEntretien.IsEnabled = False
            End If


        End If


    End Sub

    Private Sub Men_btnResChambre_Click(sender As Object, e As RoutedEventArgs) Handles Men_btnResChambre.Click

        Dim Disponibilite_ As New ClientReservation(MaBD)
        Disponibilite_.Show()
        'Me.Close()

    End Sub

    Private Sub Men_btnInventaire_Click(sender As Object, e As RoutedEventArgs) Handles Men_btnInventaire.Click

        Dim Inventaire_ As New Inventaire(MaBD)
        Inventaire_.Show()
        'Me.Close()

    End Sub


    Private Sub Men_btnStatistique_Click(sender As Object, e As RoutedEventArgs) Handles Men_btnStatistique.Click

        Dim Statistique_ As New Statistique(MaBD)
        Statistique_.Show()
        'Me.Close()

    End Sub

    Private Sub Men_btnQuitter_Click(sender As Object, e As RoutedEventArgs) Handles Men_btnQuitter.Click

        Me.Close()

    End Sub



    Private Sub Men_BtnEntretien_Click(sender As Object, e As RoutedEventArgs) Handles Men_BtnEntretien.Click

        Dim Entretien_ As New Entretien
        Entretien_.Show()
        'Me.Close()
    End Sub

    Private Sub Men_btnResSalle_Click(sender As Object, e As RoutedEventArgs) Handles Men_btnResSalle.Click
        Dim Salle As New ReservationSalle(MaBD, EmployeConnexion)
        Salle.Show()
        'Me.Close()

    End Sub

    Private Sub Men_BtnConsoleAdmin_Click(sender As Object, e As RoutedEventArgs) Handles Men_BtnConsoleAdmin.Click
        Dim ConsoleAdmin As New ConsoleAdmin(MaBD)
        ConsoleAdmin.Show()
    End Sub

    Private Sub Men_BtnHoraires_Click(sender As Object, e As RoutedEventArgs) Handles Men_BtnHoraires.Click

        Dim Horaire As New Horaire(MaBD)
        Horaire.Show()

    End Sub
End Class
