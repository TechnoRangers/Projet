Imports System.Web
Imports System.Web.UI
Imports Microsoft.AspNet.Identity
Imports Microsoft.AspNet.Identity.EntityFramework
Imports Microsoft.AspNet.Identity.Owin
Imports Microsoft.Owin.Security
Imports Owin
Imports System.Configuration

Partial Public Class Login
    Inherits Page

    Dim BD As New P2014_BD_GestionHotelEntities
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        'RegisterHyperLink.NavigateUrl = "Register"
        ''Activez ceci une fois que vous avez activé la confirmation du compte pour la fonctionnalité de réinitialisation du mot de passe
        ''ForgotPasswordHyperLink.NavigateUrl = "Forgot"

        'Dim returnUrl = HttpUtility.UrlEncode(Request.QueryString("ReturnUrl"))
        'If Not [String].IsNullOrEmpty(returnUrl) Then
        '    RegisterHyperLink.NavigateUrl += "?ReturnUrl=" & returnUrl
        'End If

        Dim res1 = From t1 In BD.tblMessage
                  Select t1.NoSeq

        Dim Titre1 = From t1 In BD.tblMessage
                   Where t1.NoSeq = (res1.Count + 999)
                   Select t1.Titre

        Dim Date1 = From t1 In BD.tblMessage
                   Where t1.NoSeq = (res1.Count + 999)
                   Select t1.DateM

        Dim ContenuMessage1 = From t1 In BD.tblMessage
                   Where t1.NoSeq = (res1.Count + 999)
                   Select t1.MessageM

        TitreMessage1.Text = Titre1.First.ToString
        DateMessage1.Text = Date1.First.ToString
        Message1.Text = ContenuMessage1.First.ToString

        Dim Titre2 = From t1 In BD.tblMessage
                  Where t1.NoSeq = (res1.Count + 998)
                  Select t1.Titre

        Dim Date2 = From t1 In BD.tblMessage
                   Where t1.NoSeq = (res1.Count + 998)
                   Select t1.DateM

        Dim ContenuMessage2 = From t1 In BD.tblMessage
                   Where t1.NoSeq = (res1.Count + 998)
                   Select t1.MessageM

        TitreMessage2.Text = Titre2.First.ToString
        DateMessage2.Text = Date2.First.ToString
        Message2.Text = ContenuMessage2.First.ToString
        
    End Sub

    Protected Sub LogIn(sender As Object, e As EventArgs)

        If IsValid Then
            ' Valider le mot de passe de l'utilisateur
            Dim manager = Context.GetOwinContext().GetUserManager(Of ApplicationUserManager)()
            Dim user As ApplicationUser = manager.Find(Email.Text, Password.Text)
            If user IsNot Nothing Then
                IdentityHelper.SignIn(manager, user, False)
                IdentityHelper.RedirectToReturnUrl(Request.QueryString("ReturnUrl"), Response)
            Else
                FailureText.Text = "Nom d'utilisateur ou mot de passe incorrect."
                ErrorMessage.Visible = True
            End If
        End If
    End Sub
End Class
