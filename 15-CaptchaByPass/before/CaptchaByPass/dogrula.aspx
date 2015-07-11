<%@ Page Language="C#" AutoEventWireup="true" CodeFile="dogrula.aspx.cs" Inherits="dogrula" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
	<title>Captcha Bypass</title>
	<link href="css/bootstrap.min.css" rel="stylesheet">
	<link href="css/style.css" rel="stylesheet">
	<link rel="stylesheet" type="text/css" href="css/override-bootstrap.css">
  	<link rel="apple-touch-icon-precomposed" sizes="144x144" href="img/apple-touch-icon-144-precomposed.png">
  	<link rel="apple-touch-icon-precomposed" sizes="114x114" href="img/apple-touch-icon-114-precomposed.png">
	<link rel="apple-touch-icon-precomposed" sizes="72x72" href="img/apple-touch-icon-72-precomposed.png">
	<link rel="apple-touch-icon-precomposed" href="img/apple-touch-icon-57-precomposed.png">
	<link rel="shortcut icon" href="img/favicon.png">
  	<link rel="stylesheet" type="text/css" href="font-awesome/css/font-awesome.min.css">
	<script type="text/javascript" src="js/jquery.min.js"></script>
	<script type="text/javascript" src="js/bootstrap.min.js"></script>
	<script type="text/javascript" src="js/scripts.js"></script>
    <script src="js/jquery.easing.js" type="text/javascript"></script>
    <script src="js/counter.min.js" type="text/javascript"></script>
</head>
<body>
<div class="row clearfix" style="padding:20px">
    <div class="col-md-2 column ">
    </div>
	<div class="col-md-8 column ">
		<div class="panel panel-bga">
			<div class="panel-heading">
				<h3 class="panel-title pt">
					<span class="fa fa-warning" style="font-size:14px; color:white;"></span>&nbsp;&nbsp;Sonuç
				</h3>
			</div>
			<div class="panel-body" style="font-size:12px;">
            <%if (!control)
              {%>
                <div class="row">
                    <center>
                        <span class="fa fa-warning" style="color:brown; font-size:150px; padding:20px"></span>
                    </center>
                </div>
				<div class="row">
                	<div class="col-md-12 column ">
                        <div class="alert alert-danger" role="alert" style="text-align:center">Doğrulama kodunu(captcha) yanlış girdiniz. Lütfen formu tekrar doldurun ve doğrulama kodunu doğru girdiğinize emin olun.</div>
                    </div>
                </div>
                <%}
              else
              {%> 
                <div class="row">
                    <center>
                        <span class="fa fa-thumbs-o-up" style="color:green; font-size:150px; padding:20px"></span>
                    </center>
                </div>
				<div class="row">
                	<div class="col-md-12 column ">
                        <div class="alert alert-success" role="alert" style="text-align:center">Formunuz başarılı bir şekilde elimize ulaştı. İlginiz için teşekkür ederiz.</div>
                    </div>
                </div>
              <%} %>
            </div>
        </div>
    </div>
    <div class="col-md-2 column ">
    </div>
</div>
</body>
</html>
