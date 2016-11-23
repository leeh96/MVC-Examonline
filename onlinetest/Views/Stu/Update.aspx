<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Stusite.Master" Inherits="System.Web.Mvc.ViewPage<Model.Stu>" %>


<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    <link href="<%= Url.Content("~/CSS/member.css") %>" rel="stylesheet" type="text/css" />
    <script src="<%= Url.Content("~/Scripts/jquery-1.7.1.min.js") %>" type="text/javascript"></script>
    <script src="<%= Url.Content("~/Scripts/jquery.validate.min.js") %>" type="text/javascript"></script>
    <script src="<%= Url.Content("~/Scripts/jquery.validate.unobtrusive.min.js") %>" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <% using (Html.BeginForm("Update", "Stu", FormMethod.Post))
       { %>
    <%: Html.ValidationSummary(true)%>

    <fieldset style="width:600px;">
        <legend>修改个人信息</legend>

            <%: Html.LabelFor(model => model.StuID)%> 
            <%: Html.DisplayFor(model => model.StuID)%>
        <%: Html.HiddenFor(model => model.StuID)%>
        <%: Html.HiddenFor(model => model.StuPwd)%>


        <div class="editor-label">
            <%: Html.LabelFor(model => model.StuName)%>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.StuName)%>
            <%: Html.ValidationMessageFor(model => model.StuName)%>
        </div>

        <div class="editor-label">
            <%: Html.LabelFor(model => model.StuClass)%>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.StuClass)%>
            <%: Html.ValidationMessageFor(model => model.StuClass)%>
        </div>

        <div class="editor-label">
            <%: Html.LabelFor(model => model.StuGrade)%>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.StuGrade)%>
            <%: Html.ValidationMessageFor(model => model.StuGrade)%>
        </div>

        <div class="editor-label">
            <%: Html.LabelFor(model => model.StuTel)%>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.StuTel)%>
            <%: Html.ValidationMessageFor(model => model.StuTel)%>
        </div>

        <p>
            <input type="submit" value="Save" />
        </p>
    </fieldset>
    <% } %>

  
</asp:Content>