Public Class LocationEquipement
    Dim MaBd As P2014_BD_GestionHotelEntities
    Dim noRes As tblReservationSalle

    Sub New(ByRef _MaBD As P2014_BD_GestionHotelEntities, ByRef _NoRes As Int32)
        InitializeComponent()
        MaBd = _MaBD
        noRes = New tblReservationSalle
        noRes.NoSeqReservSalle = _NoRes
        noRes = (From it In MaBd.tblReservationSalle Where it.NoSeqReservSalle = noRes.NoSeqReservSalle Select it).Single()
    End Sub

    Private Sub LocEqui_BtnAjout_Click(sender As Object, e As RoutedEventArgs) Handles LocEqui_BtnAjout.Click
        'affiche l'item dans la liste reserve
        Dim bool As Boolean = True
        Dim produit As MyItem
        Dim checkup As MyItem
        Dim value As Int32
        Dim NewEqui As tblFournitureReservationSalle
        NewEqui = New tblFournitureReservationSalle
        value = InputBox("Quantité", "Quantité", 1)

        Dim Rep = (From It In MaBd.tblFourniture Where It.DescFourniture = LocEqui_ListBoxInventaire.SelectedItem.ToString Select It.CodeFourniture).Single

        'produit = New With {Key .Name = LocEqui_ListBoxInventaire.SelectedItem, .Nombre = Rep, .Quantite = value}
        produit = New MyItem
        produit.Name = LocEqui_ListBoxInventaire.SelectedItem
        produit.Nombre = Rep
        produit.Quantite = value
        For Each el In LocEqui_ListBoxReserv.Items
            checkup = New MyItem
            checkup = el
            If checkup.Nombre = produit.Nombre Then
                bool = False
            End If
        Next
        If bool Then
            LocEqui_ListBoxReserv.Items.Add(produit)
            LocEqui_ListBoxReserv.SelectedItem = produit

            produit = New MyItem
            produit = LocEqui_ListBoxReserv.SelectedItem
            NewEqui.NoSeqReservSalle = noRes.NoSeqReservSalle
            NewEqui.CodeFourniture = produit.Nombre
            NewEqui.CodeSalle = noRes.CodeSalle
            NewEqui.QuantiteFourniture = produit.Quantite

            MaBd.tblFournitureReservationSalle.Add(NewEqui)
            'MaBd.SaveChanges()
        Else
        MessageBox.Show("l'objet est déjà dans la liste")
        End If
        'LocEqui_ListBoxInventaire.Items.Remove(LocEqui_ListBoxInventaire.SelectedItem)
    End Sub

    Private Sub LocEqui_BtnEnl_Click(sender As Object, e As RoutedEventArgs) Handles LocEqui_BtnEnl.Click
        'remove les items dans la premiere liste 
        'LocEqui_ListBoxInventaire.Items.Add(LocEqui_ListBoxReserv.SelectedItem)
        Dim rep = (From it In MaBd.tblFournitureReservationSalle Where it.NoSeqReservSalle = noRes.NoSeqReservSalle Select it).ToList
        Dim produit As MyItem
        For Each A In rep
            produit = New MyItem
            produit = LocEqui_ListBoxReserv.SelectedItem
            If produit.Nombre = A.CodeFourniture Then
                MaBd.tblFournitureReservationSalle.Remove(A)
                'MaBd.SaveChanges()
            End If
        Next
        LocEqui_ListBoxReserv.Items.Remove(LocEqui_ListBoxReserv.SelectedItem)
    End Sub

    Private Sub LocEqui_BtnAnnuler_Click(sender As Object, e As RoutedEventArgs) Handles LocEqui_BtnAnnuler.Click
        'ferme la page 
        Me.Close()
    End Sub

    Private Sub window_Loaded(sender As Object, e As RoutedEventArgs) Handles MyBase.Loaded
        'initialisation de la listbox equipement missing where  
        Dim produit As MyItem
        Dim checkup As MyItem
        Dim bool As Boolean = True
        'recherche des items dans les fourniture salle 
        Dim rep = (From it In MaBd.tblFourniture
                   Select it.DescFourniture)
        'Remplie la listview 
        For Each row In rep.ToList
            LocEqui_ListBoxInventaire.Items.Add(row)
        Next
        'Pour rechercher les objets réserver
        Dim Rep2 = (From I In MaBd.tblFournitureReservationSalle
                    Where I.NoSeqReservSalle = noRes.NoSeqReservSalle
                    Select I.CodeFourniture, I.QuantiteFourniture)
        'Remplie liste d'objet déja réserver 
        For Each row In Rep2.ToList
            bool = True
            produit = New MyItem
            produit.Name = (From item In MaBd.tblFourniture
                                             Where item.CodeFourniture = row.CodeFourniture
                                            Select item.DescFourniture).Single
            produit.Nombre = row.CodeFourniture
            produit.Quantite = row.QuantiteFourniture
            For Each item In LocEqui_ListBoxReserv.Items
                checkup = New MyItem
                checkup = item
                If produit.Nombre = checkup.Nombre Then
                    bool = False
                End If
            Next
            If (bool) Then
                LocEqui_ListBoxReserv.Items.Add(produit)
            End If
        Next

    End Sub

    Public Class MyItem
        Public Property Nombre() As String
            Get
                Return m_Nombre
            End Get
            Set(value As String)
                m_Nombre = value
            End Set
        End Property
        Private m_Nombre As String
        Public Property Name() As String
            Get
                Return m_Name
            End Get
            Set(value As String)
                m_Name = value
            End Set
        End Property
        Private m_Name As String
        Public Property Quantite() As String
            Get
                Return m_Quantite
            End Get
            Set(value As String)
                m_Quantite = value
            End Set
        End Property
        Private m_Quantite As String
    End Class

    Private Sub LocEqui_BtnValider_Click(sender As Object, e As RoutedEventArgs) Handles LocEqui_BtnValider.Click
        MaBd.SaveChanges()
    End Sub
End Class
