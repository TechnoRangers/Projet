<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="PageSecondaire.aspx.vb" Inherits="AppliTutoASPNET.PageSecondaire" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Liste de chambres</h2>

    <asp:ListView ID="ListView1" runat="server" DataSourceID="LinqDataSource1">
               <ItemTemplate>
                    <td runat="server">
                        <table>
                            <tr>
                                <td>
                                        <img src="~/Images/Chambre<%# Request.QueryString("id")%>.jpg"
                                            width="100" height="75" style="border: solid" /></a>
                                </td>   
                            </tr>
                            <tr>
                                <td>
                                        <span>
                                            <b>Desc: </b><%# Eval("tblChambre.DescChambre")%>
                                        </span>
                                    </a>
                                    <br />
                                    <span>
                                        <b>TypeLit: </b><%# Eval("tblChambre.TypeLit")%>
                                    </span>
                                    <br />
                                </td>
                            </tr>
                            <tr>
                                <td>&nbsp;</td>
                            </tr>
                        </table>
                        </p>
                    </td>
                </ItemTemplate>
        

    </asp:ListView>



    


    <asp:LinqDataSource ID="LinqDataSource1" runat="server" EntityTypeName="">
    </asp:LinqDataSource>



    


    <asp:EntityDataSource ID="P2014_GestionHotel" runat="server" ConnectionString="name=P2014_BD_GestionHotelEntities" DefaultContainerName="P2014_BD_GestionHotelEntities" EnableFlattening="False" EntitySetName="tblChambre"></asp:EntityDataSource>
</asp:Content>

