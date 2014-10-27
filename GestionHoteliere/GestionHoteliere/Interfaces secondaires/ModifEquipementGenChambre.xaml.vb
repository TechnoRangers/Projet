Public Class ModifEquipementGenChambre
    Dim MaBD As P2014_BD_GestionHotelEntities
    Dim MonEqGenChamb As tblEquipementGeneriqueChambre
    Sub New(ByRef _MaBD As P2014_BD_GestionHotelEntities, Optional ByRef _MonEqGenChamb As tblEquipementGeneriqueChambre = Nothing)
        InitializeComponent()
        MaBD = _MaBD
        MonEqGenChamb = _MonEqGenChamb

        eqgenchamb_txtCodeEquipementGenChambre.DataContext = MonEqGenChamb
        eqgenchamb_txtNomEquipementGenChambre.DataContext = MonEqGenChamb

        If MonEqGenChamb IsNot Nothing Then
            eqgenchamb_txtCodeEquipementGenChambre.IsEnabled = False
        Else
            eqgenchamb_txtCodeEquipementGenChambre.IsEnabled = True
        End If
    End Sub

    Private Sub eqgenchamb_btnConfirmer_Click(sender As Object, e As RoutedEventArgs) Handles eqgenchamb_btnConfirmer.Click
        Try
            If MonEqGenChamb Is Nothing Then
                MonEqGenChamb = New tblEquipementGeneriqueChambre()
                MonEqGenChamb.CodeEquipementGenChambre = eqgenchamb_txtCodeEquipementGenChambre.Text
                MonEqGenChamb.NomEquipementGenChambre = eqgenchamb_txtNomEquipementGenChambre.Text

                MaBD.tblEquipementGeneriqueChambre.Add(MonEqGenChamb)
            End If
            MaBD.SaveChanges()
        Catch ex As Exception
            MaBD.tblEquipementGeneriqueChambre.Remove(MonEqGenChamb)
            MessageBox.Show("Existe deja")
        End Try

        Me.Close()
    End Sub
End Class
