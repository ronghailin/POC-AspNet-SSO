<%@ Page Title="Home" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="AspNetWebFormsApp2._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="col-lg-8">
            <table class="table table-bordered table-condensed">
                <thead>
                    <tr>
                        <th>Claim Type</th>
                        <th>Claim Value</th>
                    </tr>
                </thead>
                <% foreach (var claim in System.Security.Claims.ClaimsPrincipal.Current.Claims)
                    { %>
                <tr>
                    <td class="col-lg-4"><%= claim.Type %></td>
                    <td class="col-lg-4"><%= claim.Value %></td>
                </tr>
                <%}%>
            </table>
        </div>
        <div class="col-lg-4">
        </div>
    </div>
</asp:Content>