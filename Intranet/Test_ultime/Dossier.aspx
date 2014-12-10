<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Dossier.aspx.vb" Inherits="Test_ultime.Dossier" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
    <div class="dossier">
        <div class="BlocTitreDossier">
            <img class="imageDossier" src="images/dossier.jpg" />
            <h1 class="TitreDossier"><strong>Dossier</strong></h1>
        </div>
        
        <h2>Informations personnelles</h2>
        <div class="infos">
      
            <p class="LigneBleue"><span class="libelle1">No employé</span><asp:TextBox ID="TextBox1" style="float:right; margin-right:40px; width:140px;"  runat="server"></asp:TextBox></p> 
            <p class="LigneBlanche"><span class="libelle2">Nom</span><asp:TextBox ID="TextBox2" style="float:right; margin-right:40px; width:140px;"  runat="server"></asp:TextBox></p> 
            <p class="LigneBleue"><span class="libelle1">Prénom</span><asp:TextBox ID="TextBox3" style="float:right; margin-right:40px; width:140px;"  runat="server"></asp:TextBox></p>
            <p class="LigneBlanche"><span class="libelle2">Sexe</span><asp:TextBox ID="TextBox4" style="float:right; margin-right:40px; width:140px;"  runat="server"></asp:TextBox></p>
            <p class="LigneBleue"><span class="libelle1">Date de naissance</span><asp:TextBox ID="TextBox5" style="float:right; margin-right:40px; width:140px;"  runat="server"></asp:TextBox></p>
            <p class="LigneBlanche"><span class="libelle2">Adresse</span><asp:TextBox ID="TextBox6" style="float:right; margin-right:40px; width:140px;"  runat="server" ></asp:TextBox></p>
            <asp:RegularExpressionValidator ID="ValidationNoTel" ForeColor="red" ControlToValidate="TextBox7" Display="Dynamic" ErrorMessage="Erreur. Exemple de numéro valide :418-815-9483" runat="server" ValidationExpression="^[1-9]{3}-[0-9]{3}-[0-9]{4}$" ></asp:RegularExpressionValidator>
            <p class="LigneBleue"><span class="libelle1">No telephone</span><asp:TextBox ID="TextBox7" style="float:right; margin-right:40px; width:140px;"  runat="server"></asp:TextBox></p>
            <p class="LigneBlanche"><span class="libelle2">NAS</span><asp:TextBox ID="TextBox8" style="float:right; margin-right:40px; width:140px;"  runat="server"></asp:TextBox></p>
            <p class="LigneBleue"><span class="libelle1">Type emploi</span><asp:TextBox ID="TextBox9" style="float:right; margin-right:40px; width:140px;"  runat="server"></asp:TextBox></p>
        </div>
        <h3>Informations de compte</h3>
        <div class="TitreIdentifiantMDP">
            <p class="ID">Identifiant</p>
            <p class="IDMDP"><asp:Label ID="LblID" runat="server" CssClass="LblID"></asp:Label></p><br />
            <p class="ID">Mot de passe</p>
            <p class="IDMDP"><asp:Label ID="LblMDP" runat="server" CssClass="LblID"></asp:Label></p>
        </div>
        

        
    </div>

    <div class="horaire">
        <div class="BlocTitreHoraire">
            <img class="imageHoraire" src="images/poignee-main-professionnelle.jpg" />
            <h1 class="TitreHoraire">Horaire</h1>
        </div>

        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate >
        <div class="calendar">
           
                    <asp:Calendar ID="Calendar1" runat="server" BackColor="White" BorderColor="Black" BorderStyle="Solid" CellSpacing="1" Font-Names="Verdana" Font-Size="12pt" ForeColor="Black" Height="250px" NextPrevFormat="ShortMonth" Width="350px">
                    <DayHeaderStyle Font-Bold="True" Font-Size="12pt" CssClass="calendar" ForeColor="#333333" Height="8pt" />
                    <DayStyle  />
                    <NextPrevStyle Font-Bold="True" Font-Size="12pt" ForeColor="White" />
                    <OtherMonthDayStyle ForeColor="#999999" />
                    <SelectedDayStyle BackColor="#FFA42B" ForeColor="White" />
                    <TitleStyle BackColor="#FFA42B" BorderStyle="Solid" Font-Bold="True" Font-Size="13pt" ForeColor="White" Height="12pt" />
                    <TodayDayStyle BackColor="#db0000" ForeColor="White" />
                    </asp:Calendar>
            </div><br />
        <p class ="dateChiffre">Date chiffre : <asp:Label runat="server" ID="lblDateChiffre" CssClass="lblDate"></asp:Label></p><br />
        <p class="ligneHeure">Heure début de chiffre : <asp:Label runat="server" ID="LblHeureDebut" CssClass="LabelHeureDebut"></asp:Label></p>
        <p class="ligneHeure" style="background-color:white">Heure fin de chiffre : <asp:Label runat="server" ID="LblHeureFin" CssClass="LabelHeureDebut"></asp:Label></p>
        <p class="ligneHeure">Nombre heure semaine : <asp:Label runat="server" ID="LblHeureSemaine" CssClass="LabelHeureDebut"></asp:Label></p>
        
        
    </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    </div><br />
    <asp:Button runat="server" ID="Btn_EnregistrerModif" Text="Enregistrer" CssClass="btnModifier" /><br />
    <asp:Label runat="server" ID="LblActualiser" ForeColor="Red" Text="* Cliquer sur F5 pour voir les modifications de connexion" Visible="False"></asp:Label>
    
</asp:Content>

