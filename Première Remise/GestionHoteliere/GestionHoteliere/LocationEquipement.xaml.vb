Public Class LocationEquipement
    Dim MaBd As P2014_BDTestFrancoisEntities
    Dim noRes As Int32




    Sub New(ByRef _MaBD As P2014_BDTestFrancoisEntities, ByRef _NoRes As Int32)
        InitializeComponent()
        MaBd = _MaBD
        noRes = _NoRes
    End Sub

    Private Sub LocEqui_BtnAjout_Click(sender As Object, e As RoutedEventArgs) Handles LocEqui_BtnAjout.Click
        'affiche l'item dans la liste reserve
        LocEqui_ListBoxReserv.Items.Add(LocEqui_ListBoxInventaire.SelectedItem)
        LocEqui_ListBoxInventaire.Items.Remove(LocEqui_ListBoxInventaire.SelectedItem)
    End Sub

    Private Sub LocEqui_BtnEnl_Click(sender As Object, e As RoutedEventArgs) Handles LocEqui_BtnEnl.Click
        'remove les items dans la premiere liste 
        LocEqui_ListBoxInventaire.Items.Add(LocEqui_ListBoxReserv.SelectedItem)
        LocEqui_ListBoxReserv.Items.Remove(LocEqui_ListBoxReserv.SelectedItem)

    End Sub

    Private Sub LocEqui_BtnValider_Click(sender As Object, e As RoutedEventArgs) Handles LocEqui_BtnValider.Click
        'Dim NewEqui As tblReservationSalleFourniture
        'doit modifier la base de donnée avant d'ajouter un objet 
        For Each el In LocEqui_ListBoxReserv.Items
            'NewEqui.NoSeqFourniture = el.NoSeqFourniture
            'NewEqui.NoSeqReservSalle = el.NoSeqReservSalle
        Next
    End Sub

    Private Sub LocEqui_BtnAnnuler_Click(sender As Object, e As RoutedEventArgs) Handles LocEqui_BtnAnnuler.Click
        Me.Close()
    End Sub

    Private Sub window_Loaded(sender As Object, e As RoutedEventArgs) Handles MyBase.Loaded
        'initialisation de la listbox equipement For some reason the where doesn't work :S 
        Dim produit

        Dim rep = (From it In MaBd.tblFourniture
                   Where it.NoSeqChambre.Equals(DBNull.Value)
                   Select it.DescFourniture, it.NoSeqFourniture)
        'Remplie la listview 
        For Each row In rep.ToList
            produit = New With {Key .Name = row.DescFourniture, .Nombre = row.NoSeqFourniture}
            LocEqui_ListBoxInventaire.Items.Add(produit)
        Next


    End Sub
End Class
'Where it.NoSeqChambre.Equals(1000)