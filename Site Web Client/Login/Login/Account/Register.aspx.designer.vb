' ------------------------------------------------------------------------------------------- 
' Cr��e le : 10 novembre 2014
' Par : Fran�ois Morin
' Date de derni�re modification : 2014-12-15 08:33:05 
' -------------------------------------------------------------------------------------------

'------------------------------------------------------------------------------
' <g�n�r� automatiquement>
'     Ce code a �t� g�n�r� par un outil.
'
'     Les modifications apport�es � ce fichier peuvent provoquer un comportement incorrect et seront perdues si
'     le code est r�g�n�r�.
' </g�n�r� automatiquement>
'------------------------------------------------------------------------------

Option Strict On
Option Explicit On


Partial Public Class Register

    '''<summary>
    '''Contr�le ErrorMessage.
    '''</summary>
    '''<remarks>
    '''Champ g�n�r� automatiquement.
    '''Pour modifier, d�placez la d�claration de champ du fichier de concepteur dans le fichier code-behind.
    '''</remarks>
    Protected WithEvents ErrorMessage As Global.System.Web.UI.WebControls.Literal

    '''<summary>
    '''Contr�le Email.
    '''</summary>
    '''<remarks>
    '''Champ g�n�r� automatiquement.
    '''Pour modifier, d�placez la d�claration de champ du fichier de concepteur dans le fichier code-behind.
    '''</remarks>
    Protected WithEvents Email As Global.System.Web.UI.WebControls.TextBox

    '''<summary>
    '''Contr�le Password.
    '''</summary>
    '''<remarks>
    '''Champ g�n�r� automatiquement.
    '''Pour modifier, d�placez la d�claration de champ du fichier de concepteur dans le fichier code-behind.
    '''</remarks>
    Protected WithEvents Password As Global.System.Web.UI.WebControls.TextBox

    '''<summary>
    '''Contr�le RegularExpressionValidator1.
    '''</summary>
    '''<remarks>
    '''Champ g�n�r� automatiquement.
    '''Pour modifier, d�placez la d�claration de champ du fichier de concepteur dans le fichier code-behind.
    '''</remarks>
    Protected WithEvents RegularExpressionValidator1 As Global.System.Web.UI.WebControls.RegularExpressionValidator

    '''<summary>
    '''Contr�le ConfirmPassword.
    '''</summary>
    '''<remarks>
    '''Champ g�n�r� automatiquement.
    '''Pour modifier, d�placez la d�claration de champ du fichier de concepteur dans le fichier code-behind.
    '''</remarks>
    Protected WithEvents ConfirmPassword As Global.System.Web.UI.WebControls.TextBox

    '''<summary>
    '''Contr�le txtNom.
    '''</summary>
    '''<remarks>
    '''Champ g�n�r� automatiquement.
    '''Pour modifier, d�placez la d�claration de champ du fichier de concepteur dans le fichier code-behind.
    '''</remarks>
    Protected WithEvents txtNom As Global.System.Web.UI.WebControls.TextBox

    '''<summary>
    '''Contr�le txtPrenom.
    '''</summary>
    '''<remarks>
    '''Champ g�n�r� automatiquement.
    '''Pour modifier, d�placez la d�claration de champ du fichier de concepteur dans le fichier code-behind.
    '''</remarks>
    Protected WithEvents txtPrenom As Global.System.Web.UI.WebControls.TextBox

    '''<summary>
    '''Contr�le txtNoTelephone.
    '''</summary>
    '''<remarks>
    '''Champ g�n�r� automatiquement.
    '''Pour modifier, d�placez la d�claration de champ du fichier de concepteur dans le fichier code-behind.
    '''</remarks>
    Protected WithEvents txtNoTelephone As Global.System.Web.UI.WebControls.TextBox

    '''<summary>
    '''Contr�le txtNoCellulaire.
    '''</summary>
    '''<remarks>
    '''Champ g�n�r� automatiquement.
    '''Pour modifier, d�placez la d�claration de champ du fichier de concepteur dans le fichier code-behind.
    '''</remarks>
    Protected WithEvents txtNoCellulaire As Global.System.Web.UI.WebControls.TextBox

    '''<summary>
    '''Contr�le cmbPays.
    '''</summary>
    '''<remarks>
    '''Champ g�n�r� automatiquement.
    '''Pour modifier, d�placez la d�claration de champ du fichier de concepteur dans le fichier code-behind.
    '''</remarks>
    Protected WithEvents cmbPays As Global.System.Web.UI.WebControls.DropDownList

    '''<summary>
    '''Contr�le cmbProvince.
    '''</summary>
    '''<remarks>
    '''Champ g�n�r� automatiquement.
    '''Pour modifier, d�placez la d�claration de champ du fichier de concepteur dans le fichier code-behind.
    '''</remarks>
    Protected WithEvents cmbProvince As Global.System.Web.UI.WebControls.DropDownList

    '''<summary>
    '''Contr�le cmbVille.
    '''</summary>
    '''<remarks>
    '''Champ g�n�r� automatiquement.
    '''Pour modifier, d�placez la d�claration de champ du fichier de concepteur dans le fichier code-behind.
    '''</remarks>
    Protected WithEvents cmbVille As Global.System.Web.UI.WebControls.DropDownList

    '''<summary>
    '''Contr�le txtAdresse1.
    '''</summary>
    '''<remarks>
    '''Champ g�n�r� automatiquement.
    '''Pour modifier, d�placez la d�claration de champ du fichier de concepteur dans le fichier code-behind.
    '''</remarks>
    Protected WithEvents txtAdresse1 As Global.System.Web.UI.WebControls.TextBox

    '''<summary>
    '''Contr�le txtAdresse2.
    '''</summary>
    '''<remarks>
    '''Champ g�n�r� automatiquement.
    '''Pour modifier, d�placez la d�claration de champ du fichier de concepteur dans le fichier code-behind.
    '''</remarks>
    Protected WithEvents txtAdresse2 As Global.System.Web.UI.WebControls.TextBox

    '''<summary>
    '''Contr�le txtCodePostal.
    '''</summary>
    '''<remarks>
    '''Champ g�n�r� automatiquement.
    '''Pour modifier, d�placez la d�claration de champ du fichier de concepteur dans le fichier code-behind.
    '''</remarks>
    Protected WithEvents txtCodePostal As Global.System.Web.UI.WebControls.TextBox

    '''<summary>
    '''Contr�le RegularExpressionValidator2.
    '''</summary>
    '''<remarks>
    '''Champ g�n�r� automatiquement.
    '''Pour modifier, d�placez la d�claration de champ du fichier de concepteur dans le fichier code-behind.
    '''</remarks>
    Protected WithEvents RegularExpressionValidator2 As Global.System.Web.UI.WebControls.RegularExpressionValidator

    '''<summary>
    '''Contr�le txtNomEntreprise.
    '''</summary>
    '''<remarks>
    '''Champ g�n�r� automatiquement.
    '''Pour modifier, d�placez la d�claration de champ du fichier de concepteur dans le fichier code-behind.
    '''</remarks>
    Protected WithEvents txtNomEntreprise As Global.System.Web.UI.WebControls.TextBox
End Class
