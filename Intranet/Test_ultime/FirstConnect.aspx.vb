Public Class FirstConnect
    Inherits System.Web.UI.Page

    Dim BD As New P2014_BD_GestionHotelEntities
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub btnEnregistrer_Click(sender As Object, e As EventArgs) Handles btnEnregistrer.Click

        If txtBoxId.Text = "" Or txtBoxMDP.Text = "" Then
            Response.Write("<script LANGUAGE='JavaScript' >alert('Erreur champ vide')</script>")
        Else
            Dim update = (From t1 In BD.tblEmploye Where t1.IdentifiantEmploye = Context.User.Identity.Name Select t1)

            update.First().IdentifiantEmploye = txtBoxId.Text
            update.First().MdpEmploye = txtBoxMDP.Text

            Try
                BD.SaveChanges()
                Response.Write("<script LANGUAGE='JavaScript' >alert('Modification réussie')</script>")
            Catch ex As Exception
                Response.Write("<script LANGUAGE='JavaScript' >alert('Erreur')</script>")
            End Try
            Response.Write("<body><script>opener=parent;parent.close();</script></body>")
        End If

    End Sub
End Class