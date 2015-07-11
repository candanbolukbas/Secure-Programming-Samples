<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="_10_Redirects._Default" %>

<asp:Content runat="server" ID="FeaturedContent" ContentPlaceHolderID="FeaturedContent">
    <section class="featured">
        <div class="content-wrapper">
            <hgroup class="title">
                <h1><%: Title %>.</h1>
                <h2>Modify this template to jump-start your ASP.NET application.</h2>
            </hgroup>
            <p>
                To learn more about ASP.NET, visit <a href="http://asp.net" title="ASP.NET Website">http://asp.net</a>.
                The page features <mark>videos, tutorials, and samples</mark> to help you get the most from ASP.NET.
                If you have any questions about ASP.NET visit
                <a href="http://forums.asp.net/18.aspx" title="ASP.NET Forum">our forums</a>.
            </p>
        </div>
    </section>
</asp:Content>
<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <h3>We suggest the following:</h3>
    <ol class="round">
        <li class="one">
            <h5>troyhunt.com</h5>
            <a href="Redirect.aspx?url=http://troyhunt.com">Learn more…</a>
        </li>
        <li class="two">
            <h5>ASafaWeb</h5>
            <a href="Redirect.aspx?url=https://asafaweb.com">Learn more…</a>
        </li>
        <li class="three">
            <h5>OWASP</h5>
            <a href="Redirect.aspx?url=https://www.owasp.org">Learn more…</a>
        </li>
    </ol>
</asp:Content>
