<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="emplist.Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
     <link href="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
       <div class="container-fluid" style="background-color: #FFCC66; padding: 20px;">
    <!-- Buttons Row -->
    <div class="d-flex justify-content-between mb-3">
        <asp:Button ID="Button2" runat="server" Font-Bold="True" OnClick="Button2_Click" Text="Home" CssClass="btn btn-primary" />
        <asp:Button ID="Button3" runat="server" Font-Bold="True" Text="Employee List" CssClass="btn btn-secondary" OnClick="Button3_Click" />
        <asp:Button ID="Button4" runat="server" Font-Bold="True" Text="Name" CssClass="btn btn-info" />
        <asp:Button ID="Button5" runat="server" Font-Bold="True" OnClick="Button5_Click" Text="Logout" CssClass="btn btn-danger" />
    </div>

    <!-- Title Section -->
    <h3 class="text-center mb-4">Registration form</h3>

    <!-- Form for Input Fields -->
    <div class="row">
        <div class="col-md-6 offset-md-3">
            <div class="form-group">
                <label for="TextBox1" class="font-weight-bold">Name</label>
                <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control" />
            </div>
            <div class="form-group">
                <label for="TextBox2" class="font-weight-bold">Email</label>
                <asp:TextBox ID="TextBox2" runat="server" CssClass="form-control" />
            </div>
            <div class="form-group">
                <label for="TextBox3" class="font-weight-bold">Mobile No</label>
                <asp:TextBox ID="TextBox3" runat="server" CssClass="form-control" />
            </div>
            <div class="form-group">
                <label for="DropDownList1" class="font-weight-bold">Designation</label>
                <asp:DropDownList ID="DropDownList1" runat="server" CssClass="form-control">
                    <asp:ListItem>HR</asp:ListItem>
                    <asp:ListItem>Manager</asp:ListItem>
                    <asp:ListItem>Sales Pro</asp:ListItem>
                </asp:DropDownList>
            </div>
            <div class="form-group">
                <label class="font-weight-bold">Gender</label>
                <div class="form-check form-check-inline">
                   
                </div>
                <div class="form-check form-check-inline">
                    <asp:RadioButtonList ID="RadioButtonList1" runat="server">
                        <asp:ListItem>Male</asp:ListItem>
                        <asp:ListItem>Female</asp:ListItem>
                    </asp:RadioButtonList>
                   
                </div>
            </div>
            <div class="form-group">
                <label class="font-weight-bold">Course</label>
                <div class="form-check form-check-inline">
                                   </div>
                <div class="form-check form-check-inline">
                    <asp:CheckBoxList ID="CheckBoxList1" runat="server">
                        <asp:ListItem>select course</asp:ListItem>
                        <asp:ListItem>MCA</asp:ListItem>
                        <asp:ListItem>BSC</asp:ListItem>
                        <asp:ListItem>BCA</asp:ListItem>
                    </asp:CheckBoxList>
                   
                </div>
            </div>
            <div class="form-group">
                <label for="FileUpload1" class="font-weight-bold">Img Upload</label>
                <asp:FileUpload ID="FileUpload1" runat="server" CssClass="form-control-file" />
            &nbsp;<asp:Image ID="Image1" runat="server" Height="200px" Width="200px" />
            </div>

            <!-- Submit Button -->
            <div class="text-center">
                <asp:Button ID="Button6" runat="server" Font-Bold="True" OnClick="Button6_Click" Text="Submit" CssClass="btn btn-success" />
            &nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="Button7" runat="server" OnClick="Button7_Click" style="height: 42px" Text="update" />
            </div>
        </div>
    </div>
</div>
    </form>
</body>
</html>
