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


Partial Public Class Manage

    '''<summary>
    '''Contr�le SuccessMessagePlaceHolder.
    '''</summary>
    '''<remarks>
    '''Champ g�n�r� automatiquement.
    '''Pour modifier, d�placez la d�claration de champ du fichier de concepteur dans le fichier code-behind.
    '''</remarks>
    Protected WithEvents SuccessMessagePlaceHolder As Global.System.Web.UI.WebControls.PlaceHolder

    '''<summary>
    '''Contr�le modifInfo.
    '''</summary>
    '''<remarks>
    '''Champ g�n�r� automatiquement.
    '''Pour modifier, d�placez la d�claration de champ du fichier de concepteur dans le fichier code-behind.
    '''</remarks>
    Protected WithEvents modifInfo As Global.System.Web.UI.WebControls.PlaceHolder

    '''<summary>
    '''Contr�le Label1.
    '''</summary>
    '''<remarks>
    '''Champ g�n�r� automatiquement.
    '''Pour modifier, d�placez la d�claration de champ du fichier de concepteur dans le fichier code-behind.
    '''</remarks>
    Protected WithEvents Label1 As Global.System.Web.UI.WebControls.Label

    '''<summary>
    '''Contr�le txtNom.
    '''</summary>
    '''<remarks>
    '''Champ g�n�r� automatiquement.
    '''Pour modifier, d�placez la d�claration de champ du fichier de concepteur dans le fichier code-behind.
    '''</remarks>
    Protected WithEvents txtNom As Global.System.Web.UI.WebControls.TextBox

    '''<summary>
    '''Contr�le Label2.
    '''</summary>
    '''<remarks>
    '''Champ g�n�r� automatiquement.
    '''Pour modifier, d�placez la d�claration de champ du fichier de concepteur dans le fichier code-behind.
    '''</remarks>
    Protected WithEvents Label2 As Global.System.Web.UI.WebControls.Label

    '''<summary>
    '''Contr�le txtPrenom.
    '''</summary>
    '''<remarks>
    '''Champ g�n�r� automatiquement.
    '''Pour modifier, d�placez la d�claration de champ du fichier de concepteur dans le fichier code-behind.
    '''</remarks>
    Protected WithEvents txtPrenom As Global.System.Web.UI.WebControls.TextBox

    '''<summary>
    '''Contr�le Label3.
    '''</summary>
    '''<remarks>
    '''Champ g�n�r� automatiquement.
    '''Pour modifier, d�placez la d�claration de champ du fichier de concepteur dans le fichier code-behind.
    '''</remarks>
    Protected WithEvents Label3 As Global.System.Web.UI.WebControls.Label

    '''<summary>
    '''Contr�le txtNoTelephone.
    '''</summary>
    '''<remarks>
    '''Champ g�n�r� automatiquement.
    '''Pour modifier, d�placez la d�claration de champ du fichier de concepteur dans le fichier code-behind.
    '''</remarks>
    Protected WithEvents txtNoTelephone As Global.System.Web.UI.WebControls.TextBox

    '''<summary>
    '''Contr�le Label4.
    '''</summary>
    '''<remarks>
    '''Champ g�n�r� automatiquement.
    '''Pour modifier, d�placez la d�claration de champ du fichier de concepteur dans le fichier code-behind.
    '''</remarks>
    Protected WithEvents Label4 As Global.System.Web.UI.WebControls.Label

    '''<summary>
    '''Contr�le txtCellulaire.
    '''</summary>
    '''<remarks>
    '''Champ g�n�r� automatiquement.
    '''Pour modifier, d�placez la d�claration de champ du fichier de concepteur dans le fichier code-behind.
    '''</remarks>
    Protected WithEvents txtCellulaire As Global.System.Web.UI.WebControls.TextBox

    '''<summary>
    '''Contr�le Label5.
    '''</summary>
    '''<remarks>
    '''Champ g�n�r� automatiquement.
    '''Pour modifier, d�placez la d�claration de champ du fichier de concepteur dans le fichier code-behind.
    '''</remarks>
    Protected WithEvents Label5 As Global.System.Web.UI.WebControls.Label

    '''<summary>
    '''Contr�le txtAdresse1.
    '''</summary>
    '''<remarks>
    '''Champ g�n�r� automatiquement.
    '''Pour modifier, d�placez la d�claration de champ du fichier de concepteur dans le fichier code-behind.
    '''</remarks>
    Protected WithEvents txtAdresse1 As Global.System.Web.UI.WebControls.TextBox

    '''<summary>
    '''Contr�le Label6.
    '''</summary>
    '''<remarks>
    '''Champ g�n�r� automatiquement.
    '''Pour modifier, d�placez la d�claration de champ du fichier de concepteur dans le fichier code-behind.
    '''</remarks>
    Protected WithEvents Label6 As Global.System.Web.UI.WebControls.Label

    '''<summary>
    '''Contr�le txtAdresse2.
    '''</summary>
    '''<remarks>
    '''Champ g�n�r� automatiquement.
    '''Pour modifier, d�placez la d�claration de champ du fichier de concepteur dans le fichier code-behind.
    '''</remarks>
    Protected WithEvents txtAdresse2 As Global.System.Web.UI.WebControls.TextBox

    '''<summary>
    '''Contr�le Label7.
    '''</summary>
    '''<remarks>
    '''Champ g�n�r� automatiquement.
    '''Pour modifier, d�placez la d�claration de champ du fichier de concepteur dans le fichier code-behind.
    '''</remarks>
    Protected WithEvents Label7 As Global.System.Web.UI.WebControls.Label

    '''<summary>
    '''Contr�le txtEmail.
    '''</summary>
    '''<remarks>
    '''Champ g�n�r� automatiquement.
    '''Pour modifier, d�placez la d�claration de champ du fichier de concepteur dans le fichier code-behind.
    '''</remarks>
    Protected WithEvents txtEmail As Global.System.Web.UI.WebControls.TextBox

    '''<summary>
    '''Contr�le btnModifInfos.
    '''</summary>
    '''<remarks>
    '''Champ g�n�r� automatiquement.
    '''Pour modifier, d�placez la d�claration de champ du fichier de concepteur dans le fichier code-behind.
    '''</remarks>
    Protected WithEvents btnModifInfos As Global.System.Web.UI.WebControls.Button

    '''<summary>
    '''Contr�le setPassword.
    '''</summary>
    '''<remarks>
    '''Champ g�n�r� automatiquement.
    '''Pour modifier, d�placez la d�claration de champ du fichier de concepteur dans le fichier code-behind.
    '''</remarks>
    Protected WithEvents setPassword As Global.System.Web.UI.WebControls.PlaceHolder

    '''<summary>
    '''Contr�le password.
    '''</summary>
    '''<remarks>
    '''Champ g�n�r� automatiquement.
    '''Pour modifier, d�placez la d�claration de champ du fichier de concepteur dans le fichier code-behind.
    '''</remarks>
    Protected WithEvents password As Global.System.Web.UI.WebControls.TextBox

    '''<summary>
    '''Contr�le confirmPassword.
    '''</summary>
    '''<remarks>
    '''Champ g�n�r� automatiquement.
    '''Pour modifier, d�placez la d�claration de champ du fichier de concepteur dans le fichier code-behind.
    '''</remarks>
    Protected WithEvents confirmPassword As Global.System.Web.UI.WebControls.TextBox

    '''<summary>
    '''Contr�le changePasswordHolder.
    '''</summary>
    '''<remarks>
    '''Champ g�n�r� automatiquement.
    '''Pour modifier, d�placez la d�claration de champ du fichier de concepteur dans le fichier code-behind.
    '''</remarks>
    Protected WithEvents changePasswordHolder As Global.System.Web.UI.WebControls.PlaceHolder

    '''<summary>
    '''Contr�le CurrentPasswordLabel.
    '''</summary>
    '''<remarks>
    '''Champ g�n�r� automatiquement.
    '''Pour modifier, d�placez la d�claration de champ du fichier de concepteur dans le fichier code-behind.
    '''</remarks>
    Protected WithEvents CurrentPasswordLabel As Global.System.Web.UI.WebControls.Label

    '''<summary>
    '''Contr�le CurrentPassword.
    '''</summary>
    '''<remarks>
    '''Champ g�n�r� automatiquement.
    '''Pour modifier, d�placez la d�claration de champ du fichier de concepteur dans le fichier code-behind.
    '''</remarks>
    Protected WithEvents CurrentPassword As Global.System.Web.UI.WebControls.TextBox

    '''<summary>
    '''Contr�le NewPasswordLabel.
    '''</summary>
    '''<remarks>
    '''Champ g�n�r� automatiquement.
    '''Pour modifier, d�placez la d�claration de champ du fichier de concepteur dans le fichier code-behind.
    '''</remarks>
    Protected WithEvents NewPasswordLabel As Global.System.Web.UI.WebControls.Label

    '''<summary>
    '''Contr�le NewPassword.
    '''</summary>
    '''<remarks>
    '''Champ g�n�r� automatiquement.
    '''Pour modifier, d�placez la d�claration de champ du fichier de concepteur dans le fichier code-behind.
    '''</remarks>
    Protected WithEvents NewPassword As Global.System.Web.UI.WebControls.TextBox

    '''<summary>
    '''Contr�le RegularExpressionValidator1.
    '''</summary>
    '''<remarks>
    '''Champ g�n�r� automatiquement.
    '''Pour modifier, d�placez la d�claration de champ du fichier de concepteur dans le fichier code-behind.
    '''</remarks>
    Protected WithEvents RegularExpressionValidator1 As Global.System.Web.UI.WebControls.RegularExpressionValidator

    '''<summary>
    '''Contr�le ConfirmNewPasswordLabel.
    '''</summary>
    '''<remarks>
    '''Champ g�n�r� automatiquement.
    '''Pour modifier, d�placez la d�claration de champ du fichier de concepteur dans le fichier code-behind.
    '''</remarks>
    Protected WithEvents ConfirmNewPasswordLabel As Global.System.Web.UI.WebControls.Label

    '''<summary>
    '''Contr�le ConfirmNewPassword.
    '''</summary>
    '''<remarks>
    '''Champ g�n�r� automatiquement.
    '''Pour modifier, d�placez la d�claration de champ du fichier de concepteur dans le fichier code-behind.
    '''</remarks>
    Protected WithEvents ConfirmNewPassword As Global.System.Web.UI.WebControls.TextBox
End Class
