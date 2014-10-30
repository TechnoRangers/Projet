Public Class ForfaitAppli

    Dim BD As P2014_BD_GestionHotelEntities

    Sub New(ByRef _BD As P2014_BD_GestionHotelEntities)
        InitializeComponent()
        BD = _BD
    End Sub
    Private Sub For_FrmFor_Loaded(sender As Object, e As RoutedEventArgs) Handles For_FrmFor.Loaded

        Dim Forfait = From el In BD.tblForfait
                      Select el

        For_dataGridForfait.ItemsSource = Forfait.ToList

    End Sub
End Class
