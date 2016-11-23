<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Adminsite.Master"  Inherits="System.Web.Mvc.ViewPage<Model.Teacher>" %>

<%@ Import Namespace="Helper" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    <script src="<%= Url.Content("~/Scripts/jquery-1.7.1.min.js") %>" type="text/javascript"></script>
    <script src="<%= Url.Content("~/Scripts/jquery.validate.min.js") %>" type="text/javascript"></script>
    <script src="<%= Url.Content("~/Scripts/jquery.validate.unobtrusive.min.js") %>" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
 

    <% using (Html.BeginForm("AddTeacher", "Admin", FormMethod.Post))
       { %>
        <%: Html.ValidationSummary(true)%>
    
        <fieldset style="width:600px;">
            <legend>添加教师信息</legend>
    <div class="editor-label">
            <%: Html.LabelFor(model => model.TeacherID)%>
        </div>
            <%: Html.EditorFor(model => model.TeacherID,new{@Type="number"})%>
     <%: Html.ValidationMessageFor(model => model.TeacherID)%>
            <div class="editor-label">
                <%: Html.LabelFor(model => model.TeacherPwd)%>
            </div>
            <div class="editor-field">
                <%=Html.Password("TeacherPwd", null, new { @class = "opt_input" })%>
                
                <%: Html.ValidationMessageFor(model => model.TeacherPwd)%>
            </div>
    
            <div class="editor-label">
                <%: Html.LabelFor(model => model.TeacherName)%>
            </div>
            <div class="editor-field">
                <%: Html.EditorFor(model => model.TeacherName)%>
                <%: Html.ValidationMessageFor(model => model.TeacherName)%>
            </div>
    
            <div class="editor-label">
                <%: Html.LabelFor(model => model.TeacherSubject)%>
            </div>
            <div class="editor-field">
                <%: Html.EditorFor(model => model.TeacherSubject)%>
                <%: Html.ValidationMessageFor(model => model.TeacherSubject)%>
            
            </div>
    
            <div class="editor-label">
                <%: Html.LabelFor(model => model.TeacherRank)%>
            </div>
            <div class="editor-field">
                <%: Html.EditorFor(model => model.TeacherRank)%>
                <%: Html.ValidationMessageFor(model => model.TeacherRank)%>
            </div>
    
            <div class="editor-label">
                <%: Html.LabelFor(model => model.TeacherTel)%>
            </div>
            <div class="editor-field">
                <%: Html.EditorFor(model => model.TeacherTel)%>
                <%: Html.ValidationMessageFor(model => model.TeacherTel)%>
            </div>
    
            <p>
                <input type="submit" value="Save"  />
            </p>
        </fieldset>
    <% } %>
  

    </asp:Content>