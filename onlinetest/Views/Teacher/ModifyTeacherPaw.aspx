<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Teachersite.Master" Inherits="System.Web.Mvc.ViewPage<Model.Teacher>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    <link href="<%= Url.Content("~/CSS/member.css") %>" rel="stylesheet" type="text/css" />
     <script src="<%= Url.Content("~/Scripts/jquery-1.7.1.min.js") %>" type="text/javascript"></script>
    <script src="<%= Url.Content("~/Scripts/jquery.validate.min.js") %>" type="text/javascript"></script>
    <script src="<%= Url.Content("~/Scripts/jquery.validate.unobtrusive.min.js") %>" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">


    <script src="<%: Url.Content("~/Scripts/jquery-1.7.1.min.js") %>"></script>
    <script src="<%: Url.Content("~/Scripts/jquery.validate.min.js") %>"></script>
    <script src="<%: Url.Content("~/Scripts/jquery.validate.unobtrusive.min.js") %>"></script>

    <% using (Html.BeginForm("ModifyTeacherPaw", "Teacher", FormMethod.Post))
       { %>
    <%: Html.ValidationSummary(true)%>

    <fieldset>
        <legend>修改密码</legend>
        <%:Html.HiddenFor(model => model.TeacherID) %>
        <%:Html.HiddenFor(model => model.TeacherName) %>
        <%:Html.HiddenFor(model => model.TeacherRank) %>
        <%:Html.HiddenFor(model => model.TeacherSubject) %>
        <%:Html.HiddenFor(model => model.TeacherTel) %>
        教师编号：
        <%:Html.DisplayFor(model => model.TeacherID) %>
        <div class="editor-label">
           设置新密码
        </div>
        <div class="editor-field">
            <%=Html.Password("TeacherPwd", null, new { @class = "opt_input" })%>

            <%: Html.ValidationMessageFor(model => model.TeacherPwd)%>
        </div>
        <div class="editor-label">
            <%: Html.LabelFor(model => model.PasswordConfirm)%>
        </div>
        <%=Html.Password("PasswordConfirm", null, new { @class = "opt_input" })%>
        <%=Html.ValidationMessage("PasswordConfirm")%>

        <p>
            <input type="submit" value="Save"/>
        </p>
    </fieldset>
    <% } %>

    </asp:Content>