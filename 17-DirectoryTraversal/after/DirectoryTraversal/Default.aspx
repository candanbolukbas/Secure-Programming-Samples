<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="DirectoryTraversal._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <p class="lead">ASP.NET is a free web framework for building great Web sites and Web applications using HTML, CSS, and JavaScript.</p>
    </div>

    <div class="row">
        <div class="col-md-4">
            <h2>Getting started</h2>
            <asp:Image ID="imageView" runat="server" src="http://localhost:55775/resize.aspx?image=/images/1.jpg&w=300&h=200" />
        </div>
        <div class="col-md-4">
            <h2>Get more libraries</h2>
            <asp:Image ID="image1" runat="server" src="http://localhost:55775/resize.aspx?image=/images/2.jpg&w=300&h=200" />
        </div>
        <div class="col-md-4">
            <h2>Web Hosting</h2>
            <asp:Image ID="image2" runat="server" src="http://localhost:55775/resize.aspx?image=/images/5.jpg&w=300&h=200" />
        </div>
    </div>

</asp:Content>
