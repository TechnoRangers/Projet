Public Class Dossier
    Inherits System.Web.UI.Page

    Dim BD As New P2014_BD_GestionHotelEntities

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim PremiereConnexion = From t1 In BD.tblEmploye
                                Where t1.IdentifiantEmploye = Context.User.Identity.Name
                                Select t1.DatePremierCo

        If PremiereConnexion.First.ToString = "" Then

            Response.Write("<script>window.open('FirstConnect.aspx', 'Connexion', 'width=320,height=300,left=600,top=300,scrollbars=0');</script>")
            Dim update = (From t1 In BD.tblEmploye Where t1.IdentifiantEmploye = Context.User.Identity.Name Select t1)

            update.First().DatePremierCo = Date.Today

            Try
                BD.SaveChanges()
            Catch ex As Exception
                Response.Write("<script LANGUAGE='JavaScript' >alert('Erreur')</script>")
            End Try


            If Not IsPostBack Then

                Dim res = From t1 In BD.tblEmploye
                          Where t1.IdentifiantEmploye = Context.User.Identity.Name
                          Select t1.NoEmploye

                Dim res2 = From t1 In BD.tblEmploye
                          Where t1.IdentifiantEmploye = Context.User.Identity.Name
                        Select t1.NomEmploye

                Dim res3 = From t1 In BD.tblEmploye
                          Where t1.IdentifiantEmploye = Context.User.Identity.Name
                        Select t1.PrenomEmploye

                Dim res4 = From t1 In BD.tblEmploye
                          Where t1.IdentifiantEmploye = Context.User.Identity.Name
                        Select t1.SexeEmploye

                Dim res5 = From t1 In BD.tblEmploye
                         Where t1.IdentifiantEmploye = Context.User.Identity.Name
                       Select t1.DateNaissance

                Dim res6 = From t1 In BD.tblEmploye
                         Where t1.IdentifiantEmploye = Context.User.Identity.Name
                       Select t1.AdresseEmploye

                Dim res7 = From t1 In BD.tblEmploye
                         Where t1.IdentifiantEmploye = Context.User.Identity.Name
                       Select t1.NoTelephoneEmploye

                Dim res8 = From t1 In BD.tblEmploye
                         Where t1.IdentifiantEmploye = Context.User.Identity.Name
                       Select t1.NasEmploye

                Dim res9 = From t1 In BD.tblEmploye
                         Where t1.IdentifiantEmploye = Context.User.Identity.Name
                       Select t1.TypeEmploi

                TextBox1.Text = res.First.ToString
                TextBox2.Text = res2.First.ToString
                TextBox3.Text = res3.First.ToString
                TextBox4.Text = res4.First.ToString
                TextBox5.Text = res5.First.ToString
                TextBox6.Text = res6.First.ToString
                TextBox7.Text = res7.First.ToString
                TextBox8.Text = res8.First.ToString
                TextBox9.Text = res9.First.ToString

                TextBox1.Enabled = False
                TextBox2.Enabled = False
                TextBox3.Enabled = False
                TextBox4.Enabled = False
                TextBox5.Enabled = False
                TextBox8.Enabled = False
                TextBox9.Enabled = False

                LblID.Text = Context.User.Identity.Name

                Dim res10 = From t1 In BD.tblEmploye
                            Where t1.IdentifiantEmploye = Context.User.Identity.Name
                            Select t1.MdpEmploye

                LblMDP.Text = res10.First.ToString
            End If
        Else

            If Not IsPostBack Then

                Dim res = From t1 In BD.tblEmploye
                          Where t1.IdentifiantEmploye = Context.User.Identity.Name
                          Select t1.NoEmploye

                Dim res2 = From t1 In BD.tblEmploye
                          Where t1.IdentifiantEmploye = Context.User.Identity.Name
                        Select t1.NomEmploye

                Dim res3 = From t1 In BD.tblEmploye
                          Where t1.IdentifiantEmploye = Context.User.Identity.Name
                        Select t1.PrenomEmploye

                Dim res4 = From t1 In BD.tblEmploye
                          Where t1.IdentifiantEmploye = Context.User.Identity.Name
                        Select t1.SexeEmploye

                Dim res5 = From t1 In BD.tblEmploye
                         Where t1.IdentifiantEmploye = Context.User.Identity.Name
                       Select t1.DateNaissance

                Dim res6 = From t1 In BD.tblEmploye
                         Where t1.IdentifiantEmploye = Context.User.Identity.Name
                       Select t1.AdresseEmploye

                Dim res7 = From t1 In BD.tblEmploye
                         Where t1.IdentifiantEmploye = Context.User.Identity.Name
                       Select t1.NoTelephoneEmploye

                Dim res8 = From t1 In BD.tblEmploye
                         Where t1.IdentifiantEmploye = Context.User.Identity.Name
                       Select t1.NasEmploye

                Dim res9 = From t1 In BD.tblEmploye
                         Where t1.IdentifiantEmploye = Context.User.Identity.Name
                       Select t1.TypeEmploi

                TextBox1.Text = res.First.ToString
                TextBox2.Text = res2.First.ToString
                TextBox3.Text = res3.First.ToString
                TextBox4.Text = res4.First.ToString
                TextBox5.Text = res5.First.ToString
                TextBox6.Text = res6.First.ToString
                TextBox7.Text = res7.First.ToString
                TextBox8.Text = res8.First.ToString
                TextBox9.Text = res9.First.ToString

                TextBox1.Enabled = False
                TextBox2.Enabled = False
                TextBox3.Enabled = False
                TextBox4.Enabled = False
                TextBox5.Enabled = False
                TextBox8.Enabled = False
                TextBox9.Enabled = False

                LblID.Text = Context.User.Identity.Name

                Dim res10 = From t1 In BD.tblEmploye
                            Where t1.IdentifiantEmploye = Context.User.Identity.Name
                            Select t1.MdpEmploye

                LblMDP.Text = res10.First.ToString
            End If
        End If

    End Sub

    Protected Sub Calendar1_SelectionChanged(sender As Object, e As EventArgs) Handles Calendar1.SelectionChanged

        Dim dateSelection As String

        dateSelection = Calendar1.SelectedDate

        Dim res = From t1 In BD.tblChiffreTravail Join t2 In BD.tblEmploye On t1.NoEmploye Equals t2.NoEmploye
                  Where t2.IdentifiantEmploye = Context.User.Identity.Name And t1.DateChiffre = dateSelection
                  Select t1.HeureDebut

        If res.ToList.Count <> 0 Then
            lblDateChiffre.Text = dateSelection.ToString
            LblHeureDebut.Text = res.First.ToString

            Dim res2 = From t1 In BD.tblChiffreTravail Join t2 In BD.tblEmploye On t1.NoEmploye Equals t2.NoEmploye
                     Where t2.IdentifiantEmploye = Context.User.Identity.Name And t1.DateChiffre = dateSelection
                     Select t1.HeureFin

            LblHeureFin.Text = res2.First.ToString

            Dim res3 = From t1 In BD.tblEmploye
                    Where t1.IdentifiantEmploye = Context.User.Identity.Name
                  Select t1.NombreHeuresSemaines

            LblHeureSemaine.Text = res3.First.ToString
        Else
            lblDateChiffre.Text = ""
            LblHeureDebut.Text = ""
            LblHeureFin.Text = ""
            LblHeureSemaine.Text = ""
        End If


    End Sub

 
    Protected Sub Btn_EnregistrerModif_Click(sender As Object, e As EventArgs) Handles Btn_EnregistrerModif.Click

        Dim update = (From t1 In BD.tblEmploye Where t1.IdentifiantEmploye = Context.User.Identity.Name Select t1)

        update.First().AdresseEmploye = TextBox6.Text
        update.First().NoTelephoneEmploye = TextBox7.Text

        Try
            BD.SaveChanges()
            Response.Write("<script LANGUAGE='JavaScript' >alert('Modification réussie')</script>")
        Catch ex As Exception
            Response.Write("<script LANGUAGE='JavaScript' >alert('Erreur')</script>")
        End Try
        '  RaisePostBackEvent(Btn_EnregistrerModif, "")
    End Sub


End Class