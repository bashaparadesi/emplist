<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="emplist.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
     <style type="text/css">
     .auto-style1 {
         height: 752px;
         width: 1324px;
         margin-left: 72px;
     }
 </style>
 <link href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
          <div class="container mt-5" style="background-color: #FFCC66; padding: 20px; border-radius: 10px;">
    <div class="row">
        <div class="col-12 text-center">
            <h2 class="font-weight-bold text-decoration-underline">Login Form</h2>
        </div>
    </div>

        <div class="form-group row">
            <label for="UserId" class="col-sm-2 col-form-label font-weight-bold">UserId</label>
            <div class="col-sm-10">
                <asp:TextBox ID="TextBox1" runat="server" class="form-control" placeholder="Enter UserId"></asp:TextBox>
            </div>
        </div>

        <div class="form-group row">
            <label for="Password" class="col-sm-2 col-form-label font-weight-bold">Password</label>
            <div class="col-sm-10">
                <asp:TextBox ID="TextBox2" runat="server" class="form-control" placeholder="Enter Password" TextMode="Password"></asp:TextBox>
            </div>
        </div>

        <div class="form-group row">
            <div class="col-sm-10 offset-sm-2">
                <asp:Button ID="Button1" runat="server" class="btn btn-primary" OnClick="Button1_Click" Text="Login" />
            </div>
        </div>

        <div class="row">
            <div class="col-sm-12 text-center">
                <asp:Label ID="Label4" runat="server" Text="Label" class="text-muted"></asp:Label>
            </div>
        </div>

</div>

    </form>
</body>
</html>
