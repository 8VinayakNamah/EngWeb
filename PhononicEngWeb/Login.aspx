<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="PhononicEngWeb.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    
<!------ Include the above in your HEAD tag ---------->
    <!-- Required meta tags -->
    <meta charset="utf-8"/>
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no"/>
    <!-- Fonts -->
    <%--<link rel="dns-prefetch" href="https://fonts.gstatic.com"/>
    <link href="https://fonts.googleapis.com/css?family=Raleway:300,400,600" rel="stylesheet" type="text/css"/>--%>
    <link rel="stylesheet" href="css/style.css"/>
    <link rel="icon" href="Favicon.png"/>    
    <title></title>
    <link href="Content/bootstrap.css" rel="stylesheet"/>
    <script src="Scripts/bootstrap.js"></script>
    <script src="Scripts/jquery-3.5.1.js"></script>


</head>
<body>

<%--<nav class="navbar navbar-expand-lg navbar-light navbar-laravel">
    <div class="container">
        <a class="navbar-brand" href="#">Phononic</a>
        <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarSupportedContent" aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
            <span class="navbar-toggler-icon"></span>
        </button>

        <div class="collapse navbar-collapse" id="navbarSupportedContent">
            <ul class="navbar-nav ml-auto">
                <li class="nav-item">
                    <a class="nav-link" href="#">Login</a>
                </li>
                <li class="nav-item">
                    <a class="nav-link" href="#">Register</a>
                </li>
            </ul>

        </div>
    </div>
</nav>--%>
    <nav class="navbar navbar-light navbar-expand-md justify-content-center fixed-top" style="background-color: #b1dae4; margin-bottom: 50px;">
        <a href="/" class="navbar-brand d-flex mr-auto">
            <img src="Images/Logo-AdHocScrap_-_no_text_edited.jpg" height="80" width="170" class="img-fluid rounded" />
        </a>
        <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#collapsingNavbar">
            <span class="navbar-toggler-icon"></span>
        </button>
        <div class="navbar-collapse collapse " id="collapsingNavbar">
            <%--<ul class="navbar-nav w-75 justify-content-center">
                    <li class="nav-item active">
                        <a class="nav-link" href="#">AdHoc Scrap</a>
                    </li>
                    <li class="nav-item">
                        <a class="nav-link" href="">Finance</a>
                    </li>
                    <li class="nav-item">
                        <a class="nav-link" href="#">Link</a>
                    </li>
                    <li class="nav-item">
                        <a class="nav-link" href="#">new Link</a>
                    </li>
                </ul>--%>
            <ul class="nav navbar-nav ml-auto w-100 justify-content-end">
                <li class="nav-item">
                    <a class="nav-link" href="#">
                        <img src="Images/profile1.png" class="img-fluid img-thumbnail" height="30" width="30" />
                    </a>
                </li>
                <li class="nav-item">
                    <a class="nav-link" href="#">Contact Us</a>
                </li>
                <li class="nav-item">
                    <a class="nav-link" href="#">Right</a>
                </li>
            </ul>
        </div>
    </nav>
    <main class="login-form" style="margin-top: 100px;">
        <div class="cotainer">
            <div class="row justify-content-center">
                <div class="col-md-8">
                    <div class="card">
                        <div class="card-header text-center">
                            <h5 class="py-2">Login </h5>
                        </div>
                        <div class="card-body">
                            <form runat="server" class="needs-validation" novalidate="novalidate">
                                <div class="form-group row col-md-12 justify-content-center">
                                    <asp:Label runat="server" ID="lblErrorMsg" CssClass="col-form-label" ForeColor="Red"></asp:Label>
                                </div>
                                <div class="form-group row">
                                    <label for="userId" class="col-md-4 col-form-label text-md-right">User Name</label>
                                    <div class="col-md-6">
                                        <%--<input type="text" id="userId" class="form-control" name="userId" required="required" autofocus="autofocus"  />--%>
                                        <asp:TextBox runat="server" ID="txtUserName" CssClass="form-control" placeholder="JohnDoe" required="required" autofocus="autofocus"></asp:TextBox>
                                        <div class="invalid-feedback">
                                            Please provide Username
                                        </div>
                                    </div>
                                </div>

                                <div class="form-group row">
                                    <label for="password" class="col-md-4 col-form-label text-md-right">Password</label>
                                    <div class="col-md-6">
                                        <%--<input type="password" id="password" class="form-control" name="password" required="required" />--%>
                                        <asp:TextBox TextMode="Password" runat="server" ID="txtPassword" CssClass="form-control" placeholder="password" required="required" autofocus="autofocus"></asp:TextBox>
                                        <div class="invalid-feedback">
                                            Please provide Password
                                        </div>
                                    </div>
                                </div>

                                <div class="form-group row">
                                    <div class="col-md-6 offset-md-4">
                                        <div class="checkbox">
                                            <label>
                                                <input type="checkbox" name="remember" />
                                                Remember Me
                                            </label>
                                        </div>
                                    </div>
                                </div>

                                <div class="col-md-6 offset-md-4">
                                    <asp:Button CssClass="btn btn-primary" ID="btnLoginSubmit" runat="server" Text="Login" OnClick="btnLoginSubmit_Click" />
                                    <a href="#" class="btn btn-link">Forgot Your Password?</a>
                                </div>
                            </form>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </main>
</body>
<script>
// Example starter JavaScript for disabling form submissions if there are invalid fields
(function() {
  'use strict';
  window.addEventListener('load', function() {
    // Fetch all the forms we want to apply custom Bootstrap validation styles to
    var forms = document.getElementsByClassName('needs-validation');
    // Loop over them and prevent submission
    var validation = Array.prototype.filter.call(forms, function(form) {
      form.addEventListener('submit', function(event) {
        if (form.checkValidity() === false) {
          event.preventDefault();
          event.stopPropagation();
        }
        form.classList.add('was-validated');
      }, false);
    });
  }, false);
})();
</script>
</html>
