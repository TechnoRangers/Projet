' ------------------------------------------------------------------------------------------- 
' Cr��e le : 10 novembre 2014
' Par : Fran�ois Morin
' Date de derni�re modification : 2014-12-15 08:33:05 
' -------------------------------------------------------------------------------------------

Imports Microsoft.Owin
Imports Owin

<Assembly: OwinStartupAttribute(GetType(Startup))>

Partial Public Class Startup
    Public Sub Configuration(app As IAppBuilder)
        ConfigureAuth(app)
    End Sub
End Class
