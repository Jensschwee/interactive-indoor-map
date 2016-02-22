<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Website.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" type="text/css" href="http://cdn.leafletjs.com/leaflet/v0.7.7/leaflet.css" />
    <link rel="stylesheet" type="text/css" href="Style/Style.css" />
    <script type='text/javascript' src='http://ajax.googleapis.com/ajax/libs/jquery/2.0.3/jquery.min.js'></script>

    <!-- Latest compiled and minified CSS -->
    <%--<link rel="stylesheet" type="text/css" href="Style/bootstrap.min.css" />--%>

    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.0/css/bootstrap.min.css"/>

    <!-- Optional theme -->
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.0/css/bootstrap-theme.min.css">

    <!-- Latest compiled and minified JavaScript -->
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.0/js/bootstrap.min.js"></script>

    <script src="http://cdn.leafletjs.com/leaflet/v0.7.7/leaflet.js"></script>
    <%--<script type='text/javascript' src='scripts/leaflet.js'></script>--%>
    <script type='text/javascript' src='scripts/leaf-demo.js'></script>

    <%--<script type="text/javascript" src="scripts/leaflet-realtime.js"></script>--%>
</head>
<body>
    <form id="form1" runat="server">
        <%--<h1>Leaflet Example</h1>--%>

        <%--<p>Here's an interactive map indicating the countries I've either lived in or travelled through for a month or more.--%>
        <div id="map" style="width: 100%; height: 93vh; border: 1px solid #AAA;"></div>
        <div id="menu" style="width: 100%; height: 7vh; border: 1px solid #AAA;">
            <ul class="nav nav-tabs">
                <li>
                    <asp:LinkButton ID="myLink" Text="Draw Building" OnClick="DrawBuilding" runat="server" /></li>
                <%--<li><a href="#">Menu 3</a></li>--%>
            </ul>
        </div>

    </form>
</body>
</html>
