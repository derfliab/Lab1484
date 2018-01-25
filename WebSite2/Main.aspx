<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Main.aspx.cs" Inherits="Default2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Andrea Derflinger</title>
</head>
<body>
    <form id="form1" runat="server">
        <h1>Main Form:</h1>
        <h2>Please select from the following buttons to add:</h2>
        <ul>
            <li><a href="Employee.aspx"> Add Employee</a></li>
            <li><a href="Skill.aspx">Add Skill</a></li>
            <li><a href="Project.aspx">Add Project</a></li>
        </ul>
    <div>
        <br />
        <asp:Button ID="ShowData" runat="server" style="margin-right:20px" OnClick="ShowDataBtn_Click" Text="Show Data" />
        <br />
        <br />
        <asp:GridView ID="GridView1" runat="server"></asp:GridView>
        <br />
        <asp:Label ID="Label" runat="server" />
    
    </div>
        
         
    </form>
</body>
</html>
 
