<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="emplist.Home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
<style type="text/css">
    .auto-style1 {
        --bs-gutter-x: 1.5rem;
        --bs-gutter-y: 0;
        width: 100%;
        padding-right: calc(var(--bs-gutter-x) * .5);
        padding-left: calc(var(--bs-gutter-x) * .5);
        margin-right: auto;
        margin-left: auto;
        height: 720px;
    }
</style>
</head>
<body>
    <form id="form1" runat="server">
    
         <div class="auto-style1" style="background-color: #66CCFF; padding-top: 20px; padding-bottom: 20px;">
            <div class="row justify-content-center">
                <!-- Button for Home -->
                <div class="col-auto">
                    <asp:Button ID="Button1" runat="server" Font-Bold="True" OnClick="Button1_Click" Text="Home" CssClass="btn btn-primary btn-lg" />
                </div>
                
                <!-- Button for Employee List -->
                <div class="col-auto">
                    <asp:Button ID="Button2" runat="server" Font-Bold="True" OnClick="Button2_Click" Text="Employee List" CssClass="btn btn-success btn-lg" />
                </div>
                
                <!-- Button for Logout -->
                <div class="col-auto">
                    <asp:Button ID="Button3" runat="server" Font-Bold="True" OnClick="Button3_Click" Text="Logout" CssClass="btn btn-danger btn-lg" />
                </div>
            </div>

            <!-- You can add more content here (optional) -->
            <div class="row justify-content-center mt-5">
                <div class="col text-center">
                    <h1 class="display-4">Welcome to the Home Page</h1>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
