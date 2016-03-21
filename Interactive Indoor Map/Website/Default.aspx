<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Website.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" type="text/css" href="Style/leaflet.css" />
    <link rel="stylesheet" type="text/css" href="Style/non-IE-Style.css" />
    <link rel="stylesheet" type="text/css" href="Style/easy-button.css" />
    <% System.Web.HttpBrowserCapabilities browser = Request.Browser; %>
    <% Console.Write(browser.Browser);
        if (browser.Browser == "InternetExplorer" || (browser.Browser.Equals("Chrome") && browser.Version.Equals("42.0")))
        { %>
    <link rel="stylesheet" type="text/css" href="Style/IE-Style.css" />
    <% }
        else if (browser.Browser != "IE")
        { %>
    <link rel="stylesheet" type="text/css" href="Style/non-IE-Style.css" />
    <% }%>
    <script type='text/javascript' src='http://ajax.googleapis.com/ajax/libs/jquery/2.0.3/jquery.min.js'></script>


    <!-- Latest compiled and minified CSS -->
    <%--<link rel="stylesheet" type="text/css" href="Style/bootstrap.min.css" />--%>

    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.0/css/bootstrap.min.css" />

    <!-- Optional theme -->
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.0/css/bootstrap-theme.min.css">

    <!-- Latest compiled and minified JavaScript -->
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.0/js/bootstrap.min.js"></script>

    <script src="http://cdn.leafletjs.com/leaflet/v0.7.7/leaflet.js"></script>
    <script src="http://d3js.org/d3.v3.min.js" type="text/javascript"></script>

    <script src='https://api.mapbox.com/mapbox.js/plugins/leaflet-fullscreen/v1.0.1/Leaflet.fullscreen.min.js'></script>
    <link href='https://api.mapbox.com/mapbox.js/plugins/leaflet-fullscreen/v1.0.1/leaflet.fullscreen.css' rel='stylesheet' />
    <script src="scripts/L.D3SvgOverlay.min.js"></script>

    <script type='text/javascript' src='scripts/easy-button.js'></script>

    <%--<script type='text/javascript' src='scripts/leaflet.js'></script>--%>
    <script type='text/javascript' src='scripts/InitMap.js'></script>
    <script type='text/javascript' src='scripts/InfoBox.js'></script>
    <script type='text/javascript' src='scripts/Legend.js'></script>
    <script type='text/javascript' src='scripts/MenuButtons.js'></script>
    <script type='text/javascript' src='scripts/Views/View.js'></script>
    <script type='text/javascript' src='scripts/Views/TemperatureView.js'></script>
    <script type='text/javascript' src='scripts/Views/DefaultView.js'></script>


    <%--    <script type='text/javascript' src='scripts/Views/DefaultView.js'></script>
    <script type='text/javascript' src='scripts/Views/TemperatureView.js'></script>--%>






    <%--<script type="text/javascript" src="scripts/leaflet-realtime.js"></script>--%>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true">
        </asp:ScriptManager>
        <%--<p>Here's an interactive map indicating the countries I've either lived in or travelled through for a month or more.--%>
        <div id="container">
            <div id="map" style="width: 100%; height: 100vh; border: 1px solid #AAA;">
                <div id="legend">
                </div>
            </div>
        </div>
    </form>
</body>
</html>
