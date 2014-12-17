' ------------------------------------------------------------------------------------------- 
' Cr��e le : 10 novembre 2014
' Par : Fran�ois Morin
' Date de derni�re modification : 2014-12-15 08:33:05 
' -------------------------------------------------------------------------------------------

Imports System
Imports System.Web
Imports Microsoft.AspNet.Identity
Imports Microsoft.AspNet.Identity.EntityFramework
Imports Microsoft.AspNet.Identity.Owin
Imports Owin

Partial Public Class ForgotPassword
    Inherits System.Web.UI.Page

    Protected Property StatusMessage() As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    End Sub

    Protected Sub Forgot(sender As Object, e As EventArgs)
        If IsValid Then
            ' Valider le mot de passe de l'utilisateur
            Dim manager = Context.GetOwinContext().GetUserManager(Of ApplicationUserManager)()
            Dim user As ApplicationUser = manager.FindByName(Email.Text)
            If user Is Nothing OrElse Not manager.IsEmailConfirmed(user.Id) Then
                FailureText.Text = "L'utilisateur n'existe pas ou n'est pas confirm�."
                ErrorMessage.Visible = True
                Return
            End If
            ' Pour plus d'informations sur l'activation de la confirmation du compte et la r�initialisation du mot de passe, consultez  http://go.microsoft.com/fwlink/?LinkID=320771
            ' Envoyer le courrier �lectronique avec le code et la redirection pour r�initialiser la page du mot de passe
            ' Dim code = manager.GeneratePasswordResetToken(user.Id)
            ' Dim callbackUrl = IdentityHelper.GetResetPasswordRedirectUrl(code)
            ' manager.SendEmail(user.Id, "R�initialiser le mot de passe", "R�initialisez votre mot de passe en cliquant <a href=""" & callbackUrl & """>ici</a>.")
        End If
    End Sub
End Class
