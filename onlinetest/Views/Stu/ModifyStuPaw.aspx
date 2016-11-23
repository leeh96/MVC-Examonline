<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Stusite.Master" Inherits="System.Web.Mvc.ViewPage<Model.Stu>" %>


<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    <link href="<%= Url.Content("~/CSS/member.css") %>" rel="stylesheet" type="text/css" />
    <script src="<%= Url.Content("~/Scripts/jquery-1.7.1.min.js") %>" type="text/javascript"></script>
    <script src="<%= Url.Content("~/Scripts/jquery.validate.min.js") %>" type="text/javascript"></script>
    <script src="<%= Url.Content("~/Scripts/jquery.validate.unobtrusive.min.js") %>" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <% using (Html.BeginForm("ModifyStuPaw", "Stu", FormMethod.Post))
       { %>
    <%: Html.ValidationSummary(true)%>

    <fieldset style="width:600px;">
        <legend>修改密码</legend>
        <%: Html.HiddenFor(model => model.StuID)%>
        <%: Html.HiddenFor(model => model.StuName)%>
        <%: Html.HiddenFor(model => model.StuClass)%>
        <%: Html.HiddenFor(model => model.StuGrade)%>
        <%: Html.HiddenFor(model => model.StuTel)%>
        <%: Html.LabelFor(model => model.StuID)%>
        <%: Html.DisplayFor(model => model.StuID)%>
        <div class="editor-label">
            设置新密码
        </div>
        <div class="editor-field">
            <%=Html.Password("StuPwd", null, new { @class = "opt_input" })%>

            <%: Html.ValidationMessageFor(model => model.StuPwd)%>
        </div>
        <div class="editor-label">
            <%: Html.LabelFor(model => model.PasswordConfirm)%>
        </div>
        <%=Html.Password("PasswordConfirm", null, new { @class = "opt_input" })%>
        <%=Html.ValidationMessage("PasswordConfirm")%>

        <p>
            <input type="submit" value="Save" />
        </p>
    </fieldset>
    <% } %>
</asp:Content>
