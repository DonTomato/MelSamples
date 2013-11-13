<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<SurveysWebApp.Models.TenantPageViewData<Surveys.Models.Tenant>>" %>

<asp:Content ID="Content2" ContentPlaceHolderID="Head" runat="server">
    <script src="<%:Url.Content("~/Scripts/jquery-1.4.1.min.js")%>" language="javascript" type="text/javascript"></script>
    <script src="<%:Url.Content("~/Scripts/management.js")%>" language="javascript" type="text/javascript"></script>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="MenuContent" runat="server">
    <ul>
        <li class="current"><a>List of Subscribers</a></li>
    </ul>
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="breadcrumbs">
        <%:Html.ActionLink("List of Subscribers", "Index", "Management")%>
        &gt;
        <%:this.Model.Title %>
    </div>
    <div id="issuerOptionTabs">
        <div class="sectionexplanationcontainer">
            <span class="titlesection">Tenant configuration</span> 
            <span class="explanationsection">
                <div id="yourIssuerTab" class="issuerOptionTab">
                    <div class="sampleform">
                        <table class="configTable">
                            <tbody>
                                <tr>
                                    <td>
                                        Organization name:
                                    </td>
                                    <td>
                                        <%= Html.TextBoxFor(m => m.ContentModel.Name, new { size = "55" })%>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Geolocation of your host application:
                                    </td>
                                    <td>
                                        <%= Html.DropDownListFor(m => m.ContentModel.HostGeoLocation, new List<SelectListItem>
                                                            {
                                                                new SelectListItem {Text = "Anywhere Asia", Value = "Anywhere Asia"},
                                                                new SelectListItem {Text = "Anywhere Europe", Value = "Anywhere Europe"},
                                                                new SelectListItem {Text = "Anywhere US", Value = "Anywhere US"},
                                                                new SelectListItem {Text = "East Asia", Value = "East Asia"},
                                                                new SelectListItem {Text = "North Central US", Value = "North Central US"},
                                                                new SelectListItem {Text = "North Europe", Value = "North Europe"},
                                                                new SelectListItem {Text = "South Central US", Value = "South Central US"},
                                                                new SelectListItem {Text = "Southeast Asia", Value = "Southeast Asia"},
                                                                new SelectListItem {Text = "West Europe", Value = "West Europe"},
                                                            })%>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Subscription Type:
                                    </td>
                                    <td>
                                        <%= Html.DropDownListFor(m => m.ContentModel.SubscriptionKind, new List<SelectListItem>
                                                            {
                                                                new SelectListItem {Text = "Standard", Value = Surveys.Models.SubscriptionKind.Standard.ToString()},
                                                                new SelectListItem {Text = "Premium", Value = Surveys.Models.SubscriptionKind.Premium.ToString()}
                                                            }, new { @class = "subscriptionSelector" })%>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Welcome Text:
                                    </td>
                                    <td>
                                        <%: Html.TextBoxFor(m => m.ContentModel.WelcomeText, new { size = "80" })%>
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                    </div>
                    <div style="text-align: right; margin-top: 10px;">
                        <input type="button" onclick="alert('This page is just a mockup, tenants cannot be edited at Tailspin sample application.');"
                            value="Save" />
                        <input type="button" onclick="alert('This page is just a mockup, tenants cannot be deleted at Tailspin sample application.');"
                            value="Delete" />
                    </div>
                </div>
            </span>
        </div>
    </div>
</asp:Content>
