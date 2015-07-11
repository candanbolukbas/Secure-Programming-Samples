<%@ Page Language="C#" AutoEventWireup="true" CodeFile="index.aspx.cs" Inherits="Form" %>

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
    <div class="row" style="padding:20px">
        <div class="col-lg-2" style="padding:20px">
        </div>
        <div class="col-lg-8">
            <form id="iletisimform" class="register-form" action="dogrula.aspx" method="POST" role="form" style="">
	            <div class="row"> 
                    <div class="col-lg-12">
                        <div class="col-lg-12">
                            <div class="alert alert-warning" role="alert"><span class="fa fa-asterisk" style="color:brown"></span>&nbsp;&nbsp;Size daha iyi hizmet verebilmemiz için lütfen aşağıdaki bilgileri doğru bir şekilde doldurunuz ve doğrulama kodunu onaylayarak formu gönderiniz.</div>
                        </div>
                    </div>
                </div>
                <div class="form-group row">
		            <div class="col-lg-1"></div>
		            <div class="col-lg-10">
                        <div class="input-group input-group-lg">
                            <span class="input-group-addon"><span class="fa fa-list-alt" style="width:20px"></span></span>
                            <div style="border:1px solid rgb(204,204,204); height:50px;background-color:white">
                                <input ID="name" name="name" class="form-control" tabindex="1" placeholder="Ad" style="margin-top:8px;"/>
                            </div>                              
                        </div>
		            </div>
		            <div class="col-lg-1"></div>
	            </div>
	            <div class="form-group row">
                    <div class="col-lg-1"></div>
			            <div class="col-lg-10">
                            <div class="input-group input-group-lg">
                                <span class="input-group-addon"><span class="fa fa-list-alt" style="width:20px"></span></span>
                                <div style="border:1px solid rgb(204,204,204); height:50px;background-color:white">
                                    <input ID="surname" name="surname" class="form-control" TabIndex="1" placeholder="Soyad" style="margin-top:8px;"/>
                                </div>                              
                            </div>
			            </div>
		            <div class="col-lg-1"></div>
	            </div>
                <div class="form-group row">
                    <div class="col-lg-1"></div>
			            <div class="col-lg-10">
                            <div class="input-group input-group-lg">
                                <span class="input-group-addon"><span class="fa fa-at" style="width:20px"></span></span>
                                <div style="border:1px solid rgb(204,204,204); height:50px;background-color:white">
                                    <input ID="email" name="email" class="form-control" TabIndex="1" placeholder="E-mail" style="margin-top:8px;"/>
                                </div>                              
                            </div>
			            </div>
		            <div class="col-lg-1"></div>
	            </div>
                <div class="form-group row">
                    <div class="col-lg-1"></div>
			            <div class="col-lg-10">
                            <div class="input-group input-group-lg">
                                <span class="input-group-addon"><span class="fa fa-phone" style="width:20px"></span></span>
                                <div style="border:1px solid rgb(204,204,204); height:50px;background-color:white">
                                    <input ID="phone" name="phone" class="form-control" TabIndex="1" placeholder="Telefon" style="margin-top:8px;">
                                </div>                              
                            </div>
			            </div>
		            <div class="col-lg-1"></div>
	            </div>
                <div class="form-group row">
                    <div class="col-lg-1"></div>
			            <div class="col-lg-10">
                            <div class="input-group input-group-lg">
                                <span class="input-group-addon"><span class="fa fa-child" style="width:20px;"></span></span>
                                <div style="border:1px solid rgb(204,204,204); height:140px; background-color:white">
                                    <input id="comment" name="comment" TextMode="multiline" Columns="50" Rows="5" class="form-control" placeholder="Yazmak istedikleriniz..." style="margin-top:8px;"/>
                                </div>                              
                            </div>
			            </div>
		            <div class="col-lg-1"></div>
	            </div>
                <center>
                <div class="form-group row">
                    <div class="col-lg-1"></div>
			            <div class="col-lg-10">
                        <img ID="Image1" src="CImage.aspx"/>
			            </div>
		            <div class="col-lg-1"></div>
	            </div>
                </center>
                <div class="form-group row">
                    <div class="col-lg-1"></div>
			            <div class="col-lg-10">
                            <div class="input-group input-group-lg">
                                <span class="input-group-addon"><span class="fa fa-eye" style="width:20px"></span></span>
                                <div style="border:1px solid rgb(204,204,204); height:50px;background-color:white">
                                    <input ID="captcha" name="captcha" class="form-control" TabIndex="1" placeholder="Yukarıdaki metni yazın." style="margin-top:8px;"></asp:TextBox>
                                </div>                              
                            </div>
			            </div>
		            <div class="col-lg-1"></div>
	            </div>
                <div class="form-group">
		            <div class="row">
			            <div class="col-md-4"></div> 
			            <div class="col-md-4">
                            <input type="submit" ID="register" value="İletişim Formunu Gönder" 
                                class="form-control btn btn-login" tabindex="4" 
                                style="background-color:#f1c40f" text="İletişim Formunu Gönder"/>
			            </div>
		            </div>
	            </div>
            </form>
        </div>
        <div class="col-lg-2">
        </div>
</div>
</body>
</html>
