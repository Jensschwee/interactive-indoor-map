﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="Website.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
     <link rel="stylesheet" type="text/css" href="http://cdn.leafletjs.com/leaflet-0.7.2/leaflet.css" />
      
      <script type='text/javascript' src='http://ajax.googleapis.com/ajax/libs/jquery/2.0.3/jquery.min.js'></script>
      <script type='text/javascript' src='http://cdn.leafletjs.com/leaflet-0.7.2/leaflet.js?2'></script>
</head>
<body>
    <form id="form1" runat="server">
    <h1>Leaflet Example</h1>
      
      <p>Here's an interactive map indicating the countries I've either lived in or travelled through for a month or more.
      
      <div id="map" style="width: 800px; height: 440px; border: 1px solid #AAA;"></div>
      <script type='text/javascript' src='map/leaf-demo.js'></script>
    </form>
</body>
</html>
