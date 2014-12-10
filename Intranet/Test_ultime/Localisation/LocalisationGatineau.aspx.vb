Public Class LocalisationGatineau
    Inherits System.Web.UI.Page

    Dim BD As New P2014_BD_GestionHotelEntities
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim res1 = From t1 In BD.tblHotel
                  Where t1.CodeHotel = "NGN"
                  Select t1.AdresseHotel

        Dim res2 = From t1 In BD.tblHotel
                   Where t1.CodeHotel = "NGN"
                   Select t1.NoTelephoneHotel

        Dim res3 = From t1 In BD.tblHotel
                   Where t1.CodeHotel = "NGN"
                   Select t1.NoTelReservation

        Dim res4 = From t1 In BD.tblHotel
                   Where t1.CodeHotel = "NGN"
                   Select t1.NoTelecopieurHotel

        LblAdresse.Text = res1.First.ToString
        NoTelephone.Text = res2.First.ToString
        NoReservation.Text = res3.First.ToString
        NoTélécopieur.Text = res4.First.ToString

    End Sub

End Class