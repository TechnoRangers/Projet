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


Partial Public Class ReservationForfait

    '''<summary>
    '''Contr�le MessagePlaceHolder.
    '''</summary>
    '''<remarks>
    '''Champ g�n�r� automatiquement.
    '''Pour modifier, d�placez la d�claration de champ du fichier de concepteur dans le fichier code-behind.
    '''</remarks>
    Protected WithEvents MessagePlaceHolder As Global.System.Web.UI.WebControls.PlaceHolder

    '''<summary>
    '''Contr�le MonLabel1.
    '''</summary>
    '''<remarks>
    '''Champ g�n�r� automatiquement.
    '''Pour modifier, d�placez la d�claration de champ du fichier de concepteur dans le fichier code-behind.
    '''</remarks>
    Protected WithEvents MonLabel1 As Global.System.Web.UI.WebControls.Label

    '''<summary>
    '''Contr�le lblDateDebut.
    '''</summary>
    '''<remarks>
    '''Champ g�n�r� automatiquement.
    '''Pour modifier, d�placez la d�claration de champ du fichier de concepteur dans le fichier code-behind.
    '''</remarks>
    Protected WithEvents lblDateDebut As Global.System.Web.UI.WebControls.Label

    '''<summary>
    '''Contr�le MonLabel2.
    '''</summary>
    '''<remarks>
    '''Champ g�n�r� automatiquement.
    '''Pour modifier, d�placez la d�claration de champ du fichier de concepteur dans le fichier code-behind.
    '''</remarks>
    Protected WithEvents MonLabel2 As Global.System.Web.UI.WebControls.Label

    '''<summary>
    '''Contr�le lblDateFin.
    '''</summary>
    '''<remarks>
    '''Champ g�n�r� automatiquement.
    '''Pour modifier, d�placez la d�claration de champ du fichier de concepteur dans le fichier code-behind.
    '''</remarks>
    Protected WithEvents lblDateFin As Global.System.Web.UI.WebControls.Label

    '''<summary>
    '''Contr�le MonLabel3.
    '''</summary>
    '''<remarks>
    '''Champ g�n�r� automatiquement.
    '''Pour modifier, d�placez la d�claration de champ du fichier de concepteur dans le fichier code-behind.
    '''</remarks>
    Protected WithEvents MonLabel3 As Global.System.Web.UI.WebControls.Label

    '''<summary>
    '''Contr�le lblNomReserv.
    '''</summary>
    '''<remarks>
    '''Champ g�n�r� automatiquement.
    '''Pour modifier, d�placez la d�claration de champ du fichier de concepteur dans le fichier code-behind.
    '''</remarks>
    Protected WithEvents lblNomReserv As Global.System.Web.UI.WebControls.Label

    '''<summary>
    '''Contr�le MonLabel4.
    '''</summary>
    '''<remarks>
    '''Champ g�n�r� automatiquement.
    '''Pour modifier, d�placez la d�claration de champ du fichier de concepteur dans le fichier code-behind.
    '''</remarks>
    Protected WithEvents MonLabel4 As Global.System.Web.UI.WebControls.Label

    '''<summary>
    '''Contr�le lblPrixTotal.
    '''</summary>
    '''<remarks>
    '''Champ g�n�r� automatiquement.
    '''Pour modifier, d�placez la d�claration de champ du fichier de concepteur dans le fichier code-behind.
    '''</remarks>
    Protected WithEvents lblPrixTotal As Global.System.Web.UI.WebControls.Label

    '''<summary>
    '''Contr�le MonLabel5.
    '''</summary>
    '''<remarks>
    '''Champ g�n�r� automatiquement.
    '''Pour modifier, d�placez la d�claration de champ du fichier de concepteur dans le fichier code-behind.
    '''</remarks>
    Protected WithEvents MonLabel5 As Global.System.Web.UI.WebControls.Label

    '''<summary>
    '''Contr�le lblTypeCarte.
    '''</summary>
    '''<remarks>
    '''Champ g�n�r� automatiquement.
    '''Pour modifier, d�placez la d�claration de champ du fichier de concepteur dans le fichier code-behind.
    '''</remarks>
    Protected WithEvents lblTypeCarte As Global.System.Web.UI.WebControls.Label

    '''<summary>
    '''Contr�le MonLabel6.
    '''</summary>
    '''<remarks>
    '''Champ g�n�r� automatiquement.
    '''Pour modifier, d�placez la d�claration de champ du fichier de concepteur dans le fichier code-behind.
    '''</remarks>
    Protected WithEvents MonLabel6 As Global.System.Web.UI.WebControls.Label

    '''<summary>
    '''Contr�le lblNoCarte.
    '''</summary>
    '''<remarks>
    '''Champ g�n�r� automatiquement.
    '''Pour modifier, d�placez la d�claration de champ du fichier de concepteur dans le fichier code-behind.
    '''</remarks>
    Protected WithEvents lblNoCarte As Global.System.Web.UI.WebControls.Label

    '''<summary>
    '''Contr�le btnAnnuler.
    '''</summary>
    '''<remarks>
    '''Champ g�n�r� automatiquement.
    '''Pour modifier, d�placez la d�claration de champ du fichier de concepteur dans le fichier code-behind.
    '''</remarks>
    Protected WithEvents btnAnnuler As Global.System.Web.UI.WebControls.Button

    '''<summary>
    '''Contr�le btnConfirmer.
    '''</summary>
    '''<remarks>
    '''Champ g�n�r� automatiquement.
    '''Pour modifier, d�placez la d�claration de champ du fichier de concepteur dans le fichier code-behind.
    '''</remarks>
    Protected WithEvents btnConfirmer As Global.System.Web.UI.WebControls.Button

    '''<summary>
    '''Contr�le LabelNomForfait.
    '''</summary>
    '''<remarks>
    '''Champ g�n�r� automatiquement.
    '''Pour modifier, d�placez la d�claration de champ du fichier de concepteur dans le fichier code-behind.
    '''</remarks>
    Protected WithEvents LabelNomForfait As Global.System.Web.UI.WebControls.Label

    '''<summary>
    '''Contr�le ImageForfait.
    '''</summary>
    '''<remarks>
    '''Champ g�n�r� automatiquement.
    '''Pour modifier, d�placez la d�claration de champ du fichier de concepteur dans le fichier code-behind.
    '''</remarks>
    Protected WithEvents ImageForfait As Global.System.Web.UI.WebControls.Image

    '''<summary>
    '''Contr�le LabelTypeChambre.
    '''</summary>
    '''<remarks>
    '''Champ g�n�r� automatiquement.
    '''Pour modifier, d�placez la d�claration de champ du fichier de concepteur dans le fichier code-behind.
    '''</remarks>
    Protected WithEvents LabelTypeChambre As Global.System.Web.UI.WebControls.Label

    '''<summary>
    '''Contr�le LabelPrixForfait.
    '''</summary>
    '''<remarks>
    '''Champ g�n�r� automatiquement.
    '''Pour modifier, d�placez la d�claration de champ du fichier de concepteur dans le fichier code-behind.
    '''</remarks>
    Protected WithEvents LabelPrixForfait As Global.System.Web.UI.WebControls.Label

    '''<summary>
    '''Contr�le LabelNbNuit.
    '''</summary>
    '''<remarks>
    '''Champ g�n�r� automatiquement.
    '''Pour modifier, d�placez la d�claration de champ du fichier de concepteur dans le fichier code-behind.
    '''</remarks>
    Protected WithEvents LabelNbNuit As Global.System.Web.UI.WebControls.Label

    '''<summary>
    '''Contr�le LabelDescription.
    '''</summary>
    '''<remarks>
    '''Champ g�n�r� automatiquement.
    '''Pour modifier, d�placez la d�claration de champ du fichier de concepteur dans le fichier code-behind.
    '''</remarks>
    Protected WithEvents LabelDescription As Global.System.Web.UI.WebControls.Label

    '''<summary>
    '''Contr�le MonPanelClient.
    '''</summary>
    '''<remarks>
    '''Champ g�n�r� automatiquement.
    '''Pour modifier, d�placez la d�claration de champ du fichier de concepteur dans le fichier code-behind.
    '''</remarks>
    Protected WithEvents MonPanelClient As Global.System.Web.UI.WebControls.Panel

    '''<summary>
    '''Contr�le MonPlaceHolder.
    '''</summary>
    '''<remarks>
    '''Champ g�n�r� automatiquement.
    '''Pour modifier, d�placez la d�claration de champ du fichier de concepteur dans le fichier code-behind.
    '''</remarks>
    Protected WithEvents MonPlaceHolder As Global.System.Web.UI.WebControls.PlaceHolder

    '''<summary>
    '''Contr�le Label5.
    '''</summary>
    '''<remarks>
    '''Champ g�n�r� automatiquement.
    '''Pour modifier, d�placez la d�claration de champ du fichier de concepteur dans le fichier code-behind.
    '''</remarks>
    Protected WithEvents Label5 As Global.System.Web.UI.WebControls.Label

    '''<summary>
    '''Contr�le txtNom.
    '''</summary>
    '''<remarks>
    '''Champ g�n�r� automatiquement.
    '''Pour modifier, d�placez la d�claration de champ du fichier de concepteur dans le fichier code-behind.
    '''</remarks>
    Protected WithEvents txtNom As Global.System.Web.UI.WebControls.TextBox

    '''<summary>
    '''Contr�le Label6.
    '''</summary>
    '''<remarks>
    '''Champ g�n�r� automatiquement.
    '''Pour modifier, d�placez la d�claration de champ du fichier de concepteur dans le fichier code-behind.
    '''</remarks>
    Protected WithEvents Label6 As Global.System.Web.UI.WebControls.Label

    '''<summary>
    '''Contr�le txtPrenom.
    '''</summary>
    '''<remarks>
    '''Champ g�n�r� automatiquement.
    '''Pour modifier, d�placez la d�claration de champ du fichier de concepteur dans le fichier code-behind.
    '''</remarks>
    Protected WithEvents txtPrenom As Global.System.Web.UI.WebControls.TextBox

    '''<summary>
    '''Contr�le Label7.
    '''</summary>
    '''<remarks>
    '''Champ g�n�r� automatiquement.
    '''Pour modifier, d�placez la d�claration de champ du fichier de concepteur dans le fichier code-behind.
    '''</remarks>
    Protected WithEvents Label7 As Global.System.Web.UI.WebControls.Label

    '''<summary>
    '''Contr�le txtNoTelephone.
    '''</summary>
    '''<remarks>
    '''Champ g�n�r� automatiquement.
    '''Pour modifier, d�placez la d�claration de champ du fichier de concepteur dans le fichier code-behind.
    '''</remarks>
    Protected WithEvents txtNoTelephone As Global.System.Web.UI.WebControls.TextBox

    '''<summary>
    '''Contr�le Label8.
    '''</summary>
    '''<remarks>
    '''Champ g�n�r� automatiquement.
    '''Pour modifier, d�placez la d�claration de champ du fichier de concepteur dans le fichier code-behind.
    '''</remarks>
    Protected WithEvents Label8 As Global.System.Web.UI.WebControls.Label

    '''<summary>
    '''Contr�le txtEmail.
    '''</summary>
    '''<remarks>
    '''Champ g�n�r� automatiquement.
    '''Pour modifier, d�placez la d�claration de champ du fichier de concepteur dans le fichier code-behind.
    '''</remarks>
    Protected WithEvents txtEmail As Global.System.Web.UI.WebControls.TextBox

    '''<summary>
    '''Contr�le Label9.
    '''</summary>
    '''<remarks>
    '''Champ g�n�r� automatiquement.
    '''Pour modifier, d�placez la d�claration de champ du fichier de concepteur dans le fichier code-behind.
    '''</remarks>
    Protected WithEvents Label9 As Global.System.Web.UI.WebControls.Label

    '''<summary>
    '''Contr�le txtAdresse.
    '''</summary>
    '''<remarks>
    '''Champ g�n�r� automatiquement.
    '''Pour modifier, d�placez la d�claration de champ du fichier de concepteur dans le fichier code-behind.
    '''</remarks>
    Protected WithEvents txtAdresse As Global.System.Web.UI.WebControls.TextBox

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
    '''Contr�le InforReserv.
    '''</summary>
    '''<remarks>
    '''Champ g�n�r� automatiquement.
    '''Pour modifier, d�placez la d�claration de champ du fichier de concepteur dans le fichier code-behind.
    '''</remarks>
    Protected WithEvents InforReserv As Global.System.Web.UI.WebControls.PlaceHolder

    '''<summary>
    '''Contr�le UpdatePanel1.
    '''</summary>
    '''<remarks>
    '''Champ g�n�r� automatiquement.
    '''Pour modifier, d�placez la d�claration de champ du fichier de concepteur dans le fichier code-behind.
    '''</remarks>
    Protected WithEvents UpdatePanel1 As Global.System.Web.UI.UpdatePanel

    '''<summary>
    '''Contr�le txtDateDebut.
    '''</summary>
    '''<remarks>
    '''Champ g�n�r� automatiquement.
    '''Pour modifier, d�placez la d�claration de champ du fichier de concepteur dans le fichier code-behind.
    '''</remarks>
    Protected WithEvents txtDateDebut As Global.System.Web.UI.WebControls.TextBox

    '''<summary>
    '''Contr�le btnExpandCalendarDebut.
    '''</summary>
    '''<remarks>
    '''Champ g�n�r� automatiquement.
    '''Pour modifier, d�placez la d�claration de champ du fichier de concepteur dans le fichier code-behind.
    '''</remarks>
    Protected WithEvents btnExpandCalendarDebut As Global.System.Web.UI.WebControls.Button

    '''<summary>
    '''Contr�le CalendrierDebut.
    '''</summary>
    '''<remarks>
    '''Champ g�n�r� automatiquement.
    '''Pour modifier, d�placez la d�claration de champ du fichier de concepteur dans le fichier code-behind.
    '''</remarks>
    Protected WithEvents CalendrierDebut As Global.System.Web.UI.WebControls.Calendar

    '''<summary>
    '''Contr�le UpdatePanel2.
    '''</summary>
    '''<remarks>
    '''Champ g�n�r� automatiquement.
    '''Pour modifier, d�placez la d�claration de champ du fichier de concepteur dans le fichier code-behind.
    '''</remarks>
    Protected WithEvents UpdatePanel2 As Global.System.Web.UI.UpdatePanel

    '''<summary>
    '''Contr�le txtDateFin.
    '''</summary>
    '''<remarks>
    '''Champ g�n�r� automatiquement.
    '''Pour modifier, d�placez la d�claration de champ du fichier de concepteur dans le fichier code-behind.
    '''</remarks>
    Protected WithEvents txtDateFin As Global.System.Web.UI.WebControls.TextBox

    '''<summary>
    '''Contr�le btnExpandCalendarFin.
    '''</summary>
    '''<remarks>
    '''Champ g�n�r� automatiquement.
    '''Pour modifier, d�placez la d�claration de champ du fichier de concepteur dans le fichier code-behind.
    '''</remarks>
    Protected WithEvents btnExpandCalendarFin As Global.System.Web.UI.WebControls.Button

    '''<summary>
    '''Contr�le CalendrierFin.
    '''</summary>
    '''<remarks>
    '''Champ g�n�r� automatiquement.
    '''Pour modifier, d�placez la d�claration de champ du fichier de concepteur dans le fichier code-behind.
    '''</remarks>
    Protected WithEvents CalendrierFin As Global.System.Web.UI.WebControls.Calendar

    '''<summary>
    '''Contr�le cmbHotel.
    '''</summary>
    '''<remarks>
    '''Champ g�n�r� automatiquement.
    '''Pour modifier, d�placez la d�claration de champ du fichier de concepteur dans le fichier code-behind.
    '''</remarks>
    Protected WithEvents cmbHotel As Global.System.Web.UI.WebControls.DropDownList

    '''<summary>
    '''Contr�le Label1.
    '''</summary>
    '''<remarks>
    '''Champ g�n�r� automatiquement.
    '''Pour modifier, d�placez la d�claration de champ du fichier de concepteur dans le fichier code-behind.
    '''</remarks>
    Protected WithEvents Label1 As Global.System.Web.UI.WebControls.Label

    '''<summary>
    '''Contr�le cmbTypeCarte.
    '''</summary>
    '''<remarks>
    '''Champ g�n�r� automatiquement.
    '''Pour modifier, d�placez la d�claration de champ du fichier de concepteur dans le fichier code-behind.
    '''</remarks>
    Protected WithEvents cmbTypeCarte As Global.System.Web.UI.WebControls.DropDownList

    '''<summary>
    '''Contr�le Label2.
    '''</summary>
    '''<remarks>
    '''Champ g�n�r� automatiquement.
    '''Pour modifier, d�placez la d�claration de champ du fichier de concepteur dans le fichier code-behind.
    '''</remarks>
    Protected WithEvents Label2 As Global.System.Web.UI.WebControls.Label

    '''<summary>
    '''Contr�le txtNoCarteCredit.
    '''</summary>
    '''<remarks>
    '''Champ g�n�r� automatiquement.
    '''Pour modifier, d�placez la d�claration de champ du fichier de concepteur dans le fichier code-behind.
    '''</remarks>
    Protected WithEvents txtNoCarteCredit As Global.System.Web.UI.WebControls.TextBox

    '''<summary>
    '''Contr�le Label3.
    '''</summary>
    '''<remarks>
    '''Champ g�n�r� automatiquement.
    '''Pour modifier, d�placez la d�claration de champ du fichier de concepteur dans le fichier code-behind.
    '''</remarks>
    Protected WithEvents Label3 As Global.System.Web.UI.WebControls.Label

    '''<summary>
    '''Contr�le txtDateExpiration.
    '''</summary>
    '''<remarks>
    '''Champ g�n�r� automatiquement.
    '''Pour modifier, d�placez la d�claration de champ du fichier de concepteur dans le fichier code-behind.
    '''</remarks>
    Protected WithEvents txtDateExpiration As Global.System.Web.UI.WebControls.TextBox

    '''<summary>
    '''Contr�le Label4.
    '''</summary>
    '''<remarks>
    '''Champ g�n�r� automatiquement.
    '''Pour modifier, d�placez la d�claration de champ du fichier de concepteur dans le fichier code-behind.
    '''</remarks>
    Protected WithEvents Label4 As Global.System.Web.UI.WebControls.Label

    '''<summary>
    '''Contr�le txtNomDetenteurCarte.
    '''</summary>
    '''<remarks>
    '''Champ g�n�r� automatiquement.
    '''Pour modifier, d�placez la d�claration de champ du fichier de concepteur dans le fichier code-behind.
    '''</remarks>
    Protected WithEvents txtNomDetenteurCarte As Global.System.Web.UI.WebControls.TextBox

    '''<summary>
    '''Contr�le btnCalculer.
    '''</summary>
    '''<remarks>
    '''Champ g�n�r� automatiquement.
    '''Pour modifier, d�placez la d�claration de champ du fichier de concepteur dans le fichier code-behind.
    '''</remarks>
    Protected WithEvents btnCalculer As Global.System.Web.UI.WebControls.Button
End Class
