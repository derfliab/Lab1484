<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Employee.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .auto-style3 {
            margin-left: 0px;
        }
        .auto-style4 {
            width: 247px;
        }
        .auto-style5 {
            width: 2980px;
        }
        .auto-style6 {
            width: 247px;
            height: 44px;
        }
        .auto-style7 {
            width: 2980px;
            height: 44px;
        }
        body{
            background-color: lightsteelblue;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server"> 
    <body>
    <div>
        <h1>Employee Form:</h1>
        <table id="employeeinfo" style="width:200%"  >
           
            <tr>
                <td class="auto-style4">
                    First Name:
                </td>
                <td class="auto-style5">
                    House Number:
                </td>
            </tr>
            <tr>
                <td class="auto-style4">
                    <input type="text" id="txtFirstName" required="" runat="server" maxlength ="20"  />
                     
                </td>
                <td class="auto-style5">
                    <input type="text" id="txtHouseNumber" required="" runat="server" maxlength="10" class="auto-style3"/>
                </td>
            </tr>
            <tr>
                <td class="auto-style4">
                    Last Name:
                </td>
                <td class="auto-style5">
                    Street:
                </td>
            </tr>
            <tr>
                <td class="auto-style4">
                    <input id="txtLastName" type="text" required="" runat="server" maxlength="30"/>
                </td>
                <td class="auto-style5">
                    <input id="txtStreet" type="text" required="" runat="server" maxlength="20"/>
                </td>
            </tr>
            <tr>
                <td class="auto-style4">
                    MI*:
                </td>
                <td class="auto-style5">
                    City/County:
                </td>
            </tr>
            <tr>
                <td class="auto-style4">
                    <input id="txtMI" type="text" runat="server" maxlength="1"/>
                </td>
                <td class="auto-style5">
                    <input id="txtCity" type="text" required="" runat="server" maxlength="25"/>
                </td>
            </tr>
            <tr>
                <td class="auto-style4">
                    Date-Of-Birth:
                </td>
                <td class="auto-style5">
                    State*:
                </td>
            </tr>
            <tr>
                <td class="auto-style4">
                    <input id="txtDOB" type="text" required="" runat="server" placeholder="YYYY-MM-DD"/>
                    
                </td>
                <td class="auto-style5">
                    <input id ="txtState" type="text" runat="server" maxlength="2" />
                </td>
            </tr>
            <tr>
               <td>
                    Skills:
                </td>  
                <td class="auto-style4">
                    Country:
                </td>
            </tr>
            <tr>
                <td>
                    <asp:DropDownList ID="DropDownSkill" required="" runat="server" Width="128px"></asp:DropDownList>
                </td>
                <td class="auto-style4">
                    <input id="txtCountry" type="text"   required="" runat="server" maxlength="2"/>
                </td>
            </tr>
            <tr >
                <td class="auto-style4">
                    Projects:
                    </td>
                <td class="auto-style5">
                    ZipCode:
                </td>
            </tr>
            <tr>
                <td class="auto-style4">

                    

                    <asp:DropDownList ID="DropDownProject" required="" runat="server" Width="128px"></asp:DropDownList>

                    

                </td>
                <td class="auto-style5">
                     <input id="txtZip" type="text" required="" runat="server" maxlength="5"/>
                </td>
            </tr>
            <tr class="spaceUnder">
                <!-- Empty Row -->
                <td class="auto-style6">

                </td>
                <td class="auto-style7">

                </td>
            </tr>
            <tr>
                <td class="auto-style4">
                    Hire Date:
                </td>
                <td class="auto-style5">
                    Termination Date*:
                </td>
            </tr>
            <tr>
                <td class="auto-style4">
                     
                    <input id="txtHire" runat="server" type="text" placeholder="YYYY-MM-DD"/>
                     
                </td>
                <td class="auto-style5">
                    <input id="txtTerm" runat="server" type="text" placeholder="YYYY-MM-DD"/>
                     
                </td>
            </tr>
            <tr>
                <td class="auto-style4">
                    Manager ID*:
                </td>
                <td class="auto-style5">
                    Salary:
                </td>
            </tr>
            <tr>
                <td class="auto-style4">
                    <input id="txtManager" type="text" runat="server"/>
                </td>
                <td class="auto-style5">
                    <input id="txtSalary" required="" type="text" runat="server"/>
                </td>
            </tr>
             <tr>
                <!-- Empty Row -->
                <td class="auto-style4">

                </td>
                <td class="auto-style5">

                </td>
            </tr>
        
        </table>
        <p>
        &nbsp*Fields may be left empty.
    </p>  
         
        
         
        <asp:Button ID="ClearBtn" runat="server" style="margin-right:20px" OnClick="ClearBtn_Click" Text="Clear" />
        <asp:Button ID="EmployeeCommittBtn" runat="server" style="margin-right:20px" OnClick="EmployeeCommitBtn_Click" Text="Employee Commit" />
        <asp:Button ID="ShowData" runat="server" style="margin-right:20px" OnClick="ShowDataBtn_Click" formnovalidate="false" Text="Show Data" />
        <br />
        <br />
        <asp:GridView ID="EmployeeData" runat="server"></asp:GridView>
         
        <br />

        <br />
        <br />
        <asp:Label ID="Label" runat="server" />

        </div>
        </body>
        
</asp:Content>


