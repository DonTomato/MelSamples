<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<SurveysWebApp.Models.TenantPageViewData<IEnumerable<string>>>" %>

<asp:Content ID="Content2" ContentPlaceHolderID="Head" runat="server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="MenuContent" runat="server">
    <ul>
        <li class="current"><a>List of Subscribers</a></li>
    </ul>
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <table border="0" cellspacing="0" cellpadding="0" class="tableGrid">
        <tr>
            <th>
                Tenant name
            </th>
            <th>
                Details
            </th>
            <th>
                Survey Responses
            </th>
        </tr>
        <% foreach (var tenant in this.Model.ContentModel) %>
        <% { %>
        <tr>
            <td>
                <%=tenant %>
            </td>
            <td>
                <%:Html.ActionLink("Details", "Detail", "Management", new { tenant = tenant }, new { })%>
            </td>
            <td>
                <%:Html.ActionLink("Responses", "Index", "Surveys", new { tenant = tenant }, new { })%>
            </td>
        </tr>
        <% } %>
    </table>
</asp:Content>
