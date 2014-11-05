Public Class Entretien

    Dim MaBD As P2014_BD_GestionHotelEntities

    Sub New(ByRef _MaBD As P2014_BD_GestionHotelEntities)
        InitializeComponent()
        MaBD = _MaBD
    End Sub

    Private Sub Ent_BtnCheckUp_Click(sender As Object, e As RoutedEventArgs) Handles Ent_BtnCheckUp.Click

        Dim CheckUp As New CheckUp
        CheckUp.Show()
        Me.Close()

    End Sub


    Private Sub Ent_BtnEtatChambre_Click(sender As Object, e As RoutedEventArgs) Handles Ent_BtnEtatChambre.Click

        Dim EtatChambre As New EtatChambre
        EtatChambre.Show()
        Me.Close()

    End Sub

    Private Sub Ent_BtnCheckUpSalle_Click(sender As Object, e As RoutedEventArgs) Handles Ent_BtnCheckUpSalle.Click
        Dim CheckUpSalle As New CheckUpSalle(MaBD)
        CheckUpSalle.Show()
        Me.Close()
    End Sub

    Private Sub Ent_BtnEtatSalle_Click(sender As Object, e As RoutedEventArgs) Handles Ent_BtnEtatSalle.Click
        Dim EtatSalle As New EtatSalle(MaBD)
        EtatSalle.Show()
        Me.Close()
    End Sub
End Class
