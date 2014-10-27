Public Class LocationEquipement
    Dim MaBd As P2014_BD_GestionHotelEntities
    Dim noRes As tblReservationSalle




    Sub New(ByRef _MaBD As P2014_BD_GestionHotelEntities, ByRef _NoRes As Int32)
        InitializeComponent()
        MaBd = _MaBD
        noRes = (From it In MaBd.tblReservationSalle Where it.NoSeqReservSalle = noRes.NoSeqReservSalle Select it).Single()
    End Sub

    Private Sub LocEqui_BtnAjout_Click(sender As Object, e As RoutedEventArgs) Handles LocEqui_BtnAjout.Click
        'affiche l'item dans la liste reserve
        Dim value As Int32
        value = InputBox("Quantité", "Quantité")

        Dim produit = New With {Key LocEqui_ListBoxInventaire.SelectedItem, .Quantite = value}
        LocEqui_ListBoxReserv.Items.Add(produit)
        LocEqui_ListBoxInventaire.Items.Remove(LocEqui_ListBoxInventaire.SelectedItem)
    End Sub

    Private Sub LocEqui_BtnEnl_Click(sender As Object, e As RoutedEventArgs) Handles LocEqui_BtnEnl.Click
        'remove les items dans la premiere liste 
        LocEqui_ListBoxInventaire.Items.Add(LocEqui_ListBoxReserv.SelectedItem)
        LocEqui_ListBoxReserv.Items.Remove(LocEqui_ListBoxReserv.SelectedItem)

    End Sub

    Private Sub LocEqui_BtnValider_Click(sender As Object, e As RoutedEventArgs) Handles LocEqui_BtnValider.Click
        'Dim NewEqui As tblReservationFournitureSalle
        'doit modifier la base de donnée avant d'ajouter un objet 
        For Each el In LocEqui_ListBoxReserv.Items
            '   NewEqui.NoSeqReserSalle = noRes.noSeqReserSalle
            '   NewEqui.codeFourniture  = El.CodeFourniture
            '   NewEqui.codeSalle =  noRes.NoSeqReserSalle
            '   QuantiteFourniture 
        Next
    End Sub

    Private Sub LocEqui_BtnAnnuler_Click(sender As Object, e As RoutedEventArgs) Handles LocEqui_BtnAnnuler.Click
        Me.Close()
    End Sub

    Private Sub window_Loaded(sender As Object, e As RoutedEventArgs) Handles MyBase.Loaded
        'initialisation de la listbox equipement For some reason the where doesn't work :S 
        Dim produit

        Dim rep = (From it In MaBd.tblFourniture
                   Select it.DescFourniture, it.CodeFourniture)
        'Remplie la listview 
        For Each row In rep.ToList
            produit = New With {Key .Name = row.DescFourniture, .Nombre = row.CodeFourniture}
            LocEqui_ListBoxInventaire.Items.Add(produit)
        Next

    End Sub
End Class
'Where it.NoSeqChambre.Equals(1000)