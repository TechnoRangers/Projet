' ------------------------------------------------------------------------------------------- 
' Cr��e le : 10 novembre 2014
' Par : Fran�ois Morin
' Date de derni�re modification : 2014-12-15 08:33:05 
' -------------------------------------------------------------------------------------------

Public Class Site_Mobile
    Inherits System.Web.UI.MasterPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub Unnamed_LoggingOut(sender As Object, e As LoginCancelEventArgs)
        Context.GetOwinContext().Authentication.SignOut()
    End Sub
End Class
