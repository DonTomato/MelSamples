<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<Surveys.Models.QuestionAnswer>" %>
<span class="questionText">
    <%:this.Model.QuestionText%>
</span>
<div class="answer">
    <%:this.Model.Answer%>
</div>
