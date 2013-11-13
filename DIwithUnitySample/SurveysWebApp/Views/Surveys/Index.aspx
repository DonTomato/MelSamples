<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<SurveysWebApp.Models.TenantPageViewData<IEnumerable<Surveys.Models.Survey>>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MenuContent" runat="server">
    <ul>
        <li class="current"><a>My Surveys</a></li>
    </ul>
    <div class="clear">
    </div>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="breadcrumbs">
        My Surveys
    </div>
    <% if (this.Model.ContentModel.Count() == 0) { %>
    <div class="noResults">
        <h3>There are no surveys.</h3>
    </div>
    <% } else { %>
    <%using (Html.BeginForm("Delete", "Surveys")) {%>
    <%:Html.AntiForgeryToken() %>
    <table border="0" cellspacing="0" cellpadding="0" class="tableGrid">
        <tr>
            <th>
                Title
            </th>
            <th>
                Created On
            </th>
        </tr>
        <% foreach (var survey in this.Model.ContentModel) %>
        <% { %>
        <tr>
            <td>
                <%:Html.ActionLink(survey.Title, "BrowseResponses", "Surveys",new { tenant = survey.Tenant, surveySlug = survey.SlugName }, new { }) %>
            </td>
            <td>
                <%:survey.CreatedOn.ToLongDateString()%>
            </td>
        </tr>
        <% } %>
    </table>
    <% } } %>

    <script type="text/javascript">
        function submitToDelete(url) {
            document.forms[0].action = url 
            document.forms[0].submit();
        }
    </script>
</asp:Content>
