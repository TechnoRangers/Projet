' ------------------------------------------------------------------------------------------- 
' Cr��e le : 10 novembre 2014
' Par : Fran�ois Morin
' Date de derni�re modification : 2014-12-15 08:33:05 
' -------------------------------------------------------------------------------------------

Imports System.Web.Optimization

Public Class Global_asax
    Inherits HttpApplication

    Sub Application_Start(sender As Object, e As EventArgs)
        ' Se d�clenche lorsque l'application est d�marr�e
        RouteConfig.RegisterRoutes(RouteTable.Routes)
        BundleConfig.RegisterBundles(BundleTable.Bundles)
    End Sub
End Class
