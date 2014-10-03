Public Class Menu
    Dim MaBD As P2014_BDTestFrancoisEntities
    Dim EmployeConnection As tblEmploye

    Sub New(ByRef _MaBD As P2014_BDTestFrancoisEntities)
        InitializeComponent()
        MaBD = _MaBD
    End Sub


    Private Sub Men_btnResChambre_Click(sender As Object, e As RoutedEventArgs) Handles Men_btnResChambre.Click

        Dim Disponibilite_ As New ClientReservation(MaBD)
        Disponibilite_.Show()
        Me.Close()

    End Sub

    Private Sub Men_btnInventaire_Click(sender As Object, e As RoutedEventArgs) Handles Men_btnInventaire.Click

        Dim Inventaire_ As New Inventaire
        Inventaire_.Show()
        Me.Close()

    End Sub

    Private Sub Men_btnEquipement_Click(sender As Object, e As RoutedEventArgs) Handles Men_btnEquipement.Click

        Dim Equipement_ As New Equipement
        Equipement_.Show()
        Me.Close()

    End Sub

    Private Sub Men_btnStatistique_Click(sender As Object, e As RoutedEventArgs) Handles Men_btnStatistique.Click

        Dim Statistique_ As New Statistique
        Statistique_.Show()
        Me.Close()

    End Sub

    '    Private Sub Men_btnAdmConsol_Click(sender As Object, e As RoutedEventArgs) Handles Men_btnAdmConsol.Click

    '        Dim DosEmploye_ As New DosEmploye
    '        DosEmploye_.Show()
    '        Me.Close()

    '    End Sub

    Private Sub Men_btnQuitter_Click(sender As Object, e As RoutedEventArgs) Handles Men_btnQuitter.Click

        Me.Close()

    End Sub



    Private Sub Men_BtnEntretien_Click(sender As Object, e As RoutedEventArgs) Handles Men_BtnEntretien.Click

        Dim Entretien_ As New Entretien
        Entretien_.Show()
        Me.Close()
    End Sub

    Private Sub Men_btnResSalle_Click(sender As Object, e As RoutedEventArgs) Handles Men_btnResSalle.Click
        Dim Salle As New ReservationSalle
        Salle.Show()
        Me.Close()

    End Sub
End Class
