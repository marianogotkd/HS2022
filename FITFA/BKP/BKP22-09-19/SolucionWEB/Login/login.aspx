<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="login.aspx.vb" Inherits="fitfa.login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login</title>

      <!-- Bootstrap core CSS -->
    <link href="../vendor/bootstrap/css/bootstrap.min.css" rel="stylesheet">

    <!-- Custom fonts for this template -->
    <link href="../vendor/font-awesome/css/font-awesome.min.css" rel="stylesheet" type="text/css">
    <link href='https://fonts.googleapis.com/css?family=Open+Sans:300italic,400italic,600italic,700italic,800italic,400,300,600,700,800' rel='stylesheet' type='text/css'>
    <link href='https://fonts.googleapis.com/css?family=Merriweather:400,300,300italic,400italic,700,700italic,900,900italic' rel='stylesheet' type='text/css'>

    <!-- Plugin CSS -->
    <link href="../vendor/magnific-popup/magnific-popup.css" rel="stylesheet">

    <!-- Custom styles for this template -->
    <link href="../css/creative.min.css" rel="stylesheet">


</head>
<body style="background-image:url('../img/header.jpg')" >
  
  <div class=" panel-img">
&nbsp;</div>
      	
      	<!-- User Login Panel Start Here -->
		<div>
			<div style="position: absolute; z-index: 1; top: 295px; left: -129px;" 
                id="layer2" ><div class="modal-body" style="margin:30px 0px 0px 400px">
              <div class="row">
                  <div class="col-xs-6">
                      <div>
                          <form id="loginForm" method="POST" action="/login/" novalidate="novalidate">
                              <div class="form-group">
                                  <label for="username" class="control-label">Username</label>
                                  <input type="text" class="form-control" id="username" name="username" value="" required="" title="Please enter you username" placeholder="example@gmail.com">
                                  <span class="help-block"></span>
                              </div>
                              <div class="form-group">
                                  <label for="password" class="control-label">Password</label>
                                  <input type="password" class="form-control" id="password" name="password" value="" required="" title="Please enter your password">
                                  <span class="help-block"></span>
                              </div>
                        


                              <button type="submit" class="btn btn-success btn-block">Login</button>
                              <a href="/forgot/" class="btn btn-default btn-block">Forgot Password<a href="/new-customer/" class="btn btn-info btn-block">Register New User Here</a></a>
                          </form>
                      </div>
                  </div>
                  <div class="col-xs-6">
                      <p>&nbsp;</p>
                  </div>
              </div>
          </div>
      </div>
<img src="../Img/Panel.png" alt="" /></div>  



<!-- User Login Form End Here -->
          
<!-- <button class="btn navbar-btn btn-info" type="button">New Account</button><span class="sr-only">(current)</span> -->
        
          <!-- Bootstrap core JavaScript -->
    <script src="../vendor/jquery/jquery.min.js"></script>
    <script src="../vendor/bootstrap/js/bootstrap.bundle.min.js"></script>

    <!-- Plugin JavaScript -->
    <script src="../vendor/jquery-easing/jquery.easing.min.js"></script>
    <script src="../vendor/scrollreveal/scrollreveal.min.js"></script>
    <script src="../vendor/magnific-popup/jquery.magnific-popup.min.js"></script>

    <!-- Custom scripts for this template -->
    <script src="../js/creative.min.js"></script>


   </body>
</html>
