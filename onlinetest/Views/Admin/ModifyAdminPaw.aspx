<%@ Page Language="C#"  MasterPageFile="~/Views/Shared/Adminsite.Master"  Inherits="System.Web.Mvc.ViewPage<Model.Admin>" %>


<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    <link href="<%= Url.Content("~/CSS/member.css") %>" rel="stylesheet" type="text/css" />
    <script src="<%= Url.Content("~/Scripts/jquery-1.7.1.min.js") %>" type="text/javascript"></script>
    <script src="<%= Url.Content("~/Scripts/jquery.validate.min.js") %>" type="text/javascript"></script>
    <script src="<%= Url.Content("~/Scripts/jquery.validate.unobtrusive.min.js") %>" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
   


    <% using (Html.BeginForm("ModifyAdminPaw", "Admin", FormMethod.Post))
       { %>
    <%: Html.ValidationSummary(true)%>

    <fieldset>
        <legend>stu</legend>

        <%: Html.HiddenFor(model => model.AdminID)%>
        <%:Html.DisplayFor(model => model.AdminID) %>
        <div class="editor-label">
            <%: Html.LabelFor(model => model.AdminPwd)%>
        </div>
        <div class="editor-field">
            <%=Html.Password("AdminPwd", null, new { @class = "opt_input" })%>

            <%: Html.ValidationMessageFor(model => model.AdminPwd)%>
        </div>
        <div class="editor-label">
            <%: Html.LabelFor(model => model.PasswordConfirm)%>
        </div>
        <%=Html.Password("PasswordConfirm", null, new { @class = "opt_input" })%>
        <%=Html.ValidationMessage("PasswordConfirm")%>

        <p>
            <input type="submit" value="Save"  />
        </p>
    </fieldset>
    <% } %>
    
 
        
</asp:Content>